using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ValScoresCore.Program;

namespace ValScoresCore
{
    public partial class loginScreen : Form
    {
        private Database database = new Database();
        public loginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginSequence();
        }

        private void loginSequence()
        {
            var inputUsername = txtUsername.Text.Trim();
            var inputPassword = txtPassword.Text.Trim();
            var uid = database.getUidFromUsername(inputUsername);
            if (uid == -1)
            {
                MessageBox.Show($"Username '{inputUsername}' not found.");
                return;
            }
            var password = database.getPasswordFromUID(uid);
            if (password == inputPassword)
            {
                Helper.goToNext(this, new mainForm());
            } else
            {
                MessageBox.Show("Invalid password.");
            }
        }
        public int activeUser { get; }
        private void loginScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                loginSequence();
            }
        }
    }
}
