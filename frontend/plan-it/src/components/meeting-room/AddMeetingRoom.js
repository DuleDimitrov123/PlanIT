import React, {useState} from 'react'
import * as urlConstants from '../../constants/urlConstants';
import Spinner from '../Spinner';
import {postRequestWithAuthorizationWithoutResponse} from '../../services/postRequestWithAuthorizationWithoutResponse.js';

function AddMeetingRoom({handleWasAnError}) {
    const [meetingRoomName, setMeetingRoomName] = useState(null);
    const [numberOfSeats, setNumberOfSeats] = useState(0);
    const [showSpinner, setShowSpinner] = useState(false);

    async function handleAddNewMeetingRoom() {
        setShowSpinner(true);

        const url = urlConstants.BASE_URL + urlConstants.ADD_NEW_MEETING_ROOM;
        const companyName = localStorage.getItem("companyName");
        const request = {
            companyName : companyName,
            meetingRoom : meetingRoomName,
            numberOfSeats : numberOfSeats
        };

        const {response, exception} = await postRequestWithAuthorizationWithoutResponse(request, url);

        setShowSpinner(false);

        if(exception !== null)
        {
            handleWasAnError();
        }
        else
        {
            window.location.reload("/meeting-room");
        }
    };

    return (
        <div>
            {showSpinner && <Spinner/>}
            <div>
                <div className="divForCenterContent">
                    <label>You can add some new meeting rooms</label>
                </div>
                <br/>
                <div className="form-row">
                    <div className="col" style={{paddingRight:"100px", paddingLeft:"100px"}}>
                        <input type="text" className="form-control" 
                            placeholder="Enter new meeting room name" 
                            value={meetingRoomName} 
                            onChange={(ev) => setMeetingRoomName(ev.target.value)}
                        />
                    </div>

                    <div className="col" style={{paddingRight:"100px"}}>
                        <input type="number" className="form-control" 
                            value={numberOfSeats}
                            onChange={(ev) => setNumberOfSeats(ev.target.value)}
                        />
                    </div>

                    <div className="col" style={{paddingRight:"100px"}}>
                        <button className="btn btn-primary" onClick={handleAddNewMeetingRoom}>ADD NEW MEETING ROOM</button>
                    </div>    
                </div>
            </div>
        </div>
    )
}

export default AddMeetingRoom
