using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Signal_Mood.Data;
using Signal_Mood.Models;
using Signal_Mood.SignlR;
using Newtonsoft.Json;

namespace Signal_Mood.Controllers
{
    [RoutePrefix("api/mood")]
    public class MoodApiController : ApiController
    {

        [Route("save/{mood:int:min(0):max(3)}"), HttpPost]
        public bool SaveMood(int mood)
        {
            var moodEvent = new MoodEvent { Rating = (MoodState)mood, TimeOfRating = DateTime.UtcNow };
            using (var context = new SignalMoodContext())
            {
                context.MoodEvents.Add(moodEvent);
                context.SaveChanges();
            }
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MoodHub>();
            hubContext.Clients.All.addMessage("nytt humör: " + mood);
            return moodEvent.Id > 0;
        }

        [Route("stats"), HttpPost]
        public IEnumerable<MoodEventViewModel> GetEvents(StatsQueryModel queryModel)
        {
            if (queryModel == null)
            {
                queryModel = new StatsQueryModel();
                var test = JsonConvert.SerializeObject(queryModel);
            }
            if (queryModel.ToDate == null) queryModel.ToDate = DateTime.UtcNow;

            using (var context = new SignalMoodContext())
            {
                var stats =
                    context.MoodEvents.Where(w => w.TimeOfRating >= queryModel.FromDate && w.TimeOfRating <= queryModel.ToDate.Value);
                return stats.ToList()
                    .Select(w => new MoodEventViewModel
                    {
                        Id = w.Id,
                        Rating = w.Rating,
                        TimeOfRating = w.TimeOfRating,
                        DayOfWeek = w.TimeOfRating.DayOfWeek.ToString()
                    });
            }
        }

        public class StatsQueryModel
        {
            public DateTime FromDate { get; set; }
            public DateTime? ToDate { get; set; }
        }
    }
}