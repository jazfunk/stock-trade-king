import React from "react";
import LoginForm from "./Components/LoginFormComponent";

const Login = (props) => {
  // Need to set state here when user is authenticated.
  // This functionality may not happen in this component,
  // Because I prefer a class component to update state
  return (
    <section className="home">
      <LoginForm />      
    </section>
  )
}

export default Login;
