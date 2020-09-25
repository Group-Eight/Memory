using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Memory {
    class Server {
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