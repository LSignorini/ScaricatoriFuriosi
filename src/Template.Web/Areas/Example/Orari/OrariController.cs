using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Template.Infrastructure.AspNetCore;
using Template.Services.Shared;

namespace Template.Web.Areas.Example.Orari
{
    [Area("Example")]
    public partial class OrariController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;

        public OrariController(SharedService sharedService)
        {
            _sharedService = sharedService;

            ModelUnbinderHelpers.ModelUnbinders.Add(typeof(IndexViewModel), new SimplePropertyModelUnbinder());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(Guid? Id, DateOnly giorno)
        {
            var model = new IndexViewModel();

            var orari = await _sharedService.Query(model.ToOrariIndexQuery());
            model.SetOrari(orari);

            var nave = await _sharedService.Query(new NaveDetailQuery
            {
                Id = Id.Value
            });
            model.SetNave(nave);

            DateOnly dataEu = new DateOnly(giorno.Year, giorno.Day, giorno.Month);

            model.SetGiorno(dataEu);

            var dipendentiLiberi = await _sharedService.Query(new DipendentiGiornoSelectQuery
            {
                Giorno = dataEu
            });
            model.SetDipendentiLiberi(dipendentiLiberi);

            return View(model);
        }
    }
}
