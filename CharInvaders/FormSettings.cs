using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CharInvaders
{
    public partial class FormSettings : Form
    {
        public bool shouldPlay { set; get; }
        private FormMenu menuForm;

        public FormSettings(FormMenu menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
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
            if (chkSound.Checked)
            {
                SoundCollection.ChangeSoundVolume(0);
                sldSound.Enabled = false;
            }
            else
            {
                SoundCollection.ChangeSoundVolume((int)sldSound.Value);
                sldSound.Enabled = true;
            }
        }

        private void chkPlayMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlayMusic.Checked)
            {
                SoundCollection.ChangeMusicVolume(0);
                sldMusic.Enabled = false;
            }
            else
            {
                SoundCollection.ChangeMusicVolume((int)sldMusic.Value);
                sldMusic.Enabled = true;
            }
        }

        private void sldSound_Scroll(object sender, EventArgs e)
        {
            SoundCollection.ChangeSoundVolume((int)sldSound.Value);

        }

        private void sldMusic_Scroll(object sender, EventArgs e)
        {
            SoundCollection.ChangeMusicVolume((int)sldMusic.Value);
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }

        private void FormSettings_Activated(object sender, EventArgs e)
        {
            if (SoundCollection.PlayerLaserSound.settings.volume == 0)
            {
                chkSound.Checked = true;
                sldSound.Enabled = false;
            }
            else
            {
                chkSound.Checked = false;
                sldSound.Enabled = true;
            }


            if (SoundCollection.PlayerThemeSong.settings.volume == 0)
            {
                chkPlayMusic.Checked = true;
                sldMusic.Enabled = false;
            }
            else
            {
                chkPlayMusic.Checked = false;
                sldMusic.Enabled = true;
            }
        }
    }
}
