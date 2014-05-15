using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using WMPLib;

namespace CharInvaders
{

    public static class SoundCollection
    {
        public static WindowsMediaPlayer PlayerLaserSound;
        public static WindowsMediaPlayer PlayerCannonCrush;
        public static WindowsMediaPlayer PlayerThemeSong;
        public static WindowsMediaPlayer PlayerSlowMotionStart;
        public static WindowsMediaPlayer PlayerSlowMotionFinish;

        public static void Initialize()
        {
            PlayerLaserSound = new WindowsMediaPlayer();
            PlayerCannonCrush = new WindowsMediaPlayer();
            PlayerThemeSong = new WindowsMediaPlayer();
            PlayerSlowMotionFinish = new WindowsMediaPlayer();
            PlayerSlowMotionStart = new WindowsMediaPlayer();

            PlayerThemeSong.settings.autoStart = false;
            PlayerCannonCrush.settings.autoStart = false;
            PlayerLaserSound.settings.autoStart = false;
            PlayerSlowMotionFinish.settings.autoStart = false;
            PlayerSlowMotionStart.settings.autoStart = false;

            // load
            PlayerThemeSong.URL = @"sounds\main_theme.mp3";
            PlayerCannonCrush.URL = @"sounds\explosion_iceman.mp3";
            PlayerLaserSound.URL = @"sounds\laser2.mp3";
            PlayerSlowMotionFinish.URL = @"sounds\slow_motion.mp3";
            PlayerSlowMotionStart.URL = @"sounds\slow_motion2.mp3";

            // set volume
            PlayerThemeSong.settings.volume = 60;
            PlayerCannonCrush.settings.volume = 40;
            PlayerLaserSound.settings.volume = 40;
            PlayerSlowMotionFinish.settings.volume = 80;
            PlayerSlowMotionStart.settings.volume = 80;
        }

        public static void PlayThemeSong()
        {
            //PlayerThemeSong.URL = @"sounds\main_theme.mp3";
            PlayerThemeSong.settings.volume = 50;
            PlayerThemeSong.settings.setMode("loop", true);
            PlayerThemeSong.controls.play();
        }

        public static void StopThemeSong()
        {
            PlayerThemeSong.controls.stop();
        }

        public static void PlayCrushSound()
        {
            if (PlayerCannonCrush.playState == WMPPlayState.wmppsPlaying)
            {
                PlayerCannonCrush.controls.stop();
            }
            PlayerCannonCrush.controls.play();
        }

        public static void PlayLaserSound()
        {
            if (PlayerLaserSound.playState == WMPPlayState.wmppsPlaying)
            {
                PlayerLaserSound.controls.stop();
            }
            PlayerLaserSound.controls.play();
        }

        public static void PlaySlowMotionStart()
        {
            if (PlayerSlowMotionStart.playState == WMPPlayState.wmppsPlaying)
            {
                PlayerSlowMotionStart.controls.stop();
            }
            PlayerSlowMotionStart.controls.play();
        }

        public static void PlaySlowMotionFinish()
        {
            if (PlayerSlowMotionFinish.playState == WMPPlayState.wmppsPlaying)
            {
                PlayerSlowMotionFinish.controls.stop();
            }
            PlayerSlowMotionFinish.controls.play();
        }

        public static void ChangeMusicVolume(int x)
        {
            PlayerThemeSong.settings.volume = x;
        }

        public static void ChangeSoundVolume(int x)
        {
            PlayerLaserSound.settings.volume = x;
            PlayerCannonCrush.settings.volume = x;
            if (x == 0)
            {
                PlayerSlowMotionFinish.settings.volume = 0;
                PlayerSlowMotionStart.settings.volume = 0;
            }
            else
            {
                PlayerSlowMotionFinish.settings.volume = 90;
                PlayerSlowMotionStart.settings.volume = 90;
            }
        }
    }
}
