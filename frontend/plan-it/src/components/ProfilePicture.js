import React, {useState} from 'react'
import * as urlConstants from '../constants/urlConstants.js';
import useFetch from '../services/useFetch';

function ProfilePicture() {
    const {data:profilePicture, loading:loading, error:error} = useFetch(urlConstants.GET_PROFILE_PICTURE + localStorage.getItem("username"));
    return (
        <div>
            {
                profilePicture === null || profilePicture.content === null
                ?
                    /*<img src="/pictures/avatar.png" alt="Profile picture" class="rounded-circle" style={{width:"100"}}/> */
                    <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Profile picture" class="rounded-circle" style={{width:"150"}}/>
                :
                <img src={`${profilePicture.content}`} alt="Profile picture" class="rounded-circle" style={{width:"100"}}/>
            }
        </div>
    )
}

export default ProfilePicture
