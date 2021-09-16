import React, {useState} from 'react'
import Error from '../Error';
import './MeetingRoom.css'
import * as generalHelpers from '../../services/generalHelpers'
import AddMeetingRoom from './AddMeetingRoom';
import MeetingRoomByCompany from './MeetingRoomByCompany';
import Spinner from '../Spinner';
import * as urlConstants from '../../constants/urlConstants';
import useFetch from '../../services/useFetch';
import ReserveMeetingRoom from './ReserveMeetingRoom';
import ReserveAndHistoryMeetingRoom from './ReserveAndHistoryMeetingRoom';

function MeetingRoom() { 
    const username = localStorage.getItem("username");
    const loginToken = localStorage.getItem("loginToken");
    const companyName = localStorage.getItem("companyName");

    const {data:meetingRooms, loading:loading, error:error} = useFetch(urlConstants.GET_MEETING_ROOM_BY_COMPANY + companyName);
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

    if(username === null || username === undefined || 
        loginToken === null || loginToken === undefined || 
        companyName === null || companyName === undefined)
    {
        window.location.replace("/");
    }

    const userCanCreate = generalHelpers.CheckIfLoggerUserCanCreate();

    if(error)
    {
        handleWasAnError();
    }
    if(loading)
    {
        return <Spinner/>
    }

    return (
        <div className="meetingRoomContainerDiv">
            <div className="addMeetingRoomDiv">
                {userCanCreate && <AddMeetingRoom handleWasAnError={handleWasAnError}/>}
            </div>
            <br/>
            <br/>
            <div style={{width:"100%", marginLeft:"40px"}}  className="meetingRoomByCompanyDiv">
                <MeetingRoomByCompany handleWasAnError={handleWasAnError} meetingRooms={meetingRooms}/>
            </div>
            <br/>
            <div className="reserveMeetingRoomContainerDiv">
                <div style={{width:"100%", marginLeft:"40px"}}>
                    {/*<ReserveMeetingRoom meetingRooms={meetingRooms} handleWasAnError={handleWasAnError}/>*/}
                    <ReserveAndHistoryMeetingRoom meetingRooms={meetingRooms} handleWasAnError={handleWasAnError}/>
                </div>
            </div>
        </div>
    )
}

export default MeetingRoom
