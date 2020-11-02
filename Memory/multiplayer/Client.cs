using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;

namespace Memory {
    class Client {

        Server server = new Server();

        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint ipEndPoint;

        bool _turn = false;
        public bool isTurn { get { return _turn; } set { _turn = value; } }

        public Socket Sender { get; }

        public Client() {
            this.ipHost = Dns.GetHostEntry(Dns.GetHostName());
            this.ipAddr = ipHost.AddressList[0];
            this.ipEndPoint = new IPEndPoint(this.ipAddr, 11111);

            this.Sender = new Socket(this.ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        // Connect to the host
        public bool connectTo() {
            try {
                this.Sender.Connect(this.ipEndPoint);
            } catch (Exception e) { return false; }
            return true;
        }
        
        // Receive data from host connection
        public string receive() {
            string data = this.server.receiveMessage(this.Sender);
            return data;
        }

        // Send data to host connection
        public void send(string message) { this.server.sendMessage(this.Sender, message); }

        // Disconnect from the host connection
        public void Disconnect() { this.Sender.Disconnect(true); }
    }
}
