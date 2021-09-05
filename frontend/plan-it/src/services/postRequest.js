export async function postRequest(request, url, spinnerFunction = null) {
    await fetch(url, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(request)
    }).then(p => {
        if (p.ok) {
            //console.log("Successfully");
            if (spinnerFunction) {
                spinnerFunction(false);
            }
        }
    }).catch(ex => {
        //console.log(ex);
        if (spinnerFunction) {
            spinnerFunction(false);
        }
    })
}