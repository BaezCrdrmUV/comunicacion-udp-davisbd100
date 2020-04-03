using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ComunicationUDP
{
    class UDPServer
    {
        public Socket NewSocket { get; set; }
        public int Recv { get; set; }

        public UDPServer(String Ip, int port)
        {
            byte[] data = new byte[1024];

            Console.WriteLine("Iniciando servidor UDP...");
            NewSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            NewSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            NewSocket.Bind(new IPEndPoint(IPAddress.Parse(Ip), port));
            Console.WriteLine("Servidor iniciado, esperando por un cliente...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, port);
            EndPoint remote = (EndPoint)sender;
            String message = String.Empty;
            while (true)
            {
                Recv = NewSocket.ReceiveFrom(data, ref remote);
                Console.WriteLine("Mensaje recibido de: " + remote.ToString());
                message = Encoding.ASCII.GetString(data, 0, Recv);
                Console.WriteLine(message);
                if (message == "bye")
                {
                    break;
                }
            }
            
            Console.WriteLine("Cerrando servidor");
            NewSocket.Close();
        }
    }
}
