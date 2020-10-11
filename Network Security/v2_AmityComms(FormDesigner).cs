namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PassTB = new System.Windows.Forms.TextBox();
            this.JoinChatTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.InitTB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.JoinB = new System.Windows.Forms.Button();
            this.LaunchB = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ChooseChatCLB = new System.Windows.Forms.CheckedListBox();
            this.ChatATB = new System.Windows.Forms.TextBox();
            this.ChatCTB = new System.Windows.Forms.TextBox();
            this.ChatBTB = new System.Windows.Forms.TextBox();
            this.ExitB = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ChatCB = new System.Windows.Forms.ComboBox();
            this.InputTB = new System.Windows.Forms.TextBox();
            this.SendB = new System.Windows.Forms.Button();
            this.ActiveTB = new System.Windows.Forms.TextBox();
            this.ActiveL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BackgroundImage = global::GUI.Properties.Resources.dark_wood_grain_3;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PassTB);
            this.panel1.Controls.Add(this.JoinChatTB);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.InitTB);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.JoinB);
            this.panel1.Controls.Add(this.LaunchB);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 90);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(506, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 26);
            this.label1.TabIndex = 26;
            this.label1.Text = "Password";
            // 
            // PassTB
            // 
            this.PassTB.BackColor = System.Drawing.Color.Red;
            this.PassTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassTB.Location = new System.Drawing.Point(620, 48);
            this.PassTB.Multiline = true;
            this.PassTB.Name = "PassTB";
            this.PassTB.Size = new System.Drawing.Size(116, 33);
            this.PassTB.TabIndex = 25;
            this.PassTB.TextChanged += new System.EventHandler(this.PassTB_TextChanged);
            // 
            // JoinChatTB
            // 
            this.JoinChatTB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.JoinChatTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinChatTB.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.JoinChatTB.Location = new System.Drawing.Point(322, 40);
            this.JoinChatTB.Multiline = true;
            this.JoinChatTB.Name = "JoinChatTB";
            this.JoinChatTB.Size = new System.Drawing.Size(178, 29);
            this.JoinChatTB.TabIndex = 18;
            this.JoinChatTB.Text = "IP Address";
            this.JoinChatTB.Click += new System.EventHandler(this.JoinChatTB_Click);
            this.JoinChatTB.TextChanged += new System.EventHandler(this.JoinChatTB_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(256, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 26);
            this.label7.TabIndex = 17;
            this.label7.Text = "OR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(327, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 26);
            this.label6.TabIndex = 16;
            this.label6.Text = "Join Chat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 52);
            this.label5.TabIndex = 15;
            this.label5.Text = "Launch \r\nNew Chat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(495, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 26);
            this.label8.TabIndex = 24;
            this.label8.Text = "Initials (3 char)";
            this.label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // InitTB
            // 
            this.InitTB.BackColor = System.Drawing.Color.Red;
            this.InitTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InitTB.Location = new System.Drawing.Point(654, 11);
            this.InitTB.Multiline = true;
            this.InitTB.Name = "InitTB";
            this.InitTB.Size = new System.Drawing.Size(82, 33);
            this.InitTB.TabIndex = 20;
            this.InitTB.TextChanged += new System.EventHandler(this.InitTB_TextChanged_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OliveDrab;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(8, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 133);
            this.panel2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(688, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 79);
            this.button1.TabIndex = 4;
            this.button1.Text = "JOIN";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(688, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 62);
            this.button2.TabIndex = 3;
            this.button2.Text = "LAUNCH";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "<None>"});
            this.checkedListBox1.Location = new System.Drawing.Point(166, 82);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(490, 79);
            this.checkedListBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(490, 62);
            this.textBox1.TabIndex = 1;
            // 
            // JoinB
            // 
            this.JoinB.BackColor = System.Drawing.Color.Gray;
            this.JoinB.Location = new System.Drawing.Point(742, 11);
            this.JoinB.Name = "JoinB";
            this.JoinB.Size = new System.Drawing.Size(111, 52);
            this.JoinB.TabIndex = 4;
            this.JoinB.Text = "JOIN";
            this.JoinB.UseVisualStyleBackColor = false;
            this.JoinB.Click += new System.EventHandler(this.JoinB_Click);
            // 
            // LaunchB
            // 
            this.LaunchB.BackColor = System.Drawing.Color.Gray;
            this.LaunchB.Location = new System.Drawing.Point(126, 11);
            this.LaunchB.Name = "LaunchB";
            this.LaunchB.Size = new System.Drawing.Size(111, 52);
            this.LaunchB.TabIndex = 3;
            this.LaunchB.Text = "LAUNCH";
            this.LaunchB.UseVisualStyleBackColor = false;
            this.LaunchB.Click += new System.EventHandler(this.LaunchB_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3.Location = new System.Drawing.Point(0, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 15);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(-3, 584);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(873, 17);
            this.panel4.TabIndex = 9;
            // 
            // ChooseChatCLB
            // 
            this.ChooseChatCLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseChatCLB.FormattingEnabled = true;
            this.ChooseChatCLB.Items.AddRange(new object[] {
            "Chat A",
            "Chat B",
            "Chat C"});
            this.ChooseChatCLB.Location = new System.Drawing.Point(412, 302);
            this.ChooseChatCLB.Name = "ChooseChatCLB";
            this.ChooseChatCLB.Size = new System.Drawing.Size(95, 67);
            this.ChooseChatCLB.TabIndex = 5;
            this.ChooseChatCLB.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChooseChatCLB_ItemCheck);
            // 
            // ChatATB
            // 
            this.ChatATB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ChatATB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatATB.Location = new System.Drawing.Point(104, 132);
            this.ChatATB.Multiline = true;
            this.ChatATB.Name = "ChatATB";
            this.ChatATB.ReadOnly = true;
            this.ChatATB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatATB.Size = new System.Drawing.Size(225, 428);
            this.ChatATB.TabIndex = 6;
            this.ChatATB.TextChanged += new System.EventHandler(this.ChatATB_TextChanged);
            // 
            // ChatCTB
            // 
            this.ChatCTB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ChatCTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ChatCTB.Location = new System.Drawing.Point(602, 132);
            this.ChatCTB.Multiline = true;
            this.ChatCTB.Name = "ChatCTB";
            this.ChatCTB.ReadOnly = true;
            this.ChatCTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatCTB.Size = new System.Drawing.Size(225, 428);
            this.ChatCTB.TabIndex = 10;
            this.ChatCTB.TextChanged += new System.EventHandler(this.ChatCTB_TextChanged);
            // 
            // ChatBTB
            // 
            this.ChatBTB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ChatBTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ChatBTB.Location = new System.Drawing.Point(353, 132);
            this.ChatBTB.Multiline = true;
            this.ChatBTB.Name = "ChatBTB";
            this.ChatBTB.ReadOnly = true;
            this.ChatBTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBTB.Size = new System.Drawing.Size(225, 428);
            this.ChatBTB.TabIndex = 11;
            this.ChatBTB.TextChanged += new System.EventHandler(this.ChatBTB_TextChanged);
            // 
            // ExitB
            // 
            this.ExitB.BackColor = System.Drawing.Color.Red;
            this.ExitB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitB.Location = new System.Drawing.Point(12, 264);
            this.ExitB.Name = "ExitB";
            this.ExitB.Size = new System.Drawing.Size(79, 74);
            this.ExitB.TabIndex = 18;
            this.ExitB.Text = "Exit \r\nChat";
            this.ExitB.UseVisualStyleBackColor = false;
            this.ExitB.Click += new System.EventHandler(this.ExitB_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(121, 622);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 26);
            this.label10.TabIndex = 26;
            this.label10.Text = "Message";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 635);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 26);
            this.label9.TabIndex = 25;
            this.label9.Text = "Chat #";
            // 
            // ChatCB
            // 
            this.ChatCB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ChatCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChatCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatCB.FormattingEnabled = true;
            this.ChatCB.Items.AddRange(new object[] {
            "Chat A",
            "Chat B",
            "Chat C"});
            this.ChatCB.Location = new System.Drawing.Point(12, 664);
            this.ChatCB.Name = "ChatCB";
            this.ChatCB.Size = new System.Drawing.Size(98, 33);
            this.ChatCB.TabIndex = 23;
            // 
            // InputTB
            // 
            this.InputTB.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.InputTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTB.Location = new System.Drawing.Point(126, 651);
            this.InputTB.Multiline = true;
            this.InputTB.Name = "InputTB";
            this.InputTB.Size = new System.Drawing.Size(610, 62);
            this.InputTB.TabIndex = 19;
            // 
            // SendB
            // 
            this.SendB.BackColor = System.Drawing.Color.CadetBlue;
            this.SendB.Location = new System.Drawing.Point(742, 651);
            this.SendB.Name = "SendB";
            this.SendB.Size = new System.Drawing.Size(111, 62);
            this.SendB.TabIndex = 21;
            this.SendB.Text = "SEND";
            this.SendB.UseVisualStyleBackColor = false;
            this.SendB.Click += new System.EventHandler(this.SendB_Click_1);
            // 
            // ActiveTB
            // 
            this.ActiveTB.BackColor = System.Drawing.Color.Red;
            this.ActiveTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActiveTB.Location = new System.Drawing.Point(37, 222);
            this.ActiveTB.Multiline = true;
            this.ActiveTB.Name = "ActiveTB";
            this.ActiveTB.ReadOnly = true;
            this.ActiveTB.Size = new System.Drawing.Size(25, 25);
            this.ActiveTB.TabIndex = 19;
            // 
            // ActiveL
            // 
            this.ActiveL.AutoSize = true;
            this.ActiveL.BackColor = System.Drawing.Color.Transparent;
            this.ActiveL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActiveL.ForeColor = System.Drawing.Color.White;
            this.ActiveL.Location = new System.Drawing.Point(12, 167);
            this.ActiveL.Name = "ActiveL";
            this.ActiveL.Size = new System.Drawing.Size(87, 52);
            this.ActiveL.TabIndex = 19;
            this.ActiveL.Text = "Chat \r\nInactive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(99, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Chat A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(348, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "Chat B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(597, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Chat C";
            // 
            // Form1
            // 
            this.AcceptButton = this.SendB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::GUI.Properties.Resources.bigstock_Dark_carbon_fiber_background_157510367;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(865, 725);
            this.Controls.Add(this.ActiveL);
            this.Controls.Add(this.ActiveTB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ChatCB);
            this.Controls.Add(this.InputTB);
            this.Controls.Add(this.SendB);
            this.Controls.Add(this.ExitB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChatBTB);
            this.Controls.Add(this.ChatCTB);
            this.Controls.Add(this.ChatATB);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ChooseChatCLB);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Amity Communications";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button JoinB;
        private System.Windows.Forms.Button LaunchB;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox ChooseChatCLB;
        private System.Windows.Forms.TextBox ChatATB;
        private System.Windows.Forms.TextBox ChatCTB;
        private System.Windows.Forms.TextBox ChatBTB;
        private System.Windows.Forms.Button ExitB;
        private System.Windows.Forms.TextBox JoinChatTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ChatCB;
        private System.Windows.Forms.TextBox InitTB;
        private System.Windows.Forms.TextBox InputTB;
        private System.Windows.Forms.Button SendB;
        private System.Windows.Forms.TextBox ActiveTB;
        private System.Windows.Forms.Label ActiveL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PassTB;
    }
}

