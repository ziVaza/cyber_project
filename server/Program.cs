using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        const int portNo = 500;
        private const string ipAddress = "10.27.208.94";

        static void Main(string[] args)
        {

            System.Net.IPAddress localAdd = System.Net.IPAddress.Parse(ipAddress);
            TcpListener listener = new TcpListener(localAdd, portNo);

            Console.WriteLine("Simple TCP Server");
            Console.WriteLine("Listening to ip {0} port: {1}", ipAddress, portNo);
            Console.WriteLine("Server is ready.");

            // Start listen to incoming connection requests
            listener.Start();

            // infinit loop.
            while (true)
            {
                // AcceptTcpClient - Blocking call
                // Execute will not continue until a connection is established

                // We create an instance of ChatClient so the server will be able to 
                // server multiple client at the same time.
                ChatClient user = new ChatClient(listener.AcceptTcpClient());
            }
        }
    }
}
