﻿
using LiveMusicPlayer.src.ViewModel;
using System.Diagnostics;

using System.Threading;
using System.Threading.Tasks;
using WMPLib;

namespace LiveMusicPlayer.src.Logic.MusicPlayer
{
    public class LocalMusicPlayer : IMusicPlayer
    {

        private  WindowsMediaPlayer _mediaPlayer;
        private bool _isPlay = false;
        public static bool isDrag = false;
        private double sec = 0.0;
        public LocalMusicPlayer(string musicPath)
        {
            this._mediaPlayer = new WindowsMediaPlayer();
            this._mediaPlayer.URL = musicPath;
        }

        public void PlayMusic()
        {
            this.sec = 0.0;
            this._mediaPlayer.controls.play();

   
            
            Task.Run(() =>
            {
          
                Thread.Sleep(1000);
                var vm = SeekBarViewModel.Instance;
                var maxDuration = this._mediaPlayer.currentMedia.duration;
                vm.MaxDuration = maxDuration;
                
                for(; sec < maxDuration; sec++)
                {
                       
                    vm.SeekBarPos = sec;
                    Thread.Sleep(1000);
                }
            });

            this._isPlay = true;
        }

        public void StopMusic()
        {
            this._mediaPlayer.controls.stop();
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

        public void SeekToPercent(double percent)
        {
            this.SeekToTargetPos(this._mediaPlayer.currentMedia.duration * percent);
        }

        public void SeekToTargetPos(double position)
        {
            this._mediaPlayer.controls.currentPosition = position;
            this.sec = position;
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