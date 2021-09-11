import React from 'react'
import { Navbar, Container, Nav, NavDropdown } from 'react-bootstrap';
import { Link } from "react-router-dom";

function NavBar() {
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
                        <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                            <NavDropdown.Item>Action</NavDropdown.Item>
                            <NavDropdown.Item>Another action</NavDropdown.Item>
                            <NavDropdown.Item>Something</NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item>Separated link</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    )
}

export default NavBar
