var Example;
(function (Example) {
    var Orari;
    (function (Orari) {
        class editVueModel {
            constructor(hub, model) {
                this.hub = hub;
                this.model = model;
                if (this.hub) {
                    this.hub.on("NewMessage", async (giorno, idMessage) => {
                        // do stuff with parameters
                    });
                }
            }
        }
        Orari.editVueModel = editVueModel;
    })(Orari = Example.Orari || (Example.Orari = {}));
})(Example || (Example = {}));
//# sourceMappingURL=Edit.js.map