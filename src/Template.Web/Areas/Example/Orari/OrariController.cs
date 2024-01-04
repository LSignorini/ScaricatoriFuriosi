using Microsoft.AspNetCore.Mvc;
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
        public virtual async Task<IActionResult> Index(IndexViewModel model)
        {
            var orari = await _sharedService.Query(model.ToOrariIndexQuery());
            model.SetOrari(orari);

            return View(model);
        }
    }
}
