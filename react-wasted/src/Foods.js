import React,{Component, useState} from 'react';
import { Table } from 'react-bootstrap';

export class Foods extends Component{

    constructor(props){
        super(props);
        this.state={
            foods:[],
            cartItems: []
        }
    }

    handleAddToCart = (food) => {
        console.log('in cart');
        this.setState(prevState => ({
            cartItems: prevState.cartItems.concat(food)
        }))
    
    }

    refreshList(){
        //get data from api
        fetch(process.env.REACT_APP_API + '/api/foods')
        .then(response => {
            response.json().then(data => {
                
                this.setState(() => {
                    return{
                        foods : data
                    }
                })
                //this.state.foods = data;
            });
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(){
        //this.refreshList();
    }

    render(){
    
        //const {foods}=this.state;
        return(
            <div>
                <Table className="table">
                    <thead>
                        <tr>
                        <th scope="col">ID</th>
                            <th scope="col">Name</th>
                            <th scope="col">Description</th>
                            <th scope="col">Price</th>
                            <th scope="col">Amount</th>
                            <th scope="col">Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.foods.map(food=>
                            <tr>
                                <td>{food.ID}</td>
                                <td>{food.Name}</td>
                                <td>{food.Description}</td>
                                <td >{food.FullPrice}</td>
                                <td >{food.Weight != null ? food.Weight + " kg" : food.Quantity + " units"}</td>
                                <td>Edit / Delete</td>
                                <button onClick={() => this.handleAddToCart(food)}>Add to cart</button>
                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}