using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SoftCMS.Views.Home
{
    [HubName("userActivityHub")]
    public class UserActivityHub : Hub
    {
        public static List<string> Users = new List<string>();

        public void Send(int count)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<UserActivityHub>();
            context.Clients.All.updateUsersOnlineCount(count);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            string clientId = GetClientId();
            if (Users.IndexOf(clientId) == -1)
            {
                Users.Add(clientId);
            }
            Send(Users.Count);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            string clientId = GetClientId();
            if (Users.IndexOf(clientId) == -1)
            {
                Users.Add(clientId);
            }
            Send(Users.Count);
            return base.OnReconnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string clientId = GetClientId();
            if (Users.IndexOf(clientId) > -1)
            {
                Users.Remove(clientId);
            }
            Send(Users.Count);
            return base.OnDisconnected(stopCalled);
        }

        private string GetClientId()
        {
            string clientId = "";
            if (Context.QueryString["clientId"] != null)
            {
                clientId = this.Context.QueryString["clientId"];
            }
            if (string.IsNullOrEmpty(clientId.Trim()))
            {
                clientId = Context.ConnectionId;
            }
            return clientId;
        }
    }
}