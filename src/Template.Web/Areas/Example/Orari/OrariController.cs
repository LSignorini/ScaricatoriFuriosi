using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Template.Infrastructure.AspNetCore;
using Template.Services.Shared;
using Template.Web.SignalR;
using Template.Web.SignalR.Hubs.Events;

namespace Template.Web.Areas.Example.Orari
{
    [Area("Example")]
    public partial class OrariController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;
        private readonly IPublishDomainEvents _publisher;

        public OrariController(SharedService sharedService, IPublishDomainEvents publisher)
        {
            _sharedService = sharedService;
            _publisher = publisher;
            ModelUnbinderHelpers.ModelUnbinders.Add(typeof(IndexViewModel), new SimplePropertyModelUnbinder());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(Guid? Id, DateOnly giorno)
        {
            var model = new IndexViewModel();

            DateOnly dataEu = new DateOnly(giorno.Year, giorno.Day, giorno.Month);

            var orariIndexQuery = new OrariIndexQuery
            {
                IdNave = (Guid)Id,
                Giorno = dataEu
            };
            var orari = await _sharedService.Query(orariIndexQuery);
            model.SetOrari(orari);

            var nave = await _sharedService.Query(new NaveDetailQuery
            {
                Id = Id.Value
            });
            model.SetNave(nave);

            model.SetGiorno(dataEu);

            var dipendentiLiberi = await _sharedService.Query(new DipendentiGiornoSelectQuery
            {
                Giorno = dataEu
            });
            model.SetDipendentiLiberi(dipendentiLiberi);

            return View(model);
        }

        [HttpPost]
        public virtual async void addOrarioToDipendente(int orarioInizio, Guid id, Guid idNave, DateOnly giorno)
        {
            var viewModel = new IndexViewModel();
            TimeOnly orario = new TimeOnly(orarioInizio, 0, 0);

            try
            {
                _sharedService.Handle(viewModel.ToAddOrarioCommand(id, orario, idNave, giorno));

                // Esempio lancio di un evento SignalR
                await _publisher.Publish(new NewMessageEvent
                {
                    IdGroup = Guid.NewGuid(),
                    IdUser = Guid.NewGuid(),
                    IdMessage = Guid.NewGuid()
                });
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
        }

        [HttpPost]
        public virtual async void removeOrarioDipendente(Guid idOrario)
        {
            var viewModel = new IndexViewModel();

            try
            {
                _sharedService.Handle(viewModel.ToAddOrarioCommand(idOrario));

                // Esempio lancio di un evento SignalR
                await _publisher.Publish(new NewMessageEvent
                {
                    IdGroup = Guid.NewGuid(),
                    IdUser = Guid.NewGuid(),
                    IdMessage = Guid.NewGuid()
                });
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
        }
    }
}
