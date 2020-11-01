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
        List<Button> allCards = new List<Button>();
        List<Button> cardsClicked = new List<Button>();
        List<int> cardsGenerated = new List<int>();
        Random random = new Random();
        string cards = "";
        bool playerTurn = true;
        int firstPoints = 0;
        int secondPoints = 0;
        int multiplier = 1;
        int combo= 0;


        public PlayField()
        {
            InitializeComponent();
            if (playerTurn == true)
            {
                Turn.Text = "Player 1's turn";
            }
            else
            {
                Turn.Text = "Player 2's turn";
            }
            
            this.setCards();
  
        }


        private void setCards()
        {
            int amount_cards = 0;
            string selected = "hard";
            List<string> rows = new List<string> { };
            List<string> colls = new List<string>{ };

            // Amount of cards
            if (selected == "easy")
            {
                amount_cards = 12;

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

            // Add rows (Dynamic Grid)
            if ((amount_cards/2) <= 6)
            {
                rows.Add("A");
                rows.Add("B");

                for (int x = 1; x <= (amount_cards / 2); x++)
                {
                    colls.Add(x.ToString());
                }
            }
            else if ((amount_cards / 2) > 6)
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

                    // Adding random image to button
                    int RandomNumber = random.Next(0, (amount_cards/2));
                    // Only have 2 of each card
                    do
                    {
                        RandomNumber = random.Next(0, (amount_cards / 2));

                    } while (cardsGenerated.Count(x => x == RandomNumber) == 2);

                    cardsGenerated.Add(RandomNumber);
                    allCards.Add(btn);
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
            if (flipped == 3)
            {
                flipped = 1;

                cardsClicked[0].Content = "";
                cardsClicked[1].Content = "";

                cardsClicked.Remove(cardsClicked[1]);
                cardsClicked.Remove(cardsClicked[0]);

            }
            // add Button/Card to list so you can check if they are the same
            string id = (sender as Button).Name;

            int test = allCards.IndexOf(sender as Button);

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("Memory.exe", "") + "Card" + cardsGenerated[test].ToString() + ".png";
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(path));

            (sender as Button).Content = img;

            cardsClicked.Add((sender as Button));

            // Check if cards are the same
            if(flipped == 2)
            {
                if (id == cardsClicked[0].Name)
                {
                    flipped--;
                    if (cardsClicked.Count == 2)
                    {
                        cardsClicked.Remove(cardsClicked[1]);
                    }
                }
                if (cardsClicked.Count == 2)
                {
                    if (((Image)cardsClicked[0].Content).Source.ToString() == ((Image)cardsClicked[1].Content).Source.ToString())
                    {
                        combo++;
                        GameGrid.Children.Remove(cardsClicked[1]);
                        GameGrid.Children.Remove(cardsClicked[0]);

                        if(playerTurn == true)
                        {
                            firstPoints += (100 * combo);
                            Points_Player_1.Text = "Points Player 1: "+ firstPoints.ToString();
                        }
                        else
                        {
                            secondPoints += (100 * combo);
                            Points_Player_2.Text = "Points Player 2: "+ secondPoints.ToString();
                        }

                        /*Calculate the combopoints here */
                        if(combo > 1)
                        {
                            multiplier++;
                        }
                       
                    }
                    else
                    {
                        combo = 0;
                        if (playerTurn == true)
                        {
                            playerTurn = false;
                            Turn.Text = "Player 2's turn";
                        }
                        else
                        {
                            playerTurn = true;
                            Turn.Text = "Player 1's turn";
                        }
                    }
                }
            }
        }
    }
}
