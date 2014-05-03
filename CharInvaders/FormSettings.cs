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
    public partial class FormSettings : Form
    {
        public bool shouldPlay { set; get; }
        private FormMenu menuForm;

        public FormSettings(FormMenu menuForm)
        {
            InitializeComponent();
            this.Location = menuForm.Location;
            this.menuForm = menuForm;
            shouldPlay = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            shouldPlay = chkSound.Checked;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            menuForm.shouldPlay = shouldPlay;
            this.Hide();
            menuForm.Location = this.Location;
            menuForm.Show();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
