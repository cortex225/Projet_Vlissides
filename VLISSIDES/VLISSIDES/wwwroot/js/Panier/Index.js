function changerPrixDon() {
    cbDonEco = document.getElementById("cbDonEco");
    fieldDonEco = document.getElementById("prixDonEco");
    prixTotal = document.getElementById("prixTotal");

    if (cbDonEco.checked) {
        fieldDonEco.innerText = "+5$";
        prixTotal.innerText = (parseFloat((prixTotal.innerText).replace(',', '.')) + 5.0).toFixed(2).toString().replace('.', ',');

    } else {
        fieldDonEco.innerText = "";
        prixTotal.innerText = (parseFloat((prixTotal.innerText).replace(',', '.')) - 5.0).toFixed(2).toString().replace('.', ',');
    }
}