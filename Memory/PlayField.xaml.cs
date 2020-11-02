using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        int combo = 0;
        int multiplier = 0;
        string save = "test.json";
        string backCard = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("\\bin\\Debug\\Memory.exe", "") + "\\images\\BackCard.png";
        JSONWriter writer = new JSONWriter();

        public PlayField()
        {
            InitializeComponent();
            // Create json file
            writer.CreateFile(save);

            Points_Player_1.Text = "Points " + App.playerOne + ": " + firstPoints;
            Points_Player_2.Text = "Points " + App.playerTwo + ": " + secondPoints;

            // Future JSON get the value of player's turn
            if (playerTurn == true)
            {
                Turn.Text = App.playerOne + "'s turn";
            }
            else
            {
                Turn.Text = App.playerTwo + "'s turn";
            }
            
            this.setCards();
  
        }

        private void Exit_game(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void setCards()
        {
            int amount_cards = 0;
            List<string> rows = new List<string> { };
            List<string> colls = new List<string>{ };

            // Amount of cards
            if (App.difficulty == 1)
            {
                amount_cards = 12;

            } else if (App.difficulty == 2)
            {
                amount_cards = 24;
            }
            else if (App.difficulty == 3)
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
                    btn.Click += flipCard;

                    Image back = new Image();
                    back.Source = new BitmapImage(new Uri(backCard));
                    btn.Content = back;

                    // Size of cards
                    if (App.difficulty == 1)
                    {
                        btn.Height = 200;
                        btn.Width = 200;
                    }
                    else if(App.difficulty == 2)
                    {
                        btn.Height = 150;
                        btn.Width = 150;
                    }
                    else
                    {
                        btn.Height = 130;
                        btn.Width = 130;
                    }

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

        // Show card
        private void flipCard(object sender, RoutedEventArgs e)
        {

            flipped++;
            // Flip cards back and remove them from list
            if (flipped == 3)
            {
                flipped = 1;

                Image back = new Image();
                back.Source = new BitmapImage(new Uri(backCard));
                cardsClicked[1].Content = back;

                Image back2 = new Image();
                back2.Source = new BitmapImage(new Uri(backCard));
                cardsClicked[0].Content = back2;
                
                cardsClicked.Remove(cardsClicked[1]);
                cardsClicked.Remove(cardsClicked[0]);
            }
            // add Button/Card to list so you can check if they are the same
            string id = (sender as Button).Name;

            int indexCard = allCards.IndexOf(sender as Button);

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("Memory.exe", "") + "Card" + cardsGenerated[indexCard].ToString() + ".png";
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(path));

            (sender as Button).Content = img;

            cardsClicked.Add((sender as Button));

            // Check if cards are the same
            if(flipped == 2)
            {
                // If you click the same card twice it won't add the card to the list
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
                    // Both cards are the same
                    if (((Image)cardsClicked[0].Content).Source.ToString() == ((Image)cardsClicked[1].Content).Source.ToString())
                    {
                        combo++;
                        // 50 points extra per combo
                        if(combo > 1)
                        {
                            multiplier += 50;
                        }
                        GameGrid.Children.Remove(cardsClicked[1]);
                        GameGrid.Children.Remove(cardsClicked[0]);

                        // Give points to current player
                        if(playerTurn == true)
                        {
                            firstPoints += (100 + multiplier);
                            Points_Player_1.Text = "Points " + App.playerOne + ": "+ firstPoints.ToString();
                        }
                        else
                        {
                            secondPoints += (100 + multiplier);
                            Points_Player_2.Text = "Points " + App.playerTwo + ": " + secondPoints.ToString();
                        }

                        // End game
                        if (GameGrid.Children.Count == 0)
                        {
                            Button endExit = new Button();
                            endExit.Content = "Exit";
                            endExit.Click += new RoutedEventHandler(Exit_game);
                            

                            TextBlock endText = new TextBlock();
                            endText.FontSize = 30;
                            endExit.Height = 150;
                            endExit.Width = 150;

                            // Show winner
                            if (firstPoints > secondPoints) { endText.Text = "Winner: " + App.playerOne + System.Environment.NewLine + "Points: " + firstPoints.ToString(); }
                            else if (firstPoints == secondPoints) { endText.Text = "Tie " + System.Environment.NewLine + "Points: " + firstPoints.ToString(); }
                            else { endText.Text = "Winner: " + App.playerTwo + System.Environment.NewLine + "Points: " + secondPoints.ToString(); }
                            GameGrid.Children.Add(endText);

                            Grid.SetColumn(endExit, 0);
                            Grid.SetRow(endExit, 1);
                            GameGrid.Children.Add(endExit);
                        }
                    }
                    // if wrong change turn and reset the combo
                    else
                    {
                        combo = 0;
                        multiplier = 0;
                        if (playerTurn == true)
                        {
                            playerTurn = false;
                            Turn.Text = App.playerTwo + "'s turn";
                        }
                        else
                        {
                            playerTurn = true;
                            Turn.Text = App.playerOne + "'s turn";
                        }
                    }
                }
            }
        }
    }
}
