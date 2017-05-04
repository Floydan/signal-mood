using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Signal_Mood.Models;

namespace Signal_Mood.Data
{
    public class SignalMoodContext: DbContext
    {
        public DbSet<MoodEvent> MoodEvents { get; set; }
    }
}