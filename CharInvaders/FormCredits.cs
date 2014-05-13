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
    public partial class FormCredits : Form
    {
        private FormMenu menuForm;

        public FormCredits(FormMenu menuForm)
        {
            InitializeComponent();
            this.menuForm = menuForm;
        }


        private void FormCredits_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuForm.Show();
        }
    }
}
