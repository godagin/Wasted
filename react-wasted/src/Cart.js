import React,{Component} from 'react';
import { Table } from 'react-bootstrap';
import { Chat } from './Chat';

export class Cart extends Component{

    constructor(props){
        super(props);
        this.state={
            cartItems:[],
            roomID: '',
            showChat: false
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

    onContact = (orderID) =>{

        this.setState({showChat: true, roomID: orderID});
    }
    onLeaveChat = () =>{

        window.location.reload(false);
        this.refreshList();

    }
    
    render(){
        console.log(this.state.cartItems);
        return(
            <div>
                <div>
                    <Table className="table">
                     <thead>
                         <tr>
                             <th scope="col">Name</th>
                             <th scope="col">Description</th>
                             <th scope="col">Price</th>
                             <th scope="col">Amount</th> 
                             <th scope="col">Status</th> 
                         </tr>
                     </thead>
                     <tbody>
                         {this.state.cartItems.map(order=>
                             <tr>
                                 <td>{order.FoodOrder.Name}</td>
                                 <td>{order.FoodOrder.Description}</td>
                                 <td >{order.FoodOrder.FullPrice}</td>
                                 <td >{order.FoodOrder.Weight != null ? order.Amount + " kg" : order.Amount + " units"}</td>
                                    {
                                        order.Approved == true &&
                                        <td >Approved</td>
                                    }
                                    {
                                        order.Approved == false &&
                                        <td >Not Approved</td>
                                    }
                                    {
                                        order.Approved == true && this.state.showChat == false &&
                                        <button onClick={() => this.onContact(order.ID, localStorage.getItem('userID'))}>Contact</button>
                                    }
                                    {
                                        order.Approved == true && this.state.showChat == true && order.ID == this.state.roomID &&
                                        <button onClick={() => this.onLeaveChat()}>Leave Chat</button>
                                    }
                                 <button onClick={() => this.onRemoveFromCart(order.ID)}>Remove from cart</button>
                             </tr>)}
                     </tbody>
                    </Table>
                </div>

                <div>   
                {this.state.showChat && <Chat roomID = {this.state.roomID}/>}
                </div>

            </div>
        )
    }
}

