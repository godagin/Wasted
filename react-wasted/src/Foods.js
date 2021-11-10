import React,{Component} from 'react';
import { Table } from 'react-bootstrap';
//import {Cart} from './Cart';

export class Foods extends Component{

    constructor(props){
        super(props);
        this.state={
            foods:[],
            //cartItems:[]
        }
    }

    addToCart = (ID) =>{

        /*
            const {foods, cartItems} = this.state;
            const cartData = foods.filter(food =>{
                return food.ID === ID
            })
            
            //console.log(data);

            this.setState( {cartItems: [...cartItems,...cartData]} ) 
*/ //nebereikia cartItems for now
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


               // console.log(localStorage.getItem('userID'));
              
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

    

    render(){
        
        return(
            //<div>
            //<Cart cartData={this.state.cartItems} />
            <div>
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
                                <button onClick={() => this.addToCart(food.ID)}>Add to cart</button>
                            </tr>)}
                    </tbody>
                </Table>
            </div>
           // </div>
        )
    }
}

