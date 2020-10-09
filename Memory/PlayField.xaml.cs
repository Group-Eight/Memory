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
    /// Interaction logic for PlayField.xaml
    /// </summary>
    public partial class PlayField : Page
    {
        int flipped = 0;
        List<Button> cardsClicked = new List<Button>();
        public PlayField()
        {
            InitializeComponent();
            this.setCards();
        }


        private void setCards()
        {
            int amount_cards = 0;
            string cards = "";
            string selected = "hard";
            List<string> rows = new List<string> { };
            List<string> colls = new List<string>{ };

            if (selected == "easy")
            {
                amount_cards = 6;

            } else if (selected == "medium")
            {
                amount_cards = 24;
            }
            else if (selected == "hard")
            {
                amount_cards = 40;
            }

            if ((amount_cards%2) != 0)
            {
                amount_cards++;
            }

            if ((amount_cards/2) <= 4)
            {
                rows.Add("A");
                rows.Add("B");

                for (int x = 1; x <= (amount_cards / 2); x++)
                {
                    colls.Add(x.ToString());
                }
            }
            else if ((amount_cards / 2) > 4)
            {
                if ((amount_cards % 3) != 0)
                {
                    rows.Add("A");
                    rows.Add("B");
                    rows.Add("C");
                    rows.Add("D");

                    for (int z = 1; z <= (amount_cards / 4); z++)
                    {
                        colls.Add(z.ToString());
                    }
                }
                else
                {
                    rows.Add("A");
                    rows.Add("B");
                    rows.Add("C");

                    for (int m = 1; m <= (amount_cards / 3); m++)
                    {
                        colls.Add(m.ToString());
                    }
                }
            }
            
            for (int i = 0; i < rows.Count; i++)
            {
                for (int y = 0; y < colls.Count; y++)
                {
                    // make string for future json
                    cards += rows[i];
                    cards += colls[y];
                    cards += " ";

                    // make "cards" as buttons with id of the position
                    Button btn = new Button();
                    btn.Name = rows[i]+colls[y];
                    btn.Click += showID;
                    Grid.SetColumn(btn, y);
                    Grid.SetRow(btn, i);
                    GameGrid.Children.Add(btn);
                }
                cards += "\r";
            }

            // add rows and collumns
            for (int i = 0; i < rows.Count; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }
            for (int y = 0; y < colls.Count; y++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        // Set text in button to the id/Name it has
        private void showID(object sender, RoutedEventArgs e)
        {
            flipped++;
            string id = (sender as Button).Name;
            (sender as Button).Content = id;
            cardsClicked.Add((sender as Button));

            if(flipped == 2)
            {

            }

            if (flipped == 3)
            {
                flipped = 1;

                cardsClicked[0].Content = "";
                cardsClicked[1].Content = "";

                cardsClicked.Remove(cardsClicked[1]);
                cardsClicked.Remove(cardsClicked[0]);
            }
        }
    }
}
