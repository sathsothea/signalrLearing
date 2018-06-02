using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace APISample
{
    public class SampleHub : Hub
    {
        public void sendMessage()
        {
            Clients.All.displayTime($"{DateTime.Now}");
        }

        public void addMessage(string name, string text)
        {
            Clients.All.chating(text);
        }
        
    }
}