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
        //Sets this form to 'mainform' using the manager class.
        public Form1()
        {
            InitializeComponent();
            Manager.mainForm = this;
        }


        //Once NewGame is clicked a new file is created if one does not exists, and if one does, it is cleared.
        private void NewGame_Click(object sender, EventArgs e)
        {
           
            Form2 Main = new Form2();
            Main.Show();
            this.Enabled = false;

            if (File.Exists("H:/Fight Project/Fight Project/bin/debug/Game scores.txt"))
            {
                StreamWriter Clear = new StreamWriter("H:/Fight Project/Fight Project/bin/debug/Game scores.txt", false);
                Clear.Close();
            }

            else
            {
                FileStream Scores = File.Create("H:/Fight Project/Fight Project/bin/debug/Game scores.txt");
                Scores.Close();
            }
            Manager.ResetForNew();
        }
     //Once LoadGame is clicked, like NewGame, also opens the second form 'Battleform' but does not wipe the previous score storage.
        public void LoadGame_Click(object sender, EventArgs e)
        {
            Manager.Loaded = true;
            Form2 Main = new Form2();
            Main.Show();
            this.Enabled = false;


        }
    }
}
