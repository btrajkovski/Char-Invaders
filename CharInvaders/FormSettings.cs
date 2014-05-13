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
            this.menuForm = menuForm;
            chkPlayMusic.Checked = menuForm.PlayThemeSong;
            chkSound.Checked = menuForm.PlaySounds;
            this.BackgroundImage = Properties.Resources.main_background1;
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm.Show();
        }

        private void chkSound_CheckedChanged(object sender, EventArgs e)
        {
            shouldPlay = chkSound.Checked;
            menuForm.PlaySounds = shouldPlay;
        }

        private void chkPlayMusic_CheckedChanged(object sender, EventArgs e)
        {
            menuForm.PlayThemeSong = chkPlayMusic.Checked;
            menuForm.playMusic();
        }
    }
}
