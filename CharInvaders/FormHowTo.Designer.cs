namespace CharInvaders
{
    partial class FormHowTo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHowTo));
            this.btnBack1 = new CharInvaders.CustomButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack1
            // 
            this.btnBack1.BackColor = System.Drawing.Color.Transparent;
            this.btnBack1.BackgroundImage = global::CharInvaders.Properties.Resources.main_background1;
            this.btnBack1.Image = ((System.Drawing.Image)(resources.GetObject("btnBack1.Image")));
            this.btnBack1.Location = new System.Drawing.Point(43, 449);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.Size = new System.Drawing.Size(101, 32);
            this.btnBack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBack1.TabIndex = 4;
            this.btnBack1.TabStop = false;
            this.btnBack1.Click += new System.EventHandler(this.btnBack1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CharInvaders.Properties.Resources.howto_back;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(980, 515);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormHowTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 514);
            this.Controls.Add(this.btnBack1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormHowTo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "How To Play";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCredits_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButton btnBack1;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}