using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CharInvaders
{
    public class PowerUp_Destroyer : Enemy
    {
        public PowerUp_Destroyer(Form f, int left, char letter)
            : base(f, left, letter)
        {
            base.Name = "Destroyer";
            base.Image = Properties.Resources.powerup_destroy_all;
        }
    }
}
