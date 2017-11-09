using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginForm_APPCONFIG
{
    public partial class SaltScreen : Form
    {
        public SaltScreen()
        {
            InitializeComponent();
            txtOldSalt.Text = SHA256SaltedMaker.PrintSalt();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SHA256SaltedMaker.UpdateSalt(txtNewSalt.Text);
            txtOldSalt.Text = SHA256SaltedMaker.PrintSalt();
        }
    }
}
