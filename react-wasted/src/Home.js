import React, { Component } from 'react';
import { Table } from 'react-bootstrap';


export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            foods: [],
            cheap: [],
            PhotoPath: process.env.REACT_APP_API + '/Photos/'
        }
    }

    refreshExp() {
        fetch(process.env.REACT_APP_API + '/api/home')
            .then(response => {
                response.json().then(data => {
                    this.setState(() => {
                        console.log(data);
                        return {
                            foods: data
                        }
                    })
                });
            });
    }

    refreshCheap() {
        fetch(process.env.REACT_APP_API + '/api/home/cheapest')
            .then(response => {
                response.json().then(data => {
                    this.setState(() => {
                        console.log(data);
                        return {
                            cheap: data
                        }
                    })
                });
            });
    }

    componentDidMount() {
        this.refreshExp();
        this.refreshCheap();
    }

    render() {

        return (
            <div >

                <h4>Offers that expire</h4>
                <Table className="table">
                    <thead>
                        <tr>
                            <th scope="col">Photo</th>
                            <th scope="col">Name</th>
                            <th scope="col">Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.foods.map(food =>

                            <tr>
                                <td>
                                    <img alt="" width="150px" height="150px"
                                        src={this.state.PhotoPath + food.PhotoFileName} />
                                </td>
                                <td class="align-middle">{food.Name}</td>
                                <td class="align-middle">{food.ExpDate}</td>
                                <td>


                                </td>



                            </tr>)}
                    </tbody>
                </Table>



                <h4>Cheapest offers</h4>
                <Table className="table">
                    <thead>
                        <tr>
                            <th scope="col">Photo</th>
                            <th scope="col">Name</th>
                            <th scope="col">Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.cheap.map(food =>

                            <tr>
                                <td>
                                    <img alt="" width="150px" height="150px"
                                        src={this.state.PhotoPath + food.PhotoFileName} />
                                </td>
                                <td class="align-middle">{food.Name}</td>
                                <td class="align-middle">{food.FullPrice}</td>
                                <td>
                                </td>
                            </tr>)}
                    </tbody>
                </Table>



            </div>

        )
    }
}