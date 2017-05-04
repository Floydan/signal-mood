using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Signal_Mood.Data;
using Signal_Mood.Models;

namespace Signal_Mood.Controllers
{
	[RoutePrefix("api/mood")]
	public class MoodApiController : ApiController
	{
		private SignalMoodContext MoodContext => new SignalMoodContext();

		[Route, HttpPost]
		public bool SaveMood(MoodState mood)
		{
			MoodContext.MoodEvents.Add(new MoodEvent {Rating = mood, TimeOfRating = DateTime.UtcNow});
			return MoodContext.SaveChanges() > 0;
		}

		[Route, HttpPost]
		public IEnumerable<MoodEvent> GetEvents(DateTime fromDate, DateTime? toDate)
		{
			if(toDate == null) toDate = DateTime.UtcNow;
			return MoodContext.MoodEvents.Where(w => w.TimeOfRating >= fromDate && w.TimeOfRating <= toDate.Value);
		} 
	}
}