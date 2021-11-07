import React,{Component} from 'react';
import { Table } from 'react-bootstrap';

export class Foods extends Component{
    constructor(props){
        super(props);
        this.state={
            foods:[],
            cartItems:[]
        }
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

    onAddedToCart = (food) => {
       /*
        this.setState(prevState => ({
            cartItems : prevState.cartItems.concat(food)
        }))
        */
        //console.log(cartItems);
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
                                <button onClick={() => this.onAddedToCart(food)}>Add to cart</button>
                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}