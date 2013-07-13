///<reference path="XboxInternals.d.ts" />
///<reference path="../jquery-1.8.2.d.ts" />
///<reference path="../util/modal_manager.ts" />
///<reference path="../cartographer/cartographer.ts" />

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
            showModal(ModalTypes.WarningModal, 'Woah Cowboy!', 'You can only drop 1 file at a time into Onyx.');
        else if (count == 1)
            handleFile(files[0]);

    }, false);
};

function handleFile(file: File) {
    XboxInternals.IO.FileIO.LoadFromFile(file, (io) => {
        try {
            var stfs = new XboxInternals.Stfs.StfsPackage(io, 0);
        }
        catch (e) {
            showModal(ModalTypes.ErrorModal, 'Invalid STFS Package', 'The selected file was not a valid STFS Package. Raw error is: <br /><br /> ' + e);
        }

        cartographer = new Onyx.Cartographer(stfs);
    });
}