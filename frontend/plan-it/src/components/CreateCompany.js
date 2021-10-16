import React, { useState } from 'react'
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import Spinner from './Spinner.js'
import { postRequest } from '../services/postRequest.js'
import {postRequestWithAuthorizationWithoutResponse} from '../services/postRequestWithAuthorizationWithoutResponse.js'
import * as urlConstants from '../constants/urlConstants'

function CreateCompany() {
    const [companyName, setCompanyName] = useState("");
    const [country, setCountry] = useState("");
    const [city, setCity] = useState("");
    const [address, setAddress] = useState("");
    const [description, setDescription] = useState("");
    const [numberOfWorkplaces, setNumberOfWorkplaces] = useState(0);
    const [open, setOpen] = useState(false);
    const [showSpinner, setShowSpinner] = useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    async function handleCreateNewCompany() {
        setOpen(false);
        setShowSpinner(true);

        const company = {
            companyName: companyName,
            country: country,
            city: city,
            address: address,
            description: description,
            numberOfWorkplaces: numberOfWorkplaces
        };
        await postRequestWithAuthorizationWithoutResponse(company, urlConstants.BASE_URL + urlConstants.CREATE_COMPANY)

        window.location.reload("/companies");
    };

    return (
        <div>
            {showSpinner && <Spinner />}
            <Button variant="outlined" color="primary" onClick={handleClickOpen}>
                Create new company
            </Button>
            <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
                <DialogTitle id="form-dialog-title">Create new company</DialogTitle>
                <DialogContent>
                    <div class="form-group">
                        <label>Company name:</label>
                        <input class="form-control" placeholder="Enter company name" value={companyName} onChange={(ev) => setCompanyName(ev.target.value)} />
                    </div>
                    <div class="form-group">
                        <label>Country:</label>
                        <input class="form-control" placeholder="Enter country" value={country} onChange={(ev) => setCountry(ev.target.value)} />
                    </div>
                    <div class="form-group">
                        <label>City:</label>
                        <input class="form-control" placeholder="Enter city" value={city} onChange={(ev) => setCity(ev.target.value)} />
                    </div>
                    <div class="form-group">
                        <label>Address:</label>
                        <input class="form-control" placeholder="Enter address" value={address} onChange={(ev) => setAddress(ev.target.value)} />
                    </div>
                    <div class="form-group">
                        <label>Description:</label>
                        <input class="form-control" placeholder="Enter description" value={description} onChange={(ev) => setDescription(ev.target.value)} />
                    </div>
                    <div class="form-group">
                        <label>Number of workplaces:</label>
                        <input class="form-control" type="number" value={numberOfWorkplaces} onChange={(ev) => setNumberOfWorkplaces(ev.target.value)} />
                    </div>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose} color="primary">
                        Cancel
                    </Button>
                    <Button onClick={handleCreateNewCompany} color="primary">
                        Create
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
    /*return (
        <div>
                <div class="form-group">
                    <label>Company name:</label>
                    <input class="form-control" placeholder="Enter company name" />
                </div>
                <div class="form-group">
                    <label>Country:</label>
                    <input class="form-control" placeholder="Enter country" />
                </div>
                <div class="form-group">
                    <label>City:</label>
                    <input class="form-control" placeholder="Enter city" />
                </div>
                <div class="form-group">
                    <label>Address:</label>
                    <input class="form-control" placeholder="Enter address" />
                </div>
                <div class="form-group">
                    <label>Description:</label>
                    <input class="form-control" placeholder="Enter description" />
                </div>
                <div class="form-group">
                    <label>Number of workplaces:</label>
                    <input class="form-control" type="number" />
                </div>
                <button type="submit" class="btn btn-primary">Submit</button>
            </div>
            )*/
}

export default CreateCompany
