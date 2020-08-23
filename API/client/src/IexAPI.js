import React, { Component } from "react";
import API_IEX from "./Components/IexAPIComponent";
import Stock from "./Components/Stock";
import axios from "axios";
import { iex, USER_PORTFOLIO_URL } from "./Components/configBase";

class IexAPI extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: 1, // Change this to props.user when funcionality is implemented
      stock: {},
      stocks: [],
    };
  }
  
  componentDidMount = () => {
    this.loadPortfolio();
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
    const searchURL = `${iex.IEX_BASE_URL}stock/${symbol}/${iex._endIntradayUrl}${iex._pToken}`;
    axios
      .get(searchURL)
      .then((response) => {
        this.setState({
          stock: response.data,
        });
      })
      .catch((error) => {
        console.log(error);
      });
  };
  
  loadPortfolioItems = () => {
    const apiPortfolio = [...this.state.portfolio];
    apiPortfolio.forEach((portfolioItem) => {
      axios
        .get(
          `${iex.IEX_BASE_URL}stock/${portfolioItem.stockSymbol}/${iex._endIntradayUrl}${iex._pToken}`
        )
        .then((response) => {
          let item = {
            stockSymbol: portfolioItem.stockSymbol,
            close: response.data[0].close,
            open: response.data[0].open,
            high: response.data[0].high,
            low: response.data[0].low,
            average: response.data[0].average,
            date: response.data[0].date,
            label: response.data[0].label,
            numberOfTrades: response.data[0].numberOfTrades,
          };

          const stocks = this.state.stocks.map((stock) =>
            Object.assign({}, stock)
          );

          stocks.push(item);

          this.setState({
            stocks: stocks,
          });
        })
        .catch((error) => {
          console.log(error);
        });
    });
  };

  loadPortfolio = () => {
    axios
      .get(`${USER_PORTFOLIO_URL}${this.state.user}`)
      .then((response) => {
        this.setState({
          portfolio: response.data,
        });
      })
      .catch((error) => {
        console.log(error);
      });
  };
  
  getData = (url) => {
    // For future use
    return axios.get(url).then((response) => response.data);
  };

  render() {
    return (
      <section>
        <API_IEX
          stockSymbol={this.state.stockSymbol}
          handleChange={this.handleChange}
          handleSubmit={this.handleSubmit}
          loadPortfolioItems={this.loadPortfolioItems}
        />
        <Stock stock={this.state.stock} />
      </section>
    );
  }
}

export default IexAPI;