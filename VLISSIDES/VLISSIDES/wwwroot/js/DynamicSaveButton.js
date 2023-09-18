function enableButton(itemId) {
    button = document.getElementById("saveButton " + itemId);
    button.disabled = false;
}

function disableButton(itemId) {
    button = document.getElementById("saveButton " + itemId);
    button.disabled = true;

}