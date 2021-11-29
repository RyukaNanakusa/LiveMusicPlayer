using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMusicPlayer.src.Logic.MusicPlayer
{
    public class MusicPlayerContainer
    {
        private MusicPlayerContainer()
        {}

        private static IMusicPlayer _musicPlayer = new NoneMusicPlayer();
        public static IMusicPlayer MusicPlayer
        {
            get => _musicPlayer;
            set
            {
                if (_musicPlayer.IsPlaying())
                {
                    _musicPlayer.StopMusic();
                }
                _musicPlayer = value;
            }
        }



    }
}
