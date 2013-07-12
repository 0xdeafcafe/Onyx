///<reference path="XboxInternals.d.ts" />
///<reference path="../jquery-1.8.2.d.ts" />

window.onload = () => {
    window.addEventListener("dragenter", (evt) => {
        evt.stopPropagation();
        evt.preventDefault();
    }, false);
    window.addEventListener("dragexit", (evt) => {
        evt.stopPropagation();
        evt.preventDefault();
    }, false);
    window.addEventListener("dragover", (evt) => {
        evt.stopPropagation();
        evt.preventDefault();
    }, false);
    window.addEventListener("drop", (evt) => {
        evt.stopPropagation();
        evt.preventDefault();

        var files = event.dataTransfer.files;
        var count = files.length;

        if (count > 1)
            console.log('too many files dropped');
        else if (count > 0)
            handleFile(files[0]);

    }, false);
};

function handleFile(file: File) {
    XboxInternals.IO.FileIO.LoadFromFile(file, (io) => {
        try {
            var stfs = new XboxInternals.Stfs.StfsPackage(io, 0);
            console.log(stfs);
            console.log(stfs.metaData.displayName);
            console.log(stfs.metaData.displayName.length);
        }
        catch (e) {
            console.log(e);
        }
    });
}
