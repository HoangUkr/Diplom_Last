using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace LanMessengerControls
{
    public class LanMessengerContact : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.Label txtContact;
        private System.Windows.Forms.PictureBox picSmiley;
        private System.Windows.Forms.ImageList imageList;
        private System.ComponentModel.IContainer components;
        private string contact; // username

        public LanMessengerContact()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitComponent call
            picSmiley.Image = imageList.Images[0];
        }

        private ImageList imageList1;
        private IContainer component;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 23);
            this.label1.Name = "txtContact";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact";
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(19, 23);
            this.pictureBox1.Name = "picSmiley";
            this.pictureBox1.Size = new System.Drawing.Size(26, 24);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // LanMessengerContact
            // 
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "LanMessengerContact";
            this.Resize += new System.EventHandler(this.LanMessengerContact_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
#endregion

        private Label label1;
        private PictureBox pictureBox1;

        private void LanMessengerContact_Resize(object sender, EventArgs e)
        {
            txtContact.Width = this.Width - 32;
            this.Height = 16;
        }
        public bool online;

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(new EventArgs());
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.OnDoubleClick(new EventArgs());
        }
        public bool Online
        {
            get
            {
                return online;
            }
            set
            {
                online = value;
                if (value)
                {
                    picSmiley.Image = imageList.Images[1];
                }
                else
                {
                    picSmiley.Image = imageList.Images[0];
                }
                picSmiley.Update();
                picSmiley.Refresh();
            }
        }
        public string Contact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;
            }
        }

        // Lấy display name để hiện trên Contact list
        public string DisplayName
        {
            get
            {
                return txtContact.Text;
            }
            set
            {
                txtContact.Text = value;
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            txtContact.ForeColor = System.Drawing.Color.Red;
            txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            txtContact.ForeColor = System.Drawing.Color.Purple;
            txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            txtContact.ForeColor = System.Drawing.Color.Red;
            txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            txtContact.ForeColor = System.Drawing.Color.Purple;
            txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
