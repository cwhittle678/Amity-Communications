/*******************************
          Server EXE
   ECE369 Computer Networks
*******************************/
using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        public static Hashtable clientsList = new Hashtable();
        static void Main(string[] args)
        {
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = @"\ServerTest.exe";
            start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //Server doesnt pop up when created in GUI
            TcpListener serverSocket = new TcpListener(8050);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;
            serverSocket.Start();
            Console.WriteLine("Chat Server Started ....");
            counter = 0;
            while ((true)) //Server accepts new users
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                byte[] bytesFrom = new byte[10025];
                string dataFromClient = null;
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                clientsList.Add(dataFromClient, clientSocket); //Adds new client to list of all clients
                broadcast("3**" + dataFromClient.Substring(1) + " Joined**", dataFromClient, false);
                Console.WriteLine(dataFromClient.Substring(1) + " Joined chat room ");
                handleClient client = new handleClient();
                client.startClient(clientSocket, dataFromClient.Substring(1), clientsList);
            }
            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }
        public static void broadcast(string msg, string uName, bool flag) //Sends message to clients
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;
                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length); //Sends the encoded bytes through the stream
                broadcastStream.Flush();
            }
        }  
    }
    public class handleClient //Class holding client information
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;
        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = cList;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
        }
        private void doChat() //A message was sent from a client
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;
            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$")); //Gets users full message

                    if (dataFromClient.Substring(3) == "_QUITTING") //If user pressed the exit button
                    {
                        clientsList.Remove(dataFromClient.Substring(0, 3)); //Removed from hashtable
                        Console.WriteLine("CLIENT LEAVING: " + dataFromClient.Substring(0, 3));
                        rCount = Convert.ToString(requestCount);
                        Program.broadcast("3**" + dataFromClient.Substring(0, 3) + " has left the chat**", clNo, true); //Sends message of who left
                        return;
                    }
                    else if (dataFromClient.Length == 4) //If user sent empty message
                    {
                        //Dont send empty message
                    }
                    else //User sent a normal message
                    {
                        Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
                        rCount = Convert.ToString(requestCount);
                        Program.broadcast(dataFromClient, clNo, true); //Sends message to clients
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    } 
}