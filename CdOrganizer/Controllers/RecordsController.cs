using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CDOrganizer.Models;

namespace CDOrganizer.Controllers
{
    public class RecordsController: Controller
    {
        [HttpGet("/artistes/{id}/songs/new")]
        public ActionResult New(int id)
        {
            Artist artist = Artist.GetArtist(id);
            return View(artist);
        }
    }
}