import React from "react";
import { Table } from "react-bootstrap";

const StockList = (props) => {
  let stocks;
  if (props.data === undefined || Object.keys(props.data).length === 0) {
    stocks = <tr><td>No stocks</td></tr>
  } else {
    stocks = props.data.map((stock, index) => {
      return (
        <tr key={index}>
          <td>{props.stockSymbol}</td>
          <td>{stock.average}</td>
          <td>{stock.close}</td>
          <td>{stock.date}</td>
          <td>{stock.high}</td>
          <td>{stock.label}</td>
          <td>{stock.low}</td>
          <td>{stock.minute}</td>
          <td>{stock.notational}</td>
          <td>{stock.numberOfTrades}</td>
          <td>{stock.open}</td>
          <td>{stock.volume}</td>
        </tr>
      );
    });
  }
  return (
    <section>
      <Table className="table mt-5">
        <thead>
          <tr>
            <th>Symbol</th>
            <th>Average</th>
            <th>Close</th>
            <th>Date</th>
            <th>High</th>
            <th>Label</th>
            <th>Low</th>
            <th>Minute</th>
            <th>Notational</th>
            <th>NumOfTrades</th>
            <th>Open</th>
            <th>Volume</th>
          </tr>
        </thead>
        <tbody>{stocks}</tbody>
      </Table>
    </section>
  );
};

export default StockList;