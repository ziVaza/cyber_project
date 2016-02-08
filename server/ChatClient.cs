using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Server
{
    /// <summary>
    /// The ChatClient class represents info about each client connecting to the server.
    /// </summary>
    class ChatClient 
    {
        SqlUtility sql;
        string[] log = new string[2];
        // Store list of all clients connecting to the server
        // the list is static so all memebers of the chat will be able to obtain list
        // of current connected client
        public static Hashtable AllClients = new Hashtable();
        int cnt = 0;
        // information about the client
        private TcpClient _client;

        // used for sending and reciving data
        private byte[] data;

        // the nickname being sent
        private bool ReceiveNick = false;
        bool flag = true;

        /// <summary>
        /// When the client gets connected to the server the server will create an instance of the ChatClient and pass the TcpClient
        /// </summary>
        /// <param name="client"></param>
        

        public ChatClient(TcpClient client)
        {
            sql = new SqlUtility();
            _client = client;
            // Read data from the client async
            data = new byte[_client.ReceiveBufferSize];
            Makenull(log);
            // BeginRead will begin async read from the NetworkStream
            // This allows the server to remain responsive and continue accepting new connections from other clients
            // When reading complete control will be transfered to the ReviveMessage() function.
            _client.GetStream().BeginRead(data,
                                          0,
                                          System.Convert.ToInt32(_client.ReceiveBufferSize),
                                          ReceiveMessage,
                                          null);
        }

        /// <summary>
        /// allow the server to send message to the client.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            try
            {
                System.Net.Sockets.NetworkStream ns;

                // we use lock to present multiple threads from using the networkstream object
                // this is likely to occur when the server is connected to multiple clients all of 
                // them trying to access to the networkstram at the same time.
                lock (_client.GetStream())
                {
                    ns = _client.GetStream();
                }

                // Send data to the client
                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message);
                ns.Write(bytesToSend, 0, bytesToSend.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void ReceiveMessage(IAsyncResult ar)
        {

            int bytesRead;
            try
            {
                Broadcast("message");
                lock (_client.GetStream())
                {
                    // call EndRead to handle the end of an async read.
                    bytesRead = _client.GetStream().EndRead(ar);
                }
                // if bytesread<1 -> the client disconnected
                if (bytesRead < 1)
                {
                    // remove the client from out list of clients
                    //AllClients.Remove(_clientIP);
                    // tell everyone the client left the chat.
                    //Broadcast(_ClientNick + " has left the chat.");
                    return;
                }
                else // client still connected
                {
                    if (flag)
                    {
                        string messageReceived = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                        // if the client is sending its nickname

                        if (log[0] != null && log[1] == null)
                        {
                            log[1] = messageReceived;
                            if (sql.UserExist(log[0], log[1]))
                            {
                                Broadcast("OK");
                                flag = false;
                            }
                            else
                            {
                                Makenull(log);
                                Broadcast("Wrong Username or Password");
                            }
                        }

                        if (log[0] == null)
                        {
                            log[0] = messageReceived;
                        }


                        // send message to everyone
                        //Broadcast(messageReceived);

                        if (cnt == 2)
                        {
                            Broadcast("OK");
                        }
                    }
                    else
                    {
                        StreamReader reader = new StreamReader(_client.GetStream());

                        // The first message from the client is the file size    
                        string cmdFileSize = reader.ReadLine();

                        // The first message from the client is the filename    
                        string cmdFileName = reader.ReadLine();

                        int length = cmdFileSize.Length;
                        byte[] buffer = new byte[length];
                        int received = 0;
                        int read = 0;
                        int size = 1024;
                        int remaining = 0;

                        // Read bytes from the client using the length sent from the client    
                        while (received < length)
                        {
                            remaining = length - received;
                            if (remaining < size)
                            {
                                size = remaining;
                            }

                            read = _client.GetStream().Read(buffer, received, size);
                            received += read;
                        }

                        // Save the file using the filename sent by the client    
                        using (FileStream fStream = new FileStream(Path.GetFileName(cmdFileName), FileMode.Create))
                        {
                            fStream.Write(buffer, 0, buffer.Length);
                            fStream.Flush();
                            fStream.Close();
                        }
                    }
                    lock (_client.GetStream())
                    {
                        // continue reading form the client
                        _client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(_client.ReceiveBufferSize), ReceiveMessage, null);
                    }

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// send message to all the clients that are stored in the allclients hashtable
        /// </summary>
        /// <param name="message"></param>
        public void Broadcast(string message)
        {
            Console.WriteLine(message);
            SendMessage(message + Environment.NewLine);

        }

        public void Makenull(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = null;
            }
        }
    }
}

