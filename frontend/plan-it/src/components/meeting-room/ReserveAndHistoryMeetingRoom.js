import React from 'react'
import ReserveMeetingRoom from './ReserveMeetingRoom'
import useFetch from '../../services/useFetch.js';
import * as urlConstants from '../../constants/urlConstants.js';
import Spinner from '../Spinner';
import HistoryReservations from './HistoryReservations';

function ReserveAndHistoryMeetingRoom({meetingRooms, handleWasAnError}) {
    const {data:allReservations, loading:loading, error:error} = useFetch(urlConstants.GET_ALL_RESERVED_MEETING_ROOMS);

    if(loading) return <Spinner/>
    if(error)
    {
        handleWasAnError();
    }
    
    const companyReservations = allReservations.filter(r => r.companyName === localStorage.getItem("companyName"));
    return (
        <div>
            <ul className="nav nav-pills mb-3 divForCenterContent" id="pills-tab" role="tablist">
                <li class="nav-item" role="presentation">
                    <button class="nav-link active" id="pills-reserve-tab" data-bs-toggle="pill" data-bs-target="#pills-reserve" type="button" role="tab" aria-controls="pills-reserve" aria-selected="true">Reserve</button>
                </li>
                <li class="nav-item" role="presentation">
                    <button class="nav-link" id="pills-my-reservations-tab" data-bs-toggle="pill" data-bs-target="#pills-my-reservations" type="button" role="tab" aria-controls="pills-my-reservations" aria-selected="false">All reservations</button>
                </li>
            </ul>

            <div class="tab-content" id="pills-tabContent">
                <div class="tab-pane fade show active" id="pills-reserve" role="tabpanel" aria-labelledby="pills-reserve-tab">
                    <ReserveMeetingRoom meetingRooms={meetingRooms} handleWasAnError={handleWasAnError}/>
                </div>
                <div class="tab-pane fade" id="pills-my-reservations" role="tabpanel" aria-labelledby="pills-my-reservations-tab">
                    <HistoryReservations allReservations={companyReservations} meetingRooms={meetingRooms} handleWasAnError={handleWasAnError} />
                </div>
            </div>
        </div>
    )
}

export default ReserveAndHistoryMeetingRoom
