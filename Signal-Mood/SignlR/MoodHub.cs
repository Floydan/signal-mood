using Microsoft.AspNet.SignalR;

namespace Signal_Mood.SignlR
{
    public class MoodHub: Hub
    {
        public void Send(string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(message);
        }
    }
    
}