using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace LoginForm_APPCONFIG
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            var appSettings = ConfigurationManager.AppSettings;

            string username = appSettings["username"];
            string password = appSettings["password"];

            SHA256SaltedMaker ssmUsername = new SHA256SaltedMaker(txtUsername.Text);
            SHA256SaltedMaker ssmPassword = new SHA256SaltedMaker(txtPassword.Text);

            //MessageBox.Show(ssmUsername.ToString());
            //salt vero per test Cx{PdA]/>,

            if ((ssmUsername.ToString() == username) && (ssmPassword.ToString() == password))
                {
                    this.Hide();
                    Main mainWindow = new Main();
                    mainWindow.Show();
                }
            else
                {
                    MessageBox.Show("Username o Password sbagliati");
                }
        }

        private void btnSalt_Click(object sender, EventArgs e)
        {
            SaltScreen saltWindow = new SaltScreen();
            saltWindow.Show();
        }
    }
}
