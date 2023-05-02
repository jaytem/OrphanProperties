using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using <Site>.Web.Features.OrphanProperties.Services;

namespace <Site>.Web.Features.OrphanProperties.Controllers
{
    [Authorize(Roles = "WebAdmins")]
    [ApiController]
    [Route("/Admin/orphanPropertiesReport", Name = "OrphanPropertiesReport")]
    public class OrphanPropertiesRerportController : Controller
    {
        private IOrphanPropertiesService _orphanPropertiesService;

        public OrphanPropertiesRerportController(IOrphanPropertiesService orphanPropertiesService)
        {
            _orphanPropertiesService = orphanPropertiesService;
        }

        public ActionResult Index()
        {
            var model = _orphanPropertiesService.CompileOrphanProperties();

            return View("~/Features/OrphanProperties/Views/Index.cshtml", model);
        }
    }
}
