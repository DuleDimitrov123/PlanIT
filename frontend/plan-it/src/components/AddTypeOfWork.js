import React, {useState} from 'react'
import { Spinner } from 'react-bootstrap';
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import * as urlConstants from '../constants/urlConstants.js'
import * as generalConstants from '../constants/generalConstants.js';
import * as exceptionConstants from '../constants/exceptionConstants.js';
import {postRequestWithAuthorization} from '../services/postRequestWithAuthorization';

function AddTypeOfWork() {
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [typeOfWork, setTypeOfWork] = useState(generalConstants.WFH);
    const [showSpinner, setShowSpinner] = useState(false);
    const [errorMessage, setErrorMessage] = useState(null);

    async function handleAddTypeOfWork(){
        //alert(selectedDate.getDate())
        setShowSpinner(true);

        const url = urlConstants.BASE_URL + urlConstants.ADD_TYPE_OF_WORK;
        let partForToken = '';
        const token = localStorage.getItem("loginToken");
        if(token!=null && token!=undefined)
        {
            partForToken = "Bearer "+token;
        }

        const staffUsername = localStorage.getItem("username");
        const companyName = localStorage.getItem("companyName");
        const request = {
            staffUsername : staffUsername,
            date : selectedDate,
            companyName : companyName,
            typeOfWork : typeOfWork
        };

        /*const {response, exception} = await postRequestWithAuthorization(request, url);
        console.log(exception);

        if(exception !== null)
        {
            if (exception instanceof Promise)
            {
                const message = await exception.text();
                if(message.includes(exceptionConstants.WORKING_FROM_OFFICE_NOT_POSSIBLE))
                {
                    setErrorMessage(exceptionConstants.WORKING_FROM_OFFICE_NOT_POSSIBLE);
                }
            }
            console.log(exception);
        }*/
        
        try
        {
            const response = await fetch(url, {
                method: "POST",
                headers: { "Content-Type": "application/json",
                "Authorization":partForToken
            },
                body: JSON.stringify(request)
            });

            if (response.ok) {
                window.location.reload();
            }
            else if(response.status === 401) {
                localStorage.removeItem("loginToken");
                localStorage.removeItem("username");
                localStorage.removeItem("companyName");

                window.location.replace("/logIn");
            }
            else
            {
                const message = await response.text();
                if(message.includes(exceptionConstants.WORKING_FROM_OFFICE_NOT_POSSIBLE))
                {
                    setErrorMessage(exceptionConstants.WORKING_FROM_OFFICE_NOT_POSSIBLE);
                }   
            }
        }catch(ex) {
            console.log(ex);
        };

        setShowSpinner(false);
    }

    return (
        <div>
            {showSpinner && <Spinner/>}
            <h3 style={{textAlign: 'center'}}>Add type of work for a day</h3>
            <div className="form-row">
                <div className="col">
                    <label>Type of work</label>
                    <select className="form-control" style={{height:'30px'}} value={typeOfWork} onChange={(ev) => setTypeOfWork(ev.target.value)}>
                        <option value={generalConstants.WFH}>{generalConstants.WFH}</option>
                        <option value={generalConstants.WFO}>{generalConstants.WFO}</option>
                    </select>
                </div>
                    <div className="col">
                    <label>Date:</label>
                    <DatePicker className="form-control" 
                    selected={selectedDate}
                    onChange={date => setSelectedDate(date)}
                    dateFormat='dd/MM/yyyy'
                    filterDate={date => date.getDay() !== 6 && date.getDay() !== 0}
                    />
                </div>
            </div>
            {errorMessage && <label style={{color:"red"}}>{errorMessage}</label>}
            <hr/>
            <div className="divForCenterContent">
                <button className="btn btn-primary"
                 onClick={handleAddTypeOfWork}
                 style={{textAlign:'center', margin:'0', top:'50%'}}
                 >
                    ADD
                </button>
            </div>
            <div className="wrapperHandleAddTypeOfWork">
                <label>Note: You can also change type of work for a day by adding new type of work for a day.</label>
            </div>
            <hr/>
        </div>
    )
}

export default AddTypeOfWork
