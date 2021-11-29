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

        fetch(process.env.REACT_APP_API + '/api/cart/' + localStorage.getItem('userID'))
        .then(response => {
            response.json().then(data => {
                console.log(data);
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


    onRemoveFromCart = (ID) =>{

        console.log(ID);
        const requestOptions = {
            method: 'DELETE', 
            headers: { 'Content-Type': 'application/json' }
            
        };
        fetch(process.env.REACT_APP_API + '/api/cart/' + ID, requestOptions) 
            .then((response) => response.json())
            .then(data => {
                console.log(data);
            })


        this.setState(state => { //instead of rerendering we just remove item from this local list
            const cartItems = state.cartItems.filter((item) => ID != item.ID);
            return{
                cartItems,
            };
        });
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
                         </tr>
                     </thead>
                     
                     <tbody>
                         {this.state.cartItems.map(order=>
                             <tr>
                                 <td>{order.FoodOrder.Name}</td>
                                 <td>{order.FoodOrder.Description}</td>
                                 <td >{order.FoodOrder.FullPrice}</td>
                                 <td >{order.FoodOrder.Weight != null ? order.FoodOrder.Weight + " kg" : order.FoodOrder.Quantity + " units"}</td>
                                 <button onClick={() => this.onRemoveFromCart(order.ID)}>Remove from cart</button>
                             </tr>)}
                     </tbody>
                 </Table>
             </div>
        )
    }
}

