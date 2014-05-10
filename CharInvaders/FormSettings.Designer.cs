namespace WindowsFormsApplication1
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.chkSound = new System.Windows.Forms.CheckBox();
            this.chkPlayMusic = new System.Windows.Forms.CheckBox();
            this.btnBack1 = new WindowsFormsApplication1.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSound
            // 
            this.chkSound.AutoSize = true;
            this.chkSound.Checked = true;
            this.chkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSound.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSound.Location = new System.Drawing.Point(59, 82);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(122, 27);
            this.chkSound.TabIndex = 0;
            this.chkSound.Text = "Play Sound";
            this.chkSound.UseVisualStyleBackColor = true;
            this.chkSound.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkPlayMusic
            // 
            this.chkPlayMusic.AutoSize = true;
            this.chkPlayMusic.Checked = true;
            this.chkPlayMusic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlayMusic.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.chkPlayMusic.Location = new System.Drawing.Point(58, 136);
            this.chkPlayMusic.Name = "chkPlayMusic";
            this.chkPlayMusic.Size = new System.Drawing.Size(115, 27);
            this.chkPlayMusic.TabIndex = 7;
            this.chkPlayMusic.Text = "Play Music";
            this.chkPlayMusic.UseVisualStyleBackColor = true;
            this.chkPlayMusic.CheckedChanged += new System.EventHandler(this.chkPlayMusic_CheckedChanged);
            // 
            // btnBack1
            // 
            this.btnBack1.BackColor = System.Drawing.Color.Transparent;
            this.btnBack1.Image = ((System.Drawing.Image)(resources.GetObject("btnBack1.Image")));
            this.btnBack1.Location = new System.Drawing.Point(54, 404);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.Size = new System.Drawing.Size(101, 32);
            this.btnBack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnBack1.TabIndex = 8;
            this.btnBack1.TabStop = false;
            this.btnBack1.Click += new System.EventHandler(this.btnBack1_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 475);
            this.Controls.Add(this.btnBack1);
            this.Controls.Add(this.chkPlayMusic);
            this.Controls.Add(this.chkSound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.Activated += new System.EventHandler(this.FormSettings_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.CheckBox chkPlayMusic;
        private CustomButton btnBack1;
    }
}