using System.Net.Sockets;

namespace ChatService.Test
{
    public class EchoTcpClient : ChatService.Tcp.TcpClient
    {
        public bool Connected { get; set; }
        public bool Disconnected { get; set; }
        public bool Errors { get; set; }

        public EchoTcpClient(string address, int port) : base(address, port) { }

        protected override void OnConnected() { Connected = true; }
        protected override void OnDisconnected() { Disconnected = true; }
        protected override void OnError(SocketError error) { Errors = true; }
    }
}