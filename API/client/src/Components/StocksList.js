import React from "react";
import { Table } from "react-bootstrap";

const StockList = (props) => {
  let stockRows;
  if (props.stocks === undefined || Object.keys(props.stocks).length === 0) {
    stockRows = (<tr><td>No stocks to display</td></tr>);
  } else {
    stockRows = props.stocks.map((stock, index) => {
      return (
        <tr key={index}>
          <td>{stock.stockSymbol}</td>
          <td>{stock.close}</td>
          <td>{stock.open}</td>
          <td>{stock.high}</td>
          <td>{stock.low}</td>
          <td>{stock.average}</td>
          <td>{stock.date}</td>
          <td>{stock.label}</td>
          <td>{stock.numberOfTrades}</td>
        </tr>
      );
    });
  }
  return (
    <section>
      <Table className="table-dark table-striped table-borderless table-hover table-bg-trans text-nowrap">
        <thead>
          <tr className="table-th">
            <th>Symbol</th>
            <th>Close $</th>
            <th>Open $</th>
            <th>High</th>
            <th>Low</th>
            <th>Avg</th>
            <th>Date</th>
            <th>Time</th>
            <th>Trades</th>
          </tr>
        </thead>
        <tbody>{stockRows}</tbody>
      </Table>
    </section>
  );
};

export default StockList;