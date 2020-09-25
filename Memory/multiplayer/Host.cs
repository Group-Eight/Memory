using System;
using System.Collections.Generic;
using System.Resources;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Memory {
    class Host {

        Server server = new Server();

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
                // Bind the IP & Port with the listener socket
                listener.Bind(ipEndPoint);
                listener.Listen(10);
                while (true) {
                    Console.WriteLine("Waiting for connection!");

                    // Accept the clients connection
                    Socket client = listener.Accept();

                    // Gameplay here 
                    // ---------------------

                    // Variables for the receiving message
                    string data = null;

                    while (true) {
                        data += server.receiveMessage(client);
                        if (data.IndexOf("<EOF>") >= -1) { break; }
                    }

                    // Write the message to the console - Debug reasons
                    Console.WriteLine("Message received -> {0}", data);

                    // Send the message as bytes.
                    server.sendMessage(client ,"Boodschap");

                    //client.Shutdown(SocketShutdown.Both);
                    //client.Close();
                }
            } catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}