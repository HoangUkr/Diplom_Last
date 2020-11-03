using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Erasmus
{
    public partial class FormLogReader : Form
    {
        public FormLogReader()
        {
            InitializeComponent();
            InitializeListView();
        }
        public void InitializeListView()
        {
            ColumnHeader header1 = this.lvListMessage.Columns.Add("Name", 27 * Convert.ToInt32(lvListMessage.Font.SizeInPoints), HorizontalAlignment.Center);
            ColumnHeader header2 = this.lvListMessage.Columns.Add("Time", 20 * Convert.ToInt32(lvListMessage.Font.SizeInPoints), HorizontalAlignment.Center);
        }
        string path = "logs/" + Global.username + "/"; 
        string[] listContact;
        string[] listFile;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogReader_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(path))
            {
                listContact = Directory.GetDirectories(path);
                List<string> items = new List<string>();
                for (int i = 0; i < listContact.Length; i++)
                {
                    items.Add(GetFolderContact(listContact[i]));
                }
                lbListContact.DataSource = items;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }
        private string GetFolderContact(string path)
        {
            string name;
            int index = path.IndexOf("/", 5) + 1; 
            name = path.Substring(index, path.Length - index); 
            return name;
        }
        private string GetFileContact(string path)
        {
            string pattern = "[0-9]+.dat";
            Regex filename = new Regex(pattern);
            Match m = filename.Match(path);
            if (m.Success)
            {
                return m.Value;
            }
            return "";
        }
        private string FileNametoTime(string name)
        {
            string s;
            s = name;
            s = s.Insert(2, "/");
            s = s.Insert(5, "/");
            s = s.Substring(0, s.Length - 4);
            return s;
        }

        private void lbListContact_SelectedValueChanged(object sender, EventArgs e)
        {
            lvListMessage.Clear();
            InitializeListView();
            listFile = Directory.GetFiles(path + lbListContact.SelectedItem.ToString());
            for (int i = 0; i < listFile.Length; i++)
            {
                AddItemstoListView(lbListContact.SelectedItem.ToString(), FileNametoTime(GetFileContact(listFile[i])));
            }
            rtbLogMessage.Clear();
        }
        private void AddItemstoListView(string Contact, string time)
        {
            int n = this.lvListMessage.Items.Count;
            this.lvListMessage.Items.Add(Contact);
            this.lvListMessage.Items[n].SubItems.Add(time);
        }

        private void lvListMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            if (this.lvListMessage.SelectedItems.Count > 0)
                index = this.lvListMessage.SelectedIndices[0]; // Lấy stt của 1 Items trên lvMessage

            FileStream fs = new FileStream(listFile[index], FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            rtbLogMessage.Clear();
            rtbLogMessage.AppendText(sr.ReadToEnd());
            fs.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure", "Delete log chat...", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    for (int i = 0; i < lvListMessage.Items.Count; i++)
                    {
                        if (lvListMessage.Items[i].Checked)
                        {
                            lvListMessage.Items[i].Remove();
                            File.Delete(listFile[i]);
                            listFile = Directory.GetFiles(path + lbListContact.SelectedItem.ToString());
                            rtbLogMessage.Clear();
                        }
                    }
                    break;
                case DialogResult.No:
                    this.DialogResult = DialogResult.None;
                    break;
            }
        }

        private void lvListMessage_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked == true || lvListMessage.CheckedItems.Count > 0)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }
    }
}
