import React,{Component} from 'react';
import {Form, Row, Col, Button} from 'react-bootstrap';

export class Register extends Component{
    constructor(props){
        super(props);
        this.state = {
            input:{
                name : "",
                surname : "",
                email : "",
                username : "",
                password : ""
            }
        }
    }

    inputHandler = (event) => {
        switch(event.target.id){
            case "formGridName" :
                this.state.input.name = event.target.value;
                break;
            case "formGridSurname" :
                this.state.input.surname = event.target.value;
                break;
            case "formGridEmail" :
                this.state.input.email = event.target.value;
                break;
            case "formGridUsername" :
                this.state.input.username = event.target.value;
                break;
            case "formGridPassword" :
                this.state.input.password = event.target.value;
                break;
        }
        this.setState((state) => {return state;});
    }

    submitHandler = (event) => {
        const requestOptions = {
            method: 'POST', 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                UserName: this.state.input.username,
                Name: this.state.input.name,
                Surname: this.state.input.surname,
                ContactEmail: this.state.input.email, 
                Password: this.state.input.password
             })
        };
        fetch(process.env.REACT_APP_API + '/api/register', requestOptions) 
            .then(response => response.json())
            .then(data => {console.log(data);});
    }

    render(){
        return(
            <Form >
                <Row className="mb-3">
                    <Form.Group as={Col} defaultValue={this.state.input.name} controlId="formGridName" onChange={this.inputHandler}>
                        <Form.Label>Name</Form.Label>
                        <Form.Control placeholder="Name" />
                    </Form.Group>

                    <Form.Group as={Col} defaultValue={this.state.input.surname} controlId="formGridSurname" onChange={this.inputHandler}>
                        <Form.Label>Surname</Form.Label>
                        <Form.Control placeholder="Surname" />
                    </Form.Group>
                </Row>

                <Form.Group className="mb-3" defaultValue={this.state.input.email} controlId="formGridEmail" onChange={this.inputHandler}>
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" placeholder="Enter email" />
                </Form.Group>

                <Row className="mb-3">
                    <Form.Group as={Col} defaultValue={this.state.input.username} controlId="formGridUsername" onChange={this.inputHandler}>
                        <Form.Label>Username</Form.Label>
                        <Form.Control placeholder="username" />
                    </Form.Group>

                    <Form.Group as={Col} defaultValue={this.state.input.password} controlId="formGridPassword" onChange={this.inputHandler}>
                        <Form.Label>Password</Form.Label>
                        <Form.Control type="password" placeholder="Password" />
                    </Form.Group>
                </Row>
    
                <Button variant="primary" type="submit" onClick={this.submitHandler}>
                    Submit
                </Button>
                </Form>
        )
    }
}

export default Register;