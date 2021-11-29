using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMusicPlayer.src.Logic.MusicPlayer
{
    public interface IMusicPlayer
    {
        /**
         * 曲の再生開始
         */
        public void PlayMusic();

        public void PouseMusic();

        public void StopMusic();

        public bool IsPlaying();

        /// <summary>
        /// 再生開始位置まで戻る
        /// </summary>
        public void SeekToStart();

        /// <summary>
        /// ユーザーがシークバーで指定した位置まで移動
        /// </summary>
        /// <param name="position"></param>
        public void SeekToTargetPos(double position);

        /// <summary>
        /// 曲の最後まで移動
        /// </summary>
        public void SeekToEnd();

        public void SeekToPercent(double percent);

    }
}
