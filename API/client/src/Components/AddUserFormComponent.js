import React from "react";
import { Form, Button, Col } from "react-bootstrap";

const AddUserFormComponent = (props) => {
  return (
    <section className="form-container">
      <Form onSubmit={props.handleSubmit}>
        <Form.Row>
          <Form.Group as={Col} controlId="frmFirstName">
            <Form.Label>First Name</Form.Label>
            <Form.Control
              onChange={props.handleChange}
              defaultValue={props.firstName}
              type="text"
              placeholder=""
              name="firstName"
            />
          </Form.Group>
          <Form.Group as={Col} controlId="frmLastName">
            <Form.Label>Last Name</Form.Label>
            <Form.Control
              onChange={props.handleChange}
              defaultValue={props.lastName}
              type="text"
              placeholder=""
              name="lastName"
            />
          </Form.Group>
        </Form.Row>
        <Form.Row>
          <Form.Group as={Col} controlId="frmEmail">
            <Form.Label>Email address</Form.Label>
            <Form.Control
              onChange={props.handleChange}
              defaultValue={props.email}
              type="email"
              placeholder=""
              name="email"
            />
          </Form.Group>
          <Form.Group as={Col} controlId="frmPassWord">
            <Form.Label>Password</Form.Label>
            <Form.Control
              onChange={props.handleChange}
              defaultValue={props.passWord}
              type="password"
              placeholder=""
              name="passWord"
            />
          </Form.Group>
        </Form.Row>
        {/* <Form.Group controlId="formBasicCheckbox">
          <Form.Check type="checkbox" label="Check me out" />
        </Form.Group> */}
        <Button variant="primary" type="submit">
          Submit
        </Button>
      </Form>
    </section>
  );
};

export default AddUserFormComponent;
