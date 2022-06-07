let latitude, longitude = "";

if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(onSuccess, onError);

} else {
    alert("tarayıcınız konum bilgisi alamıyor...");
}

function onSuccess(position) {
    latitude = position.coords.latitude;
    longitude = position.coords.longitude;

    initMap();

    const api_key = "****"
    const url = `https://api.opencagedata.com/geocode/v1/json?q=${latitude}+${longitude}&key=${api_key}`;

    fetch(url)
        .then(response => response.json())
        .then(result => {
            console.log(result);
            let details = result.results[0].formatted;

            /*let { country, postcode, province, neighbourhood, road, town, state, formatted } = details;*/

            document.getElementById("CustomerAdressid").value =
                `${details}`;


        });
}

function onError(error) {
    if (error.code == 1) {
        alert("kullanıcı erişim iznini reddetti.");
    } else if (error.code == 2) {
        alert("konum alınamadı");
    }
    else {
        alert("bir hata oluştu");
    }
}

let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: latitude, lng: longitude },
        zoom: 15,
    });

    const marker = new google.maps.Marker({
        position: { lat: latitude, lng: longitude },
        map: map,
    });
}





