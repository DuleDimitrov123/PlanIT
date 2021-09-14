import React, {useState} from 'react'
import Spinner from '../Spinner';
import {putRequestWithAuthorizationWithoutResponse} from '../../services/putRequestWithAuthorizationWithoutResponse';
import * as urlConstants from '../../constants/urlConstants';

function MeetingRoomCard({meetingRoom, handleWasAnError}) {
    const [numberOfSeats, setNumberOfSeats] = useState(meetingRoom.numberOfSeats);

    async function handleEditMeetingRoom() {
        const url = urlConstants.BASE_URL + urlConstants.UPDATE_MEETING_ROOM;
        const request = {
            companyName : meetingRoom.companyName,
            meetingRoom : meetingRoom.meetingRoom,
            newNumberOfSeats : numberOfSeats
        };

        const {response, exception} = await putRequestWithAuthorizationWithoutResponse(request, url);

        if(exception !== null)
        {
            handleWasAnError();
        }
    }
    return (
        <div>
            <div class="card-header">Here you can edit meeting room</div>
            <div class="card-body">
                <div style={{display:"flex", flexDirection:"row"}}>
                    <label style={{width:"50%"}}>Company name</label>
                    <input className="form-control" type="text" value={meetingRoom.companyName} disabled/>        
                </div>

                <br/>

                <div style={{display:"flex", flexDirection:"row"}}>
                    <label style={{width:"50%"}}>Meeting room name</label>
                    <input className="form-control" type="text" value={meetingRoom.meetingRoom} disabled/>        
                </div>

                <br/>

                <div style={{display:"flex", flexDirection:"row"}}>
                    <label style={{width:"50%"}}>Number of seats</label>
                    <input className="form-control" type="number" value={numberOfSeats} onChange={(ev) => setNumberOfSeats(ev.target.value)}/>        
                </div>

                <br/>

                <div className="divForCenterContent">
                    <button className="btn btn-secondary" onClick={handleEditMeetingRoom}>CHANGE</button>
                </div>
            </div>
        </div>
    )
}

export default MeetingRoomCard
