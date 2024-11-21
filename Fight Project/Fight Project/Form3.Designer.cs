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
            this.EndTextbox = new System.Windows.Forms.TextBox();
            this.RestartButton = new System.Windows.Forms.Button();
            this.Winnerbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EndTextbox
            // 
            this.EndTextbox.Location = new System.Drawing.Point(686, 192);
            this.EndTextbox.Name = "EndTextbox";
            this.EndTextbox.Size = new System.Drawing.Size(59, 20);
            this.EndTextbox.TabIndex = 0;
            this.EndTextbox.Text = "THE END";
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(613, 414);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(219, 87);
            this.RestartButton.TabIndex = 2;
            this.RestartButton.Text = "Continue";
            this.RestartButton.UseVisualStyleBackColor = true;
            // 
            // Winnerbox
            // 
            this.Winnerbox.Location = new System.Drawing.Point(581, 254);
            this.Winnerbox.Name = "Winnerbox";
            this.Winnerbox.Size = new System.Drawing.Size(296, 20);
            this.Winnerbox.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 639);
            this.Controls.Add(this.Winnerbox);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.EndTextbox);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EndTextbox;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.TextBox Winnerbox;
    }
}