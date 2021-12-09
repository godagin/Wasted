import React,{Component} from 'react';
import { Table } from 'react-bootstrap';
import { CreateOffer } from './CreateOffer';


export class Foods extends Component{

    constructor(props){
        super(props);
        this.state={
            foods:[],
            createOffer: false,
        }
    }
/*
    updateInputValue = (event) => {
        this.setState({
            amounts: event.target.value
        });
    }
    */
    onChange = (index) => (event) => {
        this.state.foods[index].inputValue = event.target.value;
        //this.refreshList();
        //let items = [...this.state.foods];
        //items[index] = event.target.value;
        //this.setState({
        //    foods: items
    //});
    }
        

    addToCart = (ID, BuyerID, index) =>{
        const requestOptions = {
            method: 'POST', 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                userID: BuyerID,
                foodID: ID,
                amount: this.state.foods[index].inputValue,
                })
        };
        console.log(requestOptions.body);
        fetch(process.env.REACT_APP_API + '/api/cart', requestOptions) 
            .then((response) => response.json())
            .then(data => {
                console.log(data);
            })

        
        window.location.reload(false);
        this.refreshList();        
    }


    refreshList(){
        fetch(process.env.REACT_APP_API + '/api/foods')
        .then(response => {
            response.json().then(data => {
                this.setState(() => {
                    
                    for(let food of this.state.foods)
                    {
                        food.inputValue = 0; 
                    }
                    
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
        if(localStorage.getItem('userID') === null || localStorage.getItem('userID') === undefined){
            return (<div> </div>);
        }
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
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.foods.map((food, index)=>
                            <tr key={food.ID}>
                                <td>{food.Name}</td>
                                <td>{food.Description}</td>
                                <td >{food.FullPrice}</td>
                                <td >{food.Weight != null ? food.Weight + " kg" : food.Quantity + " units"}</td>
                                <td >{food.ExpDate}</td>
                                
                                    {
                                        food.OwnerID !== localStorage.userID &&
                                        <>
                                            <td>
                                            {   
                                                food.Weight != null 
                                                ? <input type="number" value={this.state.foods[index].inputValue}
                                                step="0.01" placeholder="0.00" min="0.01" max={food.Weight} onChange={this.onChange(index)}/>
                                                : <input type="number" value={this.state.foods[index].inputValue}
                                                step="1" placeholder="0" min="1" max={food.Quantity} onChange={this.onChange(index)}/>
                                            }
                                            </td>
                                            <td>
                                                <button onClick={() => this.addToCart(food.ID, localStorage.getItem('userID'), index)}>
                                                    Add to cart
                                                </button>
                                            </td>
                                        </>
                                    }
                                  
                            </tr>)}
                    </tbody>
                </Table>
            </div>
        )
    }
}
