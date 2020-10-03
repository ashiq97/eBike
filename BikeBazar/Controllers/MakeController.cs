using BikeBazar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BikeBazar.Controllers
{
    public class MakeController : Controller
    {
        [Route("Make")]
        [Route("Make/bikes")]
        public IActionResult Bikes()
        {
            Make make = new Make { Id = 1, Name = "Jon doe" };
            return View(make);
        }

        //attribute based routing
        [Route("make/bikes/{year:int:length(4)}/{month:int:range(1,13)}")]
        public IActionResult ByYearMonth(int year,int month)
        {
            return Content(year + ";" + month);
        }
    }
}
