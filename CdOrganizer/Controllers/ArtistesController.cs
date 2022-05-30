using CDOrganizer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CDOrganizer.Controllers
{
    public class ArtistesController : Controller
    {
        [HttpGet("/artistes")]
        public ActionResult Index()
        {
            List<Artist> artists = Artist.GetAllArtists();
            return View(artists);
        }

        [HttpGet("/artistes/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/artistes")]
        public ActionResult Create(string name)
        {
            Artist artist = new Artist(name);
            return RedirectToAction("Index");
        }

        [HttpGet("/artistes/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string , object> model = new Dictionary<string, object>{};
            Artist artist = Artist.GetArtist(id);
            List<Record> records = artist.Records;
            model.Add("artist" , artist);
            model.Add("records" , records);
            return View(model);
        }

        [HttpPost("/artistes/{artistId}/songs")]
        public ActionResult Create(int artistId , string name)
        {
            Dictionary<string ,object> model = new Dictionary<string, object>{};
            Artist artist = Artist.GetArtist(artistId);
            Record record = new Record(name);
            artist.AddRecord(record);
            List<Record> records = artist.Records;
            model.Add("artist" , artist);
            model.Add("records" , records);
            return View("Show" , model);
        }
    }
}