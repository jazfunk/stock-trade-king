import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import NewNavigation from "./NewNavigation";
import Home from "../Home";
import Trade from "../Trade";
import Portfolio from "../Portfolio";
import AddUser from "../AddUser";
import Login from "../Login";

const Header = (props) => {
  return (
    <BrowserRouter>
      <header>
        <NewNavigation />
        <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/trade" exact component={Trade} />
          <Route path="/portfolio" render={(props) => <Portfolio {...props} user={props.user} />} />
          <Route path="/login" exact component={Login} />
          <Route path="/signup" render={(props) => <AddUser {...props} user={props.user} />} />
        </Switch>
      </header>
    </BrowserRouter>
  );
};

export default Header;
