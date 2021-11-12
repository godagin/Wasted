import React,{Component} from 'react';
import {Redirect} from 'react-router-dom';

export class Logout extends Component{

    render(){
        console.log(localStorage.getItem('userID'));
        if(localStorage.getItem('userID') != null)
        {
            localStorage.removeItem('userID');
            //localStorage.setItem('userID', null);
            //console.log(localStorage.getItem('userID'));
            window.location.reload(false);

        }
        return (<Redirect to ='/login'/>); 
    }
}