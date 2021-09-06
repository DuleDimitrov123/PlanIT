export async function postRequest(request, url, spinnerFunction = null) {
    let data, errorMessage='';
    try {
        const response = await fetch(url, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(request)
        });
        if(!response.ok)
        {
            errorMessage = await response.text();
        }
        data = await response.json();
    }
    catch (ex) {
        errorMessage = ex;
    }
    console.log(data);
    console.log(errorMessage);
    return {data, errorMessage};
}