using System;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class TileConfiguration
    {
        public string Description { get; set; }
        public int LayoutId { get; set; }
    }

    public class TileMainController : Controller
    {
        // GET: TileMain
        public ActionResult Index()
        {
            var tileConfiguration = new TileConfiguration();
            tileConfiguration.Description = "2 x 2";
            tileConfiguration.LayoutId = 1;

            return View(tileConfiguration);
        }

        public ActionResult GetView()
        {
            var o = new TileConfig { Time = DateTime.Now };
            return PartialView("_TilePartialView", o);
        }
    }
}