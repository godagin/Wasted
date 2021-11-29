import React,{Component} from 'react';
import { Table } from 'react-bootstrap';

export class AddedOffers extends Component{

    constructor(props){
        super(props);
        this.state={
            addedItems:[]
        }
    }

    refreshList(){

        fetch(process.env.REACT_APP_API + '/api/addedoffers/' + localStorage.getItem('userID'))
        .then(response => {
            response.json().then(data => {
                console.log(data);
                this.setState(() => {
                    return{
                        addedItems: data
                    }
                })
            });
        });
    }

    componentDidMount(){
        this.refreshList();
    }


    onRemoveOffer = (ID) =>{

        const requestOptions = {
            method: 'POST', 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                userID: localStorage.getItem('userID'),
                foodID: ID
             })
        };
        fetch(process.env.REACT_APP_API + '/api/addedoffers', requestOptions) 
            .then((response) => response.json())
            .then(data => {
                console.log(data);
            })


        this.setState(state => { //instead of rerendering we just remove item from this local list
            const addedItems = state.addedItems.filter((item) => ID != item.ID);
            return{
                addedItems,
            };
        });
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

                         </tr>
                     </thead>

                     <tbody>
                         {this.state.addedItems.map(food=>
                             <tr>
                                 <td>{food.Name}</td>
                                 <td>{food.Description}</td>
                                 <td >{food.FullPrice}</td>
                                 <td >{food.Weight != null ? food.Weight + " kg" : food.Quantity + " units"}</td>
                                 <button onClick={() => this.onRemoveOffer(food.ID)}>Remove offer</button>
                             </tr>)}
                     </tbody>
                 </Table>



                </div>

             </div>


        )
    }
}
