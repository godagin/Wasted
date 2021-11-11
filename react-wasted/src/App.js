import './App.css';
import {Home} from './Home';
import {Foods} from './Foods';
import {Cart} from './Cart';
import {Register} from './Account/Register';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import { Container } from 'react-bootstrap';
import { Login } from './Account/Login';

function App() {
  return (
    <BrowserRouter>

      <Navigation/>

      <Container>
        <Switch>
          <Route path='/' component={Home} exact/>
          {localStorage.getItem('userID') != null && <Route path='/foods' component={Foods}/>}
          {localStorage.getItem('userID') != null && <Route path='/cart' component={Cart}/>}
          <Route path='/register' component={Register}/>
          <Route path='/login' component={Login}/>
        </Switch>
      </Container>
    
    </BrowserRouter>
  );
}

export default App;
