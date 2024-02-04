using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Template.Infrastructure.AspNetCore;
using Template.Services.Shared;
using Template.Web.Infrastructure;
using Template.Web.SignalR.Hubs.Events;

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
                model.SetNave(await _sharedService.Query(new NaveDetailQuery
                {
                    Id = Id.Value
                }));
            }

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Edit(EditViewModel model)
        {
            return RedirectToAction(Actions.Edit(model.Id));
        }
    }
}
