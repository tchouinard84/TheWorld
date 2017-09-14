// Write your Javascript code.

//immediately invoked annonymous function
(function () {
    var sidebarAndWrapper = $("#sidebar,#wrapper");     // this selector gets both elements with the given ids
    var $icon = $("#sidebarToggle i.fa");

    $("#sidebarToggle").on("click",
        function() {
            sidebarAndWrapper.toggleClass("hide-sidebar");
            if (sidebarAndWrapper.hasClass("hide-sidebar")) {
                $icon.removeClass("fa-angle-left");
                $icon.addClass("fa-angle-right");
            } else {
                $icon.addClass("fa-angle-left");
                $icon.removeClass("fa-angle-right");
            }
        });
})();
