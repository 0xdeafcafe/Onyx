///<reference path="../libs/XboxInternals.d.ts" />
///<reference path="../jquery-1.8.2.d.ts" />
///<reference path="../util/modal_manager.ts" />
///<reference path="../util/mask_manager.ts" />
///<reference path="../ide/codemirror.d.ts" />
///<reference path="../stor/data_storage.ts" />
///<reference path="../util/events.ts" />

module Onyx {
    export class Cartographer {
        private stfsPackage: XboxInternals.Stfs.StfsPackage;

        constructor(stfsPack: XboxInternals.Stfs.StfsPackage) {
            this.stfsPackage = stfsPack;
            this.Init();
            this.ValidatePackage();
        }

        private Init() {

        }

        private ValidatePackage() {
            var isValid: boolean = true;

            if (this.stfsPackage.metaData.titleID != 1297287449 ||
                !this.stfsPackage.FileExists('variant'))
                isValid = false;
            
            if (isValid) {
                var extracted = this.stfsPackage.ExtractFileFromPath('variant', (p) => { });

                // File done extracting
                if (extracted.buffer.byteLength > 35000) {
                    // show error modal
                    showModal(ModalTypes.ErrorModal, 'Invalid Halo 4 Gametype', 'The selected gametype is not a valid Halo 4 gametype.');
                    return;
                }
                cartographer = this;
                this.UploadVariant(extracted);
            }
            else
            {
                // show error modal
                showModal(ModalTypes.ErrorModal, 'Invalid Halo 4 Gametype', 'The selected gametype is not a valid Halo 4 gametype.');
            }
        }

		private UploadVariant(variant: XboxInternals.IO.FileIO) {
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
        }
    }
}

var cartographer: Onyx.Cartographer = null;

$(window).on('beforeunload', function () {
    if (cartographer !== null)
        return 'Are you sure you want to exit Onyx? Any un-saved data will be lost.';
});
