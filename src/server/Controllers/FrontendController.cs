using Microsoft.AspNetCore.Mvc;

namespace FMBQ.Hub.Controllers
{
    [Route("/")]
    public class FrontendController : Controller
    {
        [HttpGet("{**url}")]
        public ActionResult Get()
        {
            return File("~/index.html", "text/html");
        }
    }
}
