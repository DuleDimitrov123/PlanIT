import React from 'react'
import useFetch from '../services/useFetch'
import * as urlConstants from '../constants/urlConstants'
import Spinner from './Spinner';

function StaffByCompany({ companyName }) {
    const { data: staffByCompany, loading: loading, error: error } = useFetch(urlConstants.GET_STAFF_BY_COMPANY + companyName);

    if (error) throw error;
    if (loading) return <Spinner />

    return (
        <ul class="list-group" >
            {staffByCompany.map(staff => {
                return (
                    <li class="list-group-item">{staff.staffUsername}</li>
                )
            })}
        </ul>
    )
}

export default StaffByCompany
