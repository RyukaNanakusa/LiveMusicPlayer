
using LiveMusicPlayer.src.ViewModel;
using System;
using System.Diagnostics;

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using WMPLib;

namespace LiveMusicPlayer.src.Logic.MusicPlayer
{
    /// <summary>
    /// TODO  
    /// 再生中はシークバーを自動で再生時間に合わせるようにしたい
    /// しかし、ユーザーがシークバーを動かすとOnvalueChangeの処理によりうまく動かなくなる.
    ///。
    /// 現在は再生時間をシークバーに反映させる処理を
    /// 現在別スレッドで一秒おきにカウントを進めて
    /// それをシークバーに反映させているが、理想は再生時間が変更されるたびにイベントを呼び出すような処理が望ましい？
    /// </summary>
    public class LocalMusicPlayer : IMusicPlayer
    {

        private  WindowsMediaPlayer _mediaPlayer;
        private bool _isPlay = false;
        public static bool isDrag = false;
        private double sec = 0.0;
        private Dispatcher _dispatcherObject;
        public LocalMusicPlayer(string musicPath, Dispatcher dispacher)
        {
            this._dispatcherObject = dispacher;
            this._mediaPlayer = new WindowsMediaPlayer();
            this._mediaPlayer.URL = musicPath;
            this._mediaPlayer.settings.volume = 25;
        }

        public void PlayMusic()
        {

            this._mediaPlayer.controls.play();
            this._isPlay = true;

            

     
            Task.Run(() =>
            {
                Thread.Sleep(1000);
                var vm = SeekBarViewModel.Instance;
             
                var maxDuration = this._mediaPlayer.currentMedia.duration;
                vm.MaxDuration = maxDuration;
                vm.MaxPlayBackTime = this._mediaPlayer.currentMedia.durationString;
                while (_isPlay)
                {
                    this._dispatcherObject.Invoke(() =>
                    {
                        vm.CurrentPlayBackTime = this._mediaPlayer.controls.currentPositionString;
                        vm.SeekBarPos = this._mediaPlayer.controls.currentPosition;
                    });
                   
                    Thread.Sleep(100);
                }

            });

            
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
