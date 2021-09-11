export async function postRequestWithAuthorization(request, url) {
        let partForToken = '';
        const token = localStorage.getItem("loginToken");
        if(token!=null && token!=undefined)
        {
            partForToken = "Bearer "+ token;
        }
        let exception = null;
        const response = await fetch(url, {
            method: "POST",
            headers: { "Content-Type": "application/json",
            "Authorization":partForToken
         },
            body: JSON.stringify(request)
        }).then(p => {
            if (p.ok) {
                console.log(p);
                return p.json()
            }
            else if(p.status === 401) {
                localStorage.removeItem("loginToken");
                localStorage.removeItem("username");
                localStorage.removeItem("companyName");

                exception = "Unauthorized";
                window.location.replace("/logIn");
            }
            else
            {
                exception = p;
            }
        }).catch(e => {
            exception = e;
        });

    return {response, exception};
}
