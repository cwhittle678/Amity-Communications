/*******************************
     Amity Communications
   ECE369 Computer Networks
*******************************/
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
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Media;

namespace GUI
{
    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        public static string IPz;
        public Form1()
        {
            InitializeComponent();
        }
        public static class Globals //Global variables stored in class
        {
            public static IPAddress ipAddress = IPAddress.Parse(IPz);
            public static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            public static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8050);
            public static Socket Sender;

            public static bool running = false;
            public static string data = null;
        }
//*********************************************************
        private void Form1_Load(object sender, EventArgs e) //On Application startup
        {
            ChatCB.SelectedIndex = 0; //set to defaults
            ActiveTB.BackColor = Color.Red;
            ExitB.Hide();
            SendB.Enabled = false;
            InputTB.Enabled = false;
            ChatCB.Enabled = false;
        }
//*********************************************************
        private void JoinB_Click(object sender, EventArgs e) //Join chat with given IP
        {
            int NumInit = InitTB.Text.Length; //Initial length check
            if (NumInit == 3)
            {
                byte[] bytes = new byte[1024];
                string S = "";
                try
                {
                    clientSocket.Connect(IPz, 8050);
                    serverStream = clientSocket.GetStream();
                    byte[] outStream = System.Text.Encoding.ASCII.GetBytes("3" + InitTB.Text + "$"); 
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
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
                catch (Exception) //Error message for no server
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: CANT CONNECT");
                }
            }
            else //Error message for invalid Init
                System.Windows.Forms.MessageBox.Show("Initials must be\n3 characters");
        }
//*********************************************************
        private void ChooseChatCLB_ItemCheck(object sender, ItemCheckEventArgs e) //Chat selector
        {
            for (int ix = 0; ix < ChooseChatCLB.Items.Count; ++ix)
                if (ix != e.Index) ChooseChatCLB.SetItemChecked(ix, false);
        }
//*********************************************************
        private void ExitB_Click(object sender, EventArgs e) //Leaving a chat
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(InitTB.Text + "_QUITTING$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            System.Windows.Forms.MessageBox.Show("You have left the chat...");
            ChatATB.Text = String.Empty; //Reset all to default
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
//*********************************************************
        private void JoinChatTB_TextChanged(object sender, EventArgs e) //Set IPz variable on text change
        {
            IPz = JoinChatTB.Text;
        }
//*********************************************************
        private void JoinChatTB_Click(object sender, EventArgs e) //Default description in TB
        {
            if (JoinChatTB.Text == "IP Address")
            {
                JoinChatTB.Text = "";
                JoinChatTB.ForeColor = Color.Black;
            }
        }
//*********************************************************
        private void InitTB_TextChanged_1(object sender, EventArgs e) //Color effects on Init TB
        {
            int NumInit = InitTB.Text.Length;
            if (NumInit != 3)
                InitTB.BackColor = Color.Red;
            else
                InitTB.BackColor = Color.Green;
        }
//*********************************************************
        private void SendB_Click_1(object sender, EventArgs e) //Send a message
        {            
            int NumInit = InitTB.Text.Length;
            if (NumInit == 3)
            {
                string S = "";
                S = ChatCB.SelectedIndex + InitTB.Text + InputTB.Text;

                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(S + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
                InputTB.Text = String.Empty;
            }
            else
                System.Windows.Forms.MessageBox.Show("Initials must be\n3 characters");
        }
//*********************************************************
        private void getMessage() //Recieve a message
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[10025];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, inStream.Length);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                msg();
            }
        }
//*********************************************************
        private void msg() //Prints message to screen (called from getMessage)
        {
            string S = ChatCB.SelectedIndex + InitTB.Text + InputTB.Text;
            string outputText = readData.Substring(0, S.Length);
            string MessID = outputText.Substring(1, 3);
            outputText = readData.Substring(4);
            SoundPlayer simpleSound = new SoundPlayer(@"\\umdfs1.umdar.umassd.edu\studentshares$\pmcgrory\Desktop\FINAL SYSTEM2.0\GUI\msgRec.wav");
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                switch ((int)Char.GetNumericValue(readData[0])) //Choose which chat
                {
                    case 0: //Chat A
                        readData = readData.Substring(1, readData.Length - 1);
                        ChatATB.AppendText(MessID + ": " + outputText);
                        ChatATB.Text += "\r\n";
                        simpleSound.Play(); //Play sound on message
                        break;
                    case 1: //Chat B
                        readData = readData.Substring(1, readData.Length - 1);
                        ChatBTB.AppendText(MessID + ": " + outputText);
                        ChatBTB.Text += "\r\n";
                        simpleSound.Play(); //Play sound on message
                        break;
                    case 2: //Chat C
                        readData = readData.Substring(1, readData.Length - 1);
                        ChatCTB.AppendText(MessID + ": " + outputText);
                        ChatCTB.Text += "\r\n";
                        simpleSound.Play(); //Play sound on message
                        break;
                    case 3: //Chat ALL
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
//*********************************************************
        private void LaunchB_Click(object sender, EventArgs e) //Launch Server EXE
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"\\umdfs1.umdar.umassd.edu\studentshares$\pmcgrory\Desktop\FINAL SYSTEM2.0\ServerTest\ServerTest\bin\Debug\netcoreapp2.0\win10-x64\ServerTest.exe";
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
        }
//*********************************************************
        private void ChatATB_TextChanged(object sender, EventArgs e) //Scrolling funct A
        {
            ChatATB.SelectionStart = ChatATB.TextLength;
            ChatATB.ScrollToCaret();
        }
//*********************************************************
        private void ChatBTB_TextChanged(object sender, EventArgs e) //Scrolling funct B
        {
            ChatBTB.SelectionStart = ChatBTB.TextLength;
            ChatBTB.ScrollToCaret();
        }
//*********************************************************
        private void ChatCTB_TextChanged(object sender, EventArgs e) //Scrolling funct C
        {
            ChatCTB.SelectionStart = ChatCTB.TextLength;
            ChatCTB.ScrollToCaret();
        }
//*********************************************************
    }
}
