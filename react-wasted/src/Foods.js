import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { CreateOffer } from './CreateOffer';

export class Foods extends Component {

    constructor(props) {
        super(props);
        this.state = {
            PhotoPath: process.env.REACT_APP_API + '/Photos/',
            createOffer: false,
            filteredItems: [],
            input: {
                searchKeyword: ""
            }
        }
    }

    addToCart = (ID, BuyerID) => {
        if (BuyerID == localStorage.getItem('userID')) {
            console.log('already in cart');
        }
        else {
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


    refreshList() {
        fetch(process.env.REACT_APP_API + '/api/foods/' + this.state.input.searchKeyword)
            .then(response => {
                response.json().then(data => {
                    this.setState(() => {
                        console.log(data);
                        return {
                            filteredItems: data
                            //foods : data
                        }
                    })
                });
            });
    }

    onAddFood() {
        this.setState(() => { return { createOffer: true } });
    }
    /*
    handleFoodAdded(){
        this.setState(() => {return{ createOffer: false}});
    }
*/

    deleteClick(id) {
        if (window.confirm('Are you sure?')) {
            fetch(process.env.REACT_APP_API + '/api/foods/' + id, {
                method: 'DELETE'
            }).then((result) => {
                result.json().then((resp) => {
                    console.warn(resp)
                })
                this.refreshList();
            })
        }
    }


    inputHandler = (event) => {
        this.state.input.searchKeyword = event.target.value;
        this.setState((state) => { return state; });
        this.refreshList();
    }
    componentDidMount() {
        this.refreshList();
    }

    render() {
        if (localStorage.getItem('userID') == null || localStorage.getItem('userID') == undefined) {
            return (<div> </div>);
        }
        return (
            <div>

                {this.state.createOffer && <CreateOffer />}

                <button onClick={() => { this.onAddFood() }}>
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
                        {this.state.filteredItems.map(food =>

                            <tr>
                                <td>
                                    <img alt="" width="150px" height="150px"
                                        src={this.state.PhotoPath + food.PhotoFileName} />
                                </td>
                                <td class="align-middle">{food.Name}</td>
                                <td class="align-middle">{food.Description}</td>
                                <td class="align-middle">{food.FullPrice}</td>
                                <td class="align-middle">{food.Weight != null ? food.Weight + " kg" : food.Quantity + " units"}</td>
                                <td class="align-middle">{food.ExpDate}</td>
                                <td>

                                    {food.OwnerID == localStorage.getItem('userID') ?
                                        <button type="button" className="btn btn-light mr-1"
                                            onClick={() => { this.updateClick() }}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                                <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                            </svg>
                                        </button>
                                        : null}

                                    {food.OwnerID == localStorage.getItem('userID') ?
                                        <button type="button" className="btn btn-light mr-1"
                                            onClick={() => { this.deleteClick(food.ID) }}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                                <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                            </svg>
                                        </button>
                                        : null}

                                </td>

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

