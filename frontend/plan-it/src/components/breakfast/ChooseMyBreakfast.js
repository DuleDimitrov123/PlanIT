import React, {useState, useEffect} from 'react'
import * as urlConstants from '../../constants/urlConstants.js'
import {postRequestWithAuthorization} from '../../services/postRequestWithAuthorization.js';
import {postRequestWithAuthorizationWithoutResponse} from '../../services/postRequestWithAuthorizationWithoutResponse.js';
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import { MultiSelect } from "react-multi-select-component";

function ChooseMyBreakfast({handleWasAnError}) {
    const [date, setDate] = useState(new Date());
    const [breakfast, setBreakfast] = useState([]);
    const [chosenBreakfastLabelValue, setchosenBreakfastLabelValue] = useState([]);
    const url = urlConstants.BASE_URL + urlConstants.GET_AVAILABLE_BREAKFAST_BY_COMPANY_AND_DATE;

    const options = breakfast.map(b =>{
        return {
            label : b,
            value : b
        };
    })

    useEffect(async ()=>{
        const companyName = localStorage.getItem("companyName");

        if(companyName != null && companyName != undefined)
        {
            const request = {
                companyName : companyName,
                date : date
            };
            console.log(request);
            const {response, exception} = await postRequestWithAuthorization(request, url);

            if(exception === null)
            {
                setBreakfast(response);
            }
            else
            {
                handleWasAnError();
            }
        }
        else
        {
            window.location.replace("/logIn");
        }
    }, [date]);

    async function handleChoosingBreakfast(){
        const url = urlConstants.BASE_URL + urlConstants.ADD_BREAKFAST_FOR_USER;
        const username = localStorage.getItem("username");

        if(username != null && username != undefined)
        {
            const request = {
                staffUsername : username,
                date : date,
                breakfastItems : chosenBreakfastLabelValue.map(c => c.value)
            };
            console.log(request);

            const {response, exception} = await postRequestWithAuthorizationWithoutResponse(request, url);

            if(exception !== null)
            {
                handleWasAnError();
            }
            else
            {
                window.location.reload();
            }
        }
        else
        {
            window.location.replace("/logIn");
        }
    };

    return (
        <div>
            <br/>
            <div className="divForCenterContent" style={{width:"100%"}}>
                <div>
                    <DatePicker className="form-control" 
                        selected={date}
                        onChange={date => setDate(date)}
                        dateFormat='dd/MM/yyyy'
                        filterDate={date => date.getDay() !== 6 && date.getDay() !== 0}
                    />        
                </div>
            </div>

            <div>
                <br/>
            </div>
            <div className="divForCenterContent">
                <label>Choose your breakfast</label>
            </div>
            <MultiSelect 
                options={options} 
                value={chosenBreakfastLabelValue} 
                onChange={setchosenBreakfastLabelValue} 
                labelledBy="Select"
            />
            <div>
                <br/>
            </div>

            <div className="divForCenterContent">
                <button className="btn btn-primary" onClick={handleChoosingBreakfast}>Choose</button>
            </div>
        </div>
    )
}

export default ChooseMyBreakfast
