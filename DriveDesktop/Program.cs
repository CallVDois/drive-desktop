using DriveDesktop.Views.Forms;

namespace DriveDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var authApi = new Gateways.Auth.KeycloakAuthApi("", "", "");

            var mainForm = new MainForm(authApi);
            mainForm.LoadControl(new Views.Controls.FolderViewControl(new Models.Folder()));

            Application.Run(mainForm);
        }
    }
}