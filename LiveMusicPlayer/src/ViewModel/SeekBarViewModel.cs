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
        private SeekBarViewModel()
        {

        }

        private bool _isDrag = false;

        private readonly static SeekBarViewModel _instance = new SeekBarViewModel();
        
        public void init()
        {
            this._maxDuration = 0.0;
            this._musicTitle = "";
            this._seekBarPos = 0.0;
        }
        public static SeekBarViewModel Instance
        {
            get => SeekBarViewModel._instance;
        }
        private double _maxDuration = 0.0;
        public double MaxDuration
        {
            get => _maxDuration;
            set => this.SetProperty(ref _maxDuration, value);
        }
        private double _seekBarPos = 0.0;

        public double SeekBarPos
        {
            get { return _seekBarPos; }
            set => this.SetProperty(ref _seekBarPos, value);
        }

        private string _musicTitle = "";
        public string MusicTitle
        {
            get => this._musicTitle;
            set => SetProperty(ref _musicTitle, value);
        }
    }
}
