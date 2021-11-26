import React, { Component } from 'react';
import { HubConnection } from '@microsoft/signalr';

export class Chat extends Component {

  constructor(props) {
    super(props);
    this.state={
      userName: '',
      message: '',
      messages: [],
      hubConnection: null,
    };
  }
/*
  componentDidMount = () => {

    const userName = localStorage.getItem('userID');

    const hubConnection = new HubConnection().withUrl('/chathub')
    .build();

    this.setState({ hubConnection, userName }, () => {
      this.state.hubConnection
        .start()
        .then(() => console.log('Connection started'))
        .catch(err => console.log('Error while establishing connection'));

      this.state.hubConnection.on('ReceiveMessage', (userName, receivedMessage) => {
        const text = `${userName}: ${receivedMessage}`;
        const messages = this.state.messages.concat([text]);
        this.setState({ messages });
      });
    });
  }*/

  sendMessage = () => {

    /*
    this.state.hubConnection
      .invoke('ReceiveMessage', this.state.userName, this.state.message)
      .catch(err => console.error(err));
  
      this.setState({message: ''});   */
      
      console.log('sent');
  };
  
  
/*
render() {
  return (
    <div>
      <br />
      <input
        type="text"
        value={this.state.message}
        onChange={e => this.setState({ message: e.target.value })}
      />

      <button onClick={this.sendMessage}>Send</button>

      <div>
        {this.state.messages.map((message, index) => (
          <span style={{display: 'block'}} key={index}> {message} </span>
        ))}
      </div>
    </div>
  );
}*/

render(){

  return (
  <div class="page-content page-container" id="page-content">
      <div class="padding">
          <div class="row container d-flex justify-content-center">
              <div class="col-md-4">
                  <div class="box box-warning direct-chat direct-chat-warning">
                      <div class="box-header with-border">
                          <h3 class="box-title">Chat with user</h3>
                      </div>
                      <div class="box-body">
                          <div class="direct-chat-messages"> 

                          <div class="direct-chat-msg">
                          {this.state.messages.map((message, index) => (<span style={{display: 'block'}} key={index}> {message} </span>))}
                          </div>

                          </div>
                      </div>
                      <div class="box-footer">
                          
                        <div class="input-group"> <input type="text" name="message" placeholder="Type Message ..." class="form-control" value={this.state.message}onChange={e => this.setState({ message: e.target.value })}/> <span class="input-group-btn"> <button type="button" class="btn btn-warning btn-flat" onClick={this.sendMessage}>Send</button> </span> </div>
   
                      </div>
                  </div>
              </div>
          </div>
      </div>
  </div>
  );

}



}
