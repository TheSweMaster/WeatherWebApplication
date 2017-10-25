// Website JavaScript code here.

window.onload = function () {
    //GetCurrentWeather();
};

var x = document.getElementById("demo");
function GetLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    x.innerHTML = "Latitude: " + position.coords.latitude +
        "<br>Longitude: " + position.coords.longitude;
}

function GetCurrentWeather() {
    resultDiv = $("#weatherResult");
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(returnPosition);
    } else {
        resultDiv.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function returnPosition(position) {

    var lat = position.coords.latitude;
    var long = position.coords.longitude;

    $.ajax({
        url: '/Weather/GetCurrentWeatherByLatLongFromAjax',
        method: 'GET',
        data: {
            latitude: lat,
            longitude: long
        }
    })
        .done(function (result) {
            $("#weatherResult").html(result);
        })

        .fail(function (xhr, status, error) {
            if (xhr.status === 400) {
                alert(xhr.responseText);
            } else {
                alert("Unknown error!");
            }
        });
}
