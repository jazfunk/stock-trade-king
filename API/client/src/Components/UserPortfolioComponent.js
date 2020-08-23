import React from "react";
import { Table } from "react-bootstrap";

const UserPortfolioComponent = (props) => {
  let stocks = props.quotes.map((quote, index) => {
    return (
      <tr key={index}>
        <td>{quote.symbol}</td>
        <td>{quote.companyName}</td>
        <td>{quote.open}</td>
        <td>{quote.close}</td>
        <td>{quote.latestTime}</td>
        <td>{quote.change}</td>
        <td>{quote.changePercent}</td>
        <td>{quote.purchasePrice}</td>
        <td>{quote.week52High}</td>
        <td>{quote.week52Low}</td>
      </tr>
    );
  });

  return (
    // Get company logo using ClearBit Logo Api
    // GET https://logo.clearbit.com/:domain
    <section>
      <Table className="table-dark table-striped table-borderless table-hover table-bg-trans text-nowrap">
        <thead>
          <tr className="table-th">
            <th>Symbol</th>
            <th>Company</th>
            <th>Open $</th>
            <th>Close $</th>
            <th>Close Date</th>
            <th>Change $</th>
            <th>Change %</th>
            <th>Purchase $</th>
            <th>52wk High</th>
            <th>52wk Low</th>
          </tr>
        </thead>
        <tbody>{stocks}</tbody>
      </Table>
    </section>
  );
};

export default UserPortfolioComponent;