using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_EF_Intro.Models;

namespace MVC_EF_Intro.Controllers
{
    public class FootballSchedulesController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: FootballSchedules/Index/?season=2019
        public ActionResult Index(int? id = null)
        {
            //var games = db.FootballSchedules.Where(x => x.Season == id).ToList();

            List<FootballSchedule> games = new List<FootballSchedule>();
            if (id == null)
            {
                games = db.FootballSchedules.ToList();
            }
            else
            {
                foreach (FootballSchedule game in db.FootballSchedules.ToList())
                {
                    if (game.Season == id)
                    {
                        games.Add(game);
                    }
                }
            }

            return View(games);
        }

        // GET: FootballSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FootballSchedule footballSchedule = db.FootballSchedules.Find(id);
            if (footballSchedule == null)
            {
                return HttpNotFound();
            }
            return View(footballSchedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
