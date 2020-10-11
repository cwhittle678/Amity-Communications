using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Net.Security;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Media;


namespace GUI
{
   
    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = "";

        double d;

        double n;
        public static string IPz;

        static RSAParameters serverPubKey;

        public Form1()
        {
            InitializeComponent();
        }

        public static class Globals
        {
            public static IPAddress ipAddress = IPAddress.Parse(IPz);
            public static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            public static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8050);
            public static Socket Sender;

            public static bool running = false;
            public static string data = null;

           public static RSAParameters myPubKey;
           public static RSAParameters myPrivKey;
        }

//********************************************************************************************************************
        private void Form1_Load(object sender, EventArgs e)
        {
            ChatCB.SelectedIndex = 0;
            ActiveTB.BackColor = Color.Red;
            ExitB.Hide();
            SendB.Enabled = false;
            InputTB.Enabled = false;
            ChatCB.Enabled = false;


        }
//********************************************************************************************************************
        private void JoinB_Click(object sender, EventArgs e)
        {
            string dataFromServer = "";
            if (InitTB.Text.ToUpper() == "CSW")
            {
                if (PassTB.Text != "cpass")
                {
                    MessageBox.Show("Password Incorrect.");
                    return;
                }
            }
            else if (InitTB.Text.ToUpper() == "PSM")
            {

                if (PassTB.Text != "ppass")
                {
                    MessageBox.Show("Password Incorrect.");
                    return;
                }
            }

            else if (InitTB.Text.ToUpper() == "DRR")
            {

                if (PassTB.Text != "dpass")
                {
                    MessageBox.Show("Password Incorrect.");
                    return;
                }
            }

            else if (InitTB.Text.ToUpper() == "JJM")
            {

                if (PassTB.Text != "jpass")
                {
                    MessageBox.Show("Password Incorrect.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("User not registered.");
                return;
            }
                int NumInit = InitTB.Text.Length;
            if (NumInit == 3)
            {
                byte[] bytes = new byte[1024];
                string S = "";
                try
                {
                    clientSocket.Connect(IPz, 54206);
                    serverStream = clientSocket.GetStream();

                    string output = "3" + InitTB.Text + "$";
                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes(output);
                    serverStream.Write(outStream, 0, outStream.Length);

                    Thread.Sleep(500);

                    serverStream.Read(bytes, 0, bytes.Length);
                    dataFromServer = System.Text.Encoding.ASCII.GetString(bytes);
                    dataFromServer = dataFromServer.Substring(0, dataFromServer.IndexOf("$"));
                    serverStream.Flush();
                    //get a stream from the string
                    var sr = new System.IO.StringReader(dataFromServer);
                    //we need a deserializer
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    //get the object back from the stream
                    serverPubKey = (RSAParameters)xs.Deserialize(sr);

                    var csp = new RSACryptoServiceProvider(2048);

                    //how to get the private key
                    Globals.myPrivKey = csp.ExportParameters(true);

                    //and the public key ...
                    Globals.myPubKey = csp.ExportParameters(false);

                    string myPubKeyString;
                    {
                        //we need some buffer
                        var sw = new System.IO.StringWriter();
                        //we need a serializer
                        var x = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                        //serialize the key into the stream
                        x.Serialize(sw, Globals.myPubKey);
                        //get the string from the stream
                        myPubKeyString = sw.ToString();


                    }
                    Thread.Sleep(500);

                    byte[] Stream = System.Text.Encoding.ASCII.GetBytes(myPubKeyString + "$");
                    serverStream.Write(Stream, 0, Stream.Length);

                    Thread ctThread = new Thread(getMessage);
                    ctThread.Start();
                    Globals.running = true;
                    JoinB.Enabled = false;
                    InitTB.Enabled = false;
                    SendB.Enabled = true;
                    InputTB.Enabled = true;
                    ChatCB.Enabled = true;
                    ActiveTB.BackColor = Color.Green;
                    ActiveL.Text = "Chat\nActive";
                    ExitB.Show();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                
            }
            else
                System.Windows.Forms.MessageBox.Show("Initials must be\n3 characters");
        }
//********************************************************************************************************************
        private void ChooseChatCLB_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < ChooseChatCLB.Items.Count; ++ix)
                if (ix != e.Index) ChooseChatCLB.SetItemChecked(ix, false);

        }
//********************************************************************************************************************
        private void ExitB_Click(object sender, EventArgs e)
        {

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(InitTB.Text + "_QUITTING$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            System.Windows.Forms.MessageBox.Show("You have left the chat...");

            ChatATB.Text = String.Empty;
            ChatBTB.Text = String.Empty;
            ChatCTB.Text = String.Empty;
            InputTB.Text = String.Empty;
            InitTB.Text = String.Empty;
            ActiveL.Text = "Chat\nInactive";
            ActiveTB.BackColor = Color.Red;

            JoinB.Enabled = true;
            InitTB.Enabled = true;

            ExitB.Hide();
            clientSocket.GetStream().Close();
        }
//********************************************************************************************************************
        private void JoinChatTB_TextChanged(object sender, EventArgs e)
        {

            IPz = JoinChatTB.Text;
        }
//********************************************************************************************************************
        private void JoinChatTB_Click(object sender, EventArgs e)
        {
            if (JoinChatTB.Text == "IP Address")
            {
                JoinChatTB.Text = "";
                JoinChatTB.ForeColor = Color.Black;
            }
        }
//********************************************************************************************************************
        private void InitTB_TextChanged_1(object sender, EventArgs e)
        {
            int NumInit = InitTB.Text.Length;
            if (NumInit != 3)
                InitTB.BackColor = Color.Red;
            else
                InitTB.BackColor = Color.Green;
        }
//********************************************************************************************************************


        private void SendB_Click_1(object sender, EventArgs e)
        {            
            //Encryption


            int NumInit = InitTB.Text.Length;
            if (NumInit == 3)
            {
                try
                {
                    string S = "";
                    S = ChatCB.SelectedIndex + InitTB.Text + InputTB.Text;

                    //    //we have a public key ... let's get a new csp and load that key
                    var csp = new RSACryptoServiceProvider();
                    csp.ImportParameters(serverPubKey);

                    //for encryption, always handle bytes...
                    var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(S);

                    //apply pkcs#1.5 padding and encrypt our data 
                    var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);

                    //we might want a string representation of our cypher text... base64 will do
                    var cypherText = Convert.ToBase64String(bytesCypherText);


                    //SENDING
                    var outStream = System.Text.Encoding.ASCII.GetBytes(cypherText + "$");
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                    InputTB.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }

            }
            else
                System.Windows.Forms.MessageBox.Show("Initials must be\n3 characters");
        }
//********************************************************************************************************************
        private void getMessage()
        {
            try
            {
                while (true)
                {
                    serverStream = clientSocket.GetStream();

                    double[] decrypted = new double[1024];
                    int buffSize = 0;
                    byte[] inStream = new byte[10025];
                    buffSize = clientSocket.ReceiveBufferSize;
                    serverStream.Read(inStream, 0, inStream.Length);
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    returndata = returndata.Substring(0, returndata.LastIndexOf("$"));
                    var csp = new RSACryptoServiceProvider();
                    csp.ImportParameters(Globals.myPrivKey);
                    var bytesCypherText = Convert.FromBase64String(returndata);



                    //decrypt and strip pkcs#1.5 padding
                    var bytesPlainTextData = csp.Decrypt(bytesCypherText, false);
                    readData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

                    msg();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
//********************************************************************************************************************
        private void msg()
        {

            string S = ChatCB.SelectedIndex + InitTB.Text + InputTB.Text;
            string MessID = readData.Substring(1, 3);
            string outputText = readData.Substring(4);
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                switch ((int)Char.GetNumericValue(readData[0]))
                {
                    case 0:
                        ChatATB.AppendText(MessID + ": " + outputText);
                        ChatATB.Text += "\r\n";
                        break;
                    case 1:
                        ChatBTB.AppendText(MessID + ": " + outputText);
                        ChatBTB.Text += "\r\n";
                        break;
                    case 2:
                        ChatCTB.AppendText(MessID + ": " + outputText);
                        ChatCTB.Text += "\r\n";
                        break;
                    case 3:
                        readData = readData.Substring(1, readData.Length - 1);
                        ChatATB.AppendText(readData + Environment.NewLine);
                        ChatBTB.AppendText(readData + Environment.NewLine);
                        ChatCTB.AppendText(readData + Environment.NewLine);
                        ChatATB.Text += "\r\n";
                        ChatBTB.Text += "\r\n";
                        ChatCTB.Text += "\r\n";
                        break;

                }
        }

        private void LaunchB_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"D:\FINAL SYSTEM3.0\ServerTest\ServerTest\bin\Debug\netcoreapp2.0\win10-x64\ServerTest.exe";

            //startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
            Process.Start(startInfo);
        }

        private void ChatATB_TextChanged(object sender, EventArgs e)
        {
            ChatATB.SelectionStart = ChatATB.TextLength;
            ChatATB.ScrollToCaret();
        }

        private void ChatBTB_TextChanged(object sender, EventArgs e)
        {
            ChatBTB.SelectionStart = ChatBTB.TextLength;
            ChatBTB.ScrollToCaret();
        }

        private void ChatCTB_TextChanged(object sender, EventArgs e)
        {
            ChatCTB.SelectionStart = ChatCTB.TextLength;
            ChatCTB.ScrollToCaret();
        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void PassTB_TextChanged(object sender, EventArgs e)
        {
            int NumChar = PassTB.Text.Length;
            if (NumChar != 0)
                PassTB.BackColor = Color.Green;
            else
                PassTB.BackColor = Color.Red;
        }


        //********************************************************************************************************************
    }
}
    