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

function Profile({setAmILoggedIn}) {
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
        <div>
            <EditProfile open = {openEditDialog} handleClose = {handleClose} staff = {staff}/>
        <div class="containerProfile">
    <div class="main-body">
    
          <div class="row gutters-sm">
            <div class="col-md-4 mb-3">
              <div class="card">
                <div class="card-body">
                  <div class="d-flex flex-column align-items-center text-center">
                    <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Admin" class="rounded-circle" style={{width:"150"}}/>
                    <div class="mt-3">
                      <h4>{staff.username}</h4>
                      {staff.position && <p class="text-secondary mb-1">{staff.position}</p>}
                      <button class="btn btn-primary" onClick={handleEditClick}>Edit</button>
                    </div>
                  </div>
                </div>
              </div>
              {/*<div class="card mt-3">
                <ul class="list-group list-group-flush">
                  <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                    <h6 class="mb-0"><svg xmlns="http://www.w3.org/2000/svg" style={{width:"24", height:"24",viewBox:"0 0 24 24",fill:"none",stroke:"currentColor",strokeWidth:"2",strokeLinecap:"round",strokeLinejoin:"round"}} class="feather feather-globe mr-2 icon-inline"/>Website</h6>
                    <span class="text-secondary">https://bootdey.com</span>
                  </li>
                </ul>
              </div>*/}
            </div>
            <div class="col-md-8">
              <div class="card mb-3">
                <div class="card-body">
                  <div class="row">
                    <div class="col-sm-3">
                      <h6 class="mb-0">First name:</h6>
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
                      <h6 class="mb-0">Last name:</h6>
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
                      {staff.dateOfBirth != null ? generalHelpers.DateTimeToDateText(staff.dateOfBirth) : 
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
{/*
              <div class="row gutters-sm">
                <div class="col-sm-6 mb-3">
                  <div class="card h-100">
                    <div class="card-body">
                      <h6 class="d-flex align-items-center mb-3"><i class="material-icons text-info mr-2">assignment</i>Project Status</h6>
                      <small>One Page</small>
                      <div class="progress mb-3" style={{height: "5px"}}>
                        <div class="progress-bar bg-primary" role="progressbar" style={{width: "89%",ariaValuenow:"89",ariaValuemin:"0",ariaValuemax:"100"}}></div>
                      </div>
                      <small>Mobile Template</small>
                    </div>
                  </div>
                </div>
                <div class="col-sm-6 mb-3">
                  <div class="card h-100">
                    <div class="card-body">
                      
                      <small>One Page</small>
                      <div class="progress mb-3" style={{height: "5px"}}>
                      <div class="progress-bar bg-primary" role="progressbar" style={{width: "89%",ariaValuenow:"89",ariaValuemin:"0",ariaValuemax:"100"}}></div>
                      </div>
                      <small>Mobile Template</small>
                    </div>
                  </div>
                </div>
              </div>
*/}

            </div>
          </div>

        </div>
    </div>
    </div>
    )
}

export default Profile
