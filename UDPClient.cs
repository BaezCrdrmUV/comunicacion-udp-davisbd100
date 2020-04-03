using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ComunicationUDP
{
    class UDPClient
    {
        public UdpClient Client { get; set; }
        
        public UDPClient(String ip, int port)
        {
            Client = new UdpClient(ip, port);
        }

        public void SendMessage()
        {
            try
            {
                while(true)
                {
                    Console.WriteLine("Ingrese un mensaje para el servidor");
                    String message = Console.ReadLine();
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);  
                    Console.WriteLine("Enviando mensaje...");
                    Client.Send(data, data.Length);
                    Console.WriteLine("Mensaje enviado");
                    if (message == "bye")
                    {
                        Console.WriteLine("Cerrando conexion");
                        break;
                    }
                }
            }catch (SocketException)
            {
                Console.WriteLine("Error al conectar al servidor");
            }
        }

    }
}
