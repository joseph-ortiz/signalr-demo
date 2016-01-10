using Microsoft.AspNet.SignalR;

namespace PerformanceSurf.Hubs
{
    public class PerfHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("Hi!");
        }
    }
}