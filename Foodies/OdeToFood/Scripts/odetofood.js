// odetofood.js

$(document).ready(function () {

    var ajaxFormSubmit = function () {
        // Capture the form or forms.
        var $form = $(this);

        // List out the http method, action and then
        // transform it into a format ajax can use.
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        };

        // Pass the above options into ajax and whenever the request is done,
        // we'll receive data. The data to update the html elements we specify.
        $.ajax(options).done(function(data) {
            var $target = $($form.attr("data-odetofood-target"));
            $target.replaceWith(data);
        });

        // We prevent the browser's default action, which is to navigate away and
        // going to the server by itself and re-drawing the page. 
        return false;
    };

    // One of more forms could utilize ajax depending on whether or not the stated
    // html attribute is there. However many forms we capture, will use ajax to
    // submit with the passed in ajaxFormSubmit function.
    $("form[data-odetofood-ajax='true']").submit(ajaxFormSubmit);

});