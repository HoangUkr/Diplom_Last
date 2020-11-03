namespace Erasmus
{
    partial class FormOfflineMessage
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
            this.btnOK = new System.Windows.Forms.Button();
            this.rtbOfflineMessages = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(453, 261);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rtbOfflineMessages
            // 
            this.rtbOfflineMessages.Location = new System.Drawing.Point(12, 12);
            this.rtbOfflineMessages.Name = "rtbOfflineMessages";
            this.rtbOfflineMessages.ReadOnly = true;
            this.rtbOfflineMessages.Size = new System.Drawing.Size(528, 240);
            this.rtbOfflineMessages.TabIndex = 2;
            this.rtbOfflineMessages.Text = "";
            // 
            // FormOfflineMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 298);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbOfflineMessages);
            this.Name = "FormOfflineMessage";
            this.Text = "FormOfflineMessage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RichTextBox rtbOfflineMessages;
    }
}