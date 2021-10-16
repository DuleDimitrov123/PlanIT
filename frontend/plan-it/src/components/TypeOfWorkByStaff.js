import React, {useState} from 'react'
import useFetch from '../services/useFetch'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import Spinner from '../components/Spinner.js';
import '../App.css'
import * as urlConstants from '../constants/urlConstants'
import * as generalConstants from '../constants/generalConstants'
import * as generalHelpers from '../services/generalHelpers'
import Error from './Error';

function TypeOfWorkByStaff() {
    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());
    const [showSpinner, setShowSpinner] = useState(false);

    const { data: typeOfWork, loading: loading, error: error } = useFetch(urlConstants.GET_TYPE_OF_WORK_BY_STAFF + localStorage.getItem("username"));

    if (error) return <Error/>;
    if (loading) return <Spinner />

    const filteredTypeOfWork=[];

    typeOfWork.forEach(t => {
        const tmpDate = new Date(t.date);

        const date = new Date(tmpDate.getFullYear(), tmpDate.getMonth(), tmpDate.getDate());
        const startDateDate = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate());
        const endDateDate = new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate());

        /*console.log("start date: " + startDate.getFullYear() + " " + startDate.getMonth() + " " + startDate.getDate())
        console.log("date: " + date.getFullYear() + " " + date.getMonth() + " " + date.getDate())
        console.log("end date: " + endDate.getFullYear() + " " + endDate.getMonth() + " " + endDate.getDate())

        console.log("start date: " +startDateDate.getTime());
        console.log("date: " +date.getTime());
        console.log("end date: " +endDateDate.getTime());*/

        if(date.getTime() >= startDateDate.getTime() && date.getTime() <= endDateDate.getTime())
        {
            filteredTypeOfWork.push(t);
        }
        
    });

    return (
        <div>
            {showSpinner && <Spinner/>}
            <label>My working history:</label>
            <div className="form-group">
                <div className="startEndDateTypeOfWorkDiv">
                    <div style={{width:"50%"}}>
                        <label>Start date:</label>

                        <DatePicker className="form-control" 
                        selected={startDate}
                        onChange={date => setStartDate(date)}
                        dateFormat='dd/MM/yyyy'
                        filterDate={date => date.getDay() !== 6 && date.getDay() !== 0}
                        />
                    </div>

                    <div style={{width:"50%"}}>
                        <label>End date:</label>

                        <DatePicker className="form-control" 
                        selected={endDate}
                        onChange={date => setEndDate(date)}
                        dateFormat='dd/MM/yyyy'
                        filterDate={date => date.getDay() !== 6 && date.getDay() !== 0}
                        />
                    </div>
                </div>

                <hr/>

                <table className="table">
                    <thead className="thead-dark">
                        <tr>
                            <th>Date</th>
                            <th scope="col">WFO</th>
                            <th scope="col">WFH</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredTypeOfWork != null && filteredTypeOfWork.map(t => {
                            return (
                                <tr>
                                    {/*<th scope="row">{generalHelpers.DateTimeToDateText(t.date)}</th>*/}
                                    <th scope="row">{new Date(t.date).toDateString()}</th>
                                    <td><input type="checkbox" checked={t.typeOfWork ===generalConstants.WFO} disabled={true}/></td>
                                    <td><input type="checkbox" checked={t.typeOfWork ===generalConstants.WFH} disabled={true}/></td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default TypeOfWorkByStaff
