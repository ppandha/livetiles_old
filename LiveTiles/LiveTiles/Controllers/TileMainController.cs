using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class TileType
    {
        public int Id { get; set; }
        public int RefreshPeriod { get; set; }
    }

    public class Notice
    {
        public string Heading { get; set; }
        public string Content { get; set; }
    }

    public class NoticeBoardTile : TileType
    {
        public List<Notice> Notices{ get; set; }
    }

    public class CalendarEvent : TileType
    {
        public DateTime date { get; set; }
        public string Description { get; set; }
    }

    public class CalendarTile : TileType
    {
        public List<CalendarEvent> Events { get; set; }
    }

    public class TwitterTile : TileType
    {
        public List<string> UserIds { get; set; }
    }

    public class NewsFeedTile : TileType
    {
        public string Url { get; set; }
    }

    
    public class TileConfiguration
    {
        public string Description { get; set; }
        public int LayoutId { get; set; }
        public List<TileType> Tiles { get; set; } 
    }

    public class TileMainController : Controller
    {
        private TileConfiguration tileConfiguration;

        public TileMainController()
        {
            
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"..\Views";
            tileConfiguration = new TileConfiguration();
            tileConfiguration.Description = "2 x 2";
            tileConfiguration.LayoutId = 1;
            tileConfiguration.Tiles = new List<TileType>
            {
                new NoticeBoardTile{Id = 1, RefreshPeriod = 0, Notices = new List<Notice>{new Notice{Heading = "heading 1", Content = "content 1"}, new Notice{Heading = "heading 2", Content = "content 2"}}},
                new CalendarTile{Id = 2, RefreshPeriod = 5000, Events = new List<CalendarEvent>{new CalendarEvent{date = new DateTime(2015,11,1), Description = "some event"}}},
                new TwitterTile{Id = 3, RefreshPeriod = 0, UserIds = new List<string>{"piersmorgan"}},
                new NewsFeedTile{Id = 4, RefreshPeriod = 4000, Url = "http://feeds.bbci.co.uk/news/rss.xml"},
            };
        }

        // GET: TileMain
        public ActionResult Index()
        {
            return View(tileConfiguration);
        }

        //    string url = "http://fooblog.com/feed";
        //XmlReader reader = XmlReader.Create(url);
        //SyndicationFeed feed = SyndicationFeed.Load(reader);
        //reader.Close();
        //foreach (SyndicationItem item in feed.Items)
        //{
        //    String subject = item.Title.Text;    
        //    String summary = item.Summary.Text;
        //    ...                
        //}
        public ActionResult GetView( int tileId)
        {
            // which tile is it?
            var tile = tileConfiguration.Tiles.Single(a => a.Id == tileId);

            if (tile is NoticeBoardTile)
            {
                return PartialView("_NoticeBoardTilePartialView", tile as NoticeBoardTile);
            }
            if (tile is CalendarTile)
            {
                return PartialView("_CalendarTilePartialView", tile as CalendarTile);
            }
            if (tile is TwitterTile)
            {
                return PartialView("_TwitterTilePartialView", tile as TwitterTile);
            }
            if (tile is NewsFeedTile)
            {
                return PartialView("_NewsFeedTilePartialView", tile as NewsFeedTile);
            }

            return PartialView("_TilePartialView");
        }
    }
}