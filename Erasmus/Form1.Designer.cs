namespace Erasmus
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tmrContactUpdate = new System.Windows.Forms.Timer(this.components);
            this.conMenuSendMessage = new System.Windows.Forms.MenuItem();
            this.conMenuRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.conMenuAddContact = new System.Windows.Forms.MenuItem();
            this.conMenuContactsPanel = new System.Windows.Forms.ContextMenu();
            this.conMenuPanelAddContact = new System.Windows.Forms.MenuItem();
            this.conMenuPanelRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.conMenuRefreshContactsPanel = new System.Windows.Forms.MenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenu();
            this.showLanMessenger = new System.Windows.Forms.MenuItem();
            this.notMenuSend = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.notMenuSignIn = new System.Windows.Forms.MenuItem();
            this.notMenuSignOut = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.notMenuAbout = new System.Windows.Forms.MenuItem();
            this.notMenuMin = new System.Windows.Forms.MenuItem();
            this.notMenuExit = new System.Windows.Forms.MenuItem();
            this.conMenu = new System.Windows.Forms.ContextMenu();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.rbtnInvisible = new System.Windows.Forms.RadioButton();
            this.rbtnOnline = new System.Windows.Forms.RadioButton();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuChat = new System.Windows.Forms.MenuItem();
            this.menuSendMessage = new System.Windows.Forms.MenuItem();
            this.menuAddContact = new System.Windows.Forms.MenuItem();
            this.menuRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuLogMessage = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuChangeUser = new System.Windows.Forms.MenuItem();
            this.menuSignOut = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuMin = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuNetworkSettings = new System.Windows.Forms.MenuItem();
            this.menuChangeDisplayName = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuMusicOnline = new System.Windows.Forms.MenuItem();
            this.menuOpenChatRoom = new System.Windows.Forms.MenuItem();
            this.menuJoinRoom = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlContacts = new System.Windows.Forms.Panel();
            this.tmrMessageReceive = new System.Windows.Forms.Timer(this.components);
            this.picSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrContactUpdate
            // 
            this.tmrContactUpdate.Interval = 3000;
            this.tmrContactUpdate.Tick += new System.EventHandler(this.tmrContactUpdate_Tick);
            // 
            // conMenuSendMessage
            // 
            this.conMenuSendMessage.Index = 0;
            this.conMenuSendMessage.Text = "Gửi một tin nhắn tới bạn này";
            // 
            // conMenuRemoveContact
            // 
            this.conMenuRemoveContact.Index = 1;
            this.conMenuRemoveContact.Text = "Xóa người bạn này";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // conMenuAddContact
            // 
            this.conMenuAddContact.Index = 3;
            this.conMenuAddContact.Text = "Thêm bạn bè...";
            // 
            // conMenuContactsPanel
            // 
            this.conMenuContactsPanel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.conMenuPanelAddContact,
            this.conMenuPanelRemoveContact,
            this.menuItem6,
            this.conMenuRefreshContactsPanel});
            // 
            // conMenuPanelAddContact
            // 
            this.conMenuPanelAddContact.Index = 0;
            this.conMenuPanelAddContact.Text = "Thêm bạn bè...";
            // 
            // conMenuPanelRemoveContact
            // 
            this.conMenuPanelRemoveContact.Index = 1;
            this.conMenuPanelRemoveContact.Text = "Xóa bạn bè...";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // conMenuRefreshContactsPanel
            // 
            this.conMenuRefreshContactsPanel.Index = 3;
            this.conMenuRefreshContactsPanel.Text = "Làm mới lại danh sách";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenu = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "LAN Messenger";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.showLanMessenger,
            this.notMenuSend,
            this.menuItem8,
            this.menuItem9,
            this.notMenuSignIn,
            this.notMenuSignOut,
            this.menuItem15,
            this.notMenuAbout,
            this.notMenuMin,
            this.notMenuExit});
            // 
            // showLanMessenger
            // 
            this.showLanMessenger.Index = 0;
            this.showLanMessenger.Text = "Hiện LAN Messenger!";
            // 
            // notMenuSend
            // 
            this.notMenuSend.Enabled = false;
            this.notMenuSend.Index = 1;
            this.notMenuSend.Text = "Gửi một tin nhắn tới...";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "-";
            // 
            // notMenuSignIn
            // 
            this.notMenuSignIn.Index = 4;
            this.notMenuSignIn.Text = "Đăng nhập";
            // 
            // notMenuSignOut
            // 
            this.notMenuSignOut.Enabled = false;
            this.notMenuSignOut.Index = 5;
            this.notMenuSignOut.Text = "Đăng xuất";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 6;
            this.menuItem15.Text = "-";
            // 
            // notMenuAbout
            // 
            this.notMenuAbout.Index = 7;
            this.notMenuAbout.Text = "Thông tin";
            // 
            // notMenuMin
            // 
            this.notMenuMin.Index = 8;
            this.notMenuMin.Text = "Thu nhỏ xuống khay hệ thống";
            // 
            // notMenuExit
            // 
            this.notMenuExit.Index = 9;
            this.notMenuExit.Text = "Thoát";
            // 
            // conMenu
            // 
            this.conMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.conMenuSendMessage,
            this.conMenuRemoveContact,
            this.menuItem5,
            this.conMenuAddContact});
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Search Bar...";
            // 
            // txtSearchName
            // 
            this.txtSearchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearchName.Enabled = false;
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearchName.Location = new System.Drawing.Point(52, 39);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(241, 23);
            this.txtSearchName.TabIndex = 10;
            this.txtSearchName.Text = "Nhập tên bạn bè cần tìm...";
            this.toolTip1.SetToolTip(this.txtSearchName, "Tìm kiếm bạn bè bằng có gợi ý bằng cách nhập tên vào đây rồi nhấn Enter.");
            this.txtSearchName.Click += new System.EventHandler(this.txtSearchName_Click);
            this.txtSearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchName_KeyDown);
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip2.ToolTipTitle = "Trạng thái...";
            // 
            // rbtnInvisible
            // 
            this.rbtnInvisible.AutoSize = true;
            this.rbtnInvisible.Enabled = false;
            this.rbtnInvisible.Location = new System.Drawing.Point(91, 12);
            this.rbtnInvisible.Name = "rbtnInvisible";
            this.rbtnInvisible.Size = new System.Drawing.Size(79, 21);
            this.rbtnInvisible.TabIndex = 13;
            this.rbtnInvisible.TabStop = true;
            this.rbtnInvisible.Text = "Invisible";
            this.toolTip2.SetToolTip(this.rbtnInvisible, "Ẩn nick với mọi người.");
            this.rbtnInvisible.UseVisualStyleBackColor = true;
            this.rbtnInvisible.CheckedChanged += new System.EventHandler(this.rbtnInvisible_CheckedChanged);
            // 
            // rbtnOnline
            // 
            this.rbtnOnline.AutoSize = true;
            this.rbtnOnline.Enabled = false;
            this.rbtnOnline.Location = new System.Drawing.Point(18, 13);
            this.rbtnOnline.Name = "rbtnOnline";
            this.rbtnOnline.Size = new System.Drawing.Size(70, 21);
            this.rbtnOnline.TabIndex = 12;
            this.rbtnOnline.TabStop = true;
            this.rbtnOnline.Text = "Online";
            this.toolTip2.SetToolTip(this.rbtnOnline, "Hiện nick với mọi người.");
            this.rbtnOnline.UseVisualStyleBackColor = true;
            this.rbtnOnline.CheckedChanged += new System.EventHandler(this.rbtnOnline_CheckedChanged);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 227);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(313, 26);
            this.statusBar.TabIndex = 8;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChat,
            this.menuItem10,
            this.menuItem13});
            // 
            // menuChat
            // 
            this.menuChat.Index = 0;
            this.menuChat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSendMessage,
            this.menuAddContact,
            this.menuRemoveContact,
            this.menuLogMessage,
            this.menuItem4,
            this.menuChangeUser,
            this.menuSignOut,
            this.menuItem7,
            this.menuMin,
            this.menuExit});
            this.menuChat.Text = "Messenger";
            // 
            // menuSendMessage
            // 
            this.menuSendMessage.Enabled = false;
            this.menuSendMessage.Index = 0;
            this.menuSendMessage.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
            this.menuSendMessage.Text = "Gửi một tin nhắn...";
            this.menuSendMessage.Click += new System.EventHandler(this.menuSendMessage_Click);
            // 
            // menuAddContact
            // 
            this.menuAddContact.Enabled = false;
            this.menuAddContact.Index = 1;
            this.menuAddContact.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            this.menuAddContact.Text = "Thêm bạn bè...";
            this.menuAddContact.Click += new System.EventHandler(this.menuAddContact_Click);
            // 
            // menuRemoveContact
            // 
            this.menuRemoveContact.Enabled = false;
            this.menuRemoveContact.Index = 2;
            this.menuRemoveContact.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftX;
            this.menuRemoveContact.Text = "Xóa bạn bè...";
            this.menuRemoveContact.Click += new System.EventHandler(this.menuRemoveContact_Click);
            // 
            // menuLogMessage
            // 
            this.menuLogMessage.Enabled = false;
            this.menuLogMessage.Index = 3;
            this.menuLogMessage.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.menuLogMessage.Text = "Lịch sử chat...";
            this.menuLogMessage.Click += new System.EventHandler(this.menuLogMessage_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // menuChangeUser
            // 
            this.menuChangeUser.Index = 5;
            this.menuChangeUser.Text = "Đăng nhập";
            this.menuChangeUser.Click += new System.EventHandler(this.menuChangeUser_Click);
            // 
            // menuSignOut
            // 
            this.menuSignOut.Enabled = false;
            this.menuSignOut.Index = 6;
            this.menuSignOut.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.menuSignOut.Text = "Đăng xuất";
            this.menuSignOut.Click += new System.EventHandler(this.menuSignOut_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "-";
            // 
            // menuMin
            // 
            this.menuMin.Index = 8;
            this.menuMin.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.menuMin.Text = "Thu nhỏ xuống khay hệ thống";
            this.menuMin.Click += new System.EventHandler(this.menuMin_Click);
            // 
            // menuExit
            // 
            this.menuExit.Index = 9;
            this.menuExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuNetworkSettings,
            this.menuChangeDisplayName,
            this.menuItem1,
            this.menuMusicOnline,
            this.menuOpenChatRoom,
            this.menuJoinRoom});
            this.menuItem10.Text = "Mở rộng";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "Tùy chỉnh";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuNetworkSettings
            // 
            this.menuNetworkSettings.Index = 1;
            this.menuNetworkSettings.Text = "Thiết lập mạng";
            this.menuNetworkSettings.Click += new System.EventHandler(this.menuNetworkSettings_Click);
            // 
            // menuChangeDisplayName
            // 
            this.menuChangeDisplayName.Enabled = false;
            this.menuChangeDisplayName.Index = 2;
            this.menuChangeDisplayName.Text = "Đổi tên hiển thị với bạn bè";
            this.menuChangeDisplayName.Click += new System.EventHandler(this.menuChangeDisplayName_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // menuMusicOnline
            // 
            this.menuMusicOnline.Index = 4;
            this.menuMusicOnline.Text = "Nghe nhạc Online";
            this.menuMusicOnline.Click += new System.EventHandler(this.menuMusicOnline_Click);
            // 
            // menuOpenChatRoom
            // 
            this.menuOpenChatRoom.Enabled = false;
            this.menuOpenChatRoom.Index = 5;
            this.menuOpenChatRoom.Text = "Mở một Chat Room";
            this.menuOpenChatRoom.Click += new System.EventHandler(this.menuOpenChatRoom_Click);
            // 
            // menuJoinRoom
            // 
            this.menuJoinRoom.Enabled = false;
            this.menuJoinRoom.Index = 6;
            this.menuJoinRoom.Text = "Tham gia một Chat Room";
            this.menuJoinRoom.Click += new System.EventHandler(this.menuJoinRoom_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuAbout});
            this.menuItem13.Text = "Trợ giúp";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 0;
            this.menuItem14.Text = "Hướng dẫn sử dụng";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 1;
            this.menuAbout.Text = "Thông tin";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.ForeColor = System.Drawing.Color.Green;
            this.lblWelcome.Location = new System.Drawing.Point(14, -7);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(113, 17);
            this.lblWelcome.TabIndex = 9;
            this.lblWelcome.Text = "Chưa đăng nhập";
            // 
            // pnlContacts
            // 
            this.pnlContacts.AutoScroll = true;
            this.pnlContacts.BackColor = System.Drawing.Color.White;
            this.pnlContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlContacts.Location = new System.Drawing.Point(14, 66);
            this.pnlContacts.Name = "pnlContacts";
            this.pnlContacts.Size = new System.Drawing.Size(279, 391);
            this.pnlContacts.TabIndex = 7;
            this.pnlContacts.Resize += new System.EventHandler(this.pnlContacts_Resize);
            // 
            // tmrMessageReceive
            // 
            this.tmrMessageReceive.Interval = 1000;
            this.tmrMessageReceive.Tick += new System.EventHandler(this.tmrMessageReceive_Tick);
            // 
            // picSearch
            // 
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Location = new System.Drawing.Point(18, 35);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(30, 28);
            this.picSearch.TabIndex = 11;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 253);
            this.Controls.Add(this.rbtnInvisible);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.rbtnOnline);
            this.Controls.Add(this.pnlContacts);
            this.Menu = this.mainMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrContactUpdate;
        private System.Windows.Forms.MenuItem conMenuSendMessage;
        private System.Windows.Forms.MenuItem conMenuRemoveContact;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem conMenuAddContact;
        private System.Windows.Forms.ContextMenu conMenuContactsPanel;
        private System.Windows.Forms.MenuItem conMenuPanelAddContact;
        private System.Windows.Forms.MenuItem conMenuPanelRemoveContact;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem conMenuRefreshContactsPanel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenu notifyMenu;
        private System.Windows.Forms.MenuItem showLanMessenger;
        private System.Windows.Forms.MenuItem notMenuSend;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem notMenuSignIn;
        private System.Windows.Forms.MenuItem notMenuSignOut;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem notMenuAbout;
        private System.Windows.Forms.MenuItem notMenuMin;
        private System.Windows.Forms.MenuItem notMenuExit;
        private System.Windows.Forms.ContextMenu conMenu;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.RadioButton rbtnInvisible;
        private System.Windows.Forms.RadioButton rbtnOnline;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuChat;
        private System.Windows.Forms.MenuItem menuSendMessage;
        private System.Windows.Forms.MenuItem menuAddContact;
        private System.Windows.Forms.MenuItem menuRemoveContact;
        private System.Windows.Forms.MenuItem menuLogMessage;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuChangeUser;
        private System.Windows.Forms.MenuItem menuSignOut;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuMin;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuNetworkSettings;
        private System.Windows.Forms.MenuItem menuChangeDisplayName;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuMusicOnline;
        private System.Windows.Forms.MenuItem menuOpenChatRoom;
        private System.Windows.Forms.MenuItem menuJoinRoom;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuAbout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel pnlContacts;
        private System.Windows.Forms.Timer tmrMessageReceive;
    }
}