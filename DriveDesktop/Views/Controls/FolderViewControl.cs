using DriveDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveDesktop.Views.Controls
{
    public partial class FolderViewControl : UserControl
    {
        private Folder folder;

        public FolderViewControl(Folder folder)
        {
            this.folder = folder;
            InitializeComponent();
        }

        private void fillListView()
        {
            
        }

    }
}
