// Script pour garder l'image rechercher dans le label

$('.custom-file-input').on('change', function () {
  const fileName = $(this).val().split('\\').pop()
  $(this).siblings('.custom-file-label').addClass('selected').html(fileName)
})
