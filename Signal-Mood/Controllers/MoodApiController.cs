﻿using System;
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
		
		[Route("save/{mood:int:min(0):max(3)}"), HttpPost]
		public bool SaveMood(int mood)
		{
			var moodEvent = new MoodEvent { Rating = (MoodState)mood, TimeOfRating = DateTime.UtcNow };
			using (var context = new SignalMoodContext())
			{
				context.MoodEvents.Add(moodEvent);
				context.SaveChanges();
			}

			return moodEvent.Id > 0;
		}

		[Route("stats"), HttpPost]
		public IEnumerable<MoodEvent> GetEvents(StatsQueryModel queryModel)
		{
			if(queryModel.ToDate == null) queryModel.ToDate = DateTime.UtcNow;
			
			using (var context = new SignalMoodContext())
			{
				var stats = context.MoodEvents.Where(w => w.TimeOfRating >= queryModel.FromDate && w.TimeOfRating <= queryModel.ToDate.Value).ToList();
				return stats;
			}
		}

		public class StatsQueryModel
		{
			public DateTime FromDate { get; set; }
			public DateTime? ToDate { get; set; }
		}
	}
}