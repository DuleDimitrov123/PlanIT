import { useState, useEffect } from "react";
import * as urlConstants from '../constants/urlConstants'

export default function useFetch(url) {
    const [data, setData] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function init() {
            try {
                const response = await fetch(urlConstants.BASE_URL + url);
                if (response.ok) {
                    const json = await response.json();
                    setData(json);
                } else {
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
