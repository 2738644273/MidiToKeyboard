using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MidiToKeyboard.Net
{
    public class SocketClient : Socket
    {
        public void SendMessage(string message)
        {
            Send(Encoding.ASCII.GetBytes(message));

        }
        public Action<string> OnReceive { set; get; }
        private static byte[] result = new byte[1024];
        private SocketClient(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) : base(addressFamily, socketType, protocolType)
        {
        }

        public static  SocketClient CreateSocketClient(string serverip, int serverPort = 8887)
        {
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse(serverip);
            SocketClient clientSocket = new SocketClient(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            clientSocket.Connect(new IPEndPoint(ip, serverPort)); //配置服务器IP与端口  
            Debug.WriteLine("连接服务器成功");
            Task recTask = new Task(() =>
            {
               while (true)
                {
                    //通过clientSocket接收数据  
                    int receiveLength = clientSocket.Receive(result);
                     clientSocket.OnReceive?.Invoke(Encoding.ASCII.GetString(result, 0, receiveLength));
                }
            });
            recTask.Start();
            //通过 clientSocket 发送数据  
            string sendMessage = "Hello Service " + DateTime.Now;
            clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
            return clientSocket;


        }
    }
}
