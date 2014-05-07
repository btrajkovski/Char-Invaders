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
            chkPlayMusic.Checked = menuForm.PlayThemeSong;
            chkSound.Checked = menuForm.PlaySounds;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            shouldPlay = chkSound.Checked;
            menuForm.PlaySounds = shouldPlay;

        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void chkPlayMusic_CheckedChanged(object sender, EventArgs e)
        {
            menuForm.PlayThemeSong = chkPlayMusic.Checked;
            menuForm.playMusic();
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm.Location = this.Location;
            menuForm.Show();
        }

        private void FormSettings_Activated(object sender, EventArgs e)
        {
            this.Location = menuForm.Location;
        }
    }
}
