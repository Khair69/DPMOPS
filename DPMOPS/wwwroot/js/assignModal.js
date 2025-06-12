function loadAssignModal(serviceRequestId) {
    document.getElementById("assignFrame").src = `/ServiceRequest/AssignEmployee/${serviceRequestId}?_=${new Date().getTime()}`;
}
function closeAssignModalAndRefresh() {
    const modal = bootstrap.Modal.getInstance(document.getElementById("assignModal"));
    modal.hide();
    window.location.href = window.location.pathname + window.location.search;
}