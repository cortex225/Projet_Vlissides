divLivres = document.getElementById("divListeAuteurLivres");

function afficherAuteurLivres(id = "") {
    fetch(`GestionAuteurs/AfficherLivre?id=${id}`, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).catch(error => {
        console.error('�chec du fetch pour supprimer le livre', error);
    }).then(function (response) {
        if (!response.ok) {
            throw Error(response);
        } else {
            console.log(response);
        }
        return response.text()
    }).then((data) => {
        console.log(data);
        divLivres.innerHTML = data;
    });
}

