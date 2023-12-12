module Example.Navi {
    export class editVueModel {
        constructor(public hub: any, public model: Example.Navi.Server.editViewModel) {
            if (this.hub) {
                this.hub.on("NewMessage", async (nomeNave: any, idMessage: any) => {
                    // do stuff with parameters
                });
            }
        }
    }
}