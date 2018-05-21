$(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) $('#goTop').fadeIn();
        else $('#goTop').fadeOut();
    });
    $('#goTop').click(function () {
        $('body,html').animate({ scrollTop: 0 }, 'slow');
    });
});

$(window).load(function () {

    $("#flexiselDemo2").flexisel({
        visibleItems: 3,
        itemsToScroll: 1,
        autoPlay: {
            enable: true,
            interval: 5000,
            pauseOnHover: true
        }
    });

});

$(window).load(function () {

    $("#flexiselDemo4").flexisel({
        visibleItems: 8,
        itemsToScroll: 1,
        autoPlay: {
            enable: true,
            interval: 5000,
            pauseOnHover: true
        }
    });

});

function removeSpaces(string) {
    return string.split(' ').join('');
}

$(document).ready(function () {
    

   
  
});



$(document).ready(function () {
    $("#tinny1").tinyscrollbar();
    $("#tinny2").tinyscrollbar();
    $("#tinny3").tinyscrollbar();

    $('.slider').hover(function () {
        $('.slider .nbs-flexisel-nav-left').css('color', '#333');
        $('.slider .nbs-flexisel-nav-left').css('border', '#0056A0 1px solid');
        $('.slider .nbs-flexisel-nav-right').css('color', '#333');
        $('.slider .nbs-flexisel-nav-right').css('border', '#0056A0 1px solid');
    }, function () {
        $('.slider .nbs-flexisel-nav-left').css('color', '#fff');
        $('.slider .nbs-flexisel-nav-left').css('border', '#fff 0px solid');
        $('.slider .nbs-flexisel-nav-right').css('color', '#fff');
        $('.slider .nbs-flexisel-nav-right').css('border', '#fff 0px solid');
    });
});

$(document).ready(function () {
    $('.slider2').hover(function () {
        $('.slider2 .nbs-flexisel-nav-left').css('color', '#333');
        $('.slider2 .nbs-flexisel-nav-left').css('border', '#0056A0 1px solid');
        $('.slider2 .nbs-flexisel-nav-right').css('color', '#333');
        $('.slider2 .nbs-flexisel-nav-right').css('border', '#0056A0 1px solid');
    }, function () {
        $('.slider2 .nbs-flexisel-nav-left').css('color', '#fff');
        $('.slider2 .nbs-flexisel-nav-left').css('border', '#fff 0px solid');
        $('.slider2 .nbs-flexisel-nav-right').css('color', '#fff');
        $('.slider2 .nbs-flexisel-nav-right').css('border', '#fff 0px solid');
    });
});


$(document).ready(function () {
    $('.nemxam').hover(function () {
        $('.nemxam .nbs-flexisel-nav-left').css('color', '#333');
        $('.nemxam .nbs-flexisel-nav-left').css('border', '#0056A0 1px solid');
        $('.nemxam .nbs-flexisel-nav-right').css('color', '#333');
        $('.nemxam .nbs-flexisel-nav-right').css('border', '#0056A0 1px solid');
        $('.nemxam .nbs-flexisel-nav-left').css('opacity', '1');
        $('.nemxam .nbs-flexisel-nav-right').css('opacity', '1');
    }, function () {
        $('.nemxam .nbs-flexisel-nav-left').css('color', '#fff');
        $('.nemxam .nbs-flexisel-nav-left').css('border', '#fff 0px solid');
        $('.nemxam .nbs-flexisel-nav-right').css('color', '#fff');
        $('.nemxam .nbs-flexisel-nav-right').css('border', '#fff 0px solid');
        $('.nemxam .nbs-flexisel-nav-left').css('opacity', '0');
        $('.nemxam .nbs-flexisel-nav-right').css('opacity', '0');
    });
});


function do_this() {

    var checkboxes = document.getElementsByName('approve[]');
    var button = document.getElementById('toggle');

    if (button.value == 'select') {
        for (var i in checkboxes) {
            checkboxes[i].checked = 'FALSE';
        }
        button.value = 'deselect';
    } else {
        for (var i in checkboxes) {
            checkboxes[i].checked = '';
        }
        button.value = 'select';
    }
}

$(document).ready(function () {
    var showChar = 500;
    var ellipsestext = "...";
    var moretext = "Read more";
    var lesstext = "Less";
    $('.more').each(function () {
        var content = $(this).html();

        if (content.length > showChar) {

            var c = content.substr(0, showChar);
            var h = content.substr(showChar - 1, content.length - showChar);

            var html = c + '<span class="moreelipses">' + ellipsestext + '</span>&nbsp;<span class="morecontent"><span>' + h + '</span>&nbsp;&nbsp;<a href="" class="morelink">' + moretext + '</a></span>';

            $(this).html(html);
        }

    });

    $(".morelink").click(function () {
        if ($(this).hasClass("less")) {
            $(this).removeClass("less");
            $(this).html(moretext);
        } else {
            $(this).addClass("less");
            $(this).html(lesstext);
        }
        $(this).parent().prev().toggle();
        $(this).prev().toggle();
        return false;
    });
});