function scroll_to(clicked_link, nav_height) {
    var element_class = clicked_link.attr('href').replace('#', '.');
    var scroll_to = 0;
    if (element_class != '.top-content') {
        element_class += '-container';
        scroll_to = $(element_class).offset().top - nav_height;
    }
    if ($(window).scrollTop() != scroll_to) {
        $('html, body').stop().animate({ scrollTop: scroll_to }, 1000);
    }
}








$(document).ready(function () {               // on document ready



    $('.left').css('pointer-events', 'none');
    $('.left .carousel-control-prev-icon').css('color', 'gray');

    $('#carouselId1').carousel({
        interval: false,
    }).on('slide.bs.carousel', function (e) {
        var itemperslide = data();
        var Totalitems = $('.r .carousel-item').length;


        $('.left').show();
        var $e = $(e.relatedTarget);
        var idx = $e.index();

        if (idx == 0) {
            $('.left').css('pointer-events', 'none');
            $('.left .carousel-control-prev-icon').css('color', 'gray');
        } else {

            $('.left').css('pointer-events', 'auto');
            $('.left .carousel-control-prev-icon').css('color', 'rgb(18 56 245)');
        }
        if ((itemperslide + idx) == Totalitems) {
            $('.right').css('pointer-events', 'none');
            $('.right .carousel-control-next-icon').css('color', 'gray');

        } else {

            $('.right').css('pointer-events', 'auto');
            $('.right .carousel-control-next-icon').css('color', 'rgb(18 56 245)');
        }

    });




    $('.left1').css('pointer-events', 'none');
    $('.left1 .carousel-control-prev-icon').css('color', 'gray');

    $('#carouselId').carousel({
        interval: false,
    }).on('slide.bs.carousel', function (e) {
        var itemperslide = data();
        var Totalitems = $('.s .carousel-item').length;


        $('.left1').show();
        var $e = $(e.relatedTarget);
        var idx = $e.index();

        if (idx == 0) {
            $('.left1').css('pointer-events', 'none');
            $('.left1 .carousel-control-prev-icon').css('color', 'gray');
        } else {

            $('.left1').css('pointer-events', 'auto');
            $('.left1 .carousel-control-prev-icon').css('color', 'rgb(18 56 245)');
        }
        if ((itemperslide + idx) == Totalitems) {
            $('.right1').css('pointer-events', 'none');
            $('.right1 .carousel-control-next-icon').css('color', 'gray');

        } else {

            $('.right1').css('pointer-events', 'auto');
            $('.right1 .carousel-control-next-icon').css('color', 'rgb(18 56 245)');
        }

    });
});


function data() {
    var itemperslide;
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        // some code..

        var width = $("html").width();

        if (width > 991) {
            itemperslide = 4;
            ;
        } else if (width > 767) {
            itemperslide = 3;

        } else {
            itemperslide = 2;

        }
    } else {

        var width = $("html").width();

        if (width > 974) {
            itemperslide = 4;
        } else if (width > 750) {

            itemperslide = 3;
        } else {
            itemperslide = 2;
        }
    }
    return itemperslide;
}