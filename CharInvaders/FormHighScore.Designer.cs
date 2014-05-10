namespace WindowsFormsApplication1
{
    partial class FormHighScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHighScore));
            this.lblScores = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear1 = new WindowsFormsApplication1.CustomButton();
            this.btnBack1 = new WindowsFormsApplication1.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScores
            // 
            this.lblScores.AutoSize = true;
            this.lblScores.BackColor = System.Drawing.Color.Transparent;
            this.lblScores.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScores.ForeColor = System.Drawing.Color.Transparent;
            this.lblScores.Location = new System.Drawing.Point(125, 92);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(117, 33);
            this.lblScores.TabIndex = 4;
            this.lblScores.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(173, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "High Score:";
            // 
            // btnClear1
            // 
            this.btnClear1.BackColor = System.Drawing.Color.Transparent;
            this.btnClear1.Image = ((System.Drawing.Image)(resources.GetObject("btnClear1.Image")));
            this.btnClear1.Location = new System.Drawing.Point(179, 404);
            this.btnClear1.Name = "btnClear1";
            this.btnClear1.Size = new System.Drawing.Size(101, 32);
            this.btnClear1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClear1.TabIndex = 9;
            this.btnClear1.TabStop = false;
            this.btnClear1.Click += new System.EventHandler(this.btnClear_Click);
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
            // FormHighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 475);
            this.Controls.Add(this.btnClear1);
            this.Controls.Add(this.btnBack1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormHighScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "High Score";
            this.Activated += new System.EventHandler(this.FormHighScore_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHighScore_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btnClear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Label label1;
        private CustomButton btnBack1;
        private CustomButton btnClear1;
    }
}