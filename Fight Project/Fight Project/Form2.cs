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

        public Form2()
        {
            InitializeComponent();

            Random random = new Random();
            int randomenemy = random.Next(1, 5);

            Enemy tr = new Enemy(100, "Tree");
            Enemy h = new Enemy(150, "Human");
            Enemy v = new Enemy(100, "Volcano");
            Enemy ts = new Enemy(75, "Tsunami");
            Enemy Opponent = new Enemy(69,"Placeholder");

            if (randomenemy == 1)
            {
                Image a = Image.FromFile("tree.jpg");
                Enemyimage.Image = a;
                 Opponent = tr;
            }
            if (randomenemy == 2)
            {
                Image a = Image.FromFile("human.png");
                Enemyimage.Image = a;
                Opponent = h;
            }
            if (randomenemy == 3)
            {
                Image a = Image.FromFile("volcano.jpg");
                Enemyimage.Image = a;
                Opponent= v;
            }
            if (randomenemy == 4)
            {
                Image a = Image.FromFile("tsunami.jpg");
                Enemyimage.Image = a;
                Opponent = ts;
            }


            if (Healthbar.Text != health.ToString())
            {
                Healthbar.Text = "Health =" + health;
            }
            if (EnemyHealthbar.Text != enemyhealth.ToString())
            {
                EnemyHealthbar.Text = Opponent.name + " Health =" + Opponent.health;
            }

            enemyhealth = Opponent.health;
            name = Opponent.name;
            Totalenemyhealth = Opponent.health;

            Enemyimage.SizeMode = PictureBoxSizeMode.Zoom;

            if (File.Exists("H:/Fight Project/Fight Project/bin/debug/Game scores"))
            {

            }
            else
            {
                FileStream Scores = File.Create("H:/Fight Project/Fight Project/bin/debug/Game scores");
                Scores.Close();
            }

        }

        List<PictureBox> inventoryslot = new List<PictureBox>();

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
                }
                if (movenumber == 2)
                {
                    EnemyAttack(20, "Fist");
                }
                if (movenumber == 3)
                {
                    EnemyAttack(15, "Stun");
                }
                if (movenumber == 4)
                {
                    EnemyAttack(0, "Heal");
                }
            }
        }
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

        public void StunCountdown()
        {
            if (enemystunned == true)
            {
                if (currentrolls < 3)
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
                if (currentrolls2 < 3)
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

        public void GameEnd(bool won)
        {
            Form3 End = new Form3();
            End.Show();
            this.Enabled = false;

            if (won)
            {
                manager.wins++;
            }
            else

            {
                manager.loss++;
            }
        }
    }


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

    public class manager
    {
        public static int wins = 0;
        public static int loss = 0;
    }
}



