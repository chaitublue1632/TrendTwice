
$(document).ready(function () {

    var value = 0
    $(".mainImg").rotate({
        bind:
        {
            click: function () {
                value += 90;
                $(this).rotate({ animateTo: value })
            }
        }
    });

    $('.thumbnailImg').hover( function () {
            $('.mainImg').attr('src', $(this).attr('src'));
     });

    //$('.mainImg').hover(function () {
    //    $('.mainImg')
    //      .wrap('<span class="mainImg" style="display:inline-block"></span>')
    //      .css('display', 'block')
    //      .parent()
    //      .zoom({ url: $('.mainImg').attr('src') });
    //});

});