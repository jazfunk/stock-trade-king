import React, { Component } from "react";
import API_IEX from "./Components/IexAPIComponent";
import StockList from "./Components/StocksList";

const iex = {
  IEX_BASE_URL: "https://cloud.iexapis.com/stable/",
  _pToken: "pk_05c40d7c1b96480583b08175d1fb4408", 
  _endUrl: "intraday-prices?chartLast=1&token=" 
}

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
    const searchURL = `${iex.IEX_BASE_URL}stock/${symbol}/${iex._endUrl}${iex._pToken}`;
    let data = "";

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
