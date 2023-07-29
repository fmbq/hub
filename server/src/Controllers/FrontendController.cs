using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace FMBQ.Hub.Controllers
{
    [Route("/")]
    [OpenApiIgnore]
    public class FrontendController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            // return File("~/index.html", "text/html");
            return View("Home");
        }
    }
}
