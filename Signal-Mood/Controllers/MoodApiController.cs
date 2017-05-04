using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Signal_Mood.Models;

namespace Signal_Mood.Controllers
{
	[RoutePrefix("api/mood")]
	public class MoodApiController : ApiController
	{
		[Route, HttpPost]
		public bool SaveMood(MoodState mood)
		{
			//new MoodEvent {Rating = mood, TimeOfRating = DateTime.UtcNow};
			return false;
		}

		[Route, HttpPost]
		public IEnumerable<MoodEvent> GetEvents(DateTime fromDate, DateTime? toDate)
		{
			if(toDate == null) toDate = DateTime.UtcNow;
			return Enumerable.Empty<MoodEvent>();
		} 
	}
}