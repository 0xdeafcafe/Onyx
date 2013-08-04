///<reference path="../libs/xbox_internals/XboxInternals.d.ts" />
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
            this.StfsPackage = stfsPack;
            this.Init();
            this.ValidatePackage();
        }
        Cartographer.prototype.Init = function () {
        };

        Cartographer.prototype.ValidatePackage = function () {
            var isValid = true;

            if (this.StfsPackage.metaData.titleID != 1297287449 || !this.StfsPackage.FileExists('variant'))
                isValid = false;

            if (isValid) {
                var extracted = this.StfsPackage.ExtractFileFromPath('variant', function (p) {
                });

                if (extracted.buffer.byteLength > 35000)
                    throw 'The selected gametype is not a valid Halo 4 gametype.';

                // Check Magic
                extracted.SetPosition(0x00);
                if (extracted.ReadString(0x04) != "_blf")
                    throw 'The selected gametype is not a valid Halo 4 gametype.';

                // Check Game Variant Chunk Header
                extracted.SetPosition(0x2F0);
                if (extracted.ReadString(0x04) != "mpvr")
                    throw 'The selected gametype is not a valid Halo 4 gametype.';
            } else {
                throw 'The selected gametype is not a valid Halo 4 gametype.';
            }
        };
        return Cartographer;
    })();
    Onyx.Cartographer = Cartographer;
})(Onyx || (Onyx = {}));
//@ sourceMappingURL=cartographer.js.map
