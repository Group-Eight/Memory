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
        List<int> BuildingWidths;

        private static Random rand = new Random();

        public MemoryCard()
        {
            InitializeComponent();
            Card.Background = new SolidColorBrush(Colors.Black);
            People = new List<Path> { Person1, Person2, Person3, Person4, Person5, Person6, Person7, Person8, Person9, Person10, Person11, Person12, Person13, Person14, Person15, Person16, Person17, Person18, Person19, Person20, Person21, Person22, Person23, Person24, Person25, Person26, Person27, Person28, Person29, Person30, Person31, Person32 };
            Buildings = new List<Canvas> { Building_1, Building_2, Building_3, Building_4 };
            BuildingWidths = new List<int> { 50, 70, 90, 120 };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetCards(2, 10);

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
                for (int i = 0; i < amountcards; i++)
                {

                    Canvas[] MyRandomArray = Buildings.OrderBy(x => rand.Next()).ToArray();
                    for (var e = 0; e < Buildings.Count; e++)
                    {
                        //set 1 house left and one right
                        Canvas.SetLeft(MyRandomArray[0], 0);
                        Canvas.SetRight(MyRandomArray[3], 0);

                        if (MyRandomArray[0] == Building_1)
                        {
                            Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[0] - 10, BuildingWidths[0] + 10));
                            if (MyRandomArray[1] == Building_2)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(100, 110));
                            }
                            else if (MyRandomArray[1] == Building_3)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(130, 140));
                            }
                            else if (MyRandomArray[1] == Building_4)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(150, 160));
                            }

                        }
                        else if (MyRandomArray[0] == Building_2)
                        {
                            Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[1] - 10, BuildingWidths[1] + 10));
                            if (MyRandomArray[1] == Building_1)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(80, 90));
                            }
                            else if (MyRandomArray[1] == Building_3)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(140, 160));
                            }
                            else if (MyRandomArray[1] == Building_4)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(180, 190));
                            }
                        }
                        else if (MyRandomArray[0] == Building_3)
                        {
                            Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[2] - 10, BuildingWidths[2] + 10));
                            if (MyRandomArray[1] == Building_1)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(130, 140));
                            }
                            else if (MyRandomArray[1] == Building_2)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(150, 160));
                            }
                            else if (MyRandomArray[1] == Building_4)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(190, 200));
                            }
                        }
                        else if (MyRandomArray[0] == Building_4)
                        {
                            Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[3] - 10, BuildingWidths[3] + 10));
                            if (MyRandomArray[1] == Building_1)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(150, 160));
                            }
                            else if (MyRandomArray[1] == Building_2)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(160, 170));
                            }
                            else if (MyRandomArray[1] == Building_3)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(180, 190));
                            }
                        }

                    }

                    /*Canvas.SetZIndex(moon, rand.Next(-1, 3));
                    Canvas.SetLeft(moon, rand.Next(20, 180));
                    Canvas.SetLeft(Lantern1, rand.Next(0, 100 + i * 10));
                    Console.WriteLine(Canvas.GetLeft(Lantern1));
                    Canvas.SetLeft(Lantern2, rand.Next(0, 250));*/

                    SaveCanvasAsPng();

                }
                savedImg = 0;

            }
            // medium
            if (difficulty == 2)
            {
                Console.WriteLine("Medium: Gamemode 2");
                
                for(int i = 0; i < amountcards; i++)
                {
                    
                    Canvas[] MyRandomArray = Buildings.OrderBy(x => rand.Next()).ToArray();
                    for (var e = 0; e < Buildings.Count; e++)
                    {
                        //set 1 house left and one right
                        Canvas.SetLeft(MyRandomArray[0], 0);
                        Canvas.SetRight(MyRandomArray[3], 0);

                        if (MyRandomArray[0] == Building_1) {
                            Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[0]- 10, BuildingWidths[0] +10)); 
                            if (MyRandomArray[1] == Building_2) {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(100, 110));
                            } else if (MyRandomArray[1] == Building_3) {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(130, 140));
                            }
                            else if (MyRandomArray[1] == Building_4) {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(150, 160));
                            }   
                        
                        }else if (MyRandomArray[0] == Building_2) { 
                            Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[1] - 10, BuildingWidths[1] + 10));
                            if (MyRandomArray[1] == Building_1)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(80, 90));
                            }
                            else if (MyRandomArray[1] == Building_3)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(140, 160));
                            }
                            else if (MyRandomArray[1] == Building_4)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(180, 190));
                            }
                        }
                        else if (MyRandomArray[0] == Building_3) { 
                            Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[2] - 10, BuildingWidths[2] + 10));
                            if (MyRandomArray[1] == Building_1)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(130, 140));
                            }
                            else if (MyRandomArray[1] == Building_2)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(150, 160));
                            }
                            else if (MyRandomArray[1] == Building_4)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(190, 200));
                            }
                        }
                        else if (MyRandomArray[0] == Building_4) { 
                            Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[3] - 10, BuildingWidths[3] + 10));
                            if (MyRandomArray[1] == Building_1)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(150, 160));
                            }
                            else if (MyRandomArray[1] == Building_2)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(160, 170));
                            }
                            else if (MyRandomArray[1] == Building_3)
                            {
                                Canvas.SetLeft(MyRandomArray[2], rand.Next(180, 190));
                            }
                        }
                       
                       




                    }

                    Canvas.SetZIndex(moon, rand.Next(-1, 3));
                    Canvas.SetLeft(moon, rand.Next(20, 180));
                    Canvas.SetLeft(Lantern1, rand.Next(0, 100 + i * 10));
                    Console.WriteLine(Canvas.GetLeft(Lantern1));
                    Canvas.SetLeft(Lantern2, rand.Next(0, 250));

                    //all people zindex -1
                    ResetPeople();

                    int randomP1 = rand.Next(0, 10);
                    int randomP2 = rand.Next(10, 20);
                    int randomP3 = rand.Next(20, 31);
                    //Console.WriteLine("P1: " + randomP1 + " p2 " + randomP2 + " p3 " + randomP3);

                    Canvas.SetZIndex(People[randomP1], 1);
                    Canvas.SetZIndex(People[randomP2], 1);
                    Canvas.SetZIndex(People[randomP3], 1);

                    SaveCanvasAsPng();

                }
                savedImg = 0;

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
                    Canvas.SetZIndex(moon, rand.Next(-1, 3));
                    Canvas.SetLeft(moon, rand.Next(20, 180));
                    Canvas.SetLeft(Lantern1, rand.Next(0, 250)); 
                    Canvas.SetLeft(Lantern2, rand.Next(0, 250));

                    //all people zindex -1
                    ResetPeople();
   
                    int randomP1 = rand.Next(0, 10);
                    int randomP2 = rand.Next(10, 20);
                    int randomP3 = rand.Next(20, 31);
                    Console.WriteLine("P1: " + randomP1 + " p2 " + randomP2 + " p3 " + randomP3);

                    Canvas.SetZIndex(People[randomP1], 1);
                    Canvas.SetZIndex(People[randomP2], 1);
                    Canvas.SetZIndex(People[randomP3], 1);

                    SaveCanvasAsPng();
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
        
        private void SaveCanvasAsPng()
        {
            Card.UpdateLayout();

            Rect bounds = VisualTreeHelper.GetDescendantBounds(Card);
            double dpi = 96d;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);

            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(Card);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }

            rtb.Render(dv);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);
                ms.Close();

                System.IO.File.WriteAllBytes("Card" + savedImg + ".png", ms.ToArray());
                savedImg++;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
