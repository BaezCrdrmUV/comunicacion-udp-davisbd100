using System;

namespace ComunicationUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args[0] == "server")
            {
                UDPServer server = new UDPServer("127.0.0.1", 8080);

            } else if(args[0] == "client")
            {
                Console.WriteLine("Ingrese el Nombre del cliente");
                string name = Console.ReadLine();
                UDPClient client = new UDPClient("127.0.0.1", 8080);
                client.SendMessage();
            }
        }
    }
}

