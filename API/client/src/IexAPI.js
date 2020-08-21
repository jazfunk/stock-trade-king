import React, { Component } from "react";
import API_IEX from "./Components/IexAPIComponent";
import StockList from "./Components/StocksList";
import { iex } from "./config/iex";

class IexAPI extends Component {
  constructor(props) {
    super();
    this.state = {
      user: props.user,
      data: {},
    };
  }

  componentDidMount = () => {
    this.setState({
      data: {},
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

    this.searchIEXForSymbol(this.state.stockSymbol);
  };

  searchIEXForSymbol = (symbol) => {
    const axios = require("axios");
    let data = "";
    const searchURL = `${iex.IEX_BASE_URL}stock/${symbol}/${iex._endUrl}${iex._pToken}`;

    var config = {
      method: "get",
      url: searchURL,
      headers: {
        "Content-Type": "application/json",
      },
      data: data,
    };

    axios(config)
      .then((response) => {
        this.setState({
          data: response.data,
        });
      })

      .catch((error) => {
        console.log(error);
      });
  };

  render() {
    return (
      <section>
        <API_IEX
          stockSymbol={this.state.stockSymbol}
          handleChange={this.handleChange}
          handleSubmit={this.handleSubmit}
        />
        <StockList
          stockSymbol={this.state.stockSymbol}
          data={this.state.data}
        />
      </section>
    );
  }
}

export default IexAPI;
