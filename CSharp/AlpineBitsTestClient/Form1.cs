using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO.Compression;
using System.Xml;
using System.Configuration;
using System.Xml.Schema;
using System.Drawing;


namespace AlpineBitsTestClient
{
    public partial class Form1 : Form
    {
        string sXSDValidationErrorString ="";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResponse.Text = "";
            button1.Text = "Loading ....";
            this.Refresh();
            string password = txtPassword.Text;
            string url = txtServer.Text;
            string username = txtUsername.Text;
          

            // OTA_INVENTORY
            var content = new MultipartFormDataContent(Guid.NewGuid().ToString());
            //Note: it's a best practice to use double-quotes, even when the name doesn't contain spaces:
            content.Add(new StringContent(cbAction.SelectedItem.ToString()), "\"action\"");
            string RequestXML = txtRequest.Text;
            if (cbAction.SelectedItem.ToString() != "getVersion" && cbAction.SelectedItem.ToString() != "getCapabilities")
                content.Add(new StringContent(RequestXML), "\"request\"");
            HttpResponseMessage result;

            // Client: acceptEncoding gzIP
            HttpClientHandler clHandler = new HttpClientHandler();
            if (cBGZIP.Checked)
                clHandler.AutomaticDecompression = DecompressionMethods.GZip;


            using (var client = new HttpClient(clHandler))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password))));
                client.DefaultRequestHeaders.Add("X-AlpineBits-ClientProtocolVersion", txtCompanyName.Text);
                client.DefaultRequestHeaders.Add("X-AlpineBits-ClientID", txtMessagePWD.Text);
                if (cBGZIPSend.Checked)
                    result = client.PostAsync(url, new CompressedContent(content, "gzip")).Result;
                else
                {
                    //                    client.DefaultRequestHeaders.TransferEncoding.Add(new TransferCodingHeaderValue("chunked"));
                    //                    client.DefaultRequestHeaders.TransferEncoding.Add(new TransferCodingHeaderValue("gzip"));
                    result = client.PostAsync(url, content).Result;
                }
            }

            if (result.StatusCode == HttpStatusCode.OK)
            {
                txtResponse.Text = result.Content.ReadAsStringAsync().Result;
            }
            else
            {
                txtResponse.Text = @"Request failed. Status code: " + result.StatusCode + ". Message Content: " + result.Content.ReadAsStringAsync().Result;
            }

            button1.Text = "Process request to server >>>";
        }

        private void txtRequest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                txtRequest.SelectAll();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbAction.SelectedItem = "getVersion";
        }

        private void btnGetCapabilities_Click(object sender, EventArgs e)
        {
            cbAction.SelectedItem = "getCapabilities";
        }

        private void btnInvASA_Click(object sender, EventArgs e)
        {
            txtRequest.Text = File.ReadAllText(@"./TestXML/Inventory_ASAHOTEL.xml");
            cbAction.SelectedItem = "OTA_HotelInvNotif:Inventory";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtRequest.Text = File.ReadAllText(@"./TestXML/GuestRequestsTest.xml");
            cbAction.SelectedItem = "OTA_Read:GuestRequests";
        }



        private void txtResponse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                txtResponse.SelectAll();
            }

        }

        private void ValidateXSD(string sXml, string XsdFilePath)
        {
            // string.Empty;
            try
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(sXml);
                sXSDValidationErrorString = "";

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add("http://www.opentravel.org/OTA/2003/05", XsdFilePath);
                settings.Schemas.Compile();
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationXSDCallBack);
                settings.ValidationType = ValidationType.Schema;

                XmlReader vreader = XmlReader.Create(new StringReader(document.OuterXml), settings);
                while (vreader.Read()) { }
                vreader.Close();

            }
            catch (Exception ex)
            {
                this.sXSDValidationErrorString = ex.Message;
            }
        }

        private void ValidationXSDCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                this.sXSDValidationErrorString += "Warning: Matching schema not found. No validation occurred (" + args.Message + ").";
            else
                this.sXSDValidationErrorString += "Validation error: " + args.Message;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ValidateXSD(txtRequest.Text, "./xsd/alpinebits2014-04.xsd");
            if (sXSDValidationErrorString.Length > 0)
                MessageBox.Show(sXSDValidationErrorString);
            else MessageBox.Show("Success!");
        }


        public string getAppSetting(string key)
        {
            //Laden der AppSettings
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Zurückgeben der dem Key zugehörigen Value
            if (config.AppSettings.Settings[key] != null)
                return config.AppSettings.Settings[key].Value;
            else return "";
        }

        public void setAppSetting(string key, string value)
        {
            //Laden der AppSettings
            Configuration config = ConfigurationManager.
                                    OpenExeConfiguration(
                                    System.Reflection.Assembly.
                                    GetExecutingAssembly().Location);
            //Überprüfen ob Key existiert
            if (config.AppSettings.Settings[key] != null)
            {
                //Key existiert. Löschen des Keys zum "überschreiben"
                config.AppSettings.Settings.Remove(key);
            }
            //Anlegen eines neuen KeyValue-Paars
            config.AppSettings.Settings.Add(key, value);
            //Speichern der aktualisierten AppSettings
            config.Save(ConfigurationSaveMode.Modified);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            setAppSetting("Username", txtUsername.Text);
            setAppSetting("Password", txtPassword.Text);
            setAppSetting("ClientID", txtMessagePWD.Text);
            setAppSetting("ProtocolVersion", txtCompanyName.Text);
            setAppSetting("Action", cbAction.Text);
            setAppSetting("Request", txtRequest.Text);
            setAppSetting("ServerUrl", txtServer.Text);
            setAppSetting("BGZIPReturn", cBGZIP.Checked ? "yes" : "no");
            setAppSetting("BGZIPSend", cBGZIPSend.Checked ? "yes" : "no");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Text = getAppSetting("Username");
            txtPassword.Text =  getAppSetting("Password");
            txtMessagePWD.Text =  getAppSetting("ClientID");
            txtCompanyName.Text = getAppSetting("ProtocolVersion");
            cbAction.Text = getAppSetting("Action");
            txtServer.Text = getAppSetting("ServerUrl");
            txtRequest.Text = getAppSetting("Request");
            cBGZIP.Checked = getAppSetting("BGZIPReturn")=="yes" ? true : false;
            cBGZIPSend.Checked = getAppSetting("BGZIPSend") == "yes" ? true : false;
        }


        // XML to string
        private string xmlToString(XmlDocument doc)
        {
            XmlDocument xd = doc;
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            XmlTextWriter xtw = null;
            try
            {
                xtw = new XmlTextWriter(sw);
                xtw.Formatting = System.Xml.Formatting.Indented;
                xd.WriteTo(xtw);
            }
            finally
            {
                if (xtw != null)
                    xtw.Close();
            }

            return sb.ToString();
        }


        //Highlights the XML in the richTextBox
        private void highlightText(RichTextBox rtb)
        {
            int Position = rtb.SelectionStart;
            int k = 0;

            string str = rtb.Text;

            int st, en;
            int lasten = -1;
            while (k < str.Length)
            {
                st = str.IndexOf('<', k);

                if (st < 0)
                    break;

                if (lasten > 0)
                {
                    rtb.Select(lasten + 1, st - lasten - 1);
                    rtb.SelectionColor = Color.Black;
                }

                en = str.IndexOf('>', st + 1);
                if (en < 0)
                    break;

                k = en + 1;
                lasten = en;

                if (str[st + 1] == '!')
                {
                    rtb.Select(st + 1, en - st - 1);
                    rtb.SelectionColor = Color.Green;
                    continue;

                }
                String nodeText = str.Substring(st + 1, en - st - 1);

                bool inString = false;

                int lastSt = -1;
                int state = 0;
                /* 0 = before node name
                 * 1 = in node name
                   2 = after node name
                   3 = in attribute
                   4 = in string
                   */
                int startNodeName = 0, startAtt = 0;
                for (int i = 0; i < nodeText.Length; ++i)
                {
                    if (nodeText[i] == '"')
                        inString = !inString;

                    if (inString && nodeText[i] == '"')
                        lastSt = i;
                    else
                        if (nodeText[i] == '"')
                        {
                            rtb.Select(lastSt + st + 2, i - lastSt - 1);
                            rtb.SelectionColor = Color.Blue;
                        }

                    switch (state)
                    {
                        case 0:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startNodeName = i;
                                state = 1;
                            }
                            break;
                        case 1:
                            if (Char.IsWhiteSpace(nodeText, i))
                            {
                                rtb.Select(startNodeName + st, i - startNodeName + 1);
                                rtb.SelectionColor = Color.Firebrick;
                                state = 2;
                            }
                            break;
                        case 2:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startAtt = i;
                                state = 3;
                            }
                            break;

                        case 3:
                            if (Char.IsWhiteSpace(nodeText, i) || nodeText[i] == '=')
                            {
                                rtb.Select(startAtt + st, i - startAtt + 1);
                                rtb.SelectionColor = Color.Red;
                                state = 4;
                            }
                            break;
                        case 4:
                            if (nodeText[i] == '"' && !inString)
                                state = 2;
                            break;
                    }
                }
                if (state == 1)
                {
                    rtb.Select(st + 1, nodeText.Length);
                    rtb.SelectionColor = Color.Firebrick;
                }
            }
            rtb.SelectionStart = Position;
            rtb.SelectionLength = 0;
        }

        private void txtRequest_TextChanged(object sender, EventArgs e)
        {
            highlightText(txtRequest);
        }

        private void txtResponse_TextChanged(object sender, EventArgs e)
        {
            highlightText(txtResponse);
        }

    }
}
