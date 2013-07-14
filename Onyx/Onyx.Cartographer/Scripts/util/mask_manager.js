///<reference path="../jquery-1.8.2.d.ts" />
// Pending Mask
var pendingMaskCount = 0;
function showPendingMask() {
    if (pendingMaskCount == 0)
        $('#pendingMask').fadeTo(200, 0.7);
    pendingMaskCount++;
}
function hidePendingMask() {
    pendingMaskCount--;
    if (pendingMaskCount > 0)
        return;

    $('#pendingMask').fadeTo(200, 0.0);
    $('#pendingMask').css('display', 'none');
}

// Modal Mask
var modalMaskCount = 0;
function showModalMask() {
    if (modalMaskCount == 0)
        $('#modalMask').fadeTo(200, 0.7);
    modalMaskCount++;
}
function hideModalMask() {
    modalMaskCount--;
    if (modalMaskCount > 0)
        return;

    $('#modalMask').fadeTo(200, 0.0);
    $('#modalMask').css('display', 'none');
}
//@ sourceMappingURL=mask_manager.js.map
