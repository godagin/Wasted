import React,{Component} from 'react';
import {Redirect} from 'react-router-dom';

export class Logout extends Component{

    render(){
        console.log(localStorage.getItem('userID'));
        if(localStorage.getItem('userID') != null)
        {

            localStorage.setItem('userID', null);
            console.log(localStorage.getItem('userID'));

        }
        return (<Redirect to ='/login'/>); 
    }
}