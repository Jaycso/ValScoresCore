using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ValScoresCore.Program;

namespace ValScoresCore
{
    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
            timer1.Start();
        }

        int counter = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter > 0)
            {
                counter--;
                loadingBar.Value += 10;
            }
            else
            {
                timer1.Stop();
                Helper.goToNext(this, new loginScreen());
            }
        }
    }
}