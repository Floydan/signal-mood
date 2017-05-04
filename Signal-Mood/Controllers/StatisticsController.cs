using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Signal_Mood.Data;
using Signal_Mood.Models;

namespace Signal_Mood.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        [HttpGet]
        public ActionResult Index(DateTime from, DateTime to)
        {
            using (var context = new SignalMoodContext())
            {
                var stats = context.MoodEvents.Where(w => w.TimeOfRating >= from && w.TimeOfRating <= to).ToList();
                var statistics = new Statistic(stats);
                return View("~/Views/Statistics/index.cshtml", statistics);
            }
        }
    }
}