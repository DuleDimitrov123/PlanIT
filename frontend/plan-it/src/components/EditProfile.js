import React, {useState} from 'react'
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import Spinner from './Spinner.js'
//@import "../../node_modules/react-moment-datepicker/lib/react-moment-datepicker";
import * as urlConstants from '../constants/urlConstants'




function EditProfile({open, handleClose, staff}) {
    const [firstName, setFirstName] = useState(staff.firstName);
    const [lastName, setLastName] = useState(staff.lastName);

    console.log(staff.dateOfBirth)
    const [dateOfBirth, setDateOfBirth] = useState(new Date(staff.dateOfBirth));
    const [position, setPosition] = useState(staff.position);
    const [showSpinner, setShowSpinner] = useState(false);

    async function handleClickOnSave(){
        setShowSpinner(true);
        const url = urlConstants.BASE_URL + urlConstants.UPDATE_STAFF_BY_USERNAME + staff.username;
        let partForToken = '';
        const token = localStorage.getItem("loginToken");
        if(token!=null && token!=undefined)
        {
            partForToken = "Bearer "+token;
        }

        const request = {
            firstName : firstName,
            lastName : lastName,
            //dateOfBirth : dateOfBirth,
            position : position
        };
        //console.log(request);

        await fetch(url, {
            method: "PUT",
            headers: { "Content-Type": "application/json",
            "Authorization":partForToken
         },
            body: JSON.stringify(request)
        }).then(p => {
            if (p.ok) {
                console.log("Successfully");
                window.location.replace(`/profile/${staff.username}`);
            }
        }).catch(ex => {
            console.log(ex);
        })
        setShowSpinner(false);
    };

    return (
        <div>
            {showSpinner && <Spinner />}
        <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
                <DialogTitle id="form-dialog-title">Edit profile info</DialogTitle>
                <DialogContent>
                    <div class="form-group">
                        <label>First name:</label>
                        <input class="form-control" value={firstName} onChange = {(ev) => setFirstName(ev.target.value)}/>
                    </div>
                    <div class="form-group">
                        <label>Last name:</label>
                        <input class="form-control" value={lastName} onChange = {(ev) => setLastName(ev.target.value)}/>
                    </div>
                    {/*<div class="form-group">
                        <label>DateOfBirth:</label>
                        <MomentDatepicker timezone={moment.} date={dateOfBirth}/>
                    </div>*/}
                    <div class="form-group">
                        <label>Position:</label>
                        <input class="form-control" value={position} onChange = {(ev) => setPosition(ev.target.value)}/>
                    </div>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose} color="primary">
                        Cancel
                    </Button>
                    <Button color="primary" onClick={handleClickOnSave}>
                        Save
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    )
}

export default EditProfile
