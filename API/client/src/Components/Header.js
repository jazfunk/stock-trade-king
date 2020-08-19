import React, { Component } from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import NewNavigation from "./NewNavigation";
import Home from "../Home";
import Trade from "../Trade";
import Portfolio from "../Portfolio";
import AddUser from "../AddUser";
import Login from "../Login";

class Header extends Component {
  render() {
    return (
      <BrowserRouter>
        <header>
          <NewNavigation />
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/trade" exact component={Trade} />
            <Route path="/portfolio" exact component={Portfolio} />
            <Route path="/login" exact component={Login} />
            <Route path="/signup" exact component={AddUser} />
          </Switch>
        </header>
      </BrowserRouter>)
  }
}

export default Header;