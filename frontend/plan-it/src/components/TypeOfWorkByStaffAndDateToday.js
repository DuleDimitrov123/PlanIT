import React, {useEffect, useState} from 'react'
import { postRequestWithAuthorization } from '../services/postRequestWithAuthorization.js'
import * as urlConstants from '../constants/urlConstants';
import { Link } from 'react-router-dom';

function TypeOfWorkByStaffAndDateToday() {
    const [date, setDate] = useState(new Date());
    const [typeOfWork, setTypeOfWork] = useState(null);

    useEffect(async()=>{
        const url = urlConstants.BASE_URL + urlConstants.GET_TYPE_OF_WORK_BY_STAFF_AND_DATE + localStorage.getItem("username");

        const request = {
            date : date
        };

        const {response, exception} = await postRequestWithAuthorization(request, url);

        if(exception === null)
        {
            setTypeOfWork(response.typeOfWork);
        }
    }, [date]);

    return (
        <div className="row">
            <div className="col">
                <p>Type of work for today:</p>
            </div>
            <div className="col">
                <div>
                    {typeOfWork === null ?
                        <div>
                            <p>You haven't chosen your type of work for today. Please visit Type of work page.</p>
                                <Link to="/typeOfWork" className="btn btn-primary">Type of work</Link>
                        </div>
                        :
                        typeOfWork
                    }
                </div>
            </div>
        </div>
    )
}

export default TypeOfWorkByStaffAndDateToday
