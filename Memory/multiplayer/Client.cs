using System;
using System.Collections.Generic;
using System.Resources;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Memory {
    class Client {
        public Client() {
            // Constructor
        }

        public void Execute() {
            while (true) {
                try {
                    IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                    // Grab the first IP address
                    IPAddress ipAddr = ipHost.AddressList[0];
                    // Get the IP & Port
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11111);

                    // Create a socket with the given configuration
                    Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    try {
                        // Connect to the Host his socket
                        sender.Connect(ipEndPoint);

                        Console.WriteLine("Connected to the host...");

                        // Create a message to send to the Host
                        byte[] message = Encoding.ASCII.GetBytes("Client says hi");
                        // Send the message
                        int byteSend = sender.Send(message);

                        // Create the variable for the receiving message
                        byte[] receiver = new byte[1024];
                        // Store the received message
                        int byteRecv = sender.Receive(receiver);

                        // Write the message to the console - Debug reasons
                        Console.WriteLine("Message -> {0}", Encoding.ASCII.GetString(receiver, 0, byteRecv));

                        //sender.Shutdown(SocketShutdown.Both);
                        //sender.Close();
                    }
                    catch (ArgumentNullException ane) {
                        Console.WriteLine("ArgumentNullException : {0}", ane.ToString()); 
                    } 
                    catch (SocketException se) {
                        Console.WriteLine("SocketException : {0}", se.ToString()); 
                        break;
                    } 
                    catch (Exception e) { 
                        Console.WriteLine("Unexpected exception : {0}", e.ToString()); 
                    } 
                }
                catch (Exception e) { 
                    Console.WriteLine(e.ToString()); 
                } 
            }
        }
    }
}