using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Signal_Mood.Models
{
    public class Statistic
    {
        private IEnumerable<MoodEvent> _ratings;
        public Statistic(IEnumerable<MoodEvent> ratings)
        {
            _ratings = ratings;
        }

        public int DayStats(DayOfWeek weekday)
        {
            var rateCount = _ratings.Count(rating => rating.TimeOfRating.DayOfWeek == weekday);
            return rateCount;
        }
    }
}