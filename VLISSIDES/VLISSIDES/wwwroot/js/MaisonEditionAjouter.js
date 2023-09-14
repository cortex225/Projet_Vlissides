
function AjouterMaisonEdition(Nom = "")
{
    var form      = ev.target.closest("form");
    var data      = new FormData(form);
    //var jsonData  = JSON.stringify(Object.fromEntries(formData));
    var csrfToken = form.querySelector(­'[name="__RequestVerificationToken"]').value;
    fetch("Ajouter", {
        method: "POST",
        body: data,
        headers: {
            RequestVerificationToken: csrfToken,
        },
    }).then(function (response) {
        if (!response.ok) {
            throw Error(response);
        }
        return response.json();
    });
}