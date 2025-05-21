using DriveDesktop.Authentication;
using DriveDesktop.Gateways.Auth;
using DriveDesktop.Gateways.Auth.Model;
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
    public partial class LoginForm : Form
    {
        private ITokenProvider _tokenProvider = null!;
        private readonly IAuthApi _authApi;
        private bool _isLoggedIn = false;

        public LoginForm(IAuthApi authApi)
        {
            this._authApi = authApi;
            InitializeComponent();
        }

        public ITokenProvider TokenProvider => _tokenProvider;
        public bool IsLoggedIn => _isLoggedIn;

        private void login_Click(object sender, EventArgs e)
        {
            var credentials = new UserCredentials { Password = passwordTextBox.Text, Username = usernameTexBox.Text };
            _tokenProvider = new MemoryTokenProvider(new TokenSession(new AuthApiTokenFetcher(_authApi, credentials)));
            _isLoggedIn = true;
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
