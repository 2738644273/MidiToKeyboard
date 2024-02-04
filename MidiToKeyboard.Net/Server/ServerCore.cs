using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace MidiToKeyboard.Net.Server
{
    public class ServerCore : TcpServer
    {
        public ServerCore(IPAddress address, int port) : base(address, port) { }

        protected override TcpSession CreateSession() {
            return new Session(this); 
        }

        protected override void OnError(SocketError error)
        {
            Debug.WriteLine($"Chat TCP server caught an error with code {error}");
        }
    }
}
