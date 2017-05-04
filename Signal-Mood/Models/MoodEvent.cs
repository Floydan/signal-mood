using System;

public enum MoodState
{
    Happy = 0,
    Content = 1,
    Dissatisfied = 2,
    PissedOff = 3
}
namespace Signal_Mood.Models
{
    public class MoodEvent
    {
        public MoodState Rating { get; set; }
        public DateTime TimeOfRating { get; set; }
        public int Id { get; set; }
    }
}