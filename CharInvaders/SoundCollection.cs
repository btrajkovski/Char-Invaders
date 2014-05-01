using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
namespace WindowsFormsApplication1
{

    public class SoundCollection
    {
        public SoundPlayer PlayerLaserSound;
        public SoundPlayer PlayerCannonCrush;

        public SoundCollection()
        {
            PlayerLaserSound = new SoundPlayer(Properties.Resources.mywavfile);
            PlayerCannonCrush = new SoundPlayer(Properties.Resources.explosion_iceman);
        }
    }
}
