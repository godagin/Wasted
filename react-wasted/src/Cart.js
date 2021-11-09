import React,{Component} from 'react';
import { Table } from 'react-bootstrap';

export class Cart extends Component{

    constructor(props){
        super(props);
        this.state={
            cartItems:[]
        }
    }

    removeFromCart = (ID) =>{

        console.log(ID);
    }

    
    render(){

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
                             <th scope="col">Buyer ID</th> 
                
                         </tr>
                     </thead>
                     <tbody>
                         {this.props.cartData.map(food=>
                             <tr>
                                 <td>{food.ID}</td>
                                 <td>{food.Name}</td>
                                 <td>{food.Description}</td>
                                 <td >{food.FullPrice}</td>
                                 <td >{food.Weight != null ? food.Weight + " kg" : food.Quantity + " units"}</td>
                                 <td >{food.BuyerID}</td>
                                 <button onClick={() => this.removeFromCart(food.ID)}>Remove from cart</button>
                             </tr>)}
                     </tbody>
                 </Table>
             </div>
            
         )
     }
}

