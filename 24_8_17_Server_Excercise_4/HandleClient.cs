﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _24_8_17_Server_Excercise_4
{
    internal class HandleClient
    {
        private TcpClient client;
        private Socket clSock;
        private StreamReader reader = null;
        private StreamWriter writer = null;

        public HandleClient(TcpClient newClient)
        {
            client = newClient;
        }

        public HandleClient(Socket newSocket)
        {
            clSock = newSocket;
        }

        public void Echo()
        {
            //using Sockets

            try
            {
                IPEndPoint remoteIPEndPoint = clSock.RemoteEndPoint as IPEndPoint;
                IPEndPoint localIPEndPoint = clSock.LocalEndPoint as IPEndPoint;

                byte[] buffer = new byte[1024];
                while (clSock.Receive(buffer) > 0)
                {
                    string str = Encoding.ASCII.GetString(buffer);
                    byte[] msg = Encoding.ASCII.GetBytes(str);
                    clSock.Send(msg);
                }
                clSock.Shutdown(SocketShutdown.Both);
                clSock.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //using Tcp

            //try
            //{
            //    reader = new StreamReader(client.GetStream());
            //    writer = new StreamWriter(client.GetStream());
            //    writer.AutoFlush = true;

            //    while (true)
            //    {
            //        string msg = reader.ReadLine();
            //        writer.WriteLine(msg);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}