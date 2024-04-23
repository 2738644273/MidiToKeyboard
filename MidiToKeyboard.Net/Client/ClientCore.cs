using System;
using System.Collections.Generic;
using System.Linq;
using TcpClient = NetCoreServer.TcpClient;
using NetCoreServer;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;

namespace MidiToKeyboard.Net.Client
{
    public class ClientCore : TcpClient
    {
        public Action<string>? OnReceive { get; set; }
        private bool _stop;
        public ClientCore(string address, int port) : base(address, port) { }

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        protected override void OnConnected()
        {
            Debug.WriteLine($"Chat TCP client connected a new session with Id {Id}");
        }

        protected override void OnDisconnected()
        {
            Debug.WriteLine($"Chat TCP client disconnected a session with Id {Id}");

            // Wait for a while...
            Thread.Sleep(1000);

            // Try to connect again
            if (!_stop)
                ConnectAsync();
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            Debug.WriteLine(Encoding.UTF8.GetString(buffer, (int)offset, (int)size));
            OnReceive?.Invoke(Encoding.UTF8.GetString(buffer, (int)offset, (int)size));
            
        }

        protected override void OnError(SocketError error)
        {
            Debug.WriteLine($"Chat TCP client caught an error with code {error}");
        }

    }

}
