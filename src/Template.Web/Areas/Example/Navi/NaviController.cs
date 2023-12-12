using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Infrastructure.AspNetCore;
using Template.Services.Shared;

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
            model.SetNavi(navi);

            return View(model);
        }
    }
}
