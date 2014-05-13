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
            this.sldSound = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sldMusic = new System.Windows.Forms.TrackBar();
            this.chkPlayMusic = new System.Windows.Forms.CheckBox();
            this.btnBack1 = new WindowsFormsApplication1.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.sldSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSound
            // 
            this.chkSound.AutoSize = true;
            this.chkSound.BackColor = System.Drawing.Color.Transparent;
            this.chkSound.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSound.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkSound.Location = new System.Drawing.Point(315, 129);
            this.chkSound.Name = "chkSound";
            this.chkSound.Size = new System.Drawing.Size(73, 26);
            this.chkSound.TabIndex = 10;
            this.chkSound.Text = "Mute";
            this.chkSound.UseVisualStyleBackColor = false;
            this.chkSound.CheckedChanged += new System.EventHandler(this.chkSound_CheckedChanged);
            // 
            // sldSound
            // 
            this.sldSound.BackColor = System.Drawing.Color.DarkRed;
            this.sldSound.LargeChange = 10;
            this.sldSound.Location = new System.Drawing.Point(92, 129);
            this.sldSound.Maximum = 100;
            this.sldSound.Name = "sldSound";
            this.sldSound.Size = new System.Drawing.Size(217, 45);
            this.sldSound.TabIndex = 12;
            this.sldSound.TickFrequency = 10;
            this.sldSound.Value = 40;
            this.sldSound.Scroll += new System.EventHandler(this.sldSound_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(86, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 33);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sound Effects Volume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(86, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 33);
            this.label2.TabIndex = 16;
            this.label2.Text = "Music Volume";
            // 
            // sldMusic
            // 
            this.sldMusic.BackColor = System.Drawing.Color.DarkRed;
            this.sldMusic.LargeChange = 10;
            this.sldMusic.Location = new System.Drawing.Point(92, 213);
            this.sldMusic.Maximum = 100;
            this.sldMusic.Name = "sldMusic";
            this.sldMusic.Size = new System.Drawing.Size(217, 45);
            this.sldMusic.TabIndex = 15;
            this.sldMusic.TickFrequency = 10;
            this.sldMusic.Value = 60;
            this.sldMusic.Scroll += new System.EventHandler(this.sldMusic_Scroll);
            // 
            // chkPlayMusic
            // 
            this.chkPlayMusic.AutoSize = true;
            this.chkPlayMusic.BackColor = System.Drawing.Color.Transparent;
            this.chkPlayMusic.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPlayMusic.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkPlayMusic.Location = new System.Drawing.Point(315, 213);
            this.chkPlayMusic.Name = "chkPlayMusic";
            this.chkPlayMusic.Size = new System.Drawing.Size(73, 26);
            this.chkPlayMusic.TabIndex = 14;
            this.chkPlayMusic.Text = "Mute";
            this.chkPlayMusic.UseVisualStyleBackColor = false;
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sldMusic);
            this.Controls.Add(this.chkPlayMusic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sldSound);
            this.Controls.Add(this.chkSound);
            this.Controls.Add(this.btnBack1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Activated += new System.EventHandler(this.FormSettings_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sldSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sldMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButton btnBack1;
        private System.Windows.Forms.CheckBox chkSound;
        private System.Windows.Forms.TrackBar sldSound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar sldMusic;
        private System.Windows.Forms.CheckBox chkPlayMusic;
    }
}