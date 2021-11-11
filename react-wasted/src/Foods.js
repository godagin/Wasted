import React,{Component} from 'react';
import { Table } from 'react-bootstrap';
import { CreateOffer } from './CreateOffer';

export class Foods extends Component{

    constructor(props){
        super(props);
        this.state={
            foods:[],
            createOffer: false
        }
    }

    addToCart = (ID, BuyerID) =>{
            if (BuyerID === 0)
            {
                const requestOptions = {
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
                })

                console.log('added');
            }
            else if (BuyerID === localStorage.getItem('userID'))
            {
                console.log('already in cart');
            }
            else
            {
                console.log('unavailable');
            }  

            this.refreshList();     
    }


    refreshList(){
        fetch(process.env.REACT_APP_API + '/api/foods')
        .then(response => {
            response.json().then(data => {
                this.setState(() => {
                    console.log(data);
                    return{
                        foods : data
                    }
                })
            });
        });
    }

    onAddFood(){
        this.setState(() => {return{ createOffer: true}});
    }
    /*
    handleFoodAdded(){
        this.setState(() => {return{ createOffer: false}});
    }
*/
    componentDidMount(){
        this.refreshList();
    }

    render(){
        
        return(
            <div>
                
                {this.state.createOffer && <CreateOffer/>}
                
                <button onClick={()=>{this.onAddFood()}}> 
                    +
                </button>
                <Table className="table">
                    <thead>
                        <tr>
                            <th scope="col">Name</th>
                            <th scope="col">Description</th>
                            <th scope="col">Price</th>
                            <th scope="col">Amount</th>
                            <th scope="col">Date</th>
                            <th scope="col">Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.foods.map(food=>
                            
                            <tr>
                                <td>{food.Name}</td>
                                <td>{food.Description}</td>
                                <td >{food.FullPrice}</td>
                                <td >{food.Weight != null ? food.Weight + " kg" : food.Quantity + " units"}</td>
                                <td >{food.ExpDate}</td>
                                <td>Edit / Delete</td>
                                <div>
                                    {
                                        food.BuyerID === 0 && food.OwnerID !== localStorage.userID &&
                                        <button onClick={() => this.addToCart(food.ID, food.BuyerID)}> 
                                            Add to cart
                                        </button>
                                    }
                                </div>
                                
                            </tr>)}
                    </tbody>
                </Table>
            </div>
           // </div>
        )
    }
}

