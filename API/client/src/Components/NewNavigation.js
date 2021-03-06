import React, { Component } from "react";
import { Navbar, Nav, NavDropdown } from "react-bootstrap";
import AppLogo from "../Images/stockTradeKingFavIconOPTIMIZED.svg";

class NewNavigation extends Component {
  render() {
    return (
      <Navbar className="custom-nav" variant="dark" expand="md">
        <Navbar.Brand href="/">
          <img
            src={AppLogo}
            width="30"
            height="30"
            className="d-inline-block align-top navbrand-glow-border"
            alt="StockTradeKing"
          />
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" className="navbar-toggler" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/trade">Trade</Nav.Link>
            <Nav.Link href="/portfolio">Portfolio</Nav.Link>
            <NavDropdown title="My Account" id="basic-nav-dropdown">
              <NavDropdown.Item className="custom-dropdown-nav" href="/login">Login</NavDropdown.Item>
              <NavDropdown.Item className="custom-dropdown-nav" href="/signup">Sign Up</NavDropdown.Item>
              {/* <NavDropdown.Divider /> */}
              <NavDropdown.Item className="custom-dropdown-nav" href="/logout">Log Out</NavDropdown.Item>
            </NavDropdown>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

export default NewNavigation;
