import React, { Component } from "react";

class Navigation extends Component {
  render() {
    return (
      <div>
        <nav class="navbar navbar-inverse">
          <div class="container-fluid">
            <div class="navbar-header">
              <a class="navbar-brand" href="#">
                WebSiteName
              </a>
            </div>
            <ul class="nav navbar-nav">
              <li class="active">
                <a href="/">Home</a>
              </li>
              <li>
                <a href="/trade">Trade</a>
              </li>
              <li>
                <a href="/portfolio">Portfolio</a>
              </li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
              <li>
                <a href="/">
                  <span class="glyphicon glyphicon-user"></span> Sign Up
                </a>
              </li>
              <li>
                <a href="/">
                  <span class="glyphicon glyphicon-log-in"></span> Login
                </a>
              </li>
            </ul>
          </div>
        </nav>

        <nav class="navbar navbar-dark bg-dark"></nav>
      </div>
    );
  }
}

export default Navigation;
