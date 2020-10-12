using System;
using System.Collections.Generic;
using System.Resources;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Controls;

namespace Memory {
    class Host {

        Server server;

        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint ipEndPoint;

        public Socket Listener { get; }

        public Socket client { get; set; }

        public Host() {
            // Constructor
            this.server = new Server();
            this.ipHost = Dns.GetHostEntry(Dns.GetHostName());
            this.ipAddr = ipHost.AddressList[0];
            this.ipEndPoint = new IPEndPoint(ipAddr, 11111);

            Listener = new Socket(this.ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public bool creation() {
            try {
                Listener.Bind(this.ipEndPoint);
                Listener.Listen(10);
            } catch (Exception e) { return false; }
            return true;
        }

        public string receive() {
            string data = null;
            this.client = Listener.Accept();
            while (true) {
                data += this.server.receiveMessage(this.client);
                if (data.IndexOf("<EOF>") >= -1) break;
            }
            this.client.Close();
            return data;
        }

        public void send(string message) {
            this.client = Listener.Accept();
            this.server.sendMessage(this.client, message);
            this.client.Close();
        }

        public void CloseConnection() {
            this.Listener.Close();
        }
    }
}