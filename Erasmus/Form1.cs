using System;
using System.Collections;
using System.Windows.Forms;
using LanMessengerLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.IO;
using System.Runtime.Remoting.Channels.Tcp;
using LanMessengerChatRoomBase;
using System.Net;

namespace Erasmus
{
    public partial class Form1 : Form
    {
       HttpChannel channel;
       string hostIP;
        
        private string[] setting = new string[6];
        public Form1()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            InitializeComponent();
            if (File.Exists("UserSetting.dat"))
                ReadUserSetting();
            else
                setting[5] = "1";

            channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel);

            statusBar.Text = "Setting...";
            if (File.Exists("NetSetting.Dat"))
            {
                FileStream fs = new FileStream("NetSetting.Dat", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                hostIP = br.ReadString();
                fs.Close();
                br.Close();
            }
            else
            {
                hostIP = "127.0.0.1";
            }
            statusBar.Text = "Successful.";
            try
            {
                MarshalByRefObject obj = (MarshalByRefObject)RemotingServices.Connect(typeof(IServer), "http://" + hostIP + ":9090/Server");
                Global.server = obj as IServer;
                (obj as RemotingClientProxy).Timeout = 5000;
            }
            catch
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();
            SignIn();
        }
        private void UpdatePanelContact()
        {
            statusBar.Text = "Download list friend from server...";
            ArrayList contacts = null;
            try
            {
                contacts = Global.server.GetContacts(Global.username);
            }
            catch
            {
                AbortConnection();
                return;
            }
            statusBar.Text = "Successful download.";
            Label lblInfo = new Label();
            lblInfo.Text = "List friend :";
            lblInfo.Location = new System.Drawing.Point(8, 4);
            lblInfo.Size = new System.Drawing.Size(200, 16);
            pnlContacts.Controls.Clear();
            Global.contactList.Clear();
            pnlContacts.Controls.Add(lblInfo);
            int i = 20;
            statusBar.Text = "Update list friend...";
            foreach (object o in contacts)
            {
                LanMessengerControls.LanMessengerContact temp = new LanMessengerControls.LanMessengerContact();
                temp.DisplayName = Global.server.GetfullName(o as string);
                temp.Contact = o as string;
                statusBar.Text = "Adding " + o as string;
                try
                {
                    temp.Online = Global.server.IsVisible(o as String);
                }
                catch
                {
                    AbortConnection();
                    return;
                }
                temp.Location = new System.Drawing.Point(8, i);
                temp.Size = new System.Drawing.Size(pnlContacts.Width - 32, 16);
                temp.DoubleClick += new System.EventHandler(this.Contact_Click);
                temp.ContextMenu = conMenu;

                pnlContacts.Controls.Add(temp);
                Global.contactList.Add(temp);
                i += 18;
            }
            CreateAutoCompleteTextBox(); 
            statusBar.Text = "Update successful.";
        }
        private void SignIn()
        {
            notifyIcon.ContextMenu = null;
            statusBar.Text = "Sign in";
            lblWelcome.Text = "Not sign in";
            FormSignIN frmSignIn = new FormSignIN();
            switch (frmSignIn.ShowDialog(this))
            {
                case DialogResult.OK:
                    Global.username = frmSignIn.txtUsername.Text;
                    try
                    {
                        ArrayList offline = Global.server.ReceiveOffline(Global.username);
                        if (offline.Count > 0)
                        {
                            FormOfflineMessage frmOffline = new FormOfflineMessage(offline);
                            frmOffline.Show();
                        }
                    }
                    catch
                    {
                        AbortConnection();
                        return;
                    }

                    txtSearchName.Enabled = true;
                    rbtnOnline.Enabled = true;
                    rbtnInvisible.Enabled = true;

                    if (Global.server.IsVisible(Global.username))
                    {
                        rbtnOnline.Checked = true;
                    }
                    else
                        rbtnInvisible.Checked = true;

                    statusBar.Text = "Signed in";
                    if (Global.server.IsVisible(Global.username))
                        lblWelcome.Text = "Hello " + Global.server.GetfullName(Global.username) + "! you are online.";
                    else
                        lblWelcome.Text = "Hello " + Global.server.GetfullName(Global.username) + "! you are invisible.";
                    tmrMessageReceive.Enabled = true;
                    tmrContactUpdate.Enabled = true;

                    this.menuAddContact.Enabled = true;
                    this.menuSendMessage.Enabled = true;
                    this.menuRemoveContact.Enabled = true;
                    this.menuLogMessage.Enabled = true;
                    this.menuChangeDisplayName.Enabled = true;
                    this.menuOpenChatRoom.Enabled = true;
                    this.menuJoinRoom.Enabled = true;
                    this.menuChangeUser.Text = "Sign in with another account...";
                    this.menuSignOut.Enabled = true;
                    this.pnlContacts.ContextMenu = this.conMenuContactsPanel;

                    this.notMenuSend.Enabled = true;
                    this.notMenuSignIn.Text = "Sign in with another account...";
                    this.notMenuSignOut.Enabled = true;

                    this.UpdatePanelContact();
                    break;
            }
            notifyIcon.ContextMenu = this.notifyMenu;
        }
        private void AbortConnection()
        {
            tmrMessageReceive.Enabled = false;
            tmrContactUpdate.Enabled = false;

            this.menuAddContact.Enabled = false;
            this.menuSendMessage.Enabled = false;
            this.menuRemoveContact.Enabled = false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
            this.menuChangeUser.Text = "Sign in...";
            this.menuSignOut.Enabled = false;
            this.pnlContacts.ContextMenu = null;

            this.notMenuSend.Enabled = false;
            this.notMenuSignIn.Text = "Sign in...";
            this.notMenuSignOut.Enabled = false;

            ArrayList a = new ArrayList();
            foreach (string key in Global.windowList.Keys)
                a.Add(key);
            foreach (string key in a)
                (Global.windowList[key] as FormMessage).Close();
            Global.username = "";
            pnlContacts.Controls.Clear();
            Global.contactList.Clear();
            this.Focus();
        }
        private void SignOut()
        {
            ArrayList a = new ArrayList();
            foreach (string key in Global.windowList.Keys)
                a.Add(key);
            foreach (string key in a)
                (Global.windowList[key] as FormMessage).Close();

            this.txtSearchName.Enabled = false;
            rbtnOnline.Enabled = false;
            rbtnInvisible.Enabled = false;
            this.txtSearchName.Clear();
            this.menuAddContact.Enabled = false;
            this.menuSendMessage.Enabled = false;
            this.menuRemoveContact.Enabled = false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
            this.menuChangeUser.Text = "Sign in...";
            this.menuSignOut.Enabled = false;
            this.pnlContacts.ContextMenu = null;
            this.notMenuSend.Enabled = false;
            this.notMenuSignIn.Text = "Sign in...";
            this.notMenuSignOut.Enabled = false;
            tmrMessageReceive.Enabled = false;
            tmrContactUpdate.Enabled = false;
            if (setting[5] == "2")
                DeleteAllLogs();
            try
            {
                Global.server.SignOut(Global.username);
                statusBar.Text = "Signed out.";
            }
            catch
            {
                AbortConnection();
                return;
            }
            finally
            {
                pnlContacts.Controls.Clear();
                Global.contactList.Clear();
                Global.username = "";

            }
        }

        private void OpenFormMessage(string contact)
        {
            if (Global.windowList.Contains(contact))
            {
                ((FormMessage)Global.windowList[contact]).Focus();
            }
            else
            {
                FormMessage frmMessage = new FormMessage();
                frmMessage.contact = contact;
                frmMessage.Text = Global.server.GetfullName(contact) + " (" + contact + ")" + " - online message.";
                frmMessage.Show();
                Global.windowList.Add(contact, frmMessage);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Dispose();
            ChannelServices.UnregisterChannel(channel);
            try
            {
                if (setting[5] == "2")
                    DeleteAllLogs();
                Global.server.SignOut(Global.username);
            }
            finally
            {
                Application.Exit();
            }
        }

        private void menuSendMessage_Click(object sender, EventArgs e)
        {
            using (FormSelectContact frmContact = new FormSelectContact())
            {
                if (frmContact.ShowDialog(this) == DialogResult.OK)
                {
                    if (frmContact.txtContact.Text == Global.username)
                    {
                        MessageBox.Show("You can't send yourself!");
                        return;
                    }
                    if (Global.windowList.Contains(frmContact.txtContact.Text))
                    {
                        ((FormMessage)Global.windowList[frmContact.txtContact.Text]).Focus();
                    }
                    else
                    {
                        FormMessage frmMessage = new FormMessage();
                        frmMessage.contact = frmContact.txtContact.Text;
                        frmMessage.Text = frmContact.txtContact.Text + " - online message.";
                        Global.windowList.Add(frmContact.txtContact.Text, frmMessage);
                        frmMessage.Show();
                    }
                }
            }
        }
        private void Contact_Click(object sender, System.EventArgs e)
        {
            OpenFormMessage(((LanMessengerControls.LanMessengerContact)sender).Contact);
        }
        private void tmrMessageReceive_Tick(object sender, EventArgs e)
        {
            LetterReceive letter;
            try
            {
                letter = Global.server.Receive(Global.username);
            }
            catch
            {
                AbortConnection();
                return;
            }
            if (letter.From == "")
            {
                return;
            }
            if (Global.windowList.Contains(letter.From))
            {
                if (letter.Message == "BUZZ IT")
                {
                    ((FormMessage)Global.windowList[letter.From]).Focus();
                }
                ((FormMessage)Global.windowList[letter.From]).AddText(letter.From, letter.Message);

            }
            else
            {
                FormMessage frmMessage = new FormMessage();
                frmMessage.contact = letter.From;
                frmMessage.Text = letter.From + " - online messageS.";
                frmMessage.AddText(letter.From, letter.Message);
                Global.windowList.Add(letter.From, frmMessage);
                frmMessage.Show();
            }
        }

        private void menuAddContact_Click(object sender, EventArgs e)
        {
            FormAddContact frmAddContact = new FormAddContact();
            if (frmAddContact.ShowDialog() == DialogResult.OK)
            {
                UpdatePanelContact();
            }
        }

        private void menuLogMessage_Click(object sender, EventArgs e)
        {
            FormLogReader f = new FormLogReader();
            f.Show();
        }

        private void menuRemoveContact_Click(object sender, EventArgs e)
        {
            FormSelectContact frmSelectContact = new FormSelectContact();
            if (frmSelectContact.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Global.server.RemoveContact(Global.username, frmSelectContact.txtContact.Text);
                    UpdatePanelContact();
                }
                catch
                {
                    AbortConnection();
                    return;
                }
            }
        }

        private void menuChangeUser_Click(object sender, EventArgs e)
        {
            try
            {
                Global.server.SignOut(Global.username);
                if (setting[5] == "2")
                    DeleteAllLogs();
                pnlContacts.Controls.Clear();
                Global.contactList.Clear();
                this.txtSearchName.Enabled = false;
                rbtnOnline.Enabled = false;
                rbtnInvisible.Enabled = false;
                this.txtSearchName.Clear();
                this.menuAddContact.Enabled = false;
                this.menuSendMessage.Enabled = false;
                this.menuRemoveContact.Enabled = false;
                this.menuLogMessage.Enabled = false;
                this.menuChangeDisplayName.Enabled = false;
                this.menuOpenChatRoom.Enabled = false;
                this.menuJoinRoom.Enabled = false;
                this.menuChangeUser.Text = "Sign in...";
                this.menuSignOut.Enabled = false;
                this.pnlContacts.ContextMenu = null;
                this.notMenuSend.Enabled = false;
                this.notMenuSignIn.Text = "Sign in...";
                this.notMenuSignOut.Enabled = false;
                tmrMessageReceive.Enabled = false;
                tmrContactUpdate.Enabled = false;
            }
            finally
            {
                SignIn();
            }
        }

        private void menuSignOut_Click(object sender, EventArgs e)
        {
            Global.server.SignOut(Global.username);
            if (setting[5] == "2")
                DeleteAllLogs();
            pnlContacts.Controls.Clear();
            Global.contactList.Clear();
            Global.username = "";
            this.txtSearchName.Enabled = false;
            rbtnOnline.Enabled = false;
            rbtnInvisible.Enabled = false;
            this.txtSearchName.Clear();
            this.menuAddContact.Enabled = false;
            this.menuSendMessage.Enabled = false;
            this.menuRemoveContact.Enabled = false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
            this.menuChangeUser.Text = "Sign in...";
            this.menuSignOut.Enabled = false;
            this.pnlContacts.ContextMenu = null;
            this.notMenuSend.Enabled = false;
            this.notMenuSignIn.Text = "Sign in...";
            this.notMenuSignOut.Enabled = false;
            tmrMessageReceive.Enabled = false;
            tmrContactUpdate.Enabled = false;
            SignIn();
        }

        private void menuMin_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon.BalloonTipTitle = "LAN MESSENGER!";
            notifyIcon.BalloonTipText = "Minimized.";
            notifyIcon.ShowBalloonTip(2000);
            this.notMenuMin.Enabled = false;
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (setting[5] == "2")
                    DeleteAllLogs();
                Global.server.SignOut(Global.username); 
            }
            finally
            {
                Application.Exit();
            }
        }
        private void DeleteAllLogs()
        {
            if (Global.username != "")
            {
                string path = "logs/" + Global.username + "/";
                if (Directory.Exists(path))
                {
                    string[] directoryContact = Directory.GetDirectories(path);
                    foreach (string dc in directoryContact)
                    {
                        string[] fileLogs = Directory.GetFiles(dc);
                        foreach (string fl in fileLogs)
                        {
                            File.Delete(fl);
                        }
                        Directory.Delete(dc);
                    }
                    Directory.Delete(path); 
                }
            }
        }
        private void CreateAutoCompleteTextBox()
        {
            string[] arrayContact = new string[Global.contactList.Count]; 
            int i = 0;
            foreach (object o in Global.contactList)
            {
                arrayContact[i] = ((LanMessengerControls.LanMessengerContact)o).Contact.ToString();
                i++;
            }

            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (string name in arrayContact)
            {
                auto.Add(name + " (" + Global.server.GetfullName(name) + ")");
            }
            txtSearchName.AutoCompleteCustomSource = auto;
        }
        public void ReadUserSetting()
        {
            FileStream fs1 = new FileStream("UserSetting.dat", FileMode.Open);
            BinaryReader w1 = new BinaryReader(fs1);
            setting[0] = w1.ReadString().ToString(); 
            setting[1] = w1.ReadString().ToString();
            setting[2] = w1.ReadString().ToString();
            setting[3] = w1.ReadString().ToString();
            setting[4] = w1.ReadString().ToString();
            setting[5] = w1.ReadString().ToString(); 
            w1.Close();
            fs1.Close();
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            FormOption fo = new FormOption();
            fo.Show();
        }

        private void menuNetworkSettings_Click(object sender, EventArgs e)
        {
            FormNetworkSetting frmNetworkSettings = new FormNetworkSetting();
            frmNetworkSettings.txtIP.Text = hostIP;
            if (frmNetworkSettings.ShowDialog() == DialogResult.OK)
            {
                hostIP = frmNetworkSettings.txtIP.Text;
                try
                {
                    AbortConnection();
                    MarshalByRefObject obj = (MarshalByRefObject)RemotingServices.Connect(typeof(IServer), "http://" + hostIP + ":9090/Server");
                    Global.server = obj as IServer;
                }
                catch
                {
                    AbortConnection();
                    return;
                }
            }
        }

        private void menuChangeDisplayName_Click(object sender, EventArgs e)
        {
            ChangeDisplayName fcdn = new ChangeDisplayName();
            fcdn.Show();
        }
        private void GoOnline(string ContactName)
        {
            TrayBalloon.TrayBalloon tb = new TrayBalloon.TrayBalloon();
            tb.BackgroundLocation = "background.bmp";
            if (File.Exists(setting[1]))
                tb.SoundLocation = setting[1];
            else
                tb.SoundLocation = "sounds/Online.wav";
            tb.Title = "Lan Messenger!";
            tb.Message = Global.server.GetfullName(ContactName) + " đã Online!";
            tb.Run();
        }
        bool Check = false;
        private void GoOffline(string ContactName)
        {
            TrayBalloon.TrayBalloon tb = new TrayBalloon.TrayBalloon();
            tb.BackgroundLocation = "background.bmp";
            if (File.Exists(setting[2]))
                tb.SoundLocation = setting[2];
            else
                tb.SoundLocation = "sounds/Offline.wav";
            tb.Title = "Lan Messenger!";
            tb.Message = Global.server.GetfullName(ContactName) + " Offline!";
            tb.Run();
        }
        private void menuMusicOnline_Click(object sender, EventArgs e)
        {
            FormMusicPlayer fmp = new FormMusicPlayer();
            fmp.Show();
        }

        private void menuOpenChatRoom_Click(object sender, EventArgs e)
        {
            channelChatRoom = new TcpChannel(7070);
            ChannelServices.RegisterChannel(channelChatRoom, false); 
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(SampleObject), Global.username.ToString(), WellKnownObjectMode.Singleton); 
            if (OpenRoom() == 0)
            {
                ChannelServices.UnregisterChannel(channelChatRoom);
                channelChatRoom = null;
            }
        }
        TcpChannel chan;
        private int OpenRoom()
        {
            ArrayList alOnlineUser = new ArrayList();
            FormChatRoom objChatWin;

            if (true)
            {
                chan = new TcpChannel();
                chan = null;
                IPHostEntry temp = Dns.GetHostByName(Dns.GetHostName().ToString());
                string IP = temp.AddressList[0].ToString();
                objChatWin = new FormChatRoom();
                objChatWin.MyGetData = new FormChatRoom.GetString(GetValue);
                objChatWin.remoteObj = (SampleObject)Activator.GetObject(typeof(LanMessengerChatRoomBase.SampleObject), "tcp://" + IP + ":7070/" + Global.username);

                if (!objChatWin.remoteObj.JoinToChatRoom(Global.username))
                {
                    MessageBox.Show(Global.username + " Signed in!");
                    ChannelServices.UnregisterChannel(chan);
                    chan = null;
                    objChatWin.Dispose();
                    return 1;
                }
                objChatWin.key = objChatWin.remoteObj.CurrentKeyNo();
                objChatWin.yourName = Global.username;
                objChatWin.Show();
                return 2;
            }
            else
            {
                MessageBox.Show("Error");
                chan = null;
                return 0; // 0: Loi
            }
        }
        private void menuJoinRoom_Click(object sender, EventArgs e)
        {
            FormJoinRoom fjr = new FormJoinRoom();
            fjr.Show();
        }
        bool ChatRoomClosed = false;
        public void GetValue(Boolean b)
        {
            ChatRoomClosed = b;
            if (ChatRoomClosed)
                ChannelServices.UnregisterChannel(channelChatRoom);
        }

        TcpChannel channelChatRoom;
        private void menuItem14_Click(object sender, EventArgs e)
        {
            if (File.Exists("help.chm"))
                System.Diagnostics.Process.Start("help.chm");
            else
                MessageBox.Show("Cant find help.chm", "Error");
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void tmrContactUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (object o in Global.contactList)
                {
                    if (((LanMessengerControls.LanMessengerContact)o).Online != Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact)) Check = !Check;
                    ((LanMessengerControls.LanMessengerContact)o).Online = Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact);
                    if (Check)
                    {
                        if (Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact))
                            GoOnline((o as LanMessengerControls.LanMessengerContact).Contact.ToString());
                        else GoOffline((o as LanMessengerControls.LanMessengerContact).Contact.ToString());
                        Check = !Check;
                    }
                }
                pnlContacts.Update();
            }
            catch
            {
                AbortConnection();
                return;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pnlContacts.Width = this.Width - 24;
            pnlContacts.Height = this.Height - 88;
        }

        private void pnlContacts_Resize(object sender, EventArgs e)
        {
            foreach (object o in Global.contactList)
            {
                ((LanMessengerControls.LanMessengerContact)o).Width = pnlContacts.Width - 32;
            }
        }

        private void rbtnOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOnline.Checked == true && !Global.server.IsVisible(Global.username))
            {
                Global.server.ChangeStatus(Global.username);
                lblWelcome.Text = "Hello " + Global.server.GetfullName(Global.username) + "! You are Online.";
            }
        }

        private void rbtnInvisible_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInvisible.Checked == true && Global.server.IsVisible(Global.username))
            {
                Global.server.ChangeStatus(Global.username);
                lblWelcome.Text = "Hello " + Global.server.GetfullName(Global.username) + "! You are invisible.";
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchName.Text != "" && txtSearchName.Text != "Enter friend name...")
            {
                OpenFormMessage(txtSearchName.Text.Substring(0, txtSearchName.Text.IndexOf('(') - 1));
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void txtSearchName_Click(object sender, EventArgs e)
        {
            this.txtSearchName.Clear();
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.ForeColor = System.Drawing.SystemColors.MenuText;
        }

        private void txtSearchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchName.Text.IndexOf('(') != -1)
                    OpenFormMessage(txtSearchName.Text.Substring(0, txtSearchName.Text.IndexOf('(') - 1)); // Mở khung chat tới Contact vừa tìm
                this.txtSearchName.Clear();
                this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtSearchName.ForeColor = System.Drawing.SystemColors.WindowFrame;
                this.txtSearchName.Text = "Enter friend name...";
            }
        }
    }

    class Global
    {
        internal static IServer server;
        internal static Hashtable windowList;
        internal static ArrayList contactList;
        internal static string username;

        static Global()
        {
            windowList = new Hashtable();
            contactList = new ArrayList();
            username = "";
        }
    }
}
