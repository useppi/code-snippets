namespace AlpineBitsTestClient
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRequest = new System.Windows.Forms.RichTextBox();
            this.txtResponse = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtMessagePWD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.cBGZIP = new System.Windows.Forms.CheckBox();
            this.cBGZIPSend = new System.Windows.Forms.CheckBox();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(13, 181);
            this.txtRequest.MaxLength = 3276700;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(624, 564);
            this.txtRequest.TabIndex = 6;
            this.txtRequest.Text = "";
            this.txtRequest.TextChanged += new System.EventHandler(this.txtRequest_TextChanged);
            this.txtRequest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRequest_KeyDown);
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(646, 218);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.Size = new System.Drawing.Size(639, 527);
            this.txtResponse.TabIndex = 10;
            this.txtResponse.Text = "no result";
            this.txtResponse.TextChanged += new System.EventHandler(this.txtResponse_TextChanged);
            this.txtResponse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResponse_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Process request to server >>>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Action:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Url to AlpineBits Server Endpoint:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "OTA Request message (RQ)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(643, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "SERVERS OTA response message (RS):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "X-AlpineBits-ClientID";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(219, 15);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(242, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(219, 41);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(242, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtMessagePWD
            // 
            this.txtMessagePWD.Location = new System.Drawing.Point(219, 67);
            this.txtMessagePWD.Name = "txtMessagePWD";
            this.txtMessagePWD.Size = new System.Drawing.Size(242, 20);
            this.txtMessagePWD.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "X-AlpineBits-ClientProtocolVersion";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(219, 94);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(242, 20);
            this.txtCompanyName.TabIndex = 4;
            // 
            // cBGZIP
            // 
            this.cBGZIP.AutoSize = true;
            this.cBGZIP.Checked = true;
            this.cBGZIP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBGZIP.Location = new System.Drawing.Point(646, 63);
            this.cBGZIP.Name = "cBGZIP";
            this.cBGZIP.Size = new System.Drawing.Size(235, 17);
            this.cBGZIP.TabIndex = 8;
            this.cBGZIP.Text = "Include \"Accept-Encoding: gzip\" in Request";
            this.cBGZIP.UseVisualStyleBackColor = true;
            // 
            // cBGZIPSend
            // 
            this.cBGZIPSend.AutoSize = true;
            this.cBGZIPSend.Checked = true;
            this.cBGZIPSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBGZIPSend.Location = new System.Drawing.Point(646, 87);
            this.cBGZIPSend.Name = "cBGZIPSend";
            this.cBGZIPSend.Size = new System.Drawing.Size(232, 17);
            this.cBGZIPSend.TabIndex = 9;
            this.cBGZIPSend.Text = "POST Request Message as GZIP to Server";
            this.cBGZIPSend.UseVisualStyleBackColor = true;
            // 
            // cbAction
            // 
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Items.AddRange(new object[] {
            "getVersion",
            "getCapabilities",
            "OTA_HotelAvailNotif:FreeRooms",
            "OTA_HotelInvNotif:Inventory",
            "OTA_Read:GuestRequests",
            "OTA_NotifReport:GuestRequests",
            "OTA_HotelRatePlanNotif:RatePlans",
            "OTA_HotelRatePlanNotif:SimplePackages"});
            this.cbAction.Location = new System.Drawing.Point(54, 141);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(289, 21);
            this.cbAction.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(362, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 34);
            this.button3.TabIndex = 27;
            this.button3.Text = "Validate XSD";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(646, 34);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(622, 20);
            this.txtServer.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 757);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cbAction);
            this.Controls.Add(this.cBGZIPSend);
            this.Controls.Add(this.cBGZIP);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMessagePWD);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.txtRequest);
            this.Name = "Form1";
            this.Text = "Generic AlpineBits TestClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtRequest;
        private System.Windows.Forms.RichTextBox txtResponse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtMessagePWD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.CheckBox cBGZIP;
        private System.Windows.Forms.CheckBox cBGZIPSend;
        private System.Windows.Forms.ComboBox cbAction;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

