﻿// odetofood.js

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
            var $newHtml = $(data);

            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        });

        // We prevent the browser's default action, which is to navigate away and
        // going to the server by itself and re-drawing the page. 
        return false;
    };

    var submitAutocompleteForm = function (event, ui) {
        var $input = $(this);

        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-odetofood-autocomplete"),
            select: submitAutocompleteForm
        };

        $input.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-odetofood-target");
            $(target).replaceWith(data);
        });
        return false;
    };

    // One of more forms could utilize ajax depending on whether or not the stated
    // html attribute is there. However many forms we capture, will use ajax to
    // submit with the passed in ajaxFormSubmit function.
    $("form[data-odetofood-ajax='true']").submit(ajaxFormSubmit);

    // Find all the inputs with autocomplete then for each one, call the appropriate function.
    $("input[data-odetofood-autocomplete]").each(createAutocomplete);

    // The main content is in the _Layout view and it contains all the html our view renders.
    // Our click event is hooked up to main content because it doesn't get destroyed and
    // re-drawn every time the page refreshes. That would defeat the purpose of what we 
    // want to do, which is to prevent re-drawing page refreshes every time we click 
    // the pagedList a tags.
    $(".main-content").on("click", ".pagedList a", getPage);

});