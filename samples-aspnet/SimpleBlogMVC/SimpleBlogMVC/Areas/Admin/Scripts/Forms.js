$(document).ready(function () {
    // Search for all data-post attributes in a tags and
    // add a click handler.
    $("a[data-post]").click(function (e) {
        // Prevents the browser from navigating to its default functionality because
        // we're writing our own functionalities.
        e.preventDefault();

        var $this = $(this);
        var message = $this.data("post");

        // If there's a message and a delete dialog box opens to confirm the message and
        // the user hits no, then we exit. Nothing happens.
        if (message && !confirm(message)) {
            return;
        }

        // Otherwise a form is created with the post action and then submits the form.
        $("<form>")
            .attr("method", "post")
            .attr("action", $this.attr("href"))
            .appendTo(document.body)
            .submit();
    });
});