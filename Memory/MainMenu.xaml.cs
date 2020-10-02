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

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        StackPanel panel = new StackPanel();
        public MainMenu()
        {
            InitializeComponent();
            //this.setText();
            //this.Content = panel;
        }

        private void setText() {
            //Label title = new Label();
            //title.Content = "Hello World";
            //panel.Children.Add(title);
        }

        private void onClickPlay(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world!");
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
            
        }
    }
}
