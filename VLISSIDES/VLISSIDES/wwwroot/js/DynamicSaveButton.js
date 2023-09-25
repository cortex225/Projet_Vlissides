allSaveButtons = document.getElementByClassName("saveButton");

function enableButton(itemId) {
    button = document.getElementById("saveButton " + itemId);
    button.style.visibility = 'visible';
}

function disableButton(itemId) {
    button = document.getElementById("saveButton " + itemId);
    button.style.visibility = 'hidden';

}

function hideAllButtons() {
    allSaveButtons.style.visibility = 'hidden';
}