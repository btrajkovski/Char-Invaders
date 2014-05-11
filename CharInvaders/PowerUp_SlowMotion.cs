using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class PowerUp_SlowMotion : Enemy
    {
        public PowerUp_SlowMotion(Form f, int left, char letter)
            : base(f, left, letter)
        {
            base.Name = "SlowMotion";
            base.Image = Properties.Resources.powerup_slow_motion;
        }
    }
}
