import React,{Component} from 'react';
import {Form, Button, Row, Col} from 'react-bootstrap';

export class CreateOffer extends Component{
    constructor(props){
        super(props);
        this.state = {
            PhotoFileName: "anonymous.jpg",
            PhotoPath: process.env.REACT_APP_API + '/Photos/',
            input:{
                type: 1,
                name: "",
                description: "",
                price: 0,
                amount: 0,
                foodType: 0,
                expiration: 0
            }
        }
    }

    inputHandler = (event) => {
        switch(event.target.id){
            case "formGridName" :
                this.state.input.name = event.target.value;
                break;
            case "formGridDescription" :
                this.state.input.description = event.target.value;
                break;
            case "formGridCategory" :
                this.state.input.foodType = event.target.value;
                break;
            case "formGridPrice" :
                this.state.input.price = event.target.value;
                break;
            case "formGridAmount" :
                this.state.input.amount = event.target.value;
                break;
            case "formGridExpiration" :
                this.state.input.expiration = event.target.value;
                break;
            case "formGridType" :
                this.state.input.type = event.target.value;
                break;
        }
        this.setState((state) => {return state;});
    }

    imageUpload=(e)=>{
        e.preventDefault();

        const formData=new FormData();
        formData.append("file", e.target.files[0], e.target.files[0].name);

        fetch(process.env.REACT_APP_API + '/api/foods/SaveFile', {
            method: 'POST',
            body: formData
        })
        .then(res=>res.json())
        .then(data=>{
            this.setState({PhotoFileName:data});
        })
    }
    radioButtonHandler = (e) => {
        if(e.target.id == "weighedRadio" && e.target.checked){
            this.state.input.type = 1;
        } else if(e.target.id == "discreteRadio" && e.target.checked){
            this.state.input.type = 2;
        }
        this.setState((state) => {return state});
    }

    submitHandler = (event) => {
        const requestOptions = {
            method: 'POST', 
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ 
                type: this.state.input.type,
                owner: localStorage.getItem('userID'),
                name: this.state.input.name,
                fullPrice: this.state.input.price, 
                description: this.state.input.description,
                amount: this.state.input.amount,
                foodType: this.state.input.foodType,
                expTime: this.state.input.expiration,
                fileName: this.state.PhotoFileName
             })
        };
        fetch(process.env.REACT_APP_API + '/api/foods', requestOptions) 
            .then(response => {
                if(response.status == 200){
                    window.location.reload(false);
                } else{
                    console.log("ERRROR!!!!!!!!!!");
                }
            });
    }


    render(){
        const{
            PhotoFileName,
            PhotoPath
        }=this.state;
        return(
            <Form >
                <Row className="mb-3">
                    <Form.Group as={Col} defaultValue={this.state.input.name} controlId="formGridName" onChange={this.inputHandler}>
                        <Form.Label>Name</Form.Label>
                        <Form.Control placeholder="Enter food name" />
                    </Form.Group>

                    <Form.Group as={Col} defaultValue={this.state.input.description} controlId="formGridDescription" onChange={this.inputHandler}>
                        <Form.Label>Description</Form.Label>
                        <Form.Control placeholder="Enter food description" />
                    </Form.Group>
                    
                    <Form.Group as={Col} defaultValue={this.state.input.foodType}>
                        <Form.Label as="legend" column sm={2}>
                            Food category
                        </Form.Label>
                        <Form.Select  id="formGridCategory" onChange={this.inputHandler}>
                            <option value="0">Default</option>
                            <option value="1">Vegetables</option>
                            <option value="2">Fruits</option>
                            <option value="3">Seafood</option>
                            <option value="4">Meat</option>
                            <option value="5">Dairy</option>
                            <option value="6">Grains, beans and nuts</option>
                            <option value="7">Confectionery</option>
                            <option value="8">Bakery</option>
                            <option value="9">Meals</option>
                        </Form.Select>
                    </Form.Group>
                </Row>
                
                
                <Row className="mb-3">
                    <Form.Group as={Col} defaultValue={this.state.input.price} controlId="formGridPrice" onChange={this.inputHandler}>
                        <Form.Label>Price</Form.Label>
                        <Form.Control type="number" min="0.0" precision={2} placeholder="Enter price" />
                    </Form.Group>

                    <Form.Group as={Col} defaultValue={this.state.input.amount} controlId="formGridAmount" onChange={this.inputHandler}>
                        <Form.Label>Amount</Form.Label>
                        <Form.Control type = "number" min="0.0" precision={2} placeholder="Enter amount" />
                    </Form.Group>

                    <Form.Group as={Col} defaultValue={this.state.input.expiration} controlId="formGridExpiration" onChange={this.inputHandler}>
                        <Form.Label>Days until expiration</Form.Label>
                        <Form.Control type="number" placeholder="Enter amount of days" />
                    </Form.Group>
                </Row>
                
                <Form.Group as={Row} className="mb-3" controlId="formGridType">
                    <Form.Label as="legend" column sm={6}>
                        Food type by amount
                    </Form.Label>
                    <Col sm={10}>
                        <Form.Check
                        checked={this.state.input.type == 1 ? true : false}
                        type="radio"
                        label="Weighed"
                        name="typeRadios"
                        id="weighedRadio"
                        onChange={this.radioButtonHandler}
                        />
                        <Form.Check
                        checked={this.state.input.type == 2 ? true : false}
                        type="radio"
                        label="Discrete"
                        name="typeRadios"
                        id="discreteRadio"
                        onChange={this.radioButtonHandler}
                        />
                    </Col>
                </Form.Group>
    
                <div className="p-2 w-50 bd-highlight">
                    <img alt="" width="200px" height="200px"
                    src={PhotoPath+PhotoFileName}/>
                    <input className="m-2" type="file" onChange={this.imageUpload}/>
                </div>
                <Button onClick={()=>{
                    //patikrinti ar dienos nera skaicius su kableliu
                    this.setState(() => {return{ 
                        createOffer: false,
                        fileName:PhotoFileName}});
                    this.submitHandler();
                    }}>
                    Submit
                </Button>
            </Form>
        )
    }
}