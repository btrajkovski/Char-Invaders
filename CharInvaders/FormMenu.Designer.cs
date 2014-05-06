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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.btnPlay = new System.Windows.Forms.PictureBox();
            this.btnHighScore = new System.Windows.Forms.PictureBox();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.btnHowToPlay = new System.Windows.Forms.PictureBox();
            this.btnCredits = new System.Windows.Forms.PictureBox();
            this.TimerBackgroundLoop = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHighScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHowToPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(182, 13);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(175, 56);
            this.btnPlay.TabIndex = 7;
            this.btnPlay.TabStop = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHighScore
            // 
            this.btnHighScore.Location = new System.Drawing.Point(178, 102);
            this.btnHighScore.Name = "btnHighScore";
            this.btnHighScore.Size = new System.Drawing.Size(177, 53);
            this.btnHighScore.TabIndex = 8;
            this.btnHighScore.TabStop = false;
            this.btnHighScore.Click += new System.EventHandler(this.btnHighScore_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(182, 187);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(175, 57);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.TabStop = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnHowToPlay
            // 
            this.btnHowToPlay.Location = new System.Drawing.Point(178, 272);
            this.btnHowToPlay.Name = "btnHowToPlay";
            this.btnHowToPlay.Size = new System.Drawing.Size(177, 57);
            this.btnHowToPlay.TabIndex = 10;
            this.btnHowToPlay.TabStop = false;
            this.btnHowToPlay.Click += new System.EventHandler(this.btnHowToPlay_Click);
            // 
            // btnCredits
            // 
            this.btnCredits.Location = new System.Drawing.Point(178, 361);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(177, 58);
            this.btnCredits.TabIndex = 11;
            this.btnCredits.TabStop = false;
            this.btnCredits.Click += new System.EventHandler(this.btnCredits_Click);
            // 
            // TimerBackgroundLoop
            // 
            this.TimerBackgroundLoop.Interval = 150;
            this.TimerBackgroundLoop.Tick += new System.EventHandler(this.TimerBackgroundLoop_Tick);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(580, 475);
            this.Controls.Add(this.btnCredits);
            this.Controls.Add(this.btnHowToPlay);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnHighScore);
            this.Controls.Add(this.btnPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHighScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHowToPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCredits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnPlay;
        private System.Windows.Forms.PictureBox btnHighScore;
        private System.Windows.Forms.PictureBox btnSettings;
        private System.Windows.Forms.PictureBox btnHowToPlay;
        private System.Windows.Forms.PictureBox btnCredits;
        private System.Windows.Forms.Timer TimerBackgroundLoop;
    }
}