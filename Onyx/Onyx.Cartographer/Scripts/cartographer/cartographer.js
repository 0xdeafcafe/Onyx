///<reference path="../libs/XboxInternals.d.ts" />
///<reference path="../jquery-1.8.2.d.ts" />
///<reference path="../util/modal_manager.ts" />
///<reference path="../util/mask_manager.ts" />
///<reference path="../ide/codemirror.d.ts" />
///<reference path="../stor/data_storage.ts" />
///<reference path="../util/events.ts" />
var Onyx;
(function (Onyx) {
    var Cartographer = (function () {
        function Cartographer(stfsPack) {
            this.stfsPackage = stfsPack;
            this.Init();
            this.ValidatePackage();
        }
        Cartographer.prototype.Init = function () {
        };

        Cartographer.prototype.ValidatePackage = function () {
            var isValid = true;

            if (this.stfsPackage.metaData.titleID != 1297287449 || !this.stfsPackage.FileExists('variant'))
                isValid = false;

            if (isValid) {
                var extracted = this.stfsPackage.ExtractFileFromPath('variant', function (p) {
                });

                if (extracted.buffer.byteLength > 35000) {
                    // show error modal
                    showModal(ModalTypes.ErrorModal, 'Invalid Halo 4 Gametype', 'The selected gametype is not a valid Halo 4 gametype.');
                    return;
                }
                cartographer = this;
                this.UploadVariant(extracted);
            } else {
                // show error modal
                showModal(ModalTypes.ErrorModal, 'Invalid Halo 4 Gametype', 'The selected gametype is not a valid Halo 4 gametype.');
            }
        };

        Cartographer.prototype.UploadVariant = function (variant) {
            showPendingMask();
            $.ajax({
                type: 'POST',
                url: Onyx.DataStorage.Domain + 'api/variant/',
                data: variant.buffer,
                headers: {
                    'Content-Type': 'application/json'
                },
                processData: false,
                success: function (data) {
                    window.location.hash = 'Create/Modify';
                    $('.scriptData > #scriptmod').val(data);

                    var editor = CodeMirror.fromTextArea(document.getElementById("scriptmod"), {
                        lineNumbers: true,
                        styleActiveLine: true,
                        theme: 'onyx',
                        value: data,
                        tabindex: 0,
                        placeholder: '',
                        autofocus: true
                    });
                    hidePendingMask();
                    reDrawCodeIde();
                }
            });
        };
        return Cartographer;
    })();
    Onyx.Cartographer = Cartographer;
})(Onyx || (Onyx = {}));

var cartographer = null;

$(window).on('beforeunload', function () {
    if (cartographer !== null)
        return 'Are you sure you want to exit Onyx? Any un-saved data will be lost.';
});
//@ sourceMappingURL=cartographer.js.map
