import React from "react";
import { Table } from "react-bootstrap";

const Stock = (props) => {
  let stockRow;
  if (props.stock === undefined || Object.keys(props.stock).length === 0) {
    stockRow = (<tr><td>No stock data</td></tr>);
  } else {
    stockRow = (
      <tr>
        <td>{props.stock[0].close}</td>
        <td>{props.stock[0].close}</td>
        <td>{props.stock[0].open}</td>
        <td>{props.stock[0].high}</td>
        <td>{props.stock[0].low}</td>
        <td>{props.stock[0].average}</td>
        <td>{props.stock[0].date}</td>
        <td>{props.stock[0].label}</td>
        <td>{props.stock[0].numberOfTrades}</td>
      </tr>
    );
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
        <tbody>{stockRow}</tbody>
      </Table>
    </section>
  );
};

export default Stock;
