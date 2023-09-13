function saveQuantite(id="", quantite=0) {
    fetch(`ModifierLivreQuantite?id=${id}&quantite=${document.getElementById(id + ' quantite').value}`, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).catch(error => console.error('Échec du fetch pour modifier la quantité de livre', error));

}