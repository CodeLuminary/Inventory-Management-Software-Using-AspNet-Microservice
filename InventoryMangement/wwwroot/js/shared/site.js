// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const loginUser = () => {
    let credential = {};
    credential.userName = document.getElementById("email");
    credential.password = document.getElementById("password");
    //ajaxApi(credential);
    fetchApi(credential);
}
function ajaxApi(jsonObject) {
    let xhhtp = new XMLHttpRequest();
    xhhtp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            alert(xhhtp.responseText);
            /*let jsonResponse = JSON.Parse(xhhtp.responseText);
            if (typeof jsonResponse === 'string') {//Check to see if the jsonResponse variable is still a string and not an object
                jsonResponse = JSON.parse(jsonResponse)
                //Get response here
            }*/
        }
    }
    xhhtp.open("POST", 'http://localhost:9694/user/login', true);
    xhhtp.setRequestHeader("Content-Type", "application/json");
    xhhtp.send(JSON.stringify(jsonObject));
}
/*
function ajaxApi(jsonObject, url) {
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
    xhhtp.open("POST", url, true);
    xhhtp.setRequestHeader("Content-type", "application/json");
    xhhtp.send(JSON.stringify(jsonObject));
}*/

function fetchApi(jsonObject) {
    fetch('http://localhost:9694/user/login', {
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(jsonObject)
    }).then(response => {
            response.text();       
    }).then(data => {
        alert(data);
        sessionStorage.setItem("token", data);
    });
}
