import logo from './logo.svg';
import './App.css';
import {Home} from './Home';
import {Foods} from './Foods';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="container">
      
    
      <Navigation/>

      <Switch>
        <Route path='/' component={Home} exact/>
        <Route path='/foods' component={Foods}/>
        
      </Switch>
      
    </div>
    </BrowserRouter>
  );
}

export default App;
