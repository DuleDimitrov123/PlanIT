import React, { useState } from 'react'
import Spinner from './Spinner'
import useFetch from '../services/useFetch'
import * as urlConstants from '../constants/urlConstants'
import '../App.css'
import { useParams, Link } from "react-router-dom";
import CreateCompany from './CreateCompany'
import Error from './Error'

function Companies() {
    const { data: companies, loading: loading, error: error } = useFetch(urlConstants.COMPANIES);
    const [showSpinner, setShowSpinner] = useState(false);
    let companyName = localStorage.getItem("companyName");
    let userHasCompany = false;

    if(companyName != null && companyName != undefined)
    {
        userHasCompany = true;
    }

    async function handleChoosingCompany(company){
        setShowSpinner(true);
        companyName = company;

        //update on the BE
        const url = urlConstants.BASE_URL + urlConstants.UPDATE_STAFF_BY_USERNAME + localStorage.getItem("username");
        let partForToken = '';
        const token = localStorage.getItem("loginToken");
        if(token!=null && token!=undefined)
        {
            partForToken = "Bearer "+token;
        }

        const request = {
            companyName : companyName
        };

        await fetch(url, {
            method: "PUT",
            headers: { "Content-Type": "application/json",
            "Authorization":partForToken
         },
            body: JSON.stringify(request)
        }).then(p => {
            if (p.ok) {
                console.log("Successfully");
                window.location.replace(`/profile/${localStorage.getItem("username")}`);
            }
        }).catch(ex => {
            console.log(ex);
        })
        setShowSpinner(false);
    }

    //if (error) throw error;
    if (error) return <Error/>
    if (loading) return <Spinner />

    return (
        <div>
            {showSpinner && <Spinner/>}
            <div className="divForCenterContent">
                {!userHasCompany && <label>Please choose a company or create new!</label>}
                <CreateCompany />
            </div>
            <div className="companiesDiv">
                {companies.map(company => {
                    return (
                        <div className="companiesOneCardDiv" key={company.companyName}>
                            <div className="card mt-5 ml-5 mr-5" style={{ width: "18rem", height: "18rem" }}>
                                <div className="card-body">
                                    <h5 className="card-title">{company.companyName}</h5>
                                    {company.description ?
                                        <p className="card-text">{company.description}</p> :
                                        <p className="card-text">{company.companyName}</p>
                                    }
                                    <div>
                                        <Link to={`/companies/${company.companyName}`} className="btn btn-primary">See more</Link>
                                        <button className="btn btn-primary" onClick={() =>handleChoosingCompany(company.companyName)}>Choose company</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    )
                })}
            </div>
        </div>
    )

}

export default Companies
