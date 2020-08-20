import React, { Component } from "react";
import AddUserForm from "./Components/AddUserFormComponent";

class AddUser extends Component {
  // constructor() {
  //   super();
  //   this.state = {
  //     user: {
  //       firstName: "",
  //       lastName: "",
  //       passWord: "",
  //       email: "",
  //     },
  //   };
  // }

  // componentDidMount = () => {
  //   const savedUser = 
  //     JSON.parse(window.localStorage.getItem("user")) || {};
  //     this.setState({
  //       user: savedUser,
  //     });
  // };

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

    this.setState({
      firstName: user.firstName,
      lastName: user.lastName,
      passWord: user.passWord,
      email: user.email,
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
