
var uri = 'api/listings';

$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            $('#listings').text(data);
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem(item) }).appendTo($('#listings'));
            });
        });

    $('#getinfo').on('click', function () {
        var id = $('#id').val();
        $.getJSON("/api/listings/" + id)
      .done(function (data) {
          $('#listings').text(data);
          $('#listingId').text(data.ListingId);
          $('#price').text(data.Price);
          $('#size').text(data.Size);
          $('#color').text(data.Color);
          // On success, 'data' contains a list of products.
          $.each(data, function (key, item) {
              // Add a list item for the product.
              $('<li>', { text: formatItem(item) }).appendTo($('#listings'));
          });
      });
    });
    
});

function formatItem(item) {
    return item.Name + ': $' + item.Price;
}

function find() {
    var id = $('#prodId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#product').text(formatItem(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#product').text('Error: ' + err);
        });
}