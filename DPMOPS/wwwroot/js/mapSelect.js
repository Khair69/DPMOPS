let map;
let marker;

const mapModal = document.getElementById('mapModal');
mapModal.addEventListener('shown.bs.modal', function () {
    // If map is not initialized
    if (!map) {
        map = L.map('map').setView([35.124180, 36.759390], 8);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; OpenStreetMap contributors'
        }).addTo(map);

        map.on('click', function (e) {
            const { lat, lng } = e.latlng;

            // Remove old marker if exists
            if (marker) {
                map.removeLayer(marker);
            }

            marker = L.marker([lat, lng]).addTo(map);
            marker.bindPopup("You selected this location").openPopup();

            // Update form inputs
            document.getElementById("latitude").value = lat.toFixed(6);
            document.getElementById("longitude").value = lng.toFixed(6);

            const selectButton = document.getElementById("selectLocation");
            selectButton.innerHTML = selectButton.innerHTML.replace(
                'اختر الموقع على الخريطة',
                'تغيير موقعك على الخريطة'
            );
            selectButton.classList.replace("btn-outline-light", "btn-outline-success");
            
        });
    } else {
        map.invalidateSize();
    }
});
