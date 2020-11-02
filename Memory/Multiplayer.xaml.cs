using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Page {

        Host host = new Host();
        Client client = new Client();

        StackPanel panel = new StackPanel();

        bool isHost = true;
        bool isConnected = false;

        string play;

        public Multiplayer() {
            InitializeComponent();
            // If player is host create the server & check if there is a client connected.
            if (isHost) { 
                this.host.creation();
                for(;;) {
                    if (this.host.connected()) {
                        this.isConnected = true; 
                        break;
                    }
                }
            }
            // If player is a client connect to host and send "ping" when done.
            if (!isHost) {
                this.client.connectTo(); 
                this.client.send("ping");
                this.isConnected = true;
            }
            // If there is a connection render the multiplayer lobby.
            if (this.isConnected) {
                if (this.isHost) this.Play.Visibility = Visibility.Visible;
                this.PlayerOne.Visibility = Visibility.Visible;
                this.PlayerTwo.Visibility = Visibility.Visible;
                this.Highscore1.Visibility = Visibility.Visible;
                this.Highscore2.Visibility = Visibility.Visible;
            }
        }

        protected void onClickPlay(object sender, RoutedEventArgs e) {

        }

        protected void initializeHost() {
            switch (this.host.isTurn) {
                case false:
                    for (;;) {
                        string message = this.host.receive();
                        if (message != null && message != "over" && message != "") this.play = message;
                        else if (message.Equals("over")) break;
                    }
                    this.host.isTurn = true;
                    break;
                case true:
                    Console.WriteLine("Host - New turn");
                    this.host.send("over");
                    this.host.isTurn = false;
                    break;
            }
        }

        protected void initializeClient() {
            switch (this.client.isTurn) {
                case false:
                    this.client.connectTo();
                    for (;;) {
                        string message = this.client.receive();
                        if (message != null && message != "over" && message != "") this.play = message;
                        else if (message.Equals("over")) break;
                    }
                    this.client.Disconnect();
                    this.client.isTurn = true;
                    break;
                case true:
                    Console.WriteLine("Client - New turn");
                    this.client.connectTo();
                    this.client.send("over");
                    this.client.Disconnect();
                    this.client.isTurn = false;
                    break;
            }
        }
    }
}
