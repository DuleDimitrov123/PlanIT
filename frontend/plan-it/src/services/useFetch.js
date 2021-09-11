import { useState, useEffect } from "react";
import * as urlConstants from '../constants/urlConstants'

export default function useFetch(url) {
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function init() {
            try {
                let partForToken = '';
                const token = localStorage.getItem("loginToken");
                if(token!=null && token!=undefined)
                {
                    partForToken = "Bearer "+token;
                }
                
                const response = await fetch(urlConstants.BASE_URL + url,{
                    method:"GET",
                    headers:{"Content-Type":"application/json",
                    "Authorization":partForToken
                   },
                });
                if (response.ok) {
                    const json = await response.json();
                    setData(json);
                } else if (response.status === 401){
                    localStorage.removeItem("loginToken");
                    localStorage.removeItem("username");
                    localStorage.removeItem("companyName");
    
                    window.location.replace("/logIn");
                }else {
                    throw response;
                }
            } catch (e) {
                setError(e);
                console.log(e);
            } finally {
                setLoading(false);
            }
        }
        init();
    }, [url]);

    return { data, error, loading };
}
