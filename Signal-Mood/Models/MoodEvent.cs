using System;

public enum MoodState
{
    Happy,
    Content,
    Dissatisfied,
    PissedOff
}
namespace Signal_Mood.Models
{
    public class MoodEvent
    {
        public MoodState Rating { get; set; }
        public DateTime TimeOfRating { get; set; }
    }
}