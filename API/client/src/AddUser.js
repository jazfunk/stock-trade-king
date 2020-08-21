import React, { Component } from "react";
import AddUserForm from "./Components/AddUserFormComponent";

class AddUser extends Component {
  ADD_USER_URL_HTTP = "http://localhost:5000/api/users/";
  ADD_USER_URL_HTTPS = "https://localhost:5001/api/users/";
  _isLoggedIn = false;

  constructor(props) {
    super();
    this.state = {
      isLoggedIn: false,
      users: []
    };
  }

  displayLoggedInUser = () => {
    // Code this up
  }

  componentDidMount = () => {
    const savedUser = JSON.parse(window.localStorage.getItem("user")) || {};
    this.setState({
      user: savedUser,
    });
  };

  handleChange = (event) => {
    event.preventDefault();
    const { name, value } = event.target;
    this.setState({
      [name]: value,
    });
  };

  handleSubmit = (event) => {
    event.preventDefault();
    event.target.reset();

    const user = {
      firstName: this.state.firstName,
      lastName: this.state.lastName,
      email: this.state.email,
      passWord: this.state.passWord,
    };

    this.postNewUser(user);
  };

  postNewUser = (user) => {
    const axios = require("axios");
    var data = JSON.stringify(user);
    var config = {
      method: "post",
      url: this.ADD_USER_URL_HTTPS,
      headers: {
        "Content-Type": "application/json",
      },
      data: data,
    };

    axios(config)
      .then((response) => {
        console.log(JSON.stringify(response.data));
        alert(`Congratulations, ${user.firstName}! \nYou're all signed up`);

        this.setState({
          isLoggedIn: true,
          user: user,
        })
      })

      .catch((error) => {
        console.log(error);
      });
  };

  render() {
    return (
      <section className="home">
        <AddUserForm
          user={this.state}
          handleSubmit={this.handleSubmit}
          handleChange={this.handleChange}
        />
      </section>
    );
  }
}

export default AddUser;
