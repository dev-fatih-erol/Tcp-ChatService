using System.Net;
using System.Net.Sockets;
using ChatService.Tcp;

namespace ChatService.Test
{
    public class EchoTcpServer : TcpServer
    {
        public bool Started { get; set; }
        public bool Stopped { get; set; }
        public bool Connected { get; set; }
        public bool Disconnected { get; set; }
        public int Clients { get; set; }
        public bool Errors { get; set; }

        public EchoTcpServer(IPAddress address, int port) : base(address, port) { }

        protected override TcpSession CreateSession() { return new EchoTcpSession(this); }

        protected override void OnStarted() { Started = true; }
        protected override void OnStopped() { Stopped = true; }
        protected override void OnConnected(TcpSession session) { Connected = true; Clients++; }
        protected override void OnDisconnected(TcpSession session) { Disconnected = true; Clients--; }
        protected override void OnError(SocketError error) { Errors = true; }
    }
}