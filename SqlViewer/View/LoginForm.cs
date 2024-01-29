using SqlViewer.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlViewer.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            HideError();
        }

        private void HideError() => lblWrongCredentials.Visible = false;
        private void ShowError() => lblWrongCredentials.Visible = true;
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                RepositoryFactory.Repository.Login(tbServer.Text.Trim(), tbUsername.Text.Trim(), tbPassword.Text.Trim());
                Close();
            }
            catch
            {
                ShowError();
            }
        }
    }
}
