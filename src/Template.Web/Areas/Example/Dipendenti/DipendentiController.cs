using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template.Infrastructure.AspNetCore;
using Template.Services.Shared;
using Template.Web.SignalR;
using Template.Web.SignalR.Hubs.Events;

namespace Template.Web.Areas.Example.Dipendenti
{
    [Area("Example")]
    public partial class DipendentiController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private readonly IPublishDomainEvents _publisher;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public DipendentiController(SharedService sharedService, IPublishDomainEvents publisher, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedService = sharedService;
            _publisher = publisher;
            _sharedLocalizer = sharedLocalizer;

            ModelUnbinderHelpers.ModelUnbinders.Add(typeof(IndexViewModel), new SimplePropertyModelUnbinder());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(IndexViewModel model)
        {
            var dipendenti = await _sharedService.Query(model.ToDipendentiIndexQuery());
            model.SetDipendenti(dipendenti);

            return View(model);
        }

        [HttpGet]
        public virtual IActionResult New()
        {
            return RedirectToAction(Actions.Edit());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? Id)
        {
            var model = new EditViewModel();

            if (Id.HasValue)
            {
                model.SetDipendente(await _sharedService.Query(new DipendenteDetailQuery
                {
                    Id = Id.Value,
                }));

                model.SetOrari(await _sharedService.Query(new NomeDipendenteDetailQuery 
                { 
                    Id = Id.Value,
                }));
            }

            return View(model);
        }
        /**
        [HttpPost]
        public virtual async Task<IActionResult> Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Id = await _sharedService.Handle(model.ToUpdateDipendenteCommand());

                    Alerts.AddSuccess(this, "Informazioni aggiornate");

                    // Esempio lancio di un evento SignalR
                    await _publisher.Publish(new NewMessageEvent
                    {
                        IdGroup =(Guid) model.Id,
                        IdUser =(Guid) model.Id,
                        IdMessage = Guid.NewGuid()
                    });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            if (ModelState.IsValid == false)
            {
                Alerts.AddError(this, "Errore in aggiornamento");
            }

            return RedirectToAction(Actions.Edit(model.Id));
        }
        */
        [HttpPost]
        public virtual async Task<IActionResult> ModificaData(string id, string visitaMedica, string patente)
        {
            var viewModel = new EditViewModel();
            Guid guidId = Guid.Parse(id);
            var arrayVisitaMedica = visitaMedica.Split('/');
            var arrayPatente = patente.Split("/");
            try
            {
                if (arrayVisitaMedica.Count() == 3 && arrayPatente.Count() == 3)
                {
                    var dataVisitaMedica = new DateOnly(int.Parse(arrayVisitaMedica[2]), int.Parse(arrayVisitaMedica[1]), int.Parse(arrayVisitaMedica[0]));
                    var dataPatente = new DateOnly(int.Parse(arrayPatente[2]), int.Parse(arrayPatente[1]), int.Parse(arrayPatente[0]));
                    var idTurno = await _sharedService.Handle(viewModel.ToUpdateDipendenteCommand(guidId, dataVisitaMedica, dataPatente));

                    // Esempio lancio di un evento SignalR
                    await _publisher.Publish(new NewMessageEvent
                    {
                        IdGroup = (Guid)idTurno,
                        IdUser = (Guid)idTurno,
                        IdMessage = Guid.NewGuid()
                    });
                    return Ok();   
                }
                else
                {
                    throw new Exception("Formato della data non valido.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
