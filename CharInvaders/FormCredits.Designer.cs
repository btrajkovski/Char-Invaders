namespace WindowsFormsApplication1
{
    partial class FormCredits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCredits));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack1 = new WindowsFormsApplication1.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.credits_back;
            this.pictureBox1.Location = new System.Drawing.Point(44, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(490, 328);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnBack1
            // 
            this.btnBack1.BackColor = System.Drawing.Color.Transparent;
            this.btnBack1.Image = ((System.Drawing.Image)(resources.GetObject("btnBack1.Image")));
            this.btnBack1.Location = new System.Drawing.Point(44, 405);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.Size = new System.Drawing.Size(101, 32);
            this.btnBack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBack1.TabIndex = 3;
            this.btnBack1.TabStop = false;
            this.btnBack1.Click += new System.EventHandler(this.btnBack1_Click);
            // 
            // FormCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 475);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCredits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCredits_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButton btnBack1;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}