          using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void NewGame_Click(object sender, EventArgs e)
        {

            Form2 Main = new Form2();
            Main.Show();
            this.Enabled = false;

            if (File.Exists("H:/Fight Project/Fight Project/bin/debug/Game scores"))
            {
                StreamWriter Clear = new StreamWriter("H:/Fight Project/Fight Project/bin/debug/Game scores", false);
                Clear.Close();
            }

            else
            {
                FileStream Scores = File.Create("H:/Fight Project/Fight Project/bin/debug/Game scores");
                Scores.Close();
            }
        }
     
        private void LoadGame_Click(object sender, EventArgs e)
        {

            Form2 Main = new Form2();
            Main.Show();
            this.Enabled = false;
        }
    }
}
