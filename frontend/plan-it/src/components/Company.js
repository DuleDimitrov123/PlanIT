import React from 'react'

import { useParams, Link } from "react-router-dom";
import Spinner from '../components/Spinner.js';
import useFetch from '../services/useFetch.js';
import * as urlConstants from '../constants/urlConstants'
import StaffByCompany from './StaffByCompany.js';

function Company() {
    const { companyName } = useParams();
    const { data: company, loading: loading, error: error } = useFetch(urlConstants.COMPANIES_BY_NAME + companyName);

    if (error) throw error;
    if (loading) return <Spinner />

    return (
        <div class="card mb-4">
            <div>
                <h2>{company.companyName}</h2>
            </div>
            <div class="card-body">
                <table class="table user-view-table m-0">
                    <tbody>
                        <tr>
                            <td>Country:</td>
                            <td>{company.country}</td>
                        </tr>
                        <tr>
                            <td>City:</td>
                            <td>{company.city}</td>
                        </tr>
                        <tr>
                            <td>Address:</td>
                            <td>{company.address}</td>
                        </tr>
                        <tr>
                            <td>Description:</td>
                            <td>{company.description}</td>
                        </tr>
                        <tr>
                            <td>Number of workplaces:</td>
                            <td>{company.numberOfWorkplaces}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div>
                <h3>Staff:</h3>
                <StaffByCompany companyName={company.companyName} />
            </div>
        </div >
    )
}

export default Company
