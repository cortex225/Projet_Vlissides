// SweetAlert2 pour afficher une notification de succès ou d 'erreur 

// Attache un gestionnaire d'événements de soumission à tous les formulaires sur la page
$('form').submit(function (e) {
    e.preventDefault();  // Empêche la soumission par défaut du formulaire
    $.ajax({    // Obtient l'URL d'action du formulaire
        url: $(this).attr('action'),
        type: 'POST',
        data: $(this).serialize(),    // Sérialise les données du formulaire pour les envoyer dans la requête
        success: function (result) {
            Swal.fire({
                icon: 'success',
                title: result,
                showConfirmButton: false,
                timer: 3000
            }).then((result) => {
                window.location.href = '@Url.Action("Login", "Compte")';
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'error',
                title: 'Une erreur s\'est produite',
                text: xhr.responseText
            });
        }
    });
});
