function afficherAuteurLivres(id = "") {
    fetch(`GestionAuteurs/AfficherLivre?id=${id}`, {
        method: 'GET'
    }).then(function (response) {
        if (!response.ok) {
            throw Error(response);
        } else {
            //btn1.setAttribute("disabled", "");
        }
        return response.text()
    }).then((data) => {
        divListeAuteurLivres.innerHTML = data;
    });
}

