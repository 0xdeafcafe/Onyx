///<reference path="../jquery-1.8.2.d.ts" />
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
//@ sourceMappingURL=events.js.map
