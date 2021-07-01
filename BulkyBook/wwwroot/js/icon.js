$(function () {
    //pin scrooler
    $('.left-scroll').click(function (e) {
        e.preventDefault();
        var container = document.getElementById('scroll-div');
        sideScroll(container, 'left', 25, 100, 10);
    });
    $('.right-scroll').click(function (e) {
        e.preventDefault();
        var container = document.getElementById('scroll-div');
        sideScroll(container, 'right', 25, 100, 10);
    })

})


function sideScroll(element, direction, speed, distance, step) {
    scrollAmount = 0;


    var slideTimer = setInterval(function () {
        if (direction == 'left') {
            element.scrollLeft -= step;

        } else {
            element.scrollLeft += step;


        }
        scrollAmount += step;
        if (scrollAmount >= distance) {
            window.clearInterval(slideTimer);
        }


    }, speed);
}

