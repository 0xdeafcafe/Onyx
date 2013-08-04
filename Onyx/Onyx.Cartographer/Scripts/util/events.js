///<reference path="../jquery-1.8.2.d.ts" />
///<reference path="../jquery.cookie.d.ts" />
///<reference path="modal_manager.ts" />
/* Redrawing The Code Editor IDE
----------------------------------------------- */
$(document).ready(function () {
    reDrawCodeIde();
});
$(window).resize(function () {
    reDrawCodeIde();
});
function reDrawCodeIde() {
    console.log($(window).outerHeight());
    $(".CodeMirror").css("height", ($(window).outerHeight() - $(".nav-tabs").outerHeight() - $("#gamesaveModify > h1").outerHeight() - 130));
}

/* Profile Dropdown
----------------------------------------------- */
$('.user-header').click(function () {
    $('.submenu').css('display', 'block');
});
$(document).mouseup(function (e) {
    var container = $(".submenu");
    if (!container.is(e.target) && container.has(e.target).length === 0)
        container.hide();
});

/* Flash Messages
----------------------------------------------- */
$(document).ready(function () {
    var flashMessage = "";
    var flashType = "";

    $.each(new Array('Success', 'Error', 'Warning', 'Info'), function (i, alert) {
        var cookie = $.cookie("Flash." + alert);

        if (cookie) {
            // get cookie data
            flashMessage = cookie;
            flashType = alert.toLocaleLowerCase();

            // delete cookie
            $.cookie("Flash." + alert, null, { path: '/' });

            // show modal
            showModalFromString(flashType, "Notification", flashMessage);

            return;
        }
    });
});
//@ sourceMappingURL=events.js.map
