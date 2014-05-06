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
            chkPlayMusic.Checked = menuForm.playThemeSong;
            chkSound.Checked = menuForm.shouldPlay;
            radioButton1.Checked = menuForm.Theme == 1;
            radioButton2.Checked = !radioButton1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            shouldPlay = chkSound.Checked;
            menuForm.shouldPlay = shouldPlay;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm.Location = this.Location;
            menuForm.Show();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void chkPlayMusic_CheckedChanged(object sender, EventArgs e)
        {
            menuForm.playThemeSong = chkPlayMusic.Checked;
            menuForm.playMusic();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            menuForm.Theme = 1;
            menuForm.setTheme();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            menuForm.Theme = 2;
            menuForm.setTheme();
        }
    }
}
