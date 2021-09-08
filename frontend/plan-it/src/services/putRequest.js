export async function putRequest(request, url, spinnerFunction = null) {
    console.log(url);
    await fetch(url, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(request)
    }).then(p => {
        if (p.ok) {
            console.log("Successfully");
            if (spinnerFunction) {
                spinnerFunction(false);
            }
        }
    }).catch(ex => {
        console.log(ex);
        if (spinnerFunction) {
            spinnerFunction(false);
        }
    })
}