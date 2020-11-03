using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using Khendys.Controls;
using System.Net;
using System.Runtime.Remoting.Channels;
using LanMessengerChatRoomBase;
using System.Runtime.Remoting.Channels.Tcp;
namespace Erasmus
{
    public partial class FormMessage : Form
    {
        private Image[] emoticons;

        internal string contact;
        private ToolBarButton tbbSmile;
        private ImageList toolBarIcons;
        private int buzzCount = 0;
        private string[] setting = new string[6]; 
        public string IPServerPhoto;
        public string IPWebcam_rq = "";
        public string IPWebcam_rp = "";
        public string LinkSongSend = ""; 
        public string IPContact;
        FormPhotoReceive fm;
        private ToolBar toolBarFormMessage;

        FormFileReceive fmr;
        public FormMessage()
        {

            InitializeComponent();
            toolBarFormMessage.DropDownArrows = false;
            // Thêm Icon cho toolbar
            tbbSmile.ImageIndex = 0;
            toolBarIcons = new ImageList();
            toolBarIcons.ImageSize = new System.Drawing.Size(20, 20);
            toolBarIcons.Images.Add(Image.FromFile("images/smiles.jpg"));
            toolBarIcons.ColorDepth = ColorDepth.Depth16Bit;
            toolBarIcons.TransparentColor = System.Drawing.Color.Transparent;
            toolBarFormMessage.ImageList = toolBarIcons;
            if (File.Exists("UserSetting.dat"))
                ReadUserSetting();
            else
                setting[5] = "1";
            emoticons = new Image[20];
            emoticons[0] = Image.FromFile("images/smiles/1.gif");
            emoticons[1] = Image.FromFile("images/smiles/2.gif");
            emoticons[2] = Image.FromFile("images/smiles/3.gif");
            emoticons[3] = Image.FromFile("images/smiles/4.gif");
            emoticons[4] = Image.FromFile("images/smiles/5.gif");
            emoticons[5] = Image.FromFile("images/smiles/8.gif");
            emoticons[6] = Image.FromFile("images/smiles/9.gif");
            emoticons[7] = Image.FromFile("images/smiles/10.gif");
            emoticons[8] = Image.FromFile("images/smiles/11.gif");
            emoticons[9] = Image.FromFile("images/smiles/14.gif");
            emoticons[10] = Image.FromFile("images/smiles/52.gif");
            emoticons[11] = Image.FromFile("images/smiles/16.gif");
            emoticons[12] = Image.FromFile("images/smiles/17.gif");
            emoticons[13] = Image.FromFile("images/smiles/22.gif");
            emoticons[14] = Image.FromFile("images/smiles/24.gif");
            emoticons[15] = Image.FromFile("images/smiles/25.gif");
            emoticons[16] = Image.FromFile("images/smiles/26.gif");
            emoticons[17] = Image.FromFile("images/smiles/28.gif");
            emoticons[18] = Image.FromFile("images/smiles/39.gif");
            emoticons[19] = Image.FromFile("images/smiles/50.gif");
        }
        internal void AddText(string person, string message)
        {
            if (message == "BUZZ IT")
            {
                tmrBuzz.Enabled = true;
                tmrBuzzOff.Enabled = true;
                rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold);
                message = "BUZZ";
                this.Focus();
                if (File.Exists(setting[0]))
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(setting[0]);
                    sound.Play();
                }
                else
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sounds/buzz.wav");
                    sound.Play();
                }
            }
            else
            {
                if (File.Exists(setting[3]))
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(setting[3]);
                    sound.Play();
                }
                else
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sounds/message.wav");
                    sound.Play();
                }
            }
            rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold);
            rtbConversation.AppendText(Global.server.GetfullName(person) + " : ");
            rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular);
            rtbConversation.AppendText(message + " \n");
            CharactertoIcon(rtbConversation);
            txtMessage.Focus();
            if (setting[5] == "1" || setting[5] == "2")
                WriteLogs(person + " : " + message);

            if (message == "Sending file...") 
            {
                this.Show();
                Global.server.Send(Global.username, contact, "Waiting...");
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " Want to send file. Do you accept it?", "Send file", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        ServerStart();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.server.GetfullName(Global.username) + " không chấp nhận yêu cầu gửi file của bạn!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }

            if (message == "Share photo...") 
            {
                this.Show();
                Global.server.Send(Global.username, contact, "Waiting...");
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " Want to share. Do you accept it", "Share photo", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        ServerPhotoStart();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.username + " deny sharing!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }

            if (message == "Invited to room...")
            {
                this.Show();
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " muốn mời bạn tham gia Chat Room. Bạn có chập nhận không?", "Yêu cầu tham gia Chat Room", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        OpenRoom();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.username + " từ chối tham gia Chat Room!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }

            if ((IPContact = CheckSendFile(message)) != "")
            {
                ClientStart(); 
            }

            if ((IPContact = CheckSharePhoto(message)) != "")
            {
                ClientPhotoStart();
            }
            if (CheckSongSend(message) != "")
            {
                this.Show();
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " Muốn mời bạn nghe một bài nhạc. Bạn có đồng ý không?", "Bạn được mời nghe nhạc", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        LinkSongSend = CheckSongSend(message); // Nhận link nhạc
                        FormMusicPlayer fmp = new FormMusicPlayer(this);
                        fmp.Show();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.server.GetfullName(Global.username) + " không muốn nghe bài nhạc này!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }

            if (message.IndexOf("Accept webCam") != -1)
            {
                IPWebcam_rp = GetIPofContact(message);
                FormWebCam fw = new FormWebCam(this);
                fw.Show();
            }

            
            if (CheckWebcamRequest(message) != "")
            {
                this.Show();
                switch (MessageBox.Show(Global.server.GetfullName(contact) + " muốn mời bạn chat Webcam. Bạn có đồng ý không?", "Chat Webcam...", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
                        string tempIP = IP.AddressList[0].ToString(); // IP máy phản hồi
                        Global.server.Send(Global.username, contact, "Được đồng ý chat webcam - IP: " + tempIP);
                        IPWebcam_rq = GetIPofContact(message); // IP của máy yêu cầu
                        FormWebCam fw = new FormWebCam(this);
                        fw.Show();
                        return;
                        break;
                    case DialogResult.No:
                        Global.server.Send(Global.username, contact, Global.username + " không muốn chat Webcam!");
                        this.DialogResult = DialogResult.None;
                        break;
                }
            }
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
                objChatWin.remoteObj = (SampleObject)Activator.GetObject(typeof(LanMessengerChatRoomBase.SampleObject), "tcp://" + Global.server.GetIP(contact) + ":7070/" + contact);

                if (!objChatWin.remoteObj.JoinToChatRoom(Global.username))
                {
                    MessageBox.Show(Global.username + " đã đăng nhập rồi!. Có thể mạng bị lag, hãy thử lại sau!");
                    ChannelServices.UnregisterChannel(chan);
                    chan = null;
                    objChatWin.Dispose();
                    return;
                }
                objChatWin.key = objChatWin.remoteObj.CurrentKeyNo();
                objChatWin.yourName = Global.username;
                objChatWin.Show();
            }

            else
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tạo Room Chat, vui lòng thử lại sau!");
                ChannelServices.UnregisterChannel(chan);
                chan = null;
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold);
            rtbConversation.AppendText(Global.server.GetfullName(Global.username) + " : ");
            rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular);
            rtbConversation.AppendText(txtMessage.Text + " \n");
            CharactertoIcon(rtbConversation);
            rtbConversation.Focus();
            if (setting[5] == "1" || setting[5] == "2")
                WriteLogs(Global.username + " : " + txtMessage.Text); // Ghi log của mình gửi
            Global.server.Send(Global.username, contact, txtMessage.Text); // Có thể xử lý thêm trường hợp ko cho phép gửi tin nhắn tới "tài koản ko tồn tại" ở đây.
            txtMessage.Focus();
            txtMessage.Clear();
        }
        string[] lastMessage = new string[10];
        int posLM = 0;
        int j = 0;
        bool UpPressed = false;

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Up)
            {
                if (e.KeyCode != Keys.Down)
                    j = posLM;
            }
            if (e.KeyCode == Keys.Up) // Lấy lại các tin đã gửi trước đó bỏ vào khung chat (Up)
            {
                UpPressed = true;
                j--;
                if (j < 0)
                {
                    j = 9;
                    if (lastMessage[9] == null)
                        j = posLM - 1;
                    if (j < 0)
                        j = 0;
                }
                txtMessage.Text = lastMessage[j];
                txtMessage.SelectionStart = txtMessage.Text.Length;
            }

            if (e.KeyCode == Keys.Down) // Lấy lại các tin đã gửi trước đó bỏ vào khung chat (Down)
            {
                if (UpPressed)
                {
                    j++;
                    if (j > 9 || lastMessage[j] == null)
                    {
                        j = 0;
                    }
                    txtMessage.Text = lastMessage[j];
                    txtMessage.SelectionStart = txtMessage.Text.Length;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (txtMessage.Text != "")
                {
                    lastMessage[posLM] = txtMessage.Text;
                    posLM++;
                    if (posLM > 9)
                        posLM = 0;
                    j = posLM;
                    btnSend_Click(null, null);
                }
            }
            // Khi nhấn Ctrl + G thì sẻ Buzz kiểu như YAHOO MESSENGER :D
            if (e.KeyCode == Keys.G && e.Control)
            {
                if (buzzCount >= 2)
                {
                    MessageBox.Show("Bạn chỉ được sử dụng tính năng BUZZ không quá 2 lần trong mỗi 5 giây.");
                    return;
                }
                buzzCount++;
                Global.server.Send(Global.username, contact, "BUZZ IT");
                rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold);
                rtbConversation.AppendText(Global.server.GetfullName(Global.username) + " : BUZZ \n");
                if (setting[5] == "1" || setting[5] == "2")
                    WriteLogs(Global.username + " : " + "BUZZ"); // Ghi log của mình gửi (buzz)
                tmrBuzz.Enabled = true;
                tmrBuzzOff.Enabled = true;
                txtMessage.Focus();
                if (File.Exists(setting[0]))
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer(setting[0]);
                    sound.Play();
                }
                else
                {
                    System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sounds/buzz.wav");
                    sound.Play();
                }
            }

        }

        private void FormMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.windowList.Remove(contact);
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMessage.Clear();
            }
        }

        private void FormMessage_Resize(object sender, EventArgs e)
        {
            rtbConversation.Width = this.Width - 24;
            rtbConversation.Height = this.Height - 96;
            btnSend.Location = new System.Drawing.Point(this.Width - 80, this.Height - 80);
            txtMessage.Location = new Point(8, this.Height - 80);
            txtMessage.Size = new System.Drawing.Size(this.Width - 96, 40);
        }
        int loc = 0;

        private void tmrBuzz_Tick(object sender, EventArgs e)
        {
            switch (loc)
            {
                case 0:
                    this.Location = new Point(this.Location.X + 10, this.Location.Y);
                    break;
                case 1:
                    this.Location = new Point(this.Location.X, this.Location.Y + 10);
                    break;
                case 2:
                    this.Location = new Point(this.Location.X - 10, this.Location.Y);
                    break;
                case 3:
                    this.Location = new Point(this.Location.X, this.Location.Y - 10);
                    break;
            }
            loc++;
            loc %= 4;
        }

        private void tmrBuzzOff_Tick(object sender, EventArgs e)
        {
            tmrBuzz.Enabled = false;
            tmrBuzz.Enabled = false;
        }

        private void tmrBuzzCount_Tick(object sender, EventArgs e)
        {
            buzzCount = 0;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (txtMessage.Text == "")
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;
        }
        private void ChangePictureBuzz1(object sender, System.EventArgs e)
        {

        }

        // Nút Buzz 1
        private void ChangePictureBuzz2(object sender, System.EventArgs e)
        {

        }
        private void ChangePictureFileTransfer1(object sender, System.EventArgs e)
        {

        }

        // Nút File Transfer 2
        private void ChangePictureFileTransfer2(object sender, System.EventArgs e)
        {

        }

        private void picSharePhoto_MouseHover(object sender, EventArgs e)
        {
            picSharePhoto.Image = Image.FromFile("images/photoshare2.png");
        }

        private void picSharePhoto_MouseLeave(object sender, EventArgs e)
        {
            picSharePhoto.Image = Image.FromFile("images/photoshare.png");
        }

        private void picWebcam_MouseLeave(object sender, EventArgs e)
        {
            picWebcam.Image = Image.FromFile("images/webcam1.png");
        }

        private void picWebcam_MouseHover(object sender, EventArgs e)
        {
            picWebcam.Image = Image.FromFile("images/webcam2.png");
        }

        private void picBuzz_Click(object sender, EventArgs e)
        {
            if (buzzCount >= 2)
            {
                MessageBox.Show("Bạn chỉ được sử dụng tính năng BUZZ không quá 2 lần trong mỗi 5 giây.");
                return;
            }
            buzzCount++;
            Global.server.Send(Global.username, contact, "BUZZ IT");
            rtbConversation.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold);
            rtbConversation.AppendText(Global.server.GetfullName(Global.username) + " : BUZZ \n");
            if (setting[5] == "1" || setting[5] == "2")
                WriteLogs(Global.username + " : " + "BUZZ"); // Ghi log của mình gửi (buzz)
            tmrBuzz.Enabled = true;
            tmrBuzzOff.Enabled = true;
            txtMessage.Focus();
            if (File.Exists(setting[0]))
            {
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer(setting[0]);
                sound.Play();
            }
            else
            {
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer("sounds/buzz.wav");
                sound.Play();
            }
        }
        private void CharactertoIcon(ExRichTextBox r)
        {
            int _index = 0;
            if ((_index = r.Find(":)")) > -1)
            {
                r.Select(_index, ":)".Length);
                r.InsertImage(Image.FromFile("images/smiles/1.gif"));
            }

            if ((_index = r.Find(":(")) > -1)
            {
                r.Select(_index, ":(".Length);
                r.InsertImage(Image.FromFile("images/smiles/2.gif"));
            }

            if ((_index = r.Find(";)")) > -1)
            {
                r.Select(_index, ";)".Length);
                r.InsertImage(Image.FromFile("images/smiles/3.gif"));
            }

            if ((_index = r.Find(":D")) > -1)
            {
                r.Select(_index, ":D".Length);
                r.InsertImage(Image.FromFile("images/smiles/4.gif"));
            }

            if ((_index = r.Find("8->")) > -1)
            {
                r.Select(_index, "8->".Length);
                r.InsertImage(Image.FromFile("images/smiles/5.gif"));
            }

            if ((_index = r.Find(":|")) > -1)
            {
                r.Select(_index, ":|".Length);
                r.InsertImage(Image.FromFile("images/smiles/22.gif"));
            }
            if ((_index = r.Find(":X")) > -1)
            {
                r.Select(_index, ":X".Length);
                r.InsertImage(Image.FromFile("images/smiles/8.gif"));
            }
            if ((_index = r.Find(":\">")) > -1)
            {
                r.Select(_index, ":\">".Length);
                r.InsertImage(Image.FromFile("images/smiles/9.gif"));
            }
            if ((_index = r.Find(":-*")) > -1)
            {
                r.Select(_index, ":-*".Length);
                r.InsertImage(Image.FromFile("images/smiles/11.gif"));
            }
            if ((_index = r.Find("X(")) > -1)
            {
                r.Select(_index, "X(".Length);
                r.InsertImage(Image.FromFile("images/smiles/14.gif"));
            }
            if ((_index = r.Find("b-)")) > -1)
            {
                r.Select(_index, "b-)".Length);
                r.InsertImage(Image.FromFile("images/smiles/16.gif"));
            }
            if ((_index = r.Find(":-S")) > -1)
            {
                r.Select(_index, ":-S".Length);
                r.InsertImage(Image.FromFile("images/smiles/17.gif"));
            }
            if ((_index = r.Find("=))")) > -1)
            {
                r.Select(_index, "=))".Length);
                r.InsertImage(Image.FromFile("images/smiles/24.gif"));
            }
            if ((_index = r.Find("O:-)")) > -1)
            {
                r.Select(_index, "O:-)".Length);
                r.InsertImage(Image.FromFile("images/smiles/25.gif"));
            }
            if ((_index = r.Find(":-B")) > -1)
            {
                r.Select(_index, ":-B".Length);
                r.InsertImage(Image.FromFile("images/smiles/26.gif"));
            }
            if ((_index = r.Find("I-)")) > -1)
            {
                r.Select(_index, "I-)".Length);
                r.InsertImage(Image.FromFile("images/smiles/28.gif"));
            }
            if ((_index = r.Find(":-?")) > -1)
            {
                r.Select(_index, ":-?".Length);
                r.InsertImage(Image.FromFile("images/smiles/39.gif"));
            }
            if ((_index = r.Find("3:-O")) > -1)
            {
                r.Select(_index, "3:-O".Length);
                r.InsertImage(Image.FromFile("images/smiles/50.gif"));
            }
            if ((_index = r.Find("~:>")) > -1)
            {
                r.Select(_index, "~:>".Length);
                r.InsertImage(Image.FromFile("images/smiles/52.gif"));
            }
            if ((_index = r.Find(":P")) > -1)
            {
                r.Select(_index, ":P".Length);
                r.InsertImage(Image.FromFile("images/smiles/10.gif"));
            }
        }

        // Các sự kiện khi bấm vào 1 Icon trên menu sẻ chèn kí tự mặt cười vào textbox

        private void IconToCharacter1(object _sender, EventArgs _args)
        {
            txtMessage.Text += ":)";
        }
        private void IconToCharacter2(object _sender, EventArgs _args)
        {
            txtMessage.Text += ":(";
        }
        private void IconToCharacter3(object _sender, EventArgs _args)
        {

            txtMessage.Text += ";)";
        }
        private void IconToCharacter4(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":D";
        }
        private void IconToCharacter5(object _sender, EventArgs _args)
        {

            txtMessage.Text += "8->";
        }
        private void IconToCharacter6(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":X";
        }
        private void IconToCharacter7(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":\">";
        }
        private void IconToCharacter8(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":P";
        }
        private void IconToCharacter9(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":-*";
        }
        private void IconToCharacter10(object _sender, EventArgs _args)
        {

            txtMessage.Text += "X(";
        }
        private void IconToCharacter11(object _sender, EventArgs _args)
        {

            txtMessage.Text += "~:>";
        }
        private void IconToCharacter12(object _sender, EventArgs _args)
        {

            txtMessage.Text += "b-)";
        }
        private void IconToCharacter13(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":-S";
        }
        private void IconToCharacter14(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":|";
        }
        private void IconToCharacter15(object _sender, EventArgs _args)
        {

            txtMessage.Text += "=))";
        }
        private void IconToCharacter16(object _sender, EventArgs _args)
        {

            txtMessage.Text += "O:-)";
        }
        private void IconToCharacter17(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":-B";
        }
        private void IconToCharacter18(object _sender, EventArgs _args)
        {
            txtMessage.Text += "I-)";
        }
        private void IconToCharacter19(object _sender, EventArgs _args)
        {

            txtMessage.Text += ":-?";
        }
        private void IconToCharacter20(object _sender, EventArgs _args)
        {
            txtMessage.Text += "3:-O";
        }

        private void picSendFile_Click(object sender, EventArgs e)
        {
            if (Global.server.IsVisible(contact))
            {
                Global.server.Send(Global.username, contact, "Đang yêu cầu truyền tải file...");
            }
            else
            {
                MessageBox.Show("Người này hiện không có Online để thực hiện việc truyền tải file. Vui lòng thử lại vào lúc khác!", "Lỗi!");
            }
        }

        private void picSharePhoto_Click(object sender, EventArgs e)
        {
            if (Global.server.IsVisible(contact))
            {
                Global.server.Send(Global.username, contact, "Đang yêu cầu chia sẻ hình ảnh...");
            }
            else
            {
                MessageBox.Show("Người này hiện không có Online để chia sẻ hình ảnh. Vui lòng thử lại vào lúc khác!", "Lỗi!");
            }
        }

        private void picWebcam_Click(object sender, EventArgs e)
        {
            if (Global.server.IsVisible(contact))
            {
                IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
                string IP_rq = IP.AddressList[0].ToString();
                Global.server.Send(Global.username, contact, " cmd-Webcam: Đang yêu cầu chia sẻ chat Webcam - IP: " + IP_rq);
            }
            else
            {
                MessageBox.Show("Người này hiện không có Online để chat Webcam. Vui lòng thử lại vào lúc khác!", "Lỗi!");
            }
        }
        public void ServerStart()
        {
            IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
            string IP_temp = IP.AddressList[0].ToString();
            Global.server.Send(Global.username, contact, " cmd-SendFile: Đã chấp nhận yêu cầu gửi file (IP: " + IP_temp + ")"); // Thông báo tới người gửi
            fmr = new FormFileReceive();
            fmr.Show();
        }

        // Server, lắng nghe kết nối để nhận hình ảnh chia sẻ (sau khi đã ấn yes)
        public void ServerPhotoStart()
        {
            IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
            IPServerPhoto = IP.AddressList[0].ToString();
            fm = new FormPhotoReceive();
            fm.Show();
            Global.server.Send(Global.username, contact, " cmd-SharePhoto: Đã chấp nhận yêu cầu chia sẻ hình ảnh (IP: " + IPServerPhoto + ")"); // Thông báo tới người gửi
        }

        // Client kết nối tới Server để gửi file
        public void ClientStart()
        {
            FormSendingFile ffs = new FormSendingFile(this);
            ffs.Show();
        }

        // Client kết nối tới Server để chia sẻ hình ảnh
        public void ClientPhotoStart()
        {
            FormPhotoSend ffs = new FormPhotoSend(this);
            ffs.Show();
        }

        // Lọc địa chỉ IP từ Message
        public string GetIPofContact(string message)
        {
            string pattern = @"(([0-1]?[0-9]{1,2}\.)|(2[0-4][0-9]\.)|(25[0-5]\.)){3}(([0-1]?[0-9]{1,2})|(2[0-4][0-9])|(25[0-5]))";
            Regex check = new Regex(pattern);
            Match m = check.Match(message);
            if (m.Success) return m.Value;
            return "Error";
        }

        // Kiểm tra người dùng có chấp nhận yêu cầu send file hay không
        public string CheckSendFile(string message)
        {
            if (message.Length > 12 && message.Substring(1, 12) == "cmd-SendFile")
            {
                return GetIPofContact(message);
            }
            return "";
        }

        // Kiểm tra người dùng có chấp nhận yêu cầu share photo hay không
        public string CheckSharePhoto(string message)
        {
            if (message.Length > 14 && message.Substring(1, 14) == "cmd-SharePhoto")
            {
                return GetIPofContact(message);
            }
            return "";
        }

        // Kiểm tra có phải là yêu cầu gửi nhạc ko, và lấy ra link nhạc
        public string CheckSongSend(string message)
        {
            if (message.Length > 10 && message.Substring(1, 9) == "cmd-Music") // Kiểm tra có phải là yêu cầu gửi nhạc?
            {
                string pattern = "http://+[^#]+"; // regex lọc link
                Regex check = new Regex(pattern);
                Match m = check.Match(message);
                if (m.Success)
                {
                    return m.Value;
                }
            }
            return "";
        }

        // Kiểm tra có phải là yêu cầu xem webcam hay không?
        public string CheckWebcamRequest(string message)
        {
            if (message.Length > 11 && message.Substring(1, 10) == "cmd-Webcam")
            {
                string IP_rq = GetIPofContact(message);
                return IP_rq;
            }
            return "";
        }

        public void ReadUserSetting()
        {
            FileStream fs1 = new FileStream("UserSetting.dat", FileMode.Open);
            BinaryReader w1 = new BinaryReader(fs1);
            setting[0] = w1.ReadString().ToString(); // Link tiếng buzz
            setting[1] = w1.ReadString().ToString(); // Link tiếng Online
            setting[2] = w1.ReadString().ToString(); // Link tiếng Offline
            setting[3] = w1.ReadString().ToString(); // Link tiếng Message
            setting[4] = w1.ReadString().ToString(); // Link thư mục lưu file
            setting[5] = w1.ReadString().ToString(); // Tùy chọn lưu logs chat
            w1.Close();
            fs1.Close();
        }

        // Hàm ghi logs chat
        private void WriteLogs(string s)
        {
            string path = "logs/" + Global.username + "/" + contact + "/"; // đường dẫn logs của người dùng đang đăng nhập            
            if (!Directory.Exists(path)) // Nếu người này chưa lưu log trước đó thì tạo thư mục mới
                Directory.CreateDirectory(path);
            path = path + TimetoFileName();
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(s);
                sw.Flush();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(s);
                sw.Flush();
                fs.Close();
            }
        }

        // Chuyển ngày hiện tại sang tên file
        private string TimetoFileName()
        {
            string s = DateTime.Today.ToShortDateString();

            if (s.IndexOf("/") == 1)
            {
                s = s.Remove(1, 1);
                s = s.Insert(0, "0");
                if (s.IndexOf("/") == 3)
                    s = s.Insert(2, "0");
                s = s.Remove(4, 1);
            }
            else
            {
                s = s.Remove(2, 1);
                if (s.IndexOf("/") == 3)
                    s = s.Insert(2, "0");
                s = s.Remove(4, 1);
            }
            s = s + ".dat";
            return s;
        }

        private void PanelFormMessage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
