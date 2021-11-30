using LiveMusicPlayer.src.Logic.MusicPlayer;
using LiveMusicPlayer.src.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LiveMusicPlayer.Views
{
    /// <summary>
    /// SeekBarControl.xaml の相互作用ロジック
    /// </summary>
    public partial class SeekBarControl : UserControl
    {
        private SeekBarViewModel _viewModel;
        private bool _isDrag = false;

        public SeekBarControl()
        {
            InitializeComponent();

            this._viewModel = SeekBarViewModel.Instance;
            this.DataContext = this._viewModel;
        }


        private void OnClickPlayMusic(object sender, RoutedEventArgs e)
        {

            var mp = MusicPlayerContainer.MusicPlayer;
            if (mp.IsPlaying())
            {
                mp.PouseMusic();
            }
            else
            {
                mp.PlayMusic();
            }

        }

        private void OnClickSeekToStart(object sender, RoutedEventArgs e)
        {
            var mp = MusicPlayerContainer.MusicPlayer;
            mp.SeekToStart();
        }

        private void OnClickSeekToEnd(object sender, RoutedEventArgs e)
        {
            var mp = MusicPlayerContainer.MusicPlayer;
            mp.SeekToEnd();
        }

        private void OnChangeMusicVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isDrag)
            {
                double seekPercent = e.NewValue;
                var mp = MusicPlayerContainer.MusicPlayer;
                mp.SeekToTargetPos(seekPercent);
                this._isDrag = true;

            }
       
        }

   

        private void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {   
            this._isDrag = false;
        }

        private void SeekBar_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            this._isDrag = true;
        }
    }
}
