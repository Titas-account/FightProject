using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.CodeDom;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Xml.Schema;

namespace Fight_Project
{
    public partial class Form2 : Form
    {   
        // Setting up Variables
        public string name = "";
        public int rolls = 0;
        int currentXPosition = 0;
        double health = 150;
        double Totalhealth = 150;
        double enemyhealth = 0;
        double Totalenemyhealth = 0;
        string Player1 = "Player 1";
        string Player2 = "Player 2";
        string currentplayer = "Player 1";
        bool burned = false;
        bool enemyburned = false;
        bool stunned = false;
        bool enemystunned = false;
        public int currentrolls = 0;
        public int currentrolls2 = 0;

        public int wins = 0;
        public int loss=0;

        Timer Main = new Timer();
         public int time = 0;

        public Form2()
        {
            //Sets the current form to 'Battleform' using the manager class.
            InitializeComponent();
            Manager.BattleForm = this;

            // Creating enemy presets and randomly choosing one to set to the current/main enemy, 'Opponent'.
            Enemy tr = new Enemy(100, "Tree");
            Enemy h = new Enemy(150, "Human");
            Enemy v = new Enemy(100, "Volcano");
            Enemy ts = new Enemy(75, "Tsunami");
            Enemy Opponent = new Enemy(69,"Placeholder");

            if (Manager.Loaded)
            {
                string[] Storage = File.ReadAllLines("H:/Fight Project/Fight Project/bin/debug/Game scores.txt");

                health = double.Parse(Storage[3]);
                Opponent.health = double.Parse(Storage[4]);
                Opponent.name = Storage[5].Trim().ToLower();
            }
            else
            {
                Random random = new Random();
                int randomenemy = random.Next(1, 5);

                if (randomenemy == 1)
                {
                    Opponent.name = "Tree";
                    Opponent = tr;
                }
                if (randomenemy == 2)
                {
                    Opponent.name = "Human";
                    Opponent = h;
                }
                if (randomenemy == 3)
                {
                    Opponent.name = "Volcano";
                    Opponent = v;
                }
                if (randomenemy == 4)
                {
                    Opponent.name = "Tsunami";
                    Opponent = ts;
                }
            }

            EnemySetup();

            void EnemySetup()
            {
                if (Opponent.name == "Tree")
                {
                    Image a = Image.FromFile("tree.jpg");
                    Enemyimage.Image = a;                   
                }
                if (Opponent.name == "Human")
                {
                    Image a = Image.FromFile("human.png");
                    Enemyimage.Image = a;
                }
                if (Opponent.name == "Volcano")
                {
                    Image a = Image.FromFile("volcano.jpg");
                    Enemyimage.Image = a;
                }
                if (Opponent.name == "Tsunami")
                {
                    Image a = Image.FromFile("tsunami.jpg");
                    Enemyimage.Image = a;
                }
                Manager.Loaded = false;
            }

            // Updates the health textbox at the start of the game.
            if (Healthbar.Text != health.ToString())
            {
                Healthbar.Text = "Health =" + health;
            }
            if (EnemyHealthbar.Text != enemyhealth.ToString())
            {
                EnemyHealthbar.Text = Opponent.name + " Health =" + Opponent.health;
            }

            //Sets the stats of the enemy to be public.
            enemyhealth = Opponent.health;
            name = Opponent.name;
            Totalenemyhealth = Opponent.health;
            Manager.EnemyName = name;

            Enemyimage.SizeMode = PictureBoxSizeMode.Zoom;

            // Sets up a timer that runs the 'ChangeTime' function with a 1 second interval.
            Main.Tick += Changetime;
            Main.Interval= 1000;
            Main.Start();

        }

        // Updates the text on the 'Timer' textbox.
         void Changetime(object sender, EventArgs e)
        {
            Timer1.Text= "Playtime "+time.ToString();
            time++;
        }

        List<PictureBox> inventoryslot = new List<PictureBox>();

        // Checks if it is the players move, if it does not it makes the computer so a random attack by referencing the 'EnemyAttack' function with a random number.
        private void RollButton_Click(object sender, EventArgs e)
        {
            if (currentplayer == "Player 1")
            {
                RandomRoll();
            }
            else
            {
                Random r = new Random();
                int movenumber = r.Next(1, 5);

                if (movenumber == 1)
                {
                    EnemyAttack(15, "Fire");
                    EnemyAttackLabel.Text="Enemy used Fire Attack";
                }
                if (movenumber == 2)
                {
                    EnemyAttack(20, "Fist");
                    EnemyAttackLabel.Text = "Enemy used Fist Attack";
                }
                if (movenumber == 3)
                {
                    EnemyAttack(15, "Stun");
                    EnemyAttackLabel.Text = "Enemy used Stun Attack";
                }
                if (movenumber == 4)
                {
                    EnemyAttack(0, "Heal");
                    EnemyAttackLabel.Text = "Enemy used Heal";
                }
            }
        }

        // Creates a random attack by referencing the 'Move' function usking a random number.
        public void RandomRoll()
        {
           if (stunned == false)
            {
            Random r = new Random();
            int movenumber = r.Next(1, 5);

            if (movenumber == 1)
            {
                Move(1);
            }
            else if (movenumber == 2) { Move(2); }
            else if (movenumber == 3) { Move(3); }
            else if (movenumber == 4) { Move(4); }
            }

            Turn();

        }

        // Checks the random move and creates a picturebox based off the type, furthermore it also sets the tag of the attack to be the stats so they can be easily accesed for each attack.
        public void Move(int type)
        {

            PictureBox xx = new PictureBox();
            xx.SizeMode = PictureBoxSizeMode.Zoom;
            xx.Location = new Point(currentXPosition, 0);
            currentXPosition += 100;

            inventoryslot.Add(xx);

            if (type == 1)
            {
                Image x = Image.FromFile("FireMove.jpg");
                xx.Image = x;
                xx.Tag = new Attack(15, "Fire");
            }
            else if (type == 2)
            {
                Image x = Image.FromFile("Fistmove.png");
                xx.Image = x;
                xx.Tag = new Attack(20, "Fist");
            }
            else if (type == 3)
            {
                Image x = Image.FromFile("Stunmove.jpg");
                xx.Image = x;
                xx.Tag = new Attack(15, "Stun");
            }
            else if (type == 4)
            {
                Image x = Image.FromFile("Healthmove.jpg");
                xx.Image = x;
                xx.Tag = new Attack(0, "Health");
            }
            xx.Click += Attack;
            Inventory.Controls.Add(xx);
        }

        // Main attack function, checks the status of the move that was clicked and links the the Turn procedure.
        void Attack(object sender, EventArgs e)
        {
            PictureBox b = sender as PictureBox;
            Attack a = b.Tag as Attack;
           
            if (currentplayer == "Player 1")
            {
                if (stunned == false)
                {
                    enemyhealth = enemyhealth - a.damage;

                    if (a.status == "Fire")
                    {
                        if (enemyburned == false)
                        {
                            enemyburned = true;
                        }
                    }
                    else if (a.status == "Stun")
                    {
                        if (enemystunned == false)
                        {
                            enemystunned = true;
                        }
                    }

                    if (a.status == "Health")
                    {
                        Heal(true);
                    }
                }
            }

            Turn();
        }

        // Makes the enemy use a random move on the player unless it is stunned.
        void EnemyAttack(int d, string s)
        {
            if (enemystunned == false)
            {
                Attack b = new Attack(d, s);

                health = health - b.damage;

                if (b.status == "Fire")
                {
                    if (burned == false)
                    {
                        burned = true;
                    }
                }
                else if (b.status == "Stun")
                {
                    if (stunned == false)
                    {
                        stunned = true;
                    }
                }

                if (b.status == "Heal")
                {
                    Heal(true);
                }
            }

            Turn();
        }

        // Gives a 1 in 4 chance of the enemy being stunned once the 'Stun' move is used.
        public void Stun()
        {
            
            Random r = new Random();
            int a = r.Next(1, 5);

            if (enemystunned == true)
            {
                if (a == 1)
                {
                    StunCountdown();
                }

            }
            if (stunned == true)
            {
                if (a == 1)
                {
                    StunCountdown();
                }
            }
        }

        // Checks if either player or computer is still stunned.
        public void StunCountdown()
        {
            if (enemystunned == true)
            {
                if (currentrolls < 2)
                {
                    enemystunned = true;
                }
                else
                {
                    enemystunned = false;
                    currentrolls = 0;
                }
                currentrolls++;
            }

            if (stunned == true)
            {
                if (currentrolls2 < 2)
                {
                    stunned = true;
                }
                else
                {
                    stunned = false;
                    currentrolls2 = 0;
                }
                currentrolls2++;
            }
        }

        //Returns the health after the burn action has been done.
        public double Burn()
        {
            if (enemyburned == true)
            {
                if (enemyhealth <= Totalenemyhealth * 0.1)
                {
                    enemyhealth = 0;
                }
                else
                {
                    enemyhealth = enemyhealth * 0.8;
                }
                return enemyhealth;
            }
            else if (burned == true)
            {
                if (health <= Totalhealth * 0.1)
                {
                    health = 0;
                }
                else
                {
                    health = health * 0.8;
                }
                return health;

            }
            else
            {
                return 0;
            }
        }

        //Returns the health after the health action has been done.
        public double Heal(bool heal)
        {
            if (heal)
            {
                if (currentplayer == "Player 1")
                {
                    if (health < Totalhealth)
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            health += 1;
                            if (health == Totalhealth)
                            {
                                break;
                            }
                        }
                    }
                    heal = false;
                    return health;
                }
                else
                {
                    if (enemyhealth < Totalenemyhealth)
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            enemyhealth += 1;
                            if (enemyhealth == Totalenemyhealth)
                            {
                                break;
                            }
                        }
                    }
                    heal = false;
                    return enemyhealth;
                }
            }
            else { return 0; }
        }

        // Updates all the move statuses (e.g. if enemy is stunned) and checks if the game has ended.
        public void Turn()
        {

            Burn();   
            if (currentrolls > 0 || currentrolls2 > 0)
            {
                StunCountdown();
            }
           else
            {
                Stun();
            }
            
            if (Healthbar.Text != "Health =" + health.ToString())
            {
                Healthbar.Text = "Health =" + health;
            }
            if (EnemyHealthbar.Text != name+" Health =" + enemyhealth.ToString())
            {
                EnemyHealthbar.Text = name+" Health =" + enemyhealth;
            }

            if (enemyhealth <= 0)
            {
                GameEnd(true);
            }
            else if (health <= 0)
            {
                GameEnd(false);
            }

                if (currentplayer == "Player 1")
                {
                    currentplayer = "Player 2";
                    rolls++;
                }
                else if (currentplayer == "Player 2")
                {
                    currentplayer = "Player 1";
                }


            if (currentplayer== "Player 1")
            {
                RollButton.Text = "ROLL";
            }
            else if (currentplayer == "Player 2")
            {
                RollButton.Text = "CONTINUE";
            }     
        }

        // Updates values in the main storage file and sets the current form to mainform.
        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            Updater();

            Manager.mainForm.Show();
            Manager.mainForm.Enabled = true;
            this.Dispose();
        }

        //Updates all the values in the files, usually done before exiting the game
        public void Updater()
        {
            Manager.time = time;
            Manager.health = health;
            Manager.enemyhealth = enemyhealth;


            StreamWriter scorecount = new StreamWriter("H:/Fight Project/Fight Project/bin/debug/Game scores.txt", false);
            scorecount.WriteLine(Manager.wins.ToString());
            scorecount.WriteLine(Manager.loss.ToString());
            scorecount.WriteLine(Manager.time.ToString());
            scorecount.WriteLine(Manager.health.ToString());
            scorecount.WriteLine(Manager.enemyhealth.ToString());
            scorecount.WriteLine(Manager.EnemyName);
            scorecount.Close();
        }
        // Checks if the Player won the game or if it was the computer.
        public void GameEnd(bool won)
        {
            if (won)
            {
                Manager.wins++;
            }
            else

            {
                Manager.loss++;
            }

            Form3 End = new Form3();
            End.Show();
            this.Enabled = false;
            this.Dispose();
        }
    }

    // Class to manage and create attacks, it contains damage and the 'status' of the attack.
    public class Attack
    {
        public double damage;
        public string status;
        public Attack(double d, string s)
        {
            damage = d;
            status = s;
        }
    }
    // Class to manage and create enemies, giving each their own health and name.
    public class Enemy
    {
        public double health;
        public string name;

        public Enemy(double h, string n)
        {
            health = h;
            name = n;
        }
    }

    // Class to manage scores, time and health of characters to pass them between forms and to help store it easily in forms.
    public class Manager
    {
        public static int wins = 0;
        public static int loss = 0;
        public static int time = 0;
        public static double health = 0;
        public static double enemyhealth = 0;
        public static Form1 mainForm;
        public static Form2 BattleForm;
        public static Form3 EndForm;
        public static bool Loaded = false;
        public static string EnemyName = "";

        public static void ResetForNew()
        {
            wins = 0;
            loss = 0;
            health = 0;
            enemyhealth = 0;
            EnemyName = "";
        }
    }
}



