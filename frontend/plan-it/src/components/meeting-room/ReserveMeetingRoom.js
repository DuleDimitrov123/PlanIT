import React, {useState} from 'react';
import '../../App.css';
import TimePicker from 'react-time-picker';
import { Calendar, momentLocalizer } from 'react-big-calendar'
import moment from 'moment'
import 'react-big-calendar/lib/css/react-big-calendar.css';
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'
import DateTimePicker from 'react-datetime-picker';
import 'react-datetime-picker/dist/DateTimePicker.css';
import {postRequestWithAuthorizationWithoutResponse} from '../../services/postRequestWithAuthorizationWithoutResponse.js'
import * as urlConstants from '../../constants/urlConstants.js';
import * as exceptionConstants from '../../constants/exceptionConstants';
import {DateTimePickerComponent} from '@syncfusion/ej2-react-calendars';
import UTCDateTimePicker from '../UTCDateTimePicker';

function ReserveMeetingRoom({meetingRooms, handleWasAnError}) {
    const [selectedMeetingRoom, setSelectedMeetingRoom] = useState(meetingRooms !== null && meetingRooms.length !== 0 ? meetingRooms[0].meetingRoom : null);
    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());
    const [numberOfSeats, setNumberOfSeats] = useState(0);
    const [errorMessage, setErrorMessage] = useState(null);

    async function  handleReserve() {
        const url = urlConstants.BASE_URL + urlConstants.RESERVE_MEETING_ROOM;
        const companyName = localStorage.getItem("companyName");
        const username = localStorage.getItem("username");
        const request = {
            meetingRoom : selectedMeetingRoom,
            companyName : companyName,
            startDateTime : startDate,
            endDateTime : endDate,
            staffUsernameWhoReserved : username,
            numberOfSeatsUsed : numberOfSeats
        };

        console.log(request);

        const {response, exception} = await postRequestWithAuthorizationWithoutResponse(request, url);

        if(exception !== null)
        {
            try
            {
                const error = await exception.text();
                if(error.includes(exceptionConstants.IT_IS_NOT_POSSIBLE_TO_RESERVE_MEETING_ROOM))
                {
                    let tmpMsg = error.split('at')[0];
                    tmpMsg = tmpMsg.replace('System.Exception: ', '');
                    setErrorMessage(tmpMsg);
                }
                else
                {
                    handleWasAnError();
                }
            }
            catch(e){
                handleWasAnError();
            }
        }
        else
        {
            window.location.replace("/meeting-room");
        }
    };

    return(
        <div className="form-group">
            <div>
                <div className="divForCenterContent">
                    <label>Choose meeting room: </label>
                </div>
                {errorMessage !== null && 
                <div className="divForCenterContent">
                    <label style={{color:"red"}}>{errorMessage}</label>
                </div>}
                <div className="divForCenterContent">
                    <select value={selectedMeetingRoom} onChange={(ev) => setSelectedMeetingRoom(ev.target.value)} style={{height:"35px"}}>
                        {meetingRooms!= null && meetingRooms.map(m => {
                            return(
                                <option key={m.meetingRoom}>{m.meetingRoom}</option>
                            )
                        })};
                    </select>
                </div>
            </div>

            <br/>

            <div>
                <div className="divForCenterContent">
                    <label>Choose start date: </label>
                </div>
                <div className="divForCenterContent">
                    <DateTimePicker
                        onChange={setStartDate}
                        value={startDate}
                        
                    />
                </div>
            </div>

            <br/>

            <div>
                <div className="divForCenterContent">
                    <label>Choose end date: </label>
                </div>
                <div className="divForCenterContent">
                    <DateTimePicker
                        onChange={setEndDate}
                        value={endDate}
                    />
                </div>
            </div>

            <br/>

            <div>
                <div className="divForCenterContent">
                    <label>Choose number of seats: </label>
                </div>
                <div className="divForCenterContent">
                    <input type="number" value={numberOfSeats} onChange={(ev) => setNumberOfSeats(ev.target.value)}/>
                </div>
            </div>

            <br/>

            <div className="divForCenterContent">
                <button className="btn btn-primary" onClick={handleReserve}>RESERVE</button>                
            </div>
        </div>
    )
}

export default ReserveMeetingRoom
