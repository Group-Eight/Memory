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
    /// Interaction logic for Page1.xamlv
    /// </summary>
    public partial class MemoryCard : Page
    {
        int savedImg = 0;
        List<Path> People;
        List<Canvas> Buildings;

        private static Random rand = new Random();

        public MemoryCard()
        {
            InitializeComponent();
            Card.Background = new SolidColorBrush(Colors.Black);
            People = new List<Path> { Person1, Person2, Person3, Person4, Person5, Person6, Person7, Person8, Person9, Person10, Person11, Person12, Person13, Person14, Person15, Person16, Person17, Person18, Person19, Person20, Person21, Person22, Person23, Person24, Person25, Person26, Person27, Person28, Person29, Person30, Person31, Person32 };
            Buildings = new List<Canvas> { Building_1, Building_2, Building_3, Building_4 };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetCards(3, 10);

        }
        public int RandomValue(int min, int max)
        {
            Random random = new Random();
            int RandomNumber = random.Next(min, max);
            return RandomNumber;
        }

        public void SetCards(int difficulty, int amountcards)
        {
            // ez
            if (difficulty == 1)
            {
                Console.WriteLine("EZ: Gamemode 1");
            }
            // medium
            if (difficulty == 2)
            {
                Console.WriteLine("Medium: Gamemode 2");
            }
            // hard
            if (difficulty == 3)
            {
                Console.WriteLine("Hard: Gamemode 3");
                //for( int i = 0; i<)
                Canvas.SetLeft(Buildings[0], 0);
                Canvas.SetLeft(Buildings[1], 40);
                Canvas.SetLeft(Buildings[2], 100);
                Canvas.SetRight(Buildings[3], 0);

                for (int i = 0; i < amountcards; i++)
                {
                    Canvas.SetZIndex(moon, RandomValue(-1, 1));
                    Canvas.SetLeft(moon, RandomValue(20, 180));
                    Canvas.SetLeft(Lantern, RandomValue(10, 80));

                    //all people zindex -1
                    ResetPeople();
   
                    int randomP1 = rand.Next(0, 10);
                    int randomP2 = rand.Next(10, 20);
                    int randomP3 = rand.Next(20, 31);
                    Console.WriteLine("P1: " + randomP1 + " p2 " + randomP2 + " p3 " + randomP3);

                    Canvas.SetZIndex(People[randomP1], 1);
                    Canvas.SetZIndex(People[randomP2], 1);
                    Canvas.SetZIndex(People[randomP3], 1);
                    


                    Rect rect = new Rect(Card.RenderSize);
                    RenderTargetBitmap rtb = new RenderTargetBitmap((int)rect.Right,
                      (int)rect.Bottom, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                    rtb.Render(Card);
                    //endcode as PNG
                    BitmapEncoder pngEncoder = new PngBitmapEncoder();
                    pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

                    //save to memory stream
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    pngEncoder.Save(ms);
                    ms.Close();
                    //img moet hier komen:  C:\Users\lisan\Documents\GitHub\Memory\Memory\
                    //img komt nu hier:     C:\Users\lisan\Documents\GitHub\Memory\Memory\bin\debug



                    System.IO.File.WriteAllBytes("Card" + savedImg + ".png", ms.ToArray());
                    savedImg++;
                    Console.WriteLine("Done");

                }
                savedImg = 0;
            }
        }

        private void ResetPeople()
        {
           for(var i = 0; i< People.Count; i++)
           {
               Canvas.SetZIndex(People[i], -1);
           }
            
            
        }
        


    }
}
