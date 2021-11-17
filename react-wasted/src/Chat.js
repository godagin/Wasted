import React, { Component } from 'react';
import { HubConnection } from '@aspnet/signalr';

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

  componentDidMount = () => {

    const userName = localStorage.getItem('userID');

    const hubConnection = new HubConnection().withUrl('/chathub')
    .build();

    this.setState({ hubConnection, userName }, () => {
      this.state.hubConnection
        .start()
        .then(() => console.log('Connection started'))
        .catch(err => console.log('Error while establishing connection'));

      this.state.hubConnection.on('Send', (userName, receivedMessage) => {
        const text = `${userName}: ${receivedMessage}`;
        const messages = this.state.messages.concat([text]);
        this.setState({ messages });
      });
    });
  }

  sendMessage = () => {
    this.state.hubConnection
      .invoke('Send', this.state.userName, this.state.message)
      .catch(err => console.error(err));
  
      this.setState({message: ''});      
  };
  
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
  }
}




