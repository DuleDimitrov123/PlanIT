import React, {useState} from 'react'
import Error from '../Error';
import AddAvailableBreakfast from './AddAvailableBreakfast';
import './Breakfast.css'
import * as generalHelpers from '../../services/generalHelpers'
import ChooseMyBreakfast from './ChooseMyBreakfast';
import MyBreakfasts from './MyBreakfasts';
import BreakfastByCompany from './BreakfastByCompany';

function Breakfast() {
    const [wasAnError, setWasAnError] = useState(false);
    const [errorMessage, setErrorMessage] = useState(null);

    const handleWasAnError = () => {
        setWasAnError(true);  
        console.log("Handle was an error called");
    };

    if(wasAnError === true)
    {
        return <Error customMessage={errorMessage}/>
    }

    const username = localStorage.getItem("username");
    const loginToken = localStorage.getItem("loginToken");
    const companyName = localStorage.getItem("companyName");

    if(username === null || username === undefined || 
        loginToken === null || loginToken === undefined || 
        companyName === null || companyName === undefined)
    {
        window.location.replace("/");
    }

    const userCanCreate = generalHelpers.CheckIfLoggerUserCanCreate();
    console.log(userCanCreate);

    return (
        <div className="breakfastDivContainer">
            <div className="divForCenterContent">
                <h1>BREAKFASTS</h1>
            </div>
            <div>
                <br/>
            </div>
          <div className="divForCenterContent">
                <div className="middleBreakfastDiv">
                    <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                        <li class="nav-item" role="presentation">
                            <button class="nav-link active" id="pills-choose-tab" data-bs-toggle="pill" data-bs-target="#pills-choose" type="button" role="tab" aria-controls="pills-choose" aria-selected="true">Choose your breakfast</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="pills-colleagues-tab" data-bs-toggle="pill" data-bs-target="#pills-colleagues" type="button" role="tab" aria-controls="pills-colleagues" aria-selected="false">What are my colleagues eating</button>
                        </li>
                        <li class="nav-item" role="presentation">
                            <button class="nav-link" id="pills-my-breakfasts-tab" data-bs-toggle="pill" data-bs-target="#pills-my-breakfasts" type="button" role="tab" aria-controls="pills-my-breakfasts" aria-selected="false">My breakfasts</button>
                        </li>
                    </ul>
                    <div class="tab-content" id="pills-tabContent">
                    <div class="tab-pane fade show active" id="pills-choose" role="tabpanel" aria-labelledby="pills-choose-tab">
                        <ChooseMyBreakfast handleWasAnError={handleWasAnError}/>
                    </div>
                    <div class="tab-pane fade" id="pills-colleagues" role="tabpanel" aria-labelledby="pills-colleagues-tab">
                        <BreakfastByCompany handleWasAnError={handleWasAnError}/>
                    </div>
                    <div class="tab-pane fade" id="pills-my-breakfasts" role="tabpanel" aria-labelledby="pills-my-breakfasts-tab">
                        <MyBreakfasts handleWasAnError={handleWasAnError}/>
                    </div>
                </div>
            </div>
                
            <div className="upperBreakfastDiv">
                {userCanCreate && <AddAvailableBreakfast/>}
            </div>
        </div>
    </div>
    )
}

export default Breakfast
