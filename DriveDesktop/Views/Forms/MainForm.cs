using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveDesktop.Views.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void LoadControl(UserControl control)
        {
            if (this.Controls.Count > 0)
                this.Controls.Clear();

            control.Dock = DockStyle.Fill;
            this.Controls.Add(control);
            this.Controls.SetChildIndex(control, 0);
        }

    }
}
