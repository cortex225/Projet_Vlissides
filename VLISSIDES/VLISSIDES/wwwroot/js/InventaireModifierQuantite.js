function saveQuantite(id = "") {
    fetch(`ModifierLivreQuantite?id=${id}&quantite=${document.getElementById(id + ' quantite').value}`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).catch(error => console.error('Échec du fetch pour modifier la quantité de livre', error));

}

function SupprimerLivre(id = "") {
    fetch(`Delete?id=${id}`, {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).catch(error => {
        console.error('Échec du fetch pour supprimer le livre', error);
    }).then(() => {
        document.getElementById(`${id}`).remove();
        $('#ModalId').modal('hide'); // Ferme la modale
    });
}


// ModalScript 
function ShowModal($url) {
    $.get($url, function (result) {
        $('.modal-content').html(result);
        $('.modal').modal('show');
    });
}