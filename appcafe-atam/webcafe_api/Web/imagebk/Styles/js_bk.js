$(document).ready(function () {
    $('a.card-window').click(function () {

        //Getting the variable's value from a link
        var cardBox = $(this).attr('href');

        //Fade in the Popup
        $(cardBox).fadeIn(300);

        //Set the center alignment padding + border see css style
        var popMargTop = ($(cardBox).height() + 24) / 2;
        var popMargLeft = ($(cardBox).width() + 24) / 2;

        $(cardBox).css({
            'margin-top': -popMargTop,
            'margin-left': -popMargLeft
        });

        // Add the mask to body
        $('body').append('<div id="mask"></div>');
        $('#mask').fadeIn(300);


        return false;
    });
    // When clicking on the button close or the mask layer the popup closed
    $('a.close').click(function () {
        $('#mask , #card-box').fadeOut(300, function () {
            $('#mask').remove();
        });


        return false;
    });
});  