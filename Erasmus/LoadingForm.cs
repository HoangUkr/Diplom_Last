using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erasmus
{
    public partial class LoadingForm : Form
    {
        public Action worker { get; set; }
        public LoadingForm(Action worker)
        {
            InitializeComponent();
            if(worker == null)
            {
                throw new ArgumentNullException();

            }
            this.worker = worker;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
