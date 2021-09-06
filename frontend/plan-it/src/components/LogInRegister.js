import './styles/LogInRegister.css'
import React, { useState } from 'react'
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import Spinner from './Spinner.js'
import { postRequest } from '../services/postRequest2.js'
import * as urlConstants from '../constants/urlConstants'
import * as exceptionConstants from '../constants/exceptionConstants.js'


function LogInRegister() {
    const [open, setOpen] = useState(false);
    const [logInUsername, setLogInUsername] = useState("");
    const [logInPassword, setLogInPassword] = useState("");
    const [errorMessageUsernameLogIn, setErrorMessageUsernameLogIn] = useState("");

    const [registerFirstName, setRegisterFirstName] = useState("");
    const [registerLastName, setRegisterLastName] = useState("");
    const [registerUsername, setRegisterUsername] = useState("");
    const [registerPassword, setRegisterPassword] = useState("");
    const [errorMessageUsernameRegister, setErrorMessageUsernameRegister] = useState("");
    const [errorMessageRegister, setErrorMessageRegister] = useState("");


    async function handleLogIn() {
        const logInRequest = {
            username: logInUsername,
            password: logInPassword
        };

        const url = urlConstants.BASE_URL + urlConstants.LOG_IN;
        let errorMessageLong='';
        try {
            const response = await fetch(url, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(logInRequest)
            });
            if(!response.ok)
            {
                errorMessageLong = await response.text();
                if(errorMessageLong.includes(exceptionConstants.INCORRECT_USERNAME_OR_PASSWORD))
                {
                    setErrorMessageUsernameLogIn(exceptionConstants.INCORRECT_USERNAME_OR_PASSWORD);
                }
            }
            else
            {
                const data = await response.json();
                const token = data.token;
                localStorage.setItem("loginToken", token);
                localStorage.setItem("username", logInUsername);
                window.location.replace(`/profile/${logInUsername}`);
            }
        }
        catch (ex) {
        }

        /*const {data:response, errorMessage:errorMessage} = await postRequest(logInRequest, url);
        if(errorMessage!='')
        {
            if(errorMessage.includes(exceptionConstants.INCORRECT_USERNAME_OR_PASSWORD))
            {
                setErrorMessageLogIn(exceptionConstants.INCORRECT_USERNAME_OR_PASSWORD);
            }
        }
        else
        {
            const data = await response.json();
            const token = data.token;
            localStorage.setItem("loginToken", token);
            localStorage.setItem("username", logInUsername);
            window.location.reload();
        }*/


    };

    async function handleRegister(){
        if(registerUsername === "" || registerPassword === "" || registerFirstName === "" || registerLastName === "")
        {
            setErrorMessageRegister("Please fill all fields!");
        }
        else
        {
            setErrorMessageRegister("");
            const registerRequest = {
                username : registerUsername,
                password : registerPassword,
                firstName : registerFirstName,
                lastName : registerLastName,
                canCreate : false
            };

            const url = urlConstants.BASE_URL + urlConstants.REGISTER;

            let errorMessageLong='';
            try {
                const response = await fetch(url, {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify(registerRequest)
                });
                if(!response.ok)
                {
                    errorMessageLong = await response.text();
                    if(errorMessageLong.includes(exceptionConstants.NOT_AVAILABLE_USERNAME))
                    {
                        setErrorMessageUsernameRegister(exceptionConstants.NOT_AVAILABLE_USERNAME);
                    }
                }
                else
                {
                    const data = await response.json();
                    const token = data.token;
                    localStorage.setItem("loginToken", token);
                    localStorage.setItem("username", logInUsername);
                    window.location.replace(`/profile/${registerUsername}`);
                }
            }
            catch (ex) {
            }
        }
    }

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };
    return (
        <div>
            {/*showSpinner && <Spinner />*/}
            <Button variant="outlined" color="primary" onClick={handleClickOpen}>
                Log in
            </Button>
            <Dialog open={open} onClose={handleClose} aria-labelledby="form-dialog-title">
                <DialogContent className="colorOfLogin">
                    <div class="login-box">
                        <div class="login-snip">
                            <input id="tab-1" type="radio" name="tab" class="sign-in"/>
                            <label for="tab-1" class="tab">Login</label>
                            <input id="tab-2" type="radio" name="tab" class="sign-up"/>
                            <label for="tab-2" class="tab">Register</label>
                            <div class="login-space">
                                <div class="login">
                                    <div class="group">
                                        <label for="user" class="label">Username</label>
                                        <input id="user" type="text" class="input" placeholder="Enter your username" value={logInUsername} onChange={(ev) => setLogInUsername(ev.target.value)} />
                                    </div>
                                    <div class="group">
                                        <label for="pass" class="label">Password</label>
                                        <input id="pass" type="password" class="input" data-type="password" placeholder="Enter your password" value={logInPassword} onChange={(ev) => setLogInPassword(ev.target.value)} />
                                    </div>
                                    {errorMessageUsernameLogIn != "" && <label>{errorMessageUsernameLogIn}</label>}
                                    <div class="group">
                                        <button class="button" onClick={handleLogIn}>Log in</button>
                                    </div>
                                </div>
                                <div class="sign-up-form">
                                    <div class="group">
                                        <label class="label">First name</label>
                                        <input type="text" class="input" placeholder="Enter your first name" value={registerFirstName} onChange={(ev) => setRegisterFirstName(ev.target.value)}/>
                                    </div>
                                    <div class="group">
                                        <label class="label">Last name</label>
                                        <input  type="text" class="input" placeholder="Enter your last name" value={registerLastName} onChange={(ev) => setRegisterLastName(ev.target.value)}/>
                                    </div>
                                    <div class="group">
                                        <label class="label">Username</label>
                                        <input type="text" class="input" placeholder="Create your Username" value={registerUsername} onChange={(ev) => setRegisterUsername(ev.target.value)}/>
                                    </div>
                                    {errorMessageUsernameRegister != "" && <label>{errorMessageUsernameRegister}</label>}
                                    <div class="group">
                                        <label class="label">Password</label>
                                        <input type="password" class="input" data-type="password" placeholder="Create your password" value={registerPassword} onChange={(ev) => setRegisterPassword(ev.target.value)}/>
                                    </div>
                                    {/*<div class="group">
                                        <label for="pass" class="label">Repeat Password</label>
                                        <input id="pass" type="password" class="input" data-type="password" placeholder="Repeat your password" />
                                    </div>*/}
                                    {errorMessageRegister != "" && <label>{errorMessageRegister}</label>}
                                    <div class="group">
                                        <button class="button" onClick={handleRegister}>Register</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </DialogContent>
            </Dialog>
        </div >
    )
}

export default LogInRegister
