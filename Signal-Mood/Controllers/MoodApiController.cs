using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Signal_Mood.Data;
using Signal_Mood.Models;

namespace Signal_Mood.Controllers
{
	[RoutePrefix("api/mood")]
	public class MoodApiController : ApiController
	{
		
		[Route("save/{mood:int}"), HttpPost]
		public bool SaveMood(int mood)
		{
			using(var context = new SignalMoodContext())
			{
				context.MoodEvents.Add(new MoodEvent { Rating = (MoodState)mood, TimeOfRating = DateTime.UtcNow });
				return context.SaveChanges() > 0;
			}
		}

		[Route("stats"), HttpPost]
		public IEnumerable<MoodEvent> GetEvents(StatsQueryModel queryModel)
		{
			if(queryModel.ToDate == null) queryModel.ToDate = DateTime.UtcNow;
			using (var context = new SignalMoodContext())
			{
				return
					context.MoodEvents.Where(
						w => w.TimeOfRating >= queryModel.FromDate && w.TimeOfRating <= queryModel.ToDate.Value);
			}
		}

		public class StatsQueryModel
		{
			public DateTime FromDate { get; set; }
			public DateTime? ToDate { get; set; }
		}
	}
}