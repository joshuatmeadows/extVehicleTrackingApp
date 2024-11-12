// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function vehicleTripByVehicle(vehicleId) {
    let data = fetch(`https://localhost:7099/getbyvehicle?vehicleId=${vehicleId}`, {
        headers: {
            'accept': 'text/plain'
        }
    });
}
