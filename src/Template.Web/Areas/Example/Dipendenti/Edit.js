var Example;
(function (Example) {
    var Dipendenti;
    (function (Dipendenti) {
        class editVueModel {
            constructor(hub, model) {
                this.hub = hub;
                this.model = model;
                if (this.hub) {
                    this.hub.on("NewMessage", async (idDipendente, idMessage) => {
                        // do stuff with parameters
                    });
                }
            }
        }
        Dipendenti.editVueModel = editVueModel;
    })(Dipendenti = Example.Dipendenti || (Example.Dipendenti = {}));
})(Example || (Example = {}));
//# sourceMappingURL=Edit.js.map