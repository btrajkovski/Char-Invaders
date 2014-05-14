using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CharInvaders
{
    public class PowerUp_Bonus : Enemy
    {
        public PowerUp_Bonus(Form f, int left, char letter) : base(f, left, letter)
        {
            base.Name = "Bonus";
            base.Image = Properties.Resources.powerup_3x_bonus;
        }
    }
}
