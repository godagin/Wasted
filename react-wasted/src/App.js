import './App.css';
import {Home} from './Home';
import {Foods} from './Foods';
import {Cart} from './Cart';
import {AddedOffers} from './AddedOffers';
import {Register} from './Account/Register';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import { Container } from 'react-bootstrap';
import { Login } from './Account/Login';
import { Logout } from './Account/Logout';

function App() {
  return (
    <BrowserRouter>

      <Navigation/>

      <Container>
        <Switch>
          <Route path='/' component={Home} exact/>
          {localStorage.getItem('userID') != null && <Route path='/foods' component={Foods}/>}
          {localStorage.getItem('userID') != null && <Route path='/cart' component={Cart}/>}
          {localStorage.getItem('userID') != null && <Route path='/addedoffers' component={AddedOffers}/>}
          { localStorage.getItem('userID') == null && <Route path='/register' component={Register}/>}
          { localStorage.getItem('userID') == null && <Route path='/login' component={Login}/>}
          <Route path='/logout' component={Logout}/>
        </Switch>
      </Container>
    
    </BrowserRouter>
  );
}

export default App;
