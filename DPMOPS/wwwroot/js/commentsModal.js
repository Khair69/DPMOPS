function loadCommentsModal(serviceRequestId) {
    document.getElementById("commentsFrame").src = `/Comments/Index/${serviceRequestId}?_=${new Date().getTime()}`;
}