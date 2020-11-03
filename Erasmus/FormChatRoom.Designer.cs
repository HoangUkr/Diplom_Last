namespace Erasmus
{
    partial class FormChatRoom
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbbListContact = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChatHere = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstOnlineUser = new System.Windows.Forms.ListBox();
            this.txtAllChat = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(678, 343);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Invite friend";
            // 
            // cbbListContact
            // 
            this.cbbListContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbListContact.FormattingEnabled = true;
            this.cbbListContact.Location = new System.Drawing.Point(669, 372);
            this.cbbListContact.Margin = new System.Windows.Forms.Padding(4);
            this.cbbListContact.Name = "cbbListContact";
            this.cbbListContact.Size = new System.Drawing.Size(160, 24);
            this.cbbListContact.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(662, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nickname in Room";
            // 
            // txtChatHere
            // 
            this.txtChatHere.Location = new System.Drawing.Point(13, 416);
            this.txtChatHere.Margin = new System.Windows.Forms.Padding(4);
            this.txtChatHere.Multiline = true;
            this.txtChatHere.Name = "txtChatHere";
            this.txtChatHere.Size = new System.Drawing.Size(636, 43);
            this.txtChatHere.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(697, 418);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 44);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstOnlineUser
            // 
            this.lstOnlineUser.FormattingEnabled = true;
            this.lstOnlineUser.ItemHeight = 16;
            this.lstOnlineUser.Location = new System.Drawing.Point(663, 30);
            this.lstOnlineUser.Margin = new System.Windows.Forms.Padding(4);
            this.lstOnlineUser.Name = "lstOnlineUser";
            this.lstOnlineUser.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstOnlineUser.Size = new System.Drawing.Size(165, 292);
            this.lstOnlineUser.TabIndex = 9;
            // 
            // txtAllChat
            // 
            this.txtAllChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllChat.Location = new System.Drawing.Point(13, 4);
            this.txtAllChat.Margin = new System.Windows.Forms.Padding(4);
            this.txtAllChat.Name = "txtAllChat";
            this.txtAllChat.ReadOnly = true;
            this.txtAllChat.Size = new System.Drawing.Size(636, 404);
            this.txtAllChat.TabIndex = 10;
            this.txtAllChat.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 479);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbListContact);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChatHere);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lstOnlineUser);
            this.Controls.Add(this.txtAllChat);
            this.Name = "FormChatRoom";
            this.Text = "FormChatRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbListContact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChatHere;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstOnlineUser;
        private System.Windows.Forms.RichTextBox txtAllChat;
        private System.Windows.Forms.Timer timer1;
    }
}