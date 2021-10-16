import './App.css';
import Companies from './components/Companies.js'
import Company from './components/Company.js'
import Home from './components/Home.js'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import NavBar from './components/NavBar.js';
import Profile from './components/Profile2';
import TypeOfWork from './components/TypeOfWork';
import LogInRegister from './components/LogInRegister';
import Error from './components/Error';
import Breakfast from './components/breakfast/Breakfast';
import MeetingRoom from './components/meeting-room/MeetingRoom';
import React, {useState} from 'react'
import * as generalHelpers from './services/generalHelpers.js';

function App() {
  const [amILoggedIn, setAmILoggedIn] = useState(generalHelpers.CheckIfIAmLoggedIn());

  return (
    <Router>
      <NavBar amILoggedIn={amILoggedIn}/>

      <Switch>
        <Route exact path="/">
          <Home amILoggedIn={amILoggedIn}/>
        </Route>

        <Route exact path="/companies">
          <Companies />
        </Route>

        <Route exact path="/companies/:companyName">
          <Company />
        </Route>

        <Route exact path="/profile/:username">
          <Profile setAmILoggedIn={setAmILoggedIn}/>
        </Route>
        
        <Route exact path="/typeOfWork">
          <TypeOfWork/>
        </Route>

        <Route exact path="/breakfast">
          <Breakfast/>
        </Route>

        <Route exact path="/meeting-room">
          <MeetingRoom/>
        </Route>

        <Route exact path="/logIn">
          <LogInRegister isOpen={true}/>
        </Route>

        <Route path="*">
          <Error/>
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
