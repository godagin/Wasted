import logo from './logo.svg';
import './App.css';
import {Home} from './Home';
import {Foods} from './Foods';
import {Cart} from './Cart';
import {Register} from './Account/Register';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import { Container } from 'react-bootstrap';

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
        </Switch>
      </Container>
    
    </BrowserRouter>
  );
}

export default App;
