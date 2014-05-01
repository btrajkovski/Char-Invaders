namespace WindowsFormsApplication1
{
    partial class FormMenu
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHighScore = new System.Windows.Forms.Button();
            this.btnCredits = new System.Windows.Forms.Button();
            this.lblScores = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(187, 95);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(179, 53);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHighScore
            // 
            this.btnHighScore.Location = new System.Drawing.Point(187, 182);
            this.btnHighScore.Name = "btnHighScore";
            this.btnHighScore.Size = new System.Drawing.Size(179, 53);
            this.btnHighScore.TabIndex = 1;
            this.btnHighScore.Text = "High Score";
            this.btnHighScore.UseVisualStyleBackColor = true;
            this.btnHighScore.Click += new System.EventHandler(this.btnHighScore_Click);
            // 
            // btnCredits
            // 
            this.btnCredits.Location = new System.Drawing.Point(187, 269);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(179, 53);
            this.btnCredits.TabIndex = 2;
            this.btnCredits.Text = "Credits";
            this.btnCredits.UseVisualStyleBackColor = true;
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScores.Location = new System.Drawing.Point(132, 48);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(99, 33);
            this.lblScores.TabIndex = 3;
            this.lblScores.Text = "label1";
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(13, 431);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(86, 32);
            this.back.TabIndex = 4;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // FormMenu
            // 
            this.AcceptButton = this.btnPlay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 475);
            this.Controls.Add(this.back);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.btnCredits);
            this.Controls.Add(this.btnHighScore);
            this.Controls.Add(this.btnPlay);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
           
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnHighScore;
        private System.Windows.Forms.Button btnCredits;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Button back;
    }
}