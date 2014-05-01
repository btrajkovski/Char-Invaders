namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.lblHit = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblMiss = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHit
            // 
            this.lblHit.AutoSize = true;
            this.lblHit.Location = new System.Drawing.Point(195, 16);
            this.lblHit.Name = "lblHit";
            this.lblHit.Size = new System.Drawing.Size(13, 13);
            this.lblHit.TabIndex = 2;
            this.lblHit.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.lblScore);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblLevel);
            this.groupBox1.Controls.Add(this.lblMiss);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblHit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devoleper Pannel";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "New Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblScore.ForeColor = System.Drawing.Color.Black;
            this.lblScore.Location = new System.Drawing.Point(273, 29);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(13, 13);
            this.lblScore.TabIndex = 9;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(231, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Score:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Level:";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(273, 16);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(13, 13);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "1";
            // 
            // lblMiss
            // 
            this.lblMiss.AutoSize = true;
            this.lblMiss.Location = new System.Drawing.Point(195, 29);
            this.lblMiss.Name = "lblMiss";
            this.lblMiss.Size = new System.Drawing.Size(13, 13);
            this.lblMiss.TabIndex = 5;
            this.lblMiss.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Miss:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hit:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(580, 475);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Char Ivaders";
            this.TransparencyKey = System.Drawing.Color.White;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblHit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMiss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Button button2;
    }
}

