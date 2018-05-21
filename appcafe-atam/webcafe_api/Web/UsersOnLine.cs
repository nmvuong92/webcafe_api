using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Web
{
    public class UsersOnLine : Hub
    {
        static List<string> users = new List<string>();

        //mỗi khi kết nối
        public override Task OnConnected()
        {
            string clientId = GetClientId();

            if (users.IndexOf(clientId) == -1)
            {
                users.Add(clientId);
            }

            ShowUsersOnLine();

            return base.OnConnected();
        }

        //kết nối lại
        public override Task OnReconnected()
        {
            string clientId = GetClientId();
            if (users.IndexOf(clientId) == -1)
            {
                users.Add(clientId);
            }

            ShowUsersOnLine();

            return base.OnReconnected();
        }

        //ngắt kết nối
        public override Task OnDisconnected()
        {
            string clientId = GetClientId();

            if (users.IndexOf(clientId) > -1)
            {
                users.Remove(clientId);
            }

            ShowUsersOnLine();
            return base.OnDisconnected();
        }

        //lấy clients
        private string GetClientId()
        {
            string clientId = "";
            if (Context.QueryString["clientId"] != null)
            {
                //clientId passed from application
                clientId = Context.QueryString["clientId"];
            }

            if (clientId.Trim() == "")
            {
                //default clientId: connectionId
                clientId = Context.ConnectionId;
            }
            return clientId;
        }

        public void Log(string message)
        {
            Clients.All.log(message);
        }
        //hiển thị user online
        public void ShowUsersOnLine()
        {
            Clients.All.showUsersOnLine(users.Count);
        }

        public void showMsg(string msg)
        {
            Clients.All.showMsg(msg);
        }
    }
}