import React, {useState} from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import { postRequestWithAuthorization } from '../services/postRequestWithAuthorization';
import * as urlConstants from '../constants/urlConstants';
import * as generalConstants from '../constants/generalConstants';
import './styles/TypeOfWork.css'
import Spinner from '../components/Spinner.js';
import '../App.css'

function TypeOfWorkByCompany() {
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [typeOfWork, setTypeOfWork] = useState(null);
    const [showSpinner, setShowSpinner] = useState(false);

    async function handleSearchTypeOfWorkByCompany() {
        setShowSpinner(true);
        const request = {
            date : selectedDate
        };
        const companyName = localStorage.getItem("companyName");

        if(companyName != null && companyName != undefined)
        {
            const url = urlConstants.BASE_URL + urlConstants.GET_TYPE_OF_WORK_BY_COMPANY_AND_DATE + companyName;

            const {response, exception} = await postRequestWithAuthorization(request, url);

            if(exception === null)
            {
                setTypeOfWork(response);
            }
        }
        else
        {
            window.location.replace("/");
        }
        setShowSpinner(false);
    }

    let typeOfWorkWFH = null;
    let typeOfWorkWFO = null;
    if (typeOfWork != null)
    {
        typeOfWorkWFO = typeOfWork.filter(t => t.typeOfWork === generalConstants.WFO);
        typeOfWorkWFH = typeOfWork.filter(t => t.typeOfWork === generalConstants.WFH);
        console.log(typeOfWorkWFO);
    }

    return (
        <div>
            {showSpinner && <Spinner/>}
            <label>Here you can see who is working from office, and who is working from home</label>
            <div class="form-group">
                    <label>Select the date:</label>

                    <DatePicker className="form-control" 
                    selected={selectedDate}
                    onChange={date => setSelectedDate(date)}
                    dateFormat='dd/MM/yyyy'
                    filterDate={date => date.getDay() !== 6 && date.getDay() !== 0}
                    />

                    <hr/>

                    <div className="divForCenterContent">
                        <button className="btn btn-primary" onClick={handleSearchTypeOfWorkByCompany}>Search</button>
                    </div>
            </div>

            <div className = "WFHWFOTableDiv">
                <table className="table" style={{width:"50%"}}>
                    <thead className="thead-dark">
                        <tr>
                            <th scope="col">WFO</th>
                        </tr>
                    </thead>
                    <tbody>
                        {typeOfWorkWFO != null && typeOfWorkWFO.map(t => {
                            return (
                                <tr id={t.staffUsername}>
                                    <td>{t.staffUsername}</td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>
                <table className="table" style={{width:"50%"}}>
                    <thead className="thead-dark">
                        <tr>
                            <th scope="col">WFH</th>
                        </tr>
                    </thead>
                    <tbody>
                        {typeOfWorkWFH !== null && typeOfWorkWFH.map(t => {
                            return (
                                <tr id={t.staffUsername}>
                                    <td>{t.staffUsername}</td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>              
            </div>
        </div>
    )
}

export default TypeOfWorkByCompany
