using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace FMBQ.Hub.Controllers
{
    [Route("/")]
    [OpenApiIgnore]
    public class FrontendController : Controller
    {
        [HttpGet("{**url}")]
        public ActionResult Get()
        {
            return File("~/index.html", "text/html");
        }
    }
}
