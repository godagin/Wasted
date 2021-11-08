import React,{Component} from 'react';
import {Redirect} from 'react-router-dom';
import {Form, Button} from 'react-bootstrap';

export class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            input : {
                username : "",
                password : ""
            }
        }
    }

    inputHandler = (event) => {
        switch(event.target.id){
            case "formGridUsername" :
                this.state.input.username = event.target.value;
                break;
            case "formGridPassword" :
                this.state.input.password = event.target.value;
                break;
        }
        this.setState((state) => {return state;});
    }

    loginHandler = (event) => { // sitas turi grazinti id kuri reik issaugot kazkur pasiekiamoj vietoj
        const requestOptions = {
            method: 'POST', 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                UserName: this.state.input.username,
                Password: this.state.input.password
             })
        };

        fetch(process.env.REACT_APP_API + '/api/login', requestOptions) 
            .then(response => response.json())
            .then(data => {
                console.log(data);
                localStorage.setItem('userID', data);
            });
        event.preventDefault();
    }

    render(){
        if(localStorage.getItem('userID') != null){
            return (<Redirect to ='/'/>);
        }
        return(
            <Form >
                <Form.Group className="mb-3" defaultValue={this.state.input.username} controlId="formGridUsername" onChange={this.inputHandler}>
                    <Form.Label>Username</Form.Label>
                    <Form.Control placeholder="username" />
                </Form.Group>

                <Form.Group className="mb-3" defaultValue={this.state.input.password} controlId="formGridPassword" onChange={this.inputHandler}>
                    <Form.Label>Password</Form.Label>
                    <Form.Control type="password" placeholder="Password" />
                </Form.Group>
    
                <Button variant="primary" type="submit" onClick={this.loginHandler}>
                    Log in
                </Button>
            </Form>
        )
    }
}