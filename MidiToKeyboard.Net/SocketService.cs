using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MidiToKeyboard.Net
{
    public class SocketService : Socket
    {
        public static Socket Client;
        public void SendMessage(string message)
        {
            Client?.Send(Encoding.ASCII.GetBytes(message));

        }
        public static SocketService CreateSocketService(string ip, int port = 8887)
        {
            IPAddress ipaddress = IPAddress.Parse(ip);
            var serverSocket = new SocketService(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ipaddress, port));  //绑定IP地址：端口
            serverSocket.Listen(10);    //设定最多10个排队连接请求  
                                        //通过Clientsoket发送数据  
            Thread myThread = new Thread(()=>
        {
            while (true)
            {
                Client = serverSocket.Accept();
                Client.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
               
            }
        }   );
            myThread.Start();
            return serverSocket;
        }
       

        private SocketService(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : base(addressFamily, socketType, protocolType)
        {
        }
    }
}
