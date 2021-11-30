import React,{Component} from 'react';
import { Table } from 'react-bootstrap';

export class Customers extends Component{

    constructor(props){
        super(props);
        this.state={
            customerList:[]
        }
    }

    
    refreshList(){

        fetch(process.env.REACT_APP_API + '/api/customers/' + localStorage.getItem('userID'))
        .then(response => {
            response.json().then(data => {
                console.log(data);
                this.setState(() => {
                    return{
                        customerList: data
                    }
                })
            });
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    onApproveOrder = (ID, approved) =>{

        const requestOptions = {
            method: 'POST', 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                orderID: ID,
                isApproved: approved
             })
        };
        fetch(process.env.REACT_APP_API + '/api/customers', requestOptions) 
            .then((response) => response.json())
            .then(data => {
                console.log(data);
            })

        window.location.reload(false);
        this.refreshList();
    }

    onContact = (ID) =>{

        
    }
    
    render(){
        
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
                             <th scope="col">Buyer ID</th> 
                             <th scope="col">Status</th> 
                         </tr>
                     </thead>
                     
                     <tbody>
                     {this.state.customerList.map(order=>
                             <tr>
                                 <td>{order.FoodOrder.Name}</td>
                                 <td>{order.FoodOrder.Description}</td>
                                 <td >{order.FoodOrder.FullPrice}</td>
                                 <td >{order.FoodOrder.Weight != null ? order.FoodOrder.Weight + " kg" : order.FoodOrder.Quantity + " units"}</td>
                                 <td >{order.Buyer.ID}</td>
                                    {
                                        order.Approved == true &&
                                        <td >Approved</td>
                                    }
                                    {
                                        order.Approved == false &&
                                        <td >Not Approved</td>
                                    }

                                    {
                                        order.Approved == false &&
                                         <button onClick={() => this.onApproveOrder(order.ID, true)}>Approve</button>
                                    }
                                    {
                                        order.Approved == true &&
                                         <button onClick={() => this.onApproveOrder(order.ID, false)}>Remove approval</button>
                                    }
                                    {
                                        order.Approved == true &&
                                        <button onClick={() => this.onContact(order.ID)}>Contact</button>
                                    }

                             </tr>)}
                    </tbody>

                     
                </Table>
                 

             </div>

             </div>

        )
    }
}

