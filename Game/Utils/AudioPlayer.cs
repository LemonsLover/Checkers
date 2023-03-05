using System;
using System.Windows.Media;

namespace Game.Utils
{
    public static class AudioPlayer
    {
        private static MediaPlayer mediaPlayer = new MediaPlayer();
        public static void Play(string fileName)
        {
            mediaPlayer.Open(new Uri($@"pack://siteoforigin:,,,/Resources/Audio/{fileName}.mp3"));
            mediaPlayer.Play();
        }
    }
}
