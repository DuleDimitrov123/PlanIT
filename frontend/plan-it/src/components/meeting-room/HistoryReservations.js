import React, {useState} from 'react'
import * as generalHelpers from '../../services/generalHelpers.js';
import * as urlConstants from '../../constants/urlConstants.js';
import {postRequestWithAuthorizationWithoutResponse} from '../../services/postRequestWithAuthorizationWithoutResponse.js';

function HistoryReservations({allReservations, meetingRooms, handleWasAnError}) {
    const [selectedMeetingRoom, setSelectedMeetingRoom] = useState('All meeting rooms');
    const [showAlert, setShowAlert] = useState(false);

    let filteredReservations = allReservations;

    if(selectedMeetingRoom !== 'All meeting rooms')
    {
        filteredReservations = allReservations.filter(r => r.meetingRoom === selectedMeetingRoom);
    }

    async function handleUnreserveMeetingRoom(r) {
        const url = urlConstants.BASE_URL + urlConstants.UNRESERVE_MEETING_ROOM;

        const {response, exception} = await postRequestWithAuthorizationWithoutResponse(r, url);

        if(exception !== null)
        {
            handleWasAnError();
        }
        else
        {
            window.location.reload();
        }
    }

    return (
        <div className="form-group">
            <div>
                <label>Filter by meeting room name: </label>
                <select className="form-control" value={selectedMeetingRoom} onChange={(ev) => setSelectedMeetingRoom(ev.target.value)} style={{height:"35px"}}>
                    <option value={'All meeting rooms'}>All meeting rooms</option>
                    {meetingRooms !== null && meetingRooms.map(m => {
                        return (
                            <option value={m.meetingRoom} key={m.meetingRoom}>{m.meetingRoom}</option>
                        )
                    })}
                </select>
            </div>

            <br/>

            <div>
                <table className="table table-bordered">
                    <thead className="thead-dark">
                        <tr>
                            <th scope="col">Company name</th>
                            <th scope="col">Meeting room</th>
                            <th scope="col">Start</th>
                            <th scope="col">End</th>
                            <th scope="col">Who reserved</th>
                            <th scope="col">Number of seats used</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {filteredReservations.map(r => {
                            return(
                                <tr>
                                    <td>{r.companyName}</td>
                                    <td>{r.meetingRoom}</td>
                                    <td>{generalHelpers.RemoveTAndTimeZoneFromDateTime(r.startDateTime)}</td>
                                    <td>{generalHelpers.RemoveTAndTimeZoneFromDateTime(r.endDateTime)}</td>
                                    <td>{r.staffUsernameWhoReserved}</td>
                                    <td>{r.numberOfSeatsUsed}</td>
                                    <td>
                                        {r.staffUsernameWhoReserved === localStorage.getItem("username")
                                        ? <button 
                                            className="btn btn-secondary" onClick={() => handleUnreserveMeetingRoom(r)}>
                                                DELETE
                                        </button>
                                        : <p>You didn't reserve</p>
                                    }
                                    </td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>
                
            </div>
        </div>
    )
}

export default HistoryReservations
