import React from 'react'
import * as urlConstants from '../../constants/urlConstants';
import useFetch from '../../services/useFetch';
import Spinner from '../Spinner';
import MeetingRoomCard from './MeetingRoomCard';

function MeetingRoomByCompany({handleWasAnError, meetingRooms}) {
    const companyName = localStorage.getItem("companyName");
    return (
        <div>
            <div class="row">
                <div class="col-4">
                    <div class="list-group" id="list-tab" role="tablist">
                        {meetingRooms !== null && meetingRooms.map((m, index) => {
                            return (
                                <a className={`list-group-item list-group-item-action ${index===0 && "active"}`} 
                                    id={`list-${companyName}-${m.meetingRoom}-list`} 
                                    data-toggle="list" href={`#list-${companyName}-${m.meetingRoom}`} 
                                    aria-controls={`${companyName}-${m.meetingRoom}`}>
                                {m.meetingRoom}
                                </a>
                            )
                        })}
                        {
                            //example for bootstrap
                            /*<a class="list-group-item list-group-item-action active" id="list-home-list" data-toggle="list" href="#list-home" role="tab" aria-controls="home">Home</a>*/
                        }
                       
                    </div>
                </div>
                <div class="col-8">
                    <div class="tab-content" id="nav-tabContent">
                        {meetingRooms !== null && meetingRooms.map((m, index) => {
                            return (
                                <div className={`tab-pane fade ${index===0 && "show active"}`} id={`list-${companyName}-${m.meetingRoom}`} role="tabpanel" aria-labelledby={`list-${companyName}-${m.meetingRoom}-list`} >
                                    <MeetingRoomCard meetingRoom={m} handleWasAnError={handleWasAnError}/>
                                </div>
                            )
                        })}
                        {
                            //example for bootstrap
                            /*<div class="tab-pane fade show active" id="list-home" role="tabpanel" aria-labelledby="list-home-list">...</div>*/
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}

export default MeetingRoomByCompany
