// Script pour garder l'image rechercher dans le label 

//     $(".custom-file-input").on("change", function () {
//         var fileName = $(this).val().split("\\").pop();
//         $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
//     });
//
//
// $('.datetimepicker').datetimepicker({
//     icons: {
//         time: "fa fa-clock-o",
//         date: "fa fa-calendar",
//         up: "fa fa-chevron-up",
//         down: "fa fa-chevron-down",
//         previous: 'fa fa-chevron-left',
//         next: 'fa fa-chevron-right',
//         today: 'fa fa-screenshot',
//         clear: 'fa fa-trash',
//         close: 'fa fa-remove'
//     }
// });

$(document).ready(function () {
    $(".profile-btn").click(function () {
        $("#UpdatePassword").hide();
        $("#UpdateProfile").fadeIn();
    });

    $(".password-btn").click(function () {
        $("#UpdateProfile").hide();
        $("#UpdatePassword").fadeIn();
    });
});

