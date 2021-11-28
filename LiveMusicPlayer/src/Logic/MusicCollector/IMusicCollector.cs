using LiveMusicPlayer.src.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMusicPlayer.logic.musicCollector
{
    public interface IMusicCollector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>musicファイルの絶対パス</returns>
        public List<MusicListModel> CollectMusic();
    }
}
