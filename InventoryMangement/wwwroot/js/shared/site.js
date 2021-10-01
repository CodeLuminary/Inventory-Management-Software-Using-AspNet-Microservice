// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const loginUser = () => {
    let credential = {};
    credential.userName = "victor2"
    credential.password = "12345";
    ajaxApi(credential);
}
function ajaxApi(jsonObject) {
    let xhhtp = new XMLHttpRequest();
    xhhtp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            let jsonResponse = JSON.parse(xhhtp.responseText);
            if (typeof jsonResponse === 'string') {//Check to see if the jsonResponse variable is still a string and not an object
                jsonResponse = JSON.parse(jsonResponse)
                //Get response here
            }
        }
    }
    xhhtp.open("POST", 'http://localhost:9694/api/user/authenticate', true);
    xhhtp.setRequestHeader("Content-type", "application/json");
    xhhtp.send(JSON.stringify(jsonObject));
}

function fetchApi(jsonObject) {
    fetch('/api/zoom', {
        method: 'POST',
        mode: 'no-cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        redirect: 'follow',
        referrerPolicy: 'no-referrer',
        body: JSON.stringify(jsonObject)
    }).then(response => response.json()).then(data => {
        //Get response here
    });
}
