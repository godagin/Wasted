import React,{Component} from 'react';
import {NavLink} from 'react-router-dom';
import {Navbar,Nav} from 'react-bootstrap';

export class Navigation extends Component{
    render(){
        return(
            <Navbar bg="dark" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                <Nav>
                    <NavLink className="d-inline p-2 bg-dark text-white" to="/">
                        Home
                    </NavLink>
                </Nav>
                {
                    localStorage.getItem('userID') != null &&
                    <Nav>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/Foods">
                            Foods
                        </NavLink>
                    </Nav>
                }
                {
                    localStorage.getItem('userID') != null &&
                    <Nav>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/Cart">
                            Cart
                        </NavLink>
                    </Nav>
                }
                {
                    localStorage.getItem('userID') != null &&
                    <Nav>
                        <NavLink className="d-inline p-2 bg-dark text-white" to="/AddedOffers">
                            Added Offers
                        </NavLink>
                    </Nav>
                }
                { localStorage.getItem('userID') == null &&
                <Nav>
                    <NavLink className="d-inline p-2 bg-dark text-white" to="/Register">
                        Register
                    </NavLink>
                </Nav>
                }
                { localStorage.getItem('userID') == null &&
                <Nav>
                    <NavLink className="d-inline p-2 bg-dark text-white" to="/Login">
                        Login
                    </NavLink>
                </Nav>
                }
                { localStorage.getItem('userID') != null &&
                <Nav>
                    <NavLink className="d-inline p-2 bg-dark text-white" to="/Logout">
                        Logout
                    </NavLink>
                </Nav>
                }
                { localStorage.getItem('userID') != null &&
               <div className="ms-auto">
                <Nav>
                    <span className="d-inline p-2 bg-dark text-white">
                       Signed in as {localStorage.getItem('userID')}
                    </span>
                </Nav>
              </div>
                }
                
                </Navbar.Collapse>
                
            </Navbar>
        )
    }
}