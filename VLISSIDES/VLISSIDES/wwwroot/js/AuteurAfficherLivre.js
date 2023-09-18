function afficherAuteurLivres(var id) {
    fetch('/GestionAuteurs/AfficherLivre', {
        method: 'GET',
        data = id
    }).then(function (response) {
        if (!response.ok) {
            throw Error(response);
        } else {
            //btn1.setAttribute("disabled", "");
        }
        return response.text()
    }).then((data) => {
        divListeAuteurLivres.innerHTML = data;
    })
}


