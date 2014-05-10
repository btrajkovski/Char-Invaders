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
    public partial class FormHowTo : Form
    {
        private FormMenu menuForm;

        public FormHowTo(FormMenu menuForm)
        {
            InitializeComponent();
            this.Location = menuForm.Location;
            this.menuForm = menuForm;
        }

        private void FormCredits_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm.Location = this.Location;
            menuForm.Show();
        }

        private void FormHowTo_Activated(object sender, EventArgs e)
        {
            this.Location = menuForm.Location;
        }

    }
}
