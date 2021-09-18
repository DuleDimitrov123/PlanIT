import React, {useState} from 'react'
import './styles/Profile.css'
import { Link, useParams } from "react-router-dom"
import useFetch from '../services/useFetch'
import * as urlConstants from '../constants/urlConstants'
import Spinner from './Spinner'
import * as generalHelpers from '../services/generalHelpers'
import EditProfile from './EditProfile'
import Error from './Error'
import jwt_decode from 'jwt-decode'
import '../App.css'
import TypeOfWorkByStaffAndDateToday from './TypeOfWorkByStaffAndDateToday'
import BreakfastByStaffAndDateToday from '../components/breakfast/BreakfastByStaffAndDateToday.js'
import ChangeProfilePicture from './ChangeProfilePicture'
import ProfilePicture from './ProfilePicture'

function Profile2({setAmILoggedIn}) {
    const { username } = useParams();

    const [openEditDialog, setOpenEditDialog] = useState(false);

    const handleEditClick = () =>{
        setOpenEditDialog(true);
    };

    const handleClickOpen = () => {
        setOpenEditDialog(true);
    };

    const handleClose = () => {
        setOpenEditDialog(false);
    };

    const { data: staff, loading: loading, error: error } = useFetch(urlConstants.GET_STAFF_BY_USERNAME + username);

    if (error) return <Error/>;
    if (loading) return <Spinner />

    //check if you should visit this page...
    const token = localStorage.getItem("loginToken");
    const decodedToken = jwt_decode(token);

    console.log(decodedToken);

    if(decodedToken.Username !== username)
    {
      return <Error customMessage={"You can't reach this page!"}/>
    }

    localStorage.setItem("companyName", staff.companyName);

    console.log(staff);

    setAmILoggedIn(true);

    return (
        <div className="mainContainerProfile2">
            <div className="leftContainerProfile2">
                <div>
                    <EditProfile open = {openEditDialog} handleClose = {handleClose} staff = {staff}/>
                    <div class="containerProfile">
                        <div class="main-body">
                            <div class="row gutters-sm">
                                <div class="col-md-4 mb-3">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="d-flex flex-column align-items-center text-center">
                                                 <ProfilePicture/>
                                                <div class="mt-3">
                                                    <h4>{staff.username}</h4>
                                                    {staff.position && <p class="text-secondary mb-1">{staff.position}</p>}
                                                    <button class="btn btn-primary" onClick={handleEditClick}>Edit</button>
                                                    <div>
                                                        <br/>
                                                    </div>
                                                    <ChangeProfilePicture/>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        

            <div className="centerContainerProfile2">
                <div class="col-md-8">
                    <div class="card mb-3">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">First name</h6>
                                    </div>
                                <div class="col-sm-9 text-secondary">
                                {
                                    staff.firstName != null ? staff.firstName : 
                                    <div>
                                        <label>Please edit your info</label>
                                    </div>
                                }
                                </div>
                            </div>
                            <hr/>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Last name</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                {
                                    staff.lastName != null ? staff.lastName : 
                                    <div>
                                        <label>Please edit your info</label>
                                    </div>
                                }
                                </div>
                            </div>
                            <hr/>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Date of birth</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                    {staff.dateOfBirth != null ? new Date(staff.dateOfBirth).toDateString() : 
                                    <div>
                                        <label>Please edit your info</label>
                                    </div>
                                    }
                                </div>
                            </div>
                            <hr/>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Company name</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                {
                                    staff.companyName != null ? staff.companyName : 
                                    <div>
                                        <label>Please choose your company</label>
                                        <Link to={"/companies"} class="btn btn-primary">See companies</Link>
                                    </div>
                                }
                                </div>
                            </div>
                            <hr/>
                            <div class="row">
                                <div class="col-sm-3">
                                    <h6 class="mb-0">Position</h6>
                                </div>
                                <div class="col-sm-9 text-secondary">
                                {
                                    staff.position != null ? staff.position : 
                                    <div>
                                        <label>Please edit your info</label>
                                    </div>
                                }
                                </div>
                            </div>
                            <hr/>
                    </div>
                </div>
            </div>
            </div>

            <div className="rightContainerProfile2">
                    <div class="col-md-8">
                        <div class="card mb-3">
                            <div class="card-body" style={{width:"100%"}}>
                                <TypeOfWorkByStaffAndDateToday/>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="card mb-3">
                            <BreakfastByStaffAndDateToday />
                        </div>
                    </div>
            </div>
        </div>
    )
}

export default Profile2
