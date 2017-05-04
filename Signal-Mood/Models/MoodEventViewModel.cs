using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Signal_Mood.Models
{
	public class MoodEventViewModel
	{
		public MoodState Rating { get; set; }
		public DateTime TimeOfRating { get; set; }
		public int Id { get; set; }
		public string DayOfWeek { get; set; }
	}
}