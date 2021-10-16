import React, {useState} from 'react';
import useFetch from '../../services/useFetch';
import * as urlConstants from '../../constants/urlConstants.js';
import Spinner from '../Spinner';
import Error from '../Error';
import * as generalHelpers from '../../services/generalHelpers.js';


function MyBreakfasts({handleWasAnError}) {
    const username = localStorage.getItem("username");

    const {data:breakfasts, loading:loading, error:error} = useFetch(urlConstants.GET_BREAKFAST_FOR_USER + username);

    if (error) 
    {
        handleWasAnError();
    }
    
    if (loading) return <Spinner/>

    return (
        <div>
            <br/>
            <table className="table table-bordered">
                <thead className="thead-dark">
                    <tr>
                        <th scope="col">Date</th>
                        <th scope="col">Breakfast</th>
                    </tr>
                </thead>
                <tbody>
                    {breakfasts !== null && breakfasts.map(b => {
                        return(
                            <tr>
                                <th>{generalHelpers.LocalDateToDateString(b.date)}</th>
                                <td>{generalHelpers.makeTextFromListOfBreakfasts(b.breakfastItems)}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </table>
        </div>
    )
}

export default MyBreakfasts
