var Onyx;
(function (Onyx) {
    var DataStorage = (function () {
        function DataStorage() {
        }
        DataStorage.Domain = 'http://localhost:1337/';
        return DataStorage;
    })();
    Onyx.DataStorage = DataStorage;
})(Onyx || (Onyx = {}));
//@ sourceMappingURL=data_storage.js.map
