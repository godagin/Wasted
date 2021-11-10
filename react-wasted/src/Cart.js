import React,{Component} from 'react';
import { Table } from 'react-bootstrap';

export class Cart extends Component{

    constructor(props){
        super(props);
        this.state={
            cartItems:[]
        }
    }

    
    refreshList(){
        fetch(process.env.REACT_APP_API + '/api/cart')
        .then(response => {
            response.json().then(data => {
                this.setState(() => {
                    return{
                        cartItems: data
                    }
                })
            });
        });
    }

    componentDidMount(){
        this.refreshList();
    }


    removeFromCart = (ID) =>{

        console.log(ID);
      /*  const requestOptions = {
            method: 'POST', 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                userID: localStorage.getItem('userID'),
                foodID: ID
             })
        };
        fetch(process.env.REACT_APP_API + '/api/cart', requestOptions) 
            .then((response) => response.json())
            .then(data => {
                console.log(data);
            })*/
    }

    
    render(){
        
        return(
             <div>
                 <Table className="table">
                     <thead>
                         <tr>
                             <th scope="col">Name</th>
                             <th scope="col">Description</th>
                             <th scope="col">Price</th>
                             <th scope="col">Amount</th>
                             <th scope="col">Buyer ID</th> 
                         </tr>
                     </thead>
                     
                     <tbody>
                         {this.state.cartItems.map(food=>
                             <tr>
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

