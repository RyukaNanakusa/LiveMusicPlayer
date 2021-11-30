using LiveMusicPlayer.src.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMusicPlayer.src.Logic.MusicPlayer
{
    /// <summary>
    /// ミュージックプレイヤーのNullオブジェクト
    /// 処理は何もせず初期値のみとして扱うことを想定
    /// </summary>
    public class NoneMusicPlayer : IMusicPlayer
    {
        public bool IsPlaying()
        {
            return false;
        }

        public void PlayMusic()
        { }

        public void PouseMusic()
        { }

        public void SeekToEnd()
        {

        }

        public void SeekToPercent(double percent)
        {
            throw new NotImplementedException();
        }

        public void SeekToStart()
        {
            
        }

        public void SeekToTargetPos(double position)
        {

        }

        public void StopMusic()
        { }
    }
}
