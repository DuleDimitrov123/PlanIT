import React, { useState } from 'react'
import Spinner from './Spinner'
import useFetch from '../services/useFetch'
import * as urlConstants from '../constants/urlConstants'
import '../App.css'
import { Link } from "react-router-dom";
import CreateCompany from './CreateCompany'

function Companies() {
    const { data: companies, loading: loading, error: error } = useFetch(urlConstants.COMPANIES);

    if (error) throw error;
    if (loading) return <Spinner />

    return (
        <div>
            <CreateCompany />
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
                                    <Link to={`/companies/${company.companyName}`} className="btn btn-primary">See more</Link>
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
