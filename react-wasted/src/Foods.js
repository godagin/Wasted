import React,{Component} from 'react';
import { Table } from 'react-bootstrap';
import { CreateOffer } from './CreateOffer';

export class Foods extends Component{

    constructor(props){
        super(props);
        this.state={
            foods:[],
            //FileName: "anonymous.jpg",
            PhotoPath: process.env.REACT_APP_API + '/Photos/',
            createOffer: false,
            filteredItems:[],
            input:{
                searchKeyword: ""
            }   
        }
    }

    addToCart = (ID, BuyerID) =>{
        if (BuyerID == localStorage.getItem('userID'))
        {
            console.log('already in cart');
        }
        else{
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
        window.location.reload(false);
        this.refreshList();        
    }


    refreshList(){
        fetch(process.env.REACT_APP_API + '/api/foods/'+ this.state.input.searchKeyword)
        .then(response => {
            response.json().then(data => {
                this.setState(() => {
                    console.log(data);
                    return{
                        filteredItems: data,
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
    inputHandler = (event) => {
        this.state.input.searchKeyword = event.target.value;
        this.setState((state) => {return state;});
        this.refreshList();
    }
    
    componentDidMount(){
        this.refreshList();
    }

    render(){

        if(localStorage.getItem('userID') == null || localStorage.getItem('userID') == undefined){
            return (<div> </div>);
        }
        return(
            <div>
                
                {this.state.createOffer && <CreateOffer/>}
                
                <button onClick={()=>{this.onAddFood()}}> 
                    +
                </button>
                <form>
                <input
                    type="text"
                    className="search-box"
                    placeholder="Search for..."
                    onChange={this.inputHandler}
                />
                
            </form>
                <Table className="table">
                    <thead>
                        <tr>
                            <th scope="col">Photo</th>
                            <th scope="col">Name</th>
                            <th scope="col">Description</th>
                            <th scope="col">Price</th>
                            <th scope="col">Amount</th>
                            <th scope="col">Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.foods.map(food=>
                            
                            <tr>
                                <td>
                                    <img alt="" width="150px" height="150px"
                                    src={this.state.PhotoPath+food.PhotoFileName} />
                                </td>
                                <td class="align-middle">{food.Name}</td>
                                <td class="align-middle">{food.Description}</td>
                                <td class="align-middle">{food.FullPrice}</td>
                                <td class="align-middle">{food.Weight != null ? food.Weight + " kg" : food.Quantity + " units"}</td>
                                <td class="align-middle">{food.ExpDate}</td>

                                    <div class="vertical-center">
                                    {
                                        food.BuyerID == 0 && food.OwnerID != localStorage.userID &&
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

