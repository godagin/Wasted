import React,{Component} from 'react';
import { Table } from 'react-bootstrap';
import {Foods} from './Foods';

export class Cart extends Component{

 
 

    render(){
       // return(
           // <div className="mt-5 d-flex justify-content-left">
              //  cart.
           // </div>
       // )
    

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
                          
                        </tr>
                    </thead>
                    <tbody>
                        {cartItems.map(food=>
                            <tr>
                                <td>{food.ID}</td>
                                <td>{food.Name}</td>
                                <td>{food.Description}</td>
                                <td >{food.FullPrice}</td>
                                <td >{food.Weight != null ? food.Weight + " kg" : food.Quantity + " units"}</td>
                              
                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}

export default Cart