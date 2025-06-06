//document.addEventListener("DOMContentLoaded", function () {
//    const citySelect = document.getElementById("citySelect");
//    const mapDiv = document.getElementById("map");

//    if (citySelect && mapDiv) {
//        citySelect.addEventListener("change", function () {
//            const selectedCity = citySelect.value;

//            // Apply desired styles
//            mapDiv.style.height = "400px";
//            mapDiv.style.visibility = "visible";

//            // Apply class
//            mapDiv.className = "my-4";

//            // Placeholder for future logic using selectedCity
//            // You can use `selectedCity` in future logic here
//        });
//    }
//});

var map = L.map('map').setView([35.124180, 36.759390], 8);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; OpenStreetMap contributors'
}).addTo(map);

var marker;

map.on('click', function (e) {
    var lat = e.latlng.lat;
    var lng = e.latlng.lng;

    // Update hidden fields
    document.getElementById('Latitude').value = lat;
    document.getElementById('Longitude').value = lng;

    // Place or move the marker
    if (marker) {
        marker.setLatLng(e.latlng);
    } else {
        marker = L.marker(e.latlng).addTo(map);
    }
});