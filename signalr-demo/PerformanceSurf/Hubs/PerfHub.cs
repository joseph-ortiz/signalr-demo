﻿using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using PerformanceSurf.Counters;

namespace PerformanceSurf.Hubs
{
    public class PerfHub : Hub
    {

        public PerfHub()
        {
            StartCounterCollection();
        }

        private void StartCounterCollection()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                var perfService = new PerfCounterService();
                while (true)
                {
                    var results = perfService.GetResults();
                    Clients.All.newCounters(results);
                    await Task.Delay(2000);
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Send(string message)
        {
            Clients.All.newMessage(
                Context.User.Identity.Name + " says " + message
                );
        }


    }
}