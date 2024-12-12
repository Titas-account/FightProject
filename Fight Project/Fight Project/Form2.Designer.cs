namespace Fight_Project
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RollButton = new System.Windows.Forms.Button();
            this.Inventory = new System.Windows.Forms.Panel();
            this.Healthbar = new System.Windows.Forms.TextBox();
            this.Enemyimage = new System.Windows.Forms.PictureBox();
            this.EnemyHealthbar = new System.Windows.Forms.TextBox();
            this.Timer1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.EnemyAttackLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Enemyimage)).BeginInit();
            this.SuspendLayout();
            // 
            // RollButton
            // 
            this.RollButton.Location = new System.Drawing.Point(300, 300);
            this.RollButton.Name = "RollButton";
            this.RollButton.Size = new System.Drawing.Size(192, 88);
            this.RollButton.TabIndex = 0;
            this.RollButton.Text = "ROLL";
            this.RollButton.UseVisualStyleBackColor = true;
            this.RollButton.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // Inventory
            // 
            this.Inventory.Location = new System.Drawing.Point(76, 235);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(611, 45);
            this.Inventory.TabIndex = 1;
            // 
            // Healthbar
            // 
            this.Healthbar.Location = new System.Drawing.Point(19, 22);
            this.Healthbar.Name = "Healthbar";
            this.Healthbar.Size = new System.Drawing.Size(187, 20);
            this.Healthbar.TabIndex = 2;
            // 
            // Enemyimage
            // 
            this.Enemyimage.Location = new System.Drawing.Point(262, 32);
            this.Enemyimage.Name = "Enemyimage";
            this.Enemyimage.Size = new System.Drawing.Size(254, 179);
            this.Enemyimage.TabIndex = 3;
            this.Enemyimage.TabStop = false;
            // 
            // EnemyHealthbar
            // 
            this.EnemyHealthbar.Location = new System.Drawing.Point(545, 191);
            this.EnemyHealthbar.Name = "EnemyHealthbar";
            this.EnemyHealthbar.Size = new System.Drawing.Size(205, 20);
            this.EnemyHealthbar.TabIndex = 4;
            // 
            // Timer1
            // 
            this.Timer1.AutoSize = true;
            this.Timer1.Location = new System.Drawing.Point(704, 37);
            this.Timer1.Name = "Timer1";
            this.Timer1.Size = new System.Drawing.Size(0, 13);
            this.Timer1.TabIndex = 5;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(685, 388);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 37);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // EnemyAttackLabel
            // 
            this.EnemyAttackLabel.AutoSize = true;
            this.EnemyAttackLabel.Location = new System.Drawing.Point(377, 412);
            this.EnemyAttackLabel.Name = "EnemyAttackLabel";
            this.EnemyAttackLabel.Size = new System.Drawing.Size(0, 13);
            this.EnemyAttackLabel.TabIndex = 8;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fight_Project.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EnemyAttackLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Timer1);
            this.Controls.Add(this.EnemyHealthbar);
            this.Controls.Add(this.Enemyimage);
            this.Controls.Add(this.Healthbar);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.RollButton);
            this.Name = "Form2";
            this.Text = "                  ";
            ((System.ComponentModel.ISupportInitialize)(this.Enemyimage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RollButton;
        private System.Windows.Forms.Panel Inventory;
        private System.Windows.Forms.TextBox Healthbar;
        private System.Windows.Forms.PictureBox Enemyimage;
        private System.Windows.Forms.TextBox EnemyHealthbar;
        private System.Windows.Forms.Label Timer1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label EnemyAttackLabel;
    }
}