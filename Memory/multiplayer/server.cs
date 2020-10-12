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
            this.initializeLobby();
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

        public void renderLobby(StackPanel stack) {
            int index = 0;
            stack.Background = Brushes.Gray;
            foreach (Label component in this.uiComponents) {
                component.Content = this.content[index];
                component.Height = 50;
                component.FontSize = 28;
                this.positions[index][1] -= (int)(component.Height);
                if (index > 0) {
                    //this.positions[index][0] = this.positions[index][0] - this.positions[index-1][0];
                    this.positions[index][1] = (this.positions[index][1] - this.positions[index-1][1]) - (int)(component.Height);
                }
                Console.WriteLine(this.positions[index][0] + " - " + this.positions[index][1]);
                component.Margin = new Thickness(this.positions[index][0], this.positions[index][1], 0, 0);
                stack.Children.Add(component);
                index++;
            }
            Console.WriteLine(stack);
        }

        private void initializeLobby() {
            /* Initialize all the labels */
            this.uiComponents.Add( new Label() );
            this.uiComponents.Add( new Label() );
            this.uiComponents.Add( new Label() );
            this.uiComponents.Add( new Label() );
        }
    }
}