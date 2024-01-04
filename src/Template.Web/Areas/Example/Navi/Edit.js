var Example;
(function (Example) {
    var Navi;
    (function (Navi) {
        class editVueModel {
            constructor(hub, model) {
                this.hub = hub;
                this.model = model;
                if (this.hub) {
                    this.hub.on("NewMessage", async (Id, idMessage) => {
                        // do stuff with parameters
                    });
                }
            }
        }
        Navi.editVueModel = editVueModel;
    })(Navi = Example.Navi || (Example.Navi = {}));
})(Example || (Example = {}));
//# sourceMappingURL=Edit.js.map