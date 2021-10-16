import React, {useEffect, useState} from 'react'
import { postRequestWithAuthorization } from '../../services/postRequestWithAuthorization.js'
import * as urlConstants from '../../constants/urlConstants'
import { Link } from 'react-router-dom';

function BreakfastByStaffAndDateToday() {
    const [date, setDate] = useState(new Date());
    const [breakfast, setBreakfasts] = useState(null);

    useEffect(async()=>{
        const url = urlConstants.BASE_URL + urlConstants.GET_BREAKFAST_BY_STAFF_AND_DATE;

        const request = {
            staffUsername : localStorage.getItem("username"),
            date : date
        };

        const {response, exception} = await postRequestWithAuthorization(request, url);

        if(exception === null)
        {
            setBreakfasts(response);
        }
    }, [date]);

    return (
        <div className="row">
            <div className="col">
                <p>Breakfast for today:</p>
            </div>
            <div className="col">
                <div>
                    {breakfast === null  || breakfast.length === 0?
                        <div>
                            <p>You haven't chosen your breakfast for today. Please visit Breakfast page.</p>
                                <Link to="/breakfast" className="btn btn-primary">Breakfast</Link>
                        </div>
                        :
                        <ul>
                            {breakfast.map(b => {
                                return(
                                    <li key={b}>{b}</li>
                                )
                            })}
                        </ul>
                    }
                </div>
            </div>
        </div>
    )
}

export default BreakfastByStaffAndDateToday
