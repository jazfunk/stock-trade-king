export const iex = {
  IEX_BASE_URL: "https://cloud.iexapis.com/stable/",
  _pToken: "pk_05c40d7c1b96480583b08175d1fb4408",
  _endIntradayUrl: "intraday-prices?chartLast=1&token=",
  _endQuoteUrl: "quote?token=",
};

export const USER_PORTFOLIO_URL = "https://localhost:5001/api/portfolio/user/";


// Will use the Bootstrap Card element for 
// the stocks whne I get the back end right.

// <Card style={{ width: "20rem" }}>
// {/* <Card.Img variant="top" src={StockTradeKingLogo} /> */}
// <Card.Body>
//   <Card.Title>[companyName]</Card.Title>
//   <Card.Text></Card.Text>
// </Card.Body>
// <ListGroup className="list-group-flush">
//   <ListGroupItem>{`Open:    $2044.80`}</ListGroupItem>
//   <ListGroupItem>{`Close:   $2049.98`}</ListGroupItem>
//   <ListGroupItem>{`+/-:     $48.15`}</ListGroupItem>
//   <ListGroupItem>{`+/- %:   0.02405`}</ListGroupItem>
//   <ListGroupItem>{`52-wk +: 2095.69`}</ListGroupItem>
//   <ListGroupItem>{`52-wk -: 0.02405`}</ListGroupItem>
//   <ListGroupItem>{`YTD +/-: 3.788564`}</ListGroupItem>
// </ListGroup>
// <Card.Body>
//   <Card.Link href="#">Buy</Card.Link>
//   <Card.Link href="#">Sell</Card.Link>
// </Card.Body>
// </Card>


// // UserPortfolio JSON Object
// {
//   "userId": 1,
//   "stockSymbol": "tsla",
//   "purchaseDate": "2020-08-21",
//   "purchasePrice": 2049.63
// }



// This API call is free
// intraday
// {
//   average: 213.148;
//   close: 213.17;
//   date: "2020-08-21";
//   high: 213.24;
//   label: "3:59 PM";
//   low: 213.075;
//   minute: "15:59";
//   notional: 1315978.29;
//   numberOfTrades: 65;
//   open: 213.08;
//   volume: 6174;
// }



// This API call costs 1 point
// quote filtered
// {
//   "symbol": "TSLA",
//   "companyName": "Tesla, Inc.",
//   "open": 2044.8,
//   "openTime": 1598016600647,
//   "close": 2049.98,
//   "closeTime": 1598040000612,
//   "high": 2095.69,
//   "highTime": 1598034727878,
//   "low": 2025.05,
//   "lowTime": 1598018604208,
//   "latestPrice": 2049.98,
//   "latestTime": "August 21, 2020",
//   "latestUpdate": 1598040000612,
//   "previousClose": 2001.83,
//   "change": 48.15,
//   "changePercent": 0.02405,
//   "iexClose": 2049.485,
//   "iexCloseTime": 1598039998414,
//   "week52High": 2095.69,
//   "week52Low": 211,
//   "ytdChange": 3.788564,
//   "lastTradeTime": 1598040000612,
//   "isUSMarketOpen": false
// }


// quote full
// {
//   "symbol": "TSLA",
//   "companyName": "Tesla, Inc.",
//   "primaryExchange": "NASDAQ",
//   "calculationPrice": "close",
//   "open": 2044.8,
//   "openTime": 1598016600647,
//   "openSource": "official",
//   "close": 2049.98,
//   "closeTime": 1598040000612,
//   "closeSource": "official",
//   "high": 2095.69,
//   "highTime": 1598034727878,
//   "highSource": "IEX real time price",
//   "low": 2025.05,
//   "lowTime": 1598018604208,
//   "lowSource": "15 minute delayed price",
//   "latestPrice": 2049.98,
//   "latestSource": "Close",
//   "latestTime": "August 21, 2020",
//   "latestUpdate": 1598040000612,
//   "latestVolume": 21489559,
//   "iexRealtimePrice": null,
//   "iexRealtimeSize": null,
//   "iexLastUpdated": null,
//   "delayedPrice": 2045,
//   "delayedPriceTime": 1598054399921,
//   "oddLotDelayedPrice": 1602.31,
//   "oddLotDelayedPriceTime": 1598041770016,
//   "extendedPrice": 2045,
//   "extendedChange": -4.98,
//   "extendedChangePercent": -0.00243,
//   "extendedPriceTime": 1598054399921,
//   "previousClose": 2001.83,
//   "previousVolume": 20611796,
//   "change": 48.15,
//   "changePercent": 0.02405,
//   "volume": 21489559,
//   "iexMarketPercent": null,
//   "iexVolume": null,
//   "avgTotalVolume": 15129454,
//   "iexBidPrice": null,
//   "iexBidSize": null,
//   "iexAskPrice": null,
//   "iexAskSize": null,
//   "iexOpen": null,
//   "iexOpenTime": null,
//   "iexClose": 2049.485,
//   "iexCloseTime": 1598039998414,
//   "marketCap": 382038372760,
//   "peRatio": 1010.44,
//   "week52High": 2095.69,
//   "week52Low": 211,
//   "ytdChange": 3.788564,
//   "lastTradeTime": 1598040000612,
//   "isUSMarketOpen": false
// }