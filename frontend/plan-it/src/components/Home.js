import React from 'react'
import LogInRegister from './LogInRegister';
import '../App.css';

function Home({amILoggedIn}) {
    return (
        <div>
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <div className="divForCenterContent">
                    {!amILoggedIn && <LogInRegister />}
                </div>
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="/pictures/working-from-home-vs-office.jpg" alt="First slide"/>
                        <div className="carousel-caption d-none d-md-block divForCenterContent">
                            <p style={{color:"blue", fontSize:"20px"}}>How do you feel today? Do you want to work from the office, or from home? Please tell your colleagues</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="/pictures/breakfast_at_the_office.jpeg" alt="Second slide"/>
                        <div className="carousel-caption d-none d-md-block divForCenterContent">
                            <p style={{color:"blue", fontSize:"20px"}}>Is it just a breakfast in the office? Choose your breakfast and socialize</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="/pictures/meeting-room.jpg" alt="Third slide"/>
                        <div className="carousel-caption d-none d-md-block divForCenterContent">
                            <p style={{color:"blue", fontSize:"20px"}}>Reserve a meeting room on time</p>
                        </div>
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>
    )
}

export default Home
