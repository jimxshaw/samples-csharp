// site.js
(function() {
    var element = document.getElementById("username");
    element.innerHTML = "Mark Hamill";

    var main = document.getElementById("main");
    main.onmouseenter = function() {
        main.style = "background: #888";
    };

    main.onmouseleave = function() {
        main.style = "";
    };
})();
