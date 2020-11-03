using System;
using System.Windows.Forms;
using System.Collections;
using LanMessengerChatRoomBase;

namespace Erasmus
{
    public partial class FormChatRoom : Form
    {
        internal SampleObject remoteObj;
        internal int key = 0;
        internal string yourName;
        public delegate void GetString(Boolean b);
        public GetString MyGetData;

        ArrayList alOnlineUser = new ArrayList();
        int skipCounter = 4;
        ArrayList onlineUser;
        public FormChatRoom()
        {
            InitializeComponent();
            foreach (object o in Global.contactList)
            {
                cbbListContact.Items.Add(Global.server.GetfullName(((LanMessengerControls.LanMessengerContact)o).Contact.ToString()) + " (" + ((LanMessengerControls.LanMessengerContact)o).Contact.ToString() + ")");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void SendMessage()
        {

            if (remoteObj != null && txtChatHere.Text.Trim().Length > 0)
            {
                remoteObj.SendMsgToSvr(Global.server.GetfullName(yourName) + ": " + txtChatHere.Text);
                txtChatHere.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remoteObj != null)
            {
                string tempStr = remoteObj.GetMsgFromSvr(key);
                if (tempStr.Trim().Length > 0)
                {
                    key++;
                    txtAllChat.Text = txtAllChat.Text + "\n" + tempStr;
                }
                {
                    onlineUser = remoteObj.GetOnlineUser();
                    lstOnlineUser.DataSource = onlineUser;
                    skipCounter = 0;

                    if (onlineUser.Count < 2)
                    {
                        txtChatHere.Text = "You should hae 2 participants";
                        txtChatHere.Enabled = false;
                    }
                    else if (txtChatHere.Text == "You should hae 2 participants" && txtChatHere.Enabled == false)
                    {
                        txtChatHere.Text = "";
                        txtChatHere.Enabled = true;
                    }
                }
            }
        }
    }
}
