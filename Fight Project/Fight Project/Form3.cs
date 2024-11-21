using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Fight_Project
{

    public partial class Form3 : Form
    {


        public Form3()
        {
            InitializeComponent();
            Main();
        }

        public void Main()
        {

            StreamWriter scorecount = new StreamWriter("H:/Fight Project/Fight Project/bin/debug/Game scores", false);
            scorecount.WriteLine(manager.wins.ToString());
            scorecount.WriteLine(manager.loss.ToString());
            scorecount.Close();

            

            Winnerbox.Text = "Player you have " + manager.wins + " wins and " + manager.loss + " losses";
        }
    }
}
