import './App.css';
import Companies from './components/Companies.js'
import Company from './components/Company.js'
import Home from './components/Home.js'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import NavBar from './components/NavBar.js';
import Profile from './components/Profile';

function App() {
  return (
    <Router>
      <NavBar />
      <Switch>
        <Route exact path="/">
          <Home />
        </Route>
        <Route exact path="/companies/:username">
          <Companies />
        </Route>
        <Route exact path="/companies/:companyName">
          <Company />
        </Route>
        <Route exact path="/profile/:username">
          <Profile />
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
