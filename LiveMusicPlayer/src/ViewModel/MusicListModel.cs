using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMusicPlayer.src.ModelView
{
    public class MusicListModel
    {
        public string MusicName { get; set; }
        public string MusicPath { get; set; }
        public string Artist { get; set; }

        public override string ToString()
        {
            return $"MusicName: {this.MusicName} MusicPath: {this.MusicPath}";
        }
    }
}
 