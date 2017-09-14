// Write your Javascript code.

//immediately invoked annonymous function
(function () {

    /*
    //Non-jQuery

        var element = document.getElementById("username");
        element.innerHTML = "Change Name";

        var main = document.getElementById("main");
        main.onmouseenter = function() {
            main.style.backgroundColor = "#888";
        };
        main.onmouseleave = function() {
            main.style.backgroundColor = "";
        };
    */

    //$ --> jQuery --> used to get elements from the page using selectors

    var element = $("#username");
    element.text("TIM CHOUINARD");

    var main = $("#main");

    /* Alternate method
        main.on("mouseenter", function () {
            main.css("background-color", "green");
        });

        main.on("mouseleave", function () {
            main.css("background-color", "");
        });
    */

    main.mouseenter(function () {
        main.css("background-color", "#888");
    });
    main.mouseleave(function () {
        main.css("background-color", "");
    });

    var menuItems = $("ul.menu li a");
    menuItems.on("click",
        function () {
            var me = $(this);
            alert(me.text());
        });
})();
