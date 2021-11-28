using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace LiveMusicPlayer.src.Logic.MusicPlayer
{
    public class LocalMusicPlayer : IMusicPlayer
    {

        private  WindowsMediaPlayer _mediaPlayer;
        private bool _isPlay = false;

        public LocalMusicPlayer(string musicPath)
        {
            this._mediaPlayer = new WindowsMediaPlayer();
            this._mediaPlayer.URL = musicPath;
        }

        public void PlayMusic()
        {
            this._mediaPlayer.controls.play();
            this._isPlay = true;
        }

        public void StopMusic()
        {
            this._mediaPlayer.controls.stop();
            this._mediaPlayer.close();
            this._isPlay = false;
        }

        public void PouseMusic()
        {
            this._mediaPlayer.controls.pause();
            this._isPlay = false;
        }

        public bool IsPlaying()
        {
            return this._isPlay;
        }


        public void SeekToStart()
        {
            SeekToTargetPos(0.0);     
        }

        public void SeekToTargetPos(double position)
        {
            this._mediaPlayer.controls.currentPosition = position;
        }

        public void SeekToEnd()
        {
            var maxPos = this._mediaPlayer.currentMedia.duration;
            SeekToTargetPos(maxPos);
        }

        ~LocalMusicPlayer()
        {
            if (this.IsPlaying())
            {
                this._mediaPlayer.controls.stop();
            }
            
            this._mediaPlayer.close();
            this._mediaPlayer = null;
        }
    }
}
