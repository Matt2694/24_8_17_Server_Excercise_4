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

        private void DoDialog()
        {

        }

        private void ExecuteCommand()
        {

        }

        private void ReceiveFromClient()
        {

        }

        public void RunClient()
        {

        }

        private void SendToClient()
        {

        }

        public void EchoHandler()
        {
            try
            {
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;

                while (true)
                {
                    string msg = reader.ReadLine();
                    string[] commandArray = msg.Split(' ');
                    if(commandArray[0] == "Echo" || commandArray[0] == "echo")
                    {
                        msg = Echo(commandArray[1]);
                    }
                    else if (commandArray[0] == "EchoUpper" || commandArray[0] == "echoupper")
                    {
                        msg = EchoUpper(commandArray[1]);
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

        public string Echo(string input)
        {
            return input;
        }

        public string EchoUpper(string input)
        {
            return input.ToUpper();
        }
    }
}