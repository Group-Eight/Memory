using System.Net.Sockets;
using System.Text;

namespace Memory {
    class Server {
        public Server() {
            // Constructor
        }

        public void sendMessage() {

        }

        public string receiveMessage(Socket sock) {
            byte[] receiver = new byte[1024];
            int byteRecv = sock.Receive(receiver);
            return Encoding.ASCII.GetString(receiver, 0, byteRecv);
        }
    }
}