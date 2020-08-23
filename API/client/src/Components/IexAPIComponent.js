import React from "react";
import { Form, Button, Col } from "react-bootstrap";

const IexAPIComponent = (props) => {
  return (
    <section className="search-api">
      <Form onSubmit={props.handleSubmit}>
        <Form.Row className="align-items-center">
          <Col xs="auto">
            <Button onClick={props.loadPortfolioItems} className="mb-2">
              View Portfolio
            </Button>
          </Col>
          <Col xs="auto">
            <Form.Control
              className="mb-2"
              onChange={props.handleChange}
              type="text"
              placeholder="Search Stock Symbol"
              name="stockSymbol"
              required={true}
            />
          </Col>
          <Col xs="auto">
            <Button type="submit" className="mb-2">
              Search
            </Button>
          </Col>
        </Form.Row>
      </Form>
    </section>
  );
};

export default IexAPIComponent;
