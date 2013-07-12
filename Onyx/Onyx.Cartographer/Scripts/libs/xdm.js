///<reference path="XboxInternals.d.ts" />
///<reference path="../jquery-1.8.2.d.ts" />
window.onload = function () {
    window.addEventListener("dragenter", function (evt) {
        evt.stopPropagation();
        evt.preventDefault();
    }, false);
    window.addEventListener("dragexit", function (evt) {
        evt.stopPropagation();
        evt.preventDefault();
    }, false);
    window.addEventListener("dragover", function (evt) {
        evt.stopPropagation();
        evt.preventDefault();
    }, false);
    window.addEventListener("drop", function (evt) {
        evt.stopPropagation();
        evt.preventDefault();

        var files = event.dataTransfer.files;
        var count = files.length;

        if (count > 1)
            console.log('too many files dropped'); else if (count > 0)
            handleFile(files[0]);
    }, false);
};

function handleFile(file) {
    XboxInternals.IO.FileIO.LoadFromFile(file, function (io) {
        try  {
            var stfs = new XboxInternals.Stfs.StfsPackage(io, 0);
            console.log(stfs);
            console.log(stfs.metaData.displayName);
            console.log(stfs.metaData.displayName.length);
        } catch (e) {
            console.log(e);
        }
    });
}
//@ sourceMappingURL=xdm.js.map
