namespace Fight_Project
{
    partial class Form3
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
            this.RestartButton = new System.Windows.Forms.Button();
            this.Winnerbox = new System.Windows.Forms.TextBox();
            this.EndTextbox = new System.Windows.Forms.Label();
            this.FinalExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(613, 414);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(219, 87);
            this.RestartButton.TabIndex = 2;
            this.RestartButton.Text = "Continue";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // Winnerbox
            // 
            this.Winnerbox.Location = new System.Drawing.Point(581, 254);
            this.Winnerbox.Name = "Winnerbox";
            this.Winnerbox.Size = new System.Drawing.Size(296, 20);
            this.Winnerbox.TabIndex = 3;
            // 
            // EndTextbox
            // 
            this.EndTextbox.AutoSize = true;
            this.EndTextbox.Location = new System.Drawing.Point(689, 219);
            this.EndTextbox.Name = "EndTextbox";
            this.EndTextbox.Size = new System.Drawing.Size(55, 13);
            this.EndTextbox.TabIndex = 4;
            this.EndTextbox.Text = "THE END";
            // 
            // FinalExit
            // 
            this.FinalExit.Location = new System.Drawing.Point(1255, 530);
            this.FinalExit.Name = "FinalExit";
            this.FinalExit.Size = new System.Drawing.Size(146, 53);
            this.FinalExit.TabIndex = 5;
            this.FinalExit.Text = "EXIT";
            this.FinalExit.UseVisualStyleBackColor = true;
            this.FinalExit.Click += new System.EventHandler(this.FinalExit_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fight_Project.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1482, 639);
            this.Controls.Add(this.FinalExit);
            this.Controls.Add(this.EndTextbox);
            this.Controls.Add(this.Winnerbox);
            this.Controls.Add(this.RestartButton);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.TextBox Winnerbox;
        private System.Windows.Forms.Label EndTextbox;
        private System.Windows.Forms.Button FinalExit;
    }
}