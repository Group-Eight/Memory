using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
using Newtonsoft.Json.Linq;
using Microsoft.Win32;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        //StackPanel panel = new StackPanel();
        StackPanel panel = new StackPanel();
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainMenu()
        {
            InitializeComponent();
        }

        private void playMusic() {
            if (!mediaPlayer.HasAudio)
            {
                mediaPlayer.Open(new Uri("../../music/Prophectical_-_Time.mp3", UriKind.Relative));
			    mediaPlayer.Play();
            }
	}

        private void onClickPlay(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Play.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void onClickHighscore(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("HighScores.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void onClickOptions(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Options.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
        private void onClickQuit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
