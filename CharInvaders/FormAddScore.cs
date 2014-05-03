using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormAddScore : Form
    {
        public string playerName {set; get;}

        public Form form;
        public FormAddScore()
        {
            InitializeComponent();
        }

        private void saveHighscore_Click(object sender, EventArgs e)
        {
            playerName = igrac.Text;
            this.DialogResult = DialogResult.OK;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
