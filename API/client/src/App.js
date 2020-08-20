import React, { Component } from 'react';
import Header from "./Components/Header";
import Footer from "./Components/Footer";

class App extends Component {
  // constructor() {
  //   super();
  //   // this.state = {
  //   //   user: {
  //   //     firstName: null,
  //   //     lastName: null,
  //   //     passWord: null,
  //   //     email: null,
  //   //   },
  //   // };
  // }

  render = () => {
    return (
      <div className="App">
        <Header />
        <Footer />
      </div>
    );
  }
  
}

export default App;
