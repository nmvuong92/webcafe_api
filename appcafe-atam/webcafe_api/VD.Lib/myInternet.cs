using System.Net.Sockets;

namespace VD.Lib
{
    public class myInternet
    {
        //kiểm tra kết nối internet?
         public static bool CheckInternetConnection(){
             TcpClient tcpClient = new TcpClient();
             tcpClient.Connect("maps.google.com", 80);
             return  tcpClient.Connected;
        }
    }
}
