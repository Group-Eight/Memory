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
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Page
    {
        public HighScores()
        {
            InitializeComponent();
            setHighScores();
        }

        private void onClickBack(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("MainMenu.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void setHighScores()
        {
            HighScoreName1.Text = "1. Dani";
            HighScorePoints1.Text = "∞ Punten";
            HighScoreName2.Text = "2. Lisanne";
            HighScorePoints2.Text = "420 Punten";
            HighScoreName3.Text = "3. Gaia";
            HighScorePoints3.Text = "69 Punten";
            HighScoreName4.Text = "4. Mathijs";
            HighScorePoints4.Text = "56 Punten";
            HighScoreName5.Text = "5. Mariska";
            HighScorePoints5.Text = "10 Punten";
            HighScoreName6.Text = "6. Niels";
            HighScorePoints6.Text = "-3 Punten";
        }

    }
}
