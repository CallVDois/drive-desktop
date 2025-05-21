using DriveDesktop.Models;

namespace DriveDesktop.Views.Controls
{
    public partial class FileItemControl : UserControl
    {
        private Models.File file;
        private Action<Guid> downloadAction;

        public FileItemControl(Models.File file, Action<Guid> downloadAction)
        {
            this.file = file;
            this.downloadAction = downloadAction;
            InitializeComponent();
        }

        private void FileItemControl_Load(object sender, EventArgs e)
        {
            this.fileNameValue.Text = file.Name;
            this.fileSizeValue.Text = file.ContentSize.ToString() + " bytes";
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            this.downloadAction.Invoke(this.file.Id);
        }
    }
}
