using DriveDesktop.Views.Forms;

namespace DriveDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var mainForm = new MainForm();
            mainForm.LoadControl(new Views.Controls.FolderViewControl(new Models.Folder()));

            Application.Run(new MainForm());
        }
    }
}