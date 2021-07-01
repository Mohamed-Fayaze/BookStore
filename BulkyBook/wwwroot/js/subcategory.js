$('#menu ul li').mouseenter(function () {
    // hide all other divs
    $(".dropdown").hide(0);
    // show the div we want
    $(this).children(".dropdown").show(0);
}).mouseleave(function () {
    $(".dropdown").hide(0);
});