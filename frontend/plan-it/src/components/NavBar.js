import React, {useState, useEffect} from 'react'
import { Navbar, Container, Nav, NavDropdown } from 'react-bootstrap';
import { Link } from "react-router-dom";
import * as generalHelpers from '../services/generalHelpers.js';

function NavBar({amILoggedIn}) {
    const handleLogOut = () => {
        generalHelpers.LogOut();   
        window.location.replace('/');
    }

    return (
        <Navbar bg="light" expand="lg">
            <Container>
                <Navbar.Brand>
                    <Link to="/">
                        PlanIT
                    </Link>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
{/*                        <Nav.Link>
                            <Link to="/companies">
                                Companies
                            </Link>
                        </Nav.Link>
*/}
                    <Nav.Link>
                        <Link to="/typeOfWork">
                            Type of work
                        </Link>
                    </Nav.Link>

                    <Nav.Link>
                        <Link to="/breakfast">
                            Breakfast
                        </Link>
                    </Nav.Link>

                    <Nav.Link>
                        <Link to="/meeting-room">
                            Meeting room
                        </Link>
                    </Nav.Link>

                    {amILoggedIn && 
                        <Nav.Link>
                            <Link to={`/profile/${localStorage.getItem('username')}`}>
                                My profile
                            </Link>
                        </Nav.Link>
                    }

                    {amILoggedIn && 
                        <Nav.Link>
                            <button onClick={handleLogOut} className="btn btn-light" >
                                Log out
                            </button>
                        </Nav.Link>
                    }
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}

export default NavBar
