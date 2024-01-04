module Example.Dipendenti{
    export class editVueModel {
        constructor(public hub: any, public model: Example.Dipendenti.Server.editViewModel) {
            if (this.hub) {
                this.hub.on("NewMessage", async (Id: any, idMessage: any) => {
                    // do stuff with parameters
                });
            }
        }
    }
}