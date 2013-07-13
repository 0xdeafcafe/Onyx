///<reference path="../jquery-1.8.2.d.ts" />

enum ModalTypes {
	WarningModal,
	ErrorModal,
    InfoModal,
    AlertModal
}

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

var modalCount: number = 1;
function showModal(modalType: ModalTypes, title: string, description: string) {
    if (modalCount == 0) {
        // add background mask
        $('#opacityMask').fadeTo(200, 0.7);
    }
    modalCount++;

    // load modal
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

    // hide opacity mask
    $('#opacityMask').css('display', 'none');

    modalCount--;
    if (modalCount == 0) {
        // remove background mask
        $('#opacityMask').fadeTo(200, 0.0);
        $('#opacityMask').css('display', 'none');
    }
}
