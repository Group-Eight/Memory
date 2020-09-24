using System;
using System.Collections.Generic;
using System.Resources;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Memory {
    class Host {
        public Host() {
            // Constructor
        }
        
        public void Execute() {
            // Configuration for connection.
            // Get IP address of host
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            // Grab the first IP address
            IPAddress ipAddr = ipHost.AddressList[0];
            // Get the IP & Port
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11111);

            // Create a socket with the given configuration
            Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try {
                listener.Bind(ipEndPoint);
                listener.Listen(10);
                while (true) {
                    Console.WriteLine("Waiting for connection!");

                    Socket client = listener.Accept();

                    byte[] bytes = new Byte[1024];
                    string data = null;

                    while (true) {
                        int numByte = client.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, numByte);
                        if (data.IndexOf("<EOF>") > -1) { break; }
                    }

                    Console.WriteLine("Message received -> {0}", data);

                    byte[] message = new Byte[1024];

                    client.Send(Encoding.ASCII.GetBytes("Hello there!"));

                    client.Shutdown(SocketShutdown.Both);

                    client.Close();
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}