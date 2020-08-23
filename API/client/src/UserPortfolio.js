import React, { Component } from "react";
import { Button } from "react-bootstrap";
import UserPortfolioTable from "./Components/UserPortfolioComponent";
import axios from "axios";
import { iex, USER_PORTFOLIO_URL } from "./Components/configBase";

class UserPortfolio extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: 1,
      quotes: [],
    };
  }

  componentDidMount = () => {
    this.loadPortfolio();    
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

  loadIexQuoteItems = () => {
    const apiPortfolio = [...this.state.portfolio];
    apiPortfolio.forEach((portfolioItem) => {
      axios
        .get(
          `${iex.IEX_BASE_URL}stock/${portfolioItem.stockSymbol}/${iex._endQuoteUrl}${iex._pToken}`
        )
        .then((response) => {
          let quote = {
            symbol: response.data.symbol,
            companyName: response.data.companyName,
            open: response.data.open,
            openTime: response.data.openTime,
            close: response.data.close,
            closeTime: response.data.closeTime,
            high: response.data.high,
            highTime: response.data.highTime,
            low: response.data.low,
            lowTime: response.data.lowTime,
            latestPrice: response.data.latestPrice,
            latestTime: response.data.latestTime,
            latestUpdate: response.data.latestUpdate,
            previousClose: response.data.previousClose,
            change: response.data.change,
            changePercent: response.data.changePercent,
            iexClose: response.data.iexClose,
            iexCloseTime: response.data.iexCloseTime,
            week52High: response.data.week52High,
            week52Low: response.data.week52Low,
            ytdChange: response.data.ytdChange,
            lastTradeTime: response.data.lastTradeTime,
            isUSMarketOpen: response.data.isUSMarketOpen,
            purchasePrice: portfolioItem.purchasePrice,
          };
          
          const quotes = [...this.state.quotes];

          quotes.push(quote);

          localStorage.setItem("iexAPIPortfolio", JSON.stringify(quotes));

          this.setState({
            quotes: quotes,
          });
        })
        .catch((error) => {
          console.log(error);
        });
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
  };

  render() {
    return (
      <section>
        <Button onClick={this.loadIexQuoteItems} className="mb-2">
          Load Portfolio
        </Button>&nbsp;&nbsp;
        <Button onClick={this.createUserPortfolio} className="mb-2">
          Load Master Portfolio
        </Button>
        <UserPortfolioTable
          user={this.state.user}
          stock={this.state.stock}
          quotes={this.state.quotes}
        />
      </section>
    );
  }
}

export default UserPortfolio;