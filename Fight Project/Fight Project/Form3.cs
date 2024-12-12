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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Fight_Project
{

    public partial class Form3 : Form
    {


        public Form3()
        {
            //Sets the current form to 'EndForm' using the manager class.
            InitializeComponent();
            Manager.EndForm = this;
            Main();
        }

        //Updates and sets the 'Winnerbox' text to the amount of wins and losses the player has.
        public void Main()
        {           
            StreamWriter scorecount = new StreamWriter("H:/Fight Project/Fight Project/bin/debug/Game scores.txt", false);
            scorecount.WriteLine(Manager.wins.ToString());
            scorecount.WriteLine(Manager.loss.ToString());
            scorecount.Close();

            Winnerbox.Text = "Player you have " + Manager.wins + " wins and " + Manager.loss + " losses";
        }

        // Updates values in the main storage file and sets the current form to mainform.
        private void FinalExit_Click(object sender, EventArgs e)
        {
            Manager.BattleForm.Updater();

            Manager.mainForm.Show();
            Manager.mainForm.Enabled = true;
            this.Dispose();
        }

        // Updates values in the main storage file and sets the current form to BattleForm.
        private void RestartButton_Click(object sender, EventArgs e)
        {
            Manager.BattleForm.Updater();

            Form2 RestartForm = new Form2();
            Manager.BattleForm.Show();
            Manager.BattleForm.Enabled = true;
            this.Dispose();
        }
    }
}






/*
             string[] Storage = File.ReadAllLines("H:/Fight Project/Fight Project/bin/debug/Game scores");
            manager.wins = int.Parse(Storage[0]);
            manager.loss = int.Parse(Storage[1]);
            manager.time = int.Parse(Storage[3]);
*/