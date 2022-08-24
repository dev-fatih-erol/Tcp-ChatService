﻿using System.Net;
using System.Net.Sockets;
using ChatService.Server.Sessions;
using ChatService.Tcp;

namespace ChatService.Server.Servers
{
    public class ChatServer : TcpServer
    {
        public ChatServer(IPAddress address, int port) : base(address, port) { }

        protected override TcpSession CreateSession() { return new ChatSession(this); }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP server caught an error with code {error}");
        }
    }
}