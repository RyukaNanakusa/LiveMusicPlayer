using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveMusicPlayer.src.ViewModel
{
    public class SeekBarViewModel: BindableBase
    {
        private readonly static SeekBarViewModel _instance = new SeekBarViewModel();
        public static SeekBarViewModel Instance
        {
            get => SeekBarViewModel._instance;
        }

        private string _musicTitle = "";
        public string MusicTitle
        {
            get => this._musicTitle;
            set => SetProperty(ref _musicTitle, value);
        }
    }
}
