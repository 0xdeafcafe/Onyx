///<reference path="../jquery-1.8.2.d.ts" />
///<reference path="mask_manager.ts" />
var ModalTypes;
(function (ModalTypes) {
    ModalTypes[ModalTypes["WarningModal"] = 0] = "WarningModal";
    ModalTypes[ModalTypes["ErrorModal"] = 1] = "ErrorModal";
    ModalTypes[ModalTypes["InfoModal"] = 2] = "InfoModal";

    ModalTypes[ModalTypes["AlertModal"] = 3] = "AlertModal";
})(ModalTypes || (ModalTypes = {}));

$('document').keypress(function (e) {
    if (e.keyCode == 27)
        closeModal();
});
$('#opacityMask').click(function () {
    closeModal();
});
$('#modal > .actions > input').click(function () {
    closeModal();
});

var modalCount = 0;
function showModal(modalType, title, description) {
    if (modalCount == 0)
        showModalMask();
    modalCount++;

    switch (modalType) {
        case ModalTypes.AlertModal:
            $('#modal').addClass('alert');
            break;
        case ModalTypes.ErrorModal:
            $('#modal').addClass('error');
            break;
        case ModalTypes.InfoModal:
            $('#modal').addClass('info');
            break;
        case ModalTypes.WarningModal:
            $('#modal').addClass('warning');
            break;
    }

    $('#modal > h1').html(title);
    $('#modal > p').html(description);
    $('#modal').fadeIn(200);
}
function closeModal() {
    if (modalCount == 0)
        return;

    // close modal
    $('#modal').fadeOut(200);
    $('#modal').removeClass();

    modalCount--;
    if (modalCount == 0)
        hideModalMask();
}
//@ sourceMappingURL=modal_manager.js.map
