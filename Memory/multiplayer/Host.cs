using System;
using System.Net;
using System.Net.Sockets;

namespace Memory {
    class Host {

        Server server = new Server();

        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint ipEndPoint;

        bool _turn = true;
        public bool isTurn { get { return _turn; } set { _turn = value; } }

        public Socket Listener { get; }
        public Socket Client { get; set; }

        public Host() {
            this.ipHost = Dns.GetHostEntry(Dns.GetHostName());
            this.ipAddr = ipHost.AddressList[0];
            this.ipEndPoint = new IPEndPoint(this.ipAddr, 11111);

            this.Listener = new Socket(this.ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        // Create a server where the client can connect
        public void creation() {
            try {
                this.Listener.Bind(this.ipEndPoint);
            } catch (Exception e) { return; }
            return;
        }
        
        // Check if there is a connection with a client
        public bool connected() {
            if (this.receive() == "ping") return true;
            return false;
        }

        // Receive data from the client connection
        public string receive() {
            string data = null;
            this.Listener.Listen(10);
            this.Client = this.Listener.Accept();
            for (;;) {
                data += this.server.receiveMessage(this.Client);
                if (data.IndexOf("<EOF>") >= -1) break;
            }
            this.Client.Close();
            return data;
        }

        // Send data to the client connection
        public void send(string message) {
            this.Listener.Listen(10);
            this.Client = this.Listener.Accept();
            this.server.sendMessage(this.Client, message);
            this.Client.Close();
        }

        // Close the server connection
        public void CloseConnection() { this.Listener.Close(); }
    }
}
