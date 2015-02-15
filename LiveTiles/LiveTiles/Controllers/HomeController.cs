using System;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class TileConfig
    {
        public DateTime Time { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var o = new TileConfig { Time = DateTime.Now };
            return View();
        }

        //public ActionResult GetView()
        //{
        //    var o = new TileConfig { Time = DateTime.Now };
        //    return PartialView("_TilePartialView", o);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}