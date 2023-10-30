function changerPrixDon() {
    cbDonEco = document.getElementById("cbDonEco");
    fieldDonEco = document.getElementById("prixDonEco");
    //prixTotal = document.getElementById("prixTotal");
    //console.log(prixtotal);
    if (cbDonEco.checked) {
        fieldDonEco.innerText = "+5,00$";
        //console.log((parseFloat(prixTotal.innerText.replaceAll(/\s+/g, "").replace(',', '.')) + 5.0).toFixed(2).toLocaleString("fr-CA"));
        prixTotal.innerText = ((parseFloat((prixTotal.innerText).replaceAll(/\s+/g, "").replace(',', '.'))) + 5.0).toFixed(2).toLocaleString("fr-CA");
        //console.log(prixtotal + parseFloat(prixtotal));
        //prixtotal.innerText = (prixtotal + 5.0).toFixed(2).toLocaleString("fr-CA");
    } else {
        fieldDonEco.innerText = "";
        //console.log((parseFloat(prixTotal.innerText.replaceAll(/\s+/g, "").replace(',', '.')) - 5.0).toFixed(2).toLocaleString("fr-CA"));
        prixTotal.innerText = ((parseFloat((prixTotal.innerText).replaceAll(/\s+/g, "").replace(',', '.'))) - 5.0).toFixed(2).toLocaleString("fr-CA");
        //console.log(prixtotal + parseFloat(prixtotal));
        //prixtotal.innerText = (prixtotal + 5.0).toFixed(2).toLocaleString("fr-CA");
    }
}