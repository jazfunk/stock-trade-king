import React, { Component } from "react";
import { Navbar, Nav } from "react-bootstrap";
import JKLogo from "../Images/titleGraphicWithLogoOPTIMIZED.svg";

class Navigation extends Component {
  render() {
    return (
      <Navbar bg="dark" variant="dark" expand="md">
        <img id="" src={JKLogo} alt="Stock Trade King Logo"></img>
        <Navbar.Brand href="/">StockTradeKing</Navbar.Brand>
        <Navbar.Toggle arai-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto nav-text">
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/trade">Trade</Nav.Link>
            <Nav.Link href="/portfolio">Portfolio</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }
}

export default Navigation;
