$(document).ready(function () {
    M.AutoInit();
    AOS.init({
        duration: 900,
        once: true,
        mirror: true
    });
    $(".owl-intro").owlCarousel({
      loop:true,
      nav: true,
      dots: true,
      items: 1,
      autoplay:true,
      autoplayTimeout:2500,
      onInitialized: counter,
      onChanged: counter,
    });
    function counter(event) {
      if (!event.namespace) {
        return;
      }
      var slides = event.relatedTarget;
      var l = slides.items().length;
      var c = slides.relative(slides.current());
      c++;
      if (c < 10) {
        c = '0' + c;
      }
      if (l < 10) {
        l = '0' + l;
      }
      $('.owl-counter').html('<small>' + l + ' |</small> ' + c);
    }
    $('.owl-events').owlCarousel({
      loop: true,
      margin: 5,
      nav: true,
      dot: false,
      navText: [
        "<i class='fa fa-chevron-left'></i>",
        "<i class='fa fa-chevron-right'></i>"
      ],
      autoplay: true,
      autoplayHoverPause: true,
      responsive: {
        0: {
          items: 2
        },
        600: {
          items: 4
        },
        1000: {
          items: 6
        },
        1200: {
          items: 8
        }
      }
    })
    $('.owl-clients').owlCarousel({
      loop: true,
      margin: 32,
      nav: true,
      dot: false,
      navText: [
        "<i class='fa fa-chevron-left'></i>",
        "<i class='fa fa-chevron-right'></i>"
      ],
      autoplay: true,
      autoplayHoverPause: true,
      responsive: {
        0: {
          items: 2
        },
        600: {
          items: 3
        },
        1000: {
          items: 4
        },
        1200: {
          items: 5
        }
      }
    })
    $('.btn, .btn-flat, .btn-floating').addClass('waves-effect');
});

