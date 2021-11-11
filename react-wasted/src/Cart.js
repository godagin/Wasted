import React,{Component} from 'react';
import { Table } from 'react-bootstrap';

export class Cart extends Component{

    constructor(props){
        super(props);
        this.state={
            cartItems:[],
            ownerCon: ''
        }
    }

    
    refreshList(){

        fetch(process.env.REACT_APP_API + '/api/cart/' + localStorage.getItem('userID'))
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


    onRemoveFromCart = (ID) =>{

        //console.log(ID);
        const requestOptions = {
            method: 'POST', 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                userID: 0,
                foodID: ID
             })
        };
        fetch(process.env.REACT_APP_API + '/api/cart', requestOptions) 
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

     getContacts = (OwnerID) =>{

        fetch(process.env.REACT_APP_API + '/api/contacts/' + OwnerID)
            .then(response => {
                response.json().then(data => {
                    this.setState(() => {
                        return{
                            ownerCon: data
                        }
                    })
                });
            });

            return this.state.ownerCon

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
                             <th scope="col">Owner Contacts</th> 
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
                                 <td >{this.getContacts(food.OwnerID)}</td>
                                 <button onClick={() => this.onRemoveFromCart(food.ID)}>Remove from cart</button>
                             </tr>)}
                     </tbody>
                 </Table>
             </div>
        )
    }
}

