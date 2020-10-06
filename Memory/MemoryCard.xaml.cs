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
        public MemoryCard()
        {
            InitializeComponent();
            Card.Background = new SolidColorBrush(Colors.Black);
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //order buildings go

            // 0-3
            SetCards(2, 10);






            /*int first = RandomValue(0, 4);
            if (first == 0)
            {
                Canvas.SetLeft(Building_1, 0);
                Canvas.SetLeft(Building_2, RandomValue(40, 150));
                Canvas.SetLeft(Building_3, RandomValue(140, 200));
                Canvas.SetLeft(Building_4, RandomValue(190, 220));
                Canvas.SetZIndex(moon, -1);
            }
            else if (first == 1)
            {
                Canvas.SetLeft(Building_2, 0);
                Canvas.SetLeft(Building_3, RandomValue(90, 170));
                Canvas.SetLeft(Building_4, RandomValue(140, 200));
                Canvas.SetLeft(Building_1, RandomValue(190, 220));
                Canvas.SetZIndex(moon, -1);
            }
            else if (first == 2)
            {
                Canvas.SetLeft(Building_3, 0);
                Canvas.SetLeft(Building_4, RandomValue(40, 150));
                Canvas.SetLeft(Building_1, RandomValue(140, 200));
                Canvas.SetLeft(Building_2, RandomValue(190, 220));
                Canvas.SetZIndex(moon, 1);
            }
            else if (first == 3)
            {
                Canvas.SetLeft(Building_4, 0);
                Canvas.SetLeft(Building_1, RandomValue(40, 150));
                Canvas.SetLeft(Building_2, RandomValue(140, 200));
                Canvas.SetLeft(Building_3, RandomValue(190, 220));
                Canvas.SetZIndex(moon, 1);
            }
            else if (first == 4)
            {
                Canvas.SetLeft(Building_2, 0);
                Canvas.SetLeft(Building_4, RandomValue(40, 150));
                Canvas.SetLeft(Building_1, RandomValue(140, 200));
                Canvas.SetLeft(Building_3, RandomValue(190, 220));
                Canvas.SetZIndex(moon, -1);
            }


            // b1 = 50
            //b2 = 70
            //b3 = 90;
            //b4 = 120


            switch (first)
            {
                case 0:
                    SetCard(0, RandomValue(40, 50), RandomValue(100, 110), 0, 0);
                    break;
                case 1:
                    SetCard(1, 0, RandomValue(40, 50), 0, 1);
                    Canvas.SetLeft(Building_2, 0);
                    Canvas.SetLeft(Building_3, RandomValue(90, 170));
                    Canvas.SetLeft(Building_4, RandomValue(140, 200));
                    Canvas.SetLeft(Building_1, RandomValue(190, 220));
                    Canvas.SetZIndex(moon, -1);
                    break;
                case 2:
                    SetCard(2, 3, 0, 1, 1);
                    break;
                case 3:
                    SetCard(2, 3, 0, 0, 1);
                    break;
                case 4:
                    SetCard(2, 3, 0, 1, 1);
                    break;
            }

            */

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

            // medium

            // hard
            if (difficulty == 3)
            {
                Canvas.SetLeft(Building_1, 0);
                Canvas.SetLeft(Building_2, 40);
                Canvas.SetLeft(Building_3, 100);
                Canvas.SetRight(Building_4, 0);

                for (int i = 0; i < amountcards; i++)
                {
                    Canvas.SetZIndex(moon, RandomValue(-1, 1));
                    Canvas.SetLeft(moon, RandomValue(20, 180));
                    Canvas.SetLeft(Lantern, RandomValue(0, 80));

                    ResetPeople();
                    switch (i)
                    {
                        case 1:

                            Canvas.SetZIndex(Person1, 4);
                            Canvas.SetZIndex(Person14, 4);
                            Canvas.SetZIndex(Person20, 4);
                            Canvas.SetZIndex(Person32, 4);
                            break;
                        case 2:
                            Canvas.SetZIndex(Person4, 4);
                            Canvas.SetZIndex(Person12, 4);
                            Canvas.SetZIndex(Person26, 4);
                            Canvas.SetZIndex(Person30, 4);
                            break;
                        case 3:
                            Canvas.SetZIndex(Person2, 4);
                            Canvas.SetZIndex(Person11, 4);
                            Canvas.SetZIndex(Person22, 4);
                            Canvas.SetZIndex(Person28, 4);
                            break;
                        case 4:
                            Canvas.SetZIndex(Person3, 4);
                            Canvas.SetZIndex(Person10, 4);
                            Canvas.SetZIndex(Person21, 4);
                            Canvas.SetZIndex(Person29, 4);
                            break;
                    }
                    
                }

            }
        }

        private void ResetPeople()
        {

        }
        private void CommandBinding_Executed(object sender, RoutedEventArgs e)
        {
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

            

            System.IO.File.WriteAllBytes("Card" + savedImg +".png" , ms.ToArray());
            savedImg++;
            Console.WriteLine("Done") ;

           
        }


    }
}
