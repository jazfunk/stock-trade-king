import React, { Component } from "react";
import AddUserForm from "./Components/AddUserFormComponent";

class AddUser extends Component {
  constructor() {
    super();
    this.state = {
      users: [],
    };
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
      passWord: this.state.passWord,
      email: this.state.email,
    };

    console.log(user);

    const users = this.state.users.map((user) => 
      Object.assign({}, user)
    );

    users.push(user);
    
    this.setState({
      users: users,
    });

    console.log(users);
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
