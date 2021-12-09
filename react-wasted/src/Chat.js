import React, { useEffect, useState, useRef} from 'react';
import * as signalR from "@aspnet/signalr";
import './Chat.css';

export const Chat = (props) => {

  const userID = localStorage.getItem('userID');
  const [connection, setConnection] = useState();
  const [messages, setMessages] = useState([]);
  const [message, setMessage] = useState('');

  const messageRef = useRef();

    useEffect(() => {
        if (messageRef && messageRef.current) {
            const { scrollHeight, clientHeight } = messageRef.current;
            messageRef.current.scrollTo({ left: 0, top: scrollHeight - clientHeight, behavior: 'smooth' });
        }
    }, [messages]);


  useEffect ( () => {

      const connection = new signalR.HubConnectionBuilder()
      .withUrl("ws://localhost:5000/ChatHub", {

        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .configureLogging(signalR.LogLevel.Information)
      .build();

      connection.on("ReceiveMessage", (userID, message) => {
        setMessages(messages => [...messages, {userID, message}]);

      });

      connection.logging = true;

      //connection.start();

      connection.start().then(() => console.log('Connection established.'))
        .catch(error => console.log(`Error while establishing connection: ${error}`))
        .then(() => connection.invoke("JoinRoom", (props.roomID).toString()))
        .catch(error => console.error(`Error while adding to group: ${error}`));

      //connection.invoke("JoinRoom", (props.roomID).toString());

      setConnection(connection); 

  }, []);

  const sendMessage = async (message)  => {

    try{
      await connection.invoke("SendGroupMessage", (props.roomID).toString(), localStorage.getItem('userID'), message);
      setMessage('');
    } catch (e)
    {
      console.log(e);
    }

  }
    return (
    <div className="chat-container">    

      <div className="card"  style={{width: '250px'}}>
        <div class="card-header">Chat</div>
          <div className='chat'>
            <div ref={messageRef} className='message-container'>
              {messages.map((m, index) =>
              <div key={index} className={m.userID == userID ? 'user-message' : 'not-user-message'}>
                <div className='message bg-primary'>{m.message}</div>
                <div className='from-user'>From: {m.userID}</div>
              </div>
              )}
            </div>
          </div>
      
        <div>
          <input
            type="text"
            onChange={e => setMessage(e.target.value)}
            value={message}
          />
          <button 
          onClick={e => {
            e.preventDefault();
            sendMessage(message);
          }}> Send</button>
        </div>
  
      </div>

    </div>  
    );
  



}