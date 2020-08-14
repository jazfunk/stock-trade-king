import React, { Component } from "react";
import { Navbar, Nav, NavDropdown } from "react-bootstrap";
import JKLogo from "../Images/myFavIconOPTIMIZED.svg";

class NewNavigation extends Component {
  render() {
    return (
      <Navbar bg="dark" variant="dark" expand="md">
        <Navbar.Brand href="/">
          <img
            src={JKLogo}
            width="30"
            height="30"
            className="d-inline-block align-top"
            alt="JK Consulting Logo"
          />
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/trade">Trade</Nav.Link>
            <NavDropdown title="My Account" id="basic-nav-dropdown">
              <NavDropdown.Item href="/login">Login</NavDropdown.Item>
              <NavDropdown.Item href="/signup">Sign Up</NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item href="/logout">Log Out</NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

export default NewNavigation;
