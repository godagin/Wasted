import './App.css';
import {Home} from './Home';
import {Foods} from './Foods';
import {Cart} from './Cart';
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
          <Route path='/foods' component={Foods}/>
          <Route path='/cart' component={Cart}/>
          <Route path='/register' component={Register}/>
          <Route path='/login' component={Login}/>
          <Route path='/logout' component={Logout}/>
        </Switch>
      </Container>
    
    </BrowserRouter>
  );
}

export default App;
