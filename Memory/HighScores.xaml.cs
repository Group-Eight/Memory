using System;
using Newtonsoft.Json.Linq;
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

        JSONParser jsonParser = new JSONParser("HighScores.Json");

        List<JToken> names = new List<JToken>();
        List<JToken> points = new List<JToken>();

        List<TextBlock> highScoreNames;
        List<TextBlock> highScorePoints;

        public HighScores()
        {
            InitializeComponent();
            
            highScoreNames = new List<TextBlock> { HighScoreName1, HighScoreName2, HighScoreName3, HighScoreName4, HighScoreName5, HighScoreName6, HighScoreName7, HighScoreName8, HighScoreName9, HighScoreName10 };
            highScorePoints = new List<TextBlock> { HighScorePoints1, HighScorePoints2, HighScorePoints3, HighScorePoints4, HighScorePoints5, HighScorePoints6, HighScorePoints7, HighScorePoints8, HighScorePoints9, HighScorePoints10 };

            names = jsonParser.getTokens("highscores");
            points = jsonParser.getTokens("points");

            setHighScores();
        }

        private void onClickBack(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("MainMenu.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void setHighScores()
        {
            int a = 0;

            for (int i = 0; i < names.Count; i++)
            {
                highScoreNames[a].Text = names[i].ToString();
                i++;
                highScorePoints[a].Text = names[i].ToString();
                a++;
            }
        }

    }
}
