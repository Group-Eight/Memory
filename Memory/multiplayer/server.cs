using System.Diagnostics;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Text;
using System.Windows.Media.TextFormatting;
using System.Windows.Media;

namespace Memory {
    class Server {

        private List<Label> uiComponents = new List<Label> { };

        private List<string> content = new List<string> { "playerOne", "playerTwo", "Highscore: 2:07", "VS" };
        private List<List<int>> positions = new List<List<int>> { 
            new List<int> { 480, 540 },
            new List<int> { 1440, 540 },
            new List<int> { 480, 900 },
            new List<int> { 960, 540 }
        };

        public Server() {
            // Constructor
        }

        public void sendMessage(Socket socket, string message) {
            byte[] byData = Encoding.ASCII.GetBytes(message);
            socket.Send(byData);
        }

        public string receiveMessage(Socket sock) {
            byte[] receiver = new byte[1024];
            int byteRecv = sock.Receive(receiver);
            return Encoding.ASCII.GetString(receiver, 0, byteRecv);
        }
    }
}
