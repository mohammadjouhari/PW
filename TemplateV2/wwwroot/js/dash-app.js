$(document).ready(function() {
    M.AutoInit();
    AOS.init({
        duration: 900,
        once: true,
        mirror: true
    });
    $('.btn, .btn-flat, .btn-floating').addClass('waves-effect');
    $("a").on('click', function(event) {
    if (this.hash !== "") {
        event.preventDefault();
        var hash = this.hash;
        if (hash == "#" || hash == "#intro" || hash == "#biography" || hash == "#technology" || hash == "#endoscope" || hash == "#surgeries" || hash == "#vlogs" || hash == "#blogs" || hash == "#reviews" || hash == "#team" || hash == "#contact") {
            // Smooth animation JQ
            $('html, body').animate({
            scrollTop: $(hash).offset().top - 50
            }, 850, function(){
    
            });
        }
        window.location.hash = hash;
    }
    });
    window.addEventListener('scroll', scrolling);
    function scrolling(){
        var st = $(this).scrollTop();
        if (st > 50){
            $('header').addClass('showLogo')
        } else {
            $('header').removeClass('showLogo')
        }
        if (st > 50){
            $('header').addClass('bg')
        } else {
            $('header').removeClass('bg')
        }
    }
});

