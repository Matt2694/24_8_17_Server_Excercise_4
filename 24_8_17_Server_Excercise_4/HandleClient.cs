using System;
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

        private byte[] ReceiveFromClient()
        {
            byte[] buffer = new byte[1024];
            clSock.Receive(buffer);
            return buffer;
        }

        private void SendToClient(string str)
        {
            byte[] msg = Encoding.ASCII.GetBytes(str);
            clSock.Send(msg);
        }

        public void EchoHandler()
        {
            EchoService echoService = new EchoService();

            //using Sockets

            //try
            //{
            //    IPEndPoint remoteIPEndPoint = clSock.RemoteEndPoint as IPEndPoint;
            //    IPEndPoint localIPEndPoint = clSock.LocalEndPoint as IPEndPoint;

            //    byte[] buffer = ReceiveFromClient();
            //    while (buffer.Length > 0)
            //    {
            //        string str = Encoding.ASCII.GetString(buffer);
            //        int i = str.IndexOf('\0');
            //        str = str.Substring(0, i);
            //        string[] commandArray = str.Split(' ');
            //        if (commandArray[0] == "Echo" || commandArray[0] == "echo")
            //        {
            //            str = EchoService.Echo(commandArray[1]);
            //        }
            //        else if (commandArray[0] == "EchoUpper" || commandArray[0] == "echoupper")
            //        {
            //            str = EchoService.EchoUpper(commandArray[1]);
            //        }
            //        else
            //        {
            //            str = "Invalid Command";
            //        }
            //        SendToClient(str);
            //        buffer = ReceiveFromClient();
            //    }
            //    clSock.Shutdown(SocketShutdown.Both);
            //    clSock.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //using Tcp

            try
            {
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;

                while (true)
                {
                    string msg = reader.ReadLine();
                    string[] commandArray = msg.Split(' ');
                    if (commandArray[0] == "Echo" || commandArray[0] == "echo")
                    {
                        msg = echoService.Echo(commandArray[1]);
                    }
                    else if (commandArray[0] == "EchoUpper" || commandArray[0] == "echoupper")
                    {
                        msg = echoService.EchoUpper(commandArray[1]);
                    }
                    else if (commandArray[0] == "EchoLast")
                    {
                        msg = echoService.EchoLast();
                    }
                    else
                    {
                        msg = "Invalid Command";
                    }
                    writer.WriteLine(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}