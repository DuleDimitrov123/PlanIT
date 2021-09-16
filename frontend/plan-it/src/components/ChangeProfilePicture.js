import React, {useState} from 'react'
import FileBase64 from 'react-file-base64';
import * as urlConstants from '../constants/urlConstants.js';
import {postRequestWithAuthorizationWithoutResponse} from '../services/postRequestWithAuthorizationWithoutResponse';

function ChangeProfilePicture() {
    const changeProfilePictureMessage = 'Change profile picture';
    const closeChangeProfilePictureMessage = 'Close';

    const [buttonMessage, setButtonMessage] = useState(changeProfilePictureMessage);
    const [profilePicture, setProfilePicture] = useState(null);

    const handleOnDoneProfilePicture = (file) => {
        setProfilePicture(file);

        alert("Added profile picture");
        console.log(profilePicture);
    };

    function handleToggleButtonClick() {
        console.log(buttonMessage);
        if(buttonMessage === closeChangeProfilePictureMessage)
        {
            setButtonMessage(changeProfilePictureMessage);
        }
        else
        {
            setButtonMessage(closeChangeProfilePictureMessage);
        }
    };

    async function handleChangeProfilePicture(){
        const url = urlConstants.BASE_URL + urlConstants.ADD_PROFILE_PICTURE;

        const request = {
            staffUsername : localStorage.getItem("username"),
            content : profilePicture.base64
        };

        const {response, exception} = await postRequestWithAuthorizationWithoutResponse(request, url);
    };

    return (
        <div>
            <button className="btn btn-primary" onClick={handleToggleButtonClick}>{buttonMessage}</button>
            {
                buttonMessage === closeChangeProfilePictureMessage &&
                    <div>
                        <br/>
                        <FileBase64
                            muliple = {false}
                            onDone = {handleOnDoneProfilePicture.bind(this)}
                        />
                        <br/>
                        <button className="btn btn-primary" onClick={handleChangeProfilePicture}>Change profile picture</button>        
                    </div>
                    
            }
            {profilePicture !== null &&
                <img src={`${profilePicture.base64}`} />
            }
        </div>
    )
}

export default ChangeProfilePicture
