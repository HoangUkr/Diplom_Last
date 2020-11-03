namespace Erasmus
{
    partial class FormMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessage));
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuSmile = new System.Windows.Forms.ContextMenu();
            this.btnSend = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmrBuzzCount = new System.Windows.Forms.Timer(this.components);
            this.tmrBuzzOff = new System.Windows.Forms.Timer(this.components);
            this.tmrBuzz = new System.Windows.Forms.Timer(this.components);
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.rtbConversation = new Khendys.Controls.ExRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.picSharePhoto = new System.Windows.Forms.PictureBox();
            this.picSendFile = new System.Windows.Forms.PictureBox();
            this.picBuzz = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSharePhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSendFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuzz)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTip4
            // 
            this.toolTip4.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip4.ToolTipTitle = "Webcam...";
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip2.ToolTipTitle = "Gửi file...";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSend.Location = new System.Drawing.Point(447, 303);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(77, 52);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Gửi";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "BUZZ!";
            // 
            // tmrBuzzCount
            // 
            this.tmrBuzzCount.Enabled = true;
            this.tmrBuzzCount.Interval = 5000;
            this.tmrBuzzCount.Tick += new System.EventHandler(this.tmrBuzzCount_Tick);
            // 
            // tmrBuzzOff
            // 
            this.tmrBuzzOff.Interval = 1000;
            this.tmrBuzzOff.Tick += new System.EventHandler(this.tmrBuzzOff_Tick);
            // 
            // tmrBuzz
            // 
            this.tmrBuzz.Interval = 31;
            this.tmrBuzz.Tick += new System.EventHandler(this.tmrBuzz_Tick);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 303);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(418, 52);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            this.txtMessage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyUp);
            // 
            // toolTip3
            // 
            this.toolTip3.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip3.ToolTipTitle = "Share Photo";
            // 
            // rtbConversation
            // 
            this.rtbConversation.HiglightColor = Khendys.Controls.RtfColor.White;
            this.rtbConversation.Location = new System.Drawing.Point(12, 12);
            this.rtbConversation.Name = "rtbConversation";
            this.rtbConversation.ReadOnly = true;
            this.rtbConversation.Size = new System.Drawing.Size(418, 230);
            this.rtbConversation.TabIndex = 9;
            this.rtbConversation.Text = "";
            this.rtbConversation.TextColor = Khendys.Controls.RtfColor.Black;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picWebcam);
            this.panel1.Controls.Add(this.picSharePhoto);
            this.panel1.Controls.Add(this.picSendFile);
            this.panel1.Controls.Add(this.picBuzz);
            this.panel1.Location = new System.Drawing.Point(17, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 35);
            this.panel1.TabIndex = 10;
            // 
            // picWebcam
            // 
            this.picWebcam.Image = ((System.Drawing.Image)(resources.GetObject("picWebcam.Image")));
            this.picWebcam.Location = new System.Drawing.Point(354, 3);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(36, 32);
            this.picWebcam.TabIndex = 12;
            this.picWebcam.TabStop = false;
            this.toolTip4.SetToolTip(this.picWebcam, "Mời chat Webcam với người này...");
            // 
            // picSharePhoto
            // 
            this.picSharePhoto.Image = ((System.Drawing.Image)(resources.GetObject("picSharePhoto.Image")));
            this.picSharePhoto.Location = new System.Drawing.Point(254, 3);
            this.picSharePhoto.Name = "picSharePhoto";
            this.picSharePhoto.Size = new System.Drawing.Size(33, 29);
            this.picSharePhoto.TabIndex = 11;
            this.picSharePhoto.TabStop = false;
            this.toolTip3.SetToolTip(this.picSharePhoto, "Chia sẻ hình ảnh với người bạn này.");
            // 
            // picSendFile
            // 
            this.picSendFile.Image = ((System.Drawing.Image)(resources.GetObject("picSendFile.Image")));
            this.picSendFile.Location = new System.Drawing.Point(158, 3);
            this.picSendFile.Name = "picSendFile";
            this.picSendFile.Size = new System.Drawing.Size(34, 29);
            this.picSendFile.TabIndex = 10;
            this.picSendFile.TabStop = false;
            this.toolTip2.SetToolTip(this.picSendFile, "Gửi file tới người bạn này...");
            // 
            // picBuzz
            // 
            this.picBuzz.BackColor = System.Drawing.SystemColors.Control;
            this.picBuzz.Image = ((System.Drawing.Image)(resources.GetObject("picBuzz.Image")));
            this.picBuzz.InitialImage = ((System.Drawing.Image)(resources.GetObject("picBuzz.InitialImage")));
            this.picBuzz.Location = new System.Drawing.Point(84, 3);
            this.picBuzz.Name = "picBuzz";
            this.picBuzz.Size = new System.Drawing.Size(22, 23);
            this.picBuzz.TabIndex = 9;
            this.picBuzz.TabStop = false;
            this.toolTip1.SetToolTip(this.picBuzz, "Buzz người bạn này!");
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 367);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbConversation);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Name = "FormMessage";
            this.Text = "FormMessage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMessage_FormClosing);
            this.Resize += new System.EventHandler(this.FormMessage_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSharePhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSendFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBuzz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ContextMenu contextMenuSmile;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Timer tmrBuzzCount;
        private System.Windows.Forms.Timer tmrBuzzOff;
        private System.Windows.Forms.Timer tmrBuzz;
        private System.Windows.Forms.TextBox txtMessage;
        private Khendys.Controls.ExRichTextBox rtbConversation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.Windows.Forms.PictureBox picSharePhoto;
        private System.Windows.Forms.PictureBox picSendFile;
        private System.Windows.Forms.PictureBox picBuzz;
    }
}