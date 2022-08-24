using System.Net.Sockets;
using ChatService.Tcp;

namespace ChatService.Test
{
    public class EchoTcpSession : TcpSession
    {
        public bool Connected { get; set; }
        public bool Disconnected { get; set; }
        public bool Errors { get; set; }

        public EchoTcpSession(TcpServer server) : base(server) { }

        protected override void OnConnected() { Connected = true; }
        protected override void OnDisconnected() { Disconnected = true; }
        protected override void OnReceived(byte[] buffer, long offset, long size) { SendAsync(buffer, offset, size); }
        protected override void OnError(SocketError error) { Errors = true; }
    }
}