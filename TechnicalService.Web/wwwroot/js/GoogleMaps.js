let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 41.0055005, lng: 28.7319848 },
        zoom: 8,
    });
}

window.initMap = initMap;