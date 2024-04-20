using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Template.Infrastructure.AspNetCore;
using Template.Services.Shared;
using System.Collections.Generic;
using Template.Web.Infrastructure;
using Template.Web.SignalR.Hubs.Events;
using System.Collections;
using System.Linq;

namespace Template.Web.Areas.Example.Navi
{
    [Area("Example")]
    public partial class NaviController : AuthenticatedBaseController
    {
        private readonly SharedService _sharedService;

        public NaviController(SharedService sharedService)
        {
            _sharedService = sharedService;

            ModelUnbinderHelpers.ModelUnbinders.Add(typeof(IndexViewModel), new SimplePropertyModelUnbinder());
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index(IndexViewModel model)
        {
            var navi = await _sharedService.Query(model.ToNaviIndexQuery());
            var arrivi = await _sharedService.Query();
            model.SetNavi(navi);
            model.SetArrivi(arrivi);

            return View(model);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Edit(Guid? Id)
        {
            var model = new EditViewModel();

            if (Id.HasValue)
            {
                var nave = await _sharedService.Query(new NaveDetailQuery
                {
                    Id = Id.Value
                });

                model.SetNave(nave);

                model.SetDateLavorazione();

                var orariDipendenti = await _sharedService.Query(new IdNaveDetailQuery
                {
                    Id = Id.Value
                });

                model.SetOrariDipendenti(orariDipendenti);

                IEnumerable<DipDisponibiliSelectDTO> dipendentiDisponibili = Array.Empty<DipDisponibiliSelectDTO>();
                foreach (var data in model.GetDateLavorazione()) { 
                    DipDisponibiliSelectDTO dipDisponibiliGiorno = await _sharedService.Query(new GiornoSelectQuery
                    {
                        Giorno = data.Data
                    });
                    IEnumerable<DipDisponibiliSelectDTO> a = Enumerable.Empty<DipDisponibiliSelectDTO>().Append(dipDisponibiliGiorno);
                    dipendentiDisponibili = dipendentiDisponibili.Concat(a);
                }

                model.setDipendentiDisponibili(dipendentiDisponibili);
            }

            return View(model);
        }

        [HttpPost]
        public virtual Task<IActionResult> Edit(EditViewModel model)
        {
            return Task.FromResult<IActionResult>(RedirectToAction(Actions.Edit(model.Id)));
        }
    }
}
