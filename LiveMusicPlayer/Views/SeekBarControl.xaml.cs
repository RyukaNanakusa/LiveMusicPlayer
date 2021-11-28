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

        public SeekBarControl()
        {
            InitializeComponent();
            
            this._viewModel = new SeekBarViewModel();
            this.DataContext = this._viewModel;
        }

        private void OnClickStartMusic(object sender, MouseButtonEventArgs e)
        {
   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var mp = MusicPlayerContainer.GetMusicPlayer();
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
            var mp = MusicPlayerContainer.GetMusicPlayer();
            mp.SeekToStart();
        }

        private void OnClickSeekToEnd(object sender, RoutedEventArgs e)
        {
            var mp = MusicPlayerContainer.GetMusicPlayer();
            mp.SeekToEnd();
        }
    }
}
