$(document).ready(function () {
  updateCartCounter()
})

function updateCartCounter () {
  $.ajax({
    url: BASE_URL + '/Panier/NbArticles',
    type: 'GET',
    dataType: 'json',
    success: function (data) {
      $('#nbArticles').html(data).animate({ fontSize: '30px' }, 1000)
    }
  })
}

// Appeler cette fonction chaque fois qu'un article est ajouté ou retiré du panier
function itemChangedInCart () {
  updateCartCounter()
}
