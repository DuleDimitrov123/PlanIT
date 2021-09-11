import React, {useState, useEffect} from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import './Breakfast.css'
import * as ulrConstants from '../../constants/urlConstants';
import {postRequestWithAuthorization} from '../../services/postRequestWithAuthorization';
import * as generalHelpers from '../../services/generalHelpers.js';

function BreakfastByCompany() {
    const [date, setDate] = useState(new Date());
    const [breakfasts, setBreakfasts] = useState([]);

    useEffect(async ()=>{
        const url = ulrConstants.BASE_URL + ulrConstants.GET_BREAKFAST_BY_COMPANY_AND_DATE;
        const companyName = localStorage.getItem("companyName");

        const request = {
            companyName : companyName,
            date : date
        };
        console.log(request);
        const {response, exception} = await postRequestWithAuthorization(request, url);

        if(exception === null)
        {
            setBreakfasts(response);
        }
        else
        {
            //TODO: use prop...
        }
    }, [date]);

    return (
        <div>
            <br/>
            <div>
                <div className="divForCenterContent">
                    <p>Select date to see what your colleagues eat </p>                    
                </div>
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
                <br/>
                <br/>
                <table className="table table-bordered">
                <thead className="thead-dark">
                    <tr>
                        <th scope="col">Username</th>
                        <th scope="col">Breakfast</th>
                    </tr>
                </thead>
                <tbody>
                    {breakfasts.map(b => {
                        return(
                            <tr>
                                <td>{b.staffUsername}</td>
                                <td>{generalHelpers.makeTextFromListOfBreakfasts(b.breakfastItems)}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </table>
            </div>
        </div>
    )
}

export default BreakfastByCompany
