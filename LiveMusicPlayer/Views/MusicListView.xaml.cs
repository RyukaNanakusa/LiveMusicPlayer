using LiveMusicPlayer.logic.musicCollector;
using LiveMusicPlayer.src.Logic.MusicPlayer;
using LiveMusicPlayer.src.ModelView;
using LiveMusicPlayer.src.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Test.xaml の相互作用ロジック
    /// </summary>
    public partial class MusicList : UserControl
    {
        private ObservableCollection<MusicListModel> _collections = new ObservableCollection<MusicListModel>();
       
        public MusicList()
        {
            InitializeComponent();
            var collector = new LocalMusicCollecotor(@"C:\Users\elmga\Music");
            //var collector = new LocalMusicCollecotor(@"D:\mu");

            var musics = collector.CollectMusic();

            musicList.ItemsSource = _collections;
            
            musics.ForEach(m => {
                this._collections.Add(m);
            });

        }



        private void OnMouseDownSelectedMusic(object sender, MouseButtonEventArgs e)
        {

            var border = sender as Border;
            var (musicTitle, musicPath) = GetMusicPathByItemRoot(border);

            MusicPlayerContainer.MusicPlayer = new LocalMusicPlayer(musicPath, Dispatcher);
            var musicPlayer = MusicPlayerContainer.MusicPlayer;
            var seekBarViewModel = SeekBarViewModel.Instance;
            seekBarViewModel.init();
            seekBarViewModel.MusicTitle = musicTitle;
            musicPlayer.PlayMusic();
        }

        private (string, string) GetMusicPathByItemRoot(Border root)
        {
            var pannel = root.Child as StackPanel;
            var musicTitle = pannel.Children[0] as TextBlock;
            var musicPath = pannel.Children[1] as TextBlock;
            return (musicTitle.Text, musicPath.Text);
        }
    }
}
