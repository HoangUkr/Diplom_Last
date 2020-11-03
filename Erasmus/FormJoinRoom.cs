using System;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using LanMessengerChatRoomBase;

namespace Erasmus
{
    public partial class FormJoinRoom : Form
    {
        public FormJoinRoom()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (txtNick.Text != "")
            {
                if (Global.server.IsVisible(txtNick.Text))
                    OpenRoom();
                else
                    MessageBox.Show("User is not online", "Error!");
            }
            else
                MessageBox.Show("Nick of creator", "Error!");
        }
        bool ChatRoomClosed = false;
        public void GetValue(Boolean b)
        {
            ChatRoomClosed = b;
            if (ChatRoomClosed)
            {
                ChannelServices.UnregisterChannel(chan);
                chan = null;
            }
        }
        TcpChannel chan;
        private void OpenRoom()
        {
            ArrayList alOnlineUser = new ArrayList();
            FormChatRoom objChatWin;

            if (chan == null)
            {
                chan = new TcpChannel();
                ChannelServices.RegisterChannel(chan, false);
                objChatWin = new FormChatRoom();
                objChatWin.MyGetData = new FormChatRoom.GetString(GetValue);
                objChatWin.remoteObj = (SampleObject)Activator.GetObject(typeof(LanMessengerChatRoomBase.SampleObject), "tcp://" + Global.server.GetIP(txtNick.Text) + ":7070/" + txtNick.Text);

                if (!objChatWin.remoteObj.JoinToChatRoom(Global.username))
                {
                    MessageBox.Show(Global.username + " sign in!");
                    ChannelServices.UnregisterChannel(chan);
                    chan = null;
                    objChatWin.Dispose();
                    return;
                }
                objChatWin.key = objChatWin.remoteObj.CurrentKeyNo();
                objChatWin.yourName = Global.username;

                this.Hide();
                objChatWin.Show();
            }
            else
            {
                MessageBox.Show("Error creating!");
                ChannelServices.UnregisterChannel(chan);
                chan = null;
            }
        }
    }
}
