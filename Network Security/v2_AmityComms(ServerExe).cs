using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleApplication1
{
    static class Globals
    {
        public static RSAParameters privKey;
    }
    class Program
    {
        public static Hashtable clientsList = new Hashtable();

        public class Person
        {
            public int hash;
            public string initials;
            public string publicKey;
        }
        public static List<Person> personList = new List<Person>();

        static void Main(string[] args)
        {
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            start.FileName = @"\ServerTest.exe";
            start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            TcpListener serverSocket = new TcpListener(54206);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine("Chat Server Started ....");
            counter = 0;
            while ((true))
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();



                byte[] bytesFrom = new byte[10025];
                string dataFromClient = null;
                string clientPubKey = null;

                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                networkStream.Flush();

                //lets take a new CSP with a new 2048 bit rsa key pair
                var csp = new RSACryptoServiceProvider(2048);

                //how to get the private key
                Globals.privKey = csp.ExportParameters(true);

                //and the public key ...
                var pubKey = csp.ExportParameters(false);

                //converting the public key into a string representation
                string pubKeyString;
                {
                    //we need some buffer
                    var sw = new System.IO.StringWriter();
                    //we need a serializer
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    //serialize the key into the stream
                    xs.Serialize(sw, pubKey);
                    //get the string from the stream
                    pubKeyString = sw.ToString();


                }
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(pubKeyString + "$");

                networkStream.Write(outStream, 0, outStream.Length);

                Thread.Sleep(500);


                networkStream.Read(bytesFrom, 0, bytesFrom.Length);

                clientPubKey = System.Text.Encoding.ASCII.GetString(bytesFrom);
                clientPubKey = clientPubKey.Substring(0, clientPubKey.IndexOf("$"));

                clientsList.Add(dataFromClient, clientSocket);

                var per = new Person();
                per.hash = clientSocket.GetHashCode();
                per.initials = dataFromClient.Substring(1);
                per.publicKey = clientPubKey;
                personList.Add(per);

                broadcast("3**" + dataFromClient.Substring(1) + " Joined**", dataFromClient, false);

                Console.WriteLine(dataFromClient.Substring(1) + " Joined chat room ");
                handleClinet client = new handleClinet();
                client.startClient(clientSocket, "0"/*dataFromClient.Substring(1)*/, clientsList);



            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }

        public static void broadcast(string msg, string uName, bool flag)
        {

            foreach (DictionaryEntry Item in clientsList)
            {
                int i = 0;
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;
                while (broadcastSocket.GetHashCode() != personList[i].hash)
                {
                    i++;
                }
                var sr = new System.IO.StringReader(personList[i].publicKey);

                //we need a deserializer
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                //get the object back from the stream
                RSAParameters PubKey = (RSAParameters)xs.Deserialize(sr);
                var csp = new RSACryptoServiceProvider();
                csp.ImportParameters(PubKey);

                //for encryption, always handle bytes...
                var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(msg);

                //apply pkcs#1.5 padding and encrypt our data 
                var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

                //we might want a string representation of our cypher text... base64 will do
                var cypherText = Convert.ToBase64String(bytesCypherText);
                Console.WriteLine("\nServer Send:" + cypherText + "\n");
                broadcastBytes = System.Text.Encoding.ASCII.GetBytes(cypherText + "$");

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }  //end broadcast function
    }//end Main class


    public class handleClinet
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

        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;

            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(Globals.privKey);

            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);

                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.LastIndexOf("$"));


                    var bytesCypherText = Convert.FromBase64String(dataFromClient);



                    //decrypt and strip pkcs#1.5 padding
                    var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);
                    var PlainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

                    clNo = PlainTextData.Substring(1, 3);
                    Console.WriteLine("\nFrom " + clNo + ": " + dataFromClient + "\n");

                    //get our original plainText back...
                    if (dataFromClient.Substring(3) == "_QUITTING")
                    {
                        clientsList.Remove(dataFromClient.Substring(0, 3));
                        networkStream.Close();
                        clientSocket.Close();
                        Console.WriteLine("CLIENT LEAVING: " + dataFromClient.Substring(0, 3));
                        rCount = Convert.ToString(requestCount);
                        Program.broadcast("3**" + dataFromClient.Substring(0, 3) + " has left the chat**", clNo, true);
                        return;
                    }
                    if (dataFromClient.Length == 4)
                    {
                        //Dont send empty message
                    }
                    else
                    {
                        Console.WriteLine("From client - " + clNo + " : " + PlainTextData.Substring(4));
                        rCount = Convert.ToString(requestCount);

                        Program.broadcast(PlainTextData, clNo, true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }//end while
        }//end doChat
    } //end class handleClinet
}//end namespace
