using LiveMusicPlayer.src.ModelView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMusicPlayer.logic.musicCollector
{
    class LocalMusicCollecotor : IMusicCollector
    {
        private readonly string _musicDirectoryPath;
        public LocalMusicCollecotor(string musicDirectoryPath)
        {
            this._musicDirectoryPath = musicDirectoryPath;
        }

        public List<MusicListModel> CollectMusic()
        {
            if (!Directory.Exists(this._musicDirectoryPath))
            {
                throw new Exception(message: "Not Found Music Directory");
            }

            FileInfo[] files =  Directory
                .CreateDirectory(this._musicDirectoryPath)
                .GetFiles();
           
            return files
                .Where(f => f.Extension == ".mp3")
                .Select(f => new MusicListModel()
            {
                MusicName = Path.GetFileNameWithoutExtension(f.Name),
                MusicPath = f.FullName
            }).ToList();
        }
    }
}
