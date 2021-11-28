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

        public static IMusicPlayer GetMusicPlayer() => _musicPlayer;
        
        public static void SetMusicPlayer(IMusicPlayer player)
        {
            var isPlaying = _musicPlayer.IsPlaying();
            if (isPlaying)
            {
                _musicPlayer.StopMusic();
            }
            _musicPlayer = null;
            _musicPlayer = player;
        }



    }
}
