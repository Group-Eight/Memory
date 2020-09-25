using System.Net.Sockets;

namespace Memory {
    class Server {
        public Server() {
            // Constructor
        }

        public void sendMessage() {

        }

        public string receiveMessage(Socket sock) {
            byte[] receiver = new byte[1024];
            sock.Receive(receiver);
            return 
        }
    }
}