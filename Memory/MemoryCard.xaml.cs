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
        List<Rectangle> Backgrounds;

        private static Random rand = new Random();

        public MemoryCard()
        {
            InitializeComponent();
            Card.Background = new SolidColorBrush(Colors.Black);
            People = new List<Path> { Person1, Person2, Person3, Person4, Person5, Person6, Person7, Person8, Person9, Person10, Person11, Person12, Person13, Person14, Person15, Person16, Person17, Person18, Person19, Person20, Person21, Person22, Person23, Person24, Person25, Person26, Person27, Person28, Person29, Person30, Person31, Person32 };
            Buildings = new List<Canvas> { Building_1, Building_2, Building_3, Building_4 };
            BuildingWidths = new List<int> { 50, 70, 90, 120 };
            //Backgrounds = new List<Rectangle> { Night, Sundown, Day , Red };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   //       mode, amount cards
            int x = 20;
            SetCards(1, x);
            // go to gaia grid
           
            //string uri = string.Format("/PlayField.xaml?x={1}", x);
            //Frame.Navigate(typeof(PlayField), new Uri(uri, UriKind.Relative));

            Uri uri = new Uri("PlayField.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
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
                    int a = rand.Next(0, 4);
                    switch (a)
                    {
                        case 0:
                            Backgroundo.Fill = Brushes.DarkBlue;
                            Canvas.SetZIndex(Sky, -1);
                            Canvas.SetZIndex(Sun, -3);
                            Canvas.SetLeft(moon, rand.Next(20, 180));
                            break;
                        case 1:
                            Backgroundo.Fill = Brushes.Orange;
                            Canvas.SetZIndex(Sun, -3);
                            Canvas.SetZIndex(Sky, -3);
                            break;
                        case 2:
                            Backgroundo.Fill = Brushes.OrangeRed;
                            Canvas.SetZIndex(Sky, -3);
                            Canvas.SetZIndex(Sun, -3);
                            Canvas.SetLeft(Sun, rand.Next(20, 180));
                            break;
                        case 3:
                            Backgroundo.Fill = Brushes.LightBlue;
                            Canvas.SetZIndex(Sky, -3);
                            Canvas.SetZIndex(Sun, -1);
                            Canvas.SetLeft(Sun, rand.Next(20, 180));
                            break;
                    }
                    Brush brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 233)));
                    Carbody.Fill = brush;

                    detailPlacement();

                    Canvas[] MyRandomArray = Buildings.OrderBy(x => rand.Next()).ToArray();
                    for (var e = 0; e < Buildings.Count; e++)
                    {
                        Canvas.SetLeft(MyRandomArray[0], 0);

                        if (MyRandomArray[1] == Building_1) { Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[0] - 10, BuildingWidths[0] + 10)); }
                        if (MyRandomArray[1] == Building_2) { Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[1] - 10, BuildingWidths[1] + 10)); }
                        if (MyRandomArray[1] == Building_3) { Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[2] - 10, BuildingWidths[2] + 10)); }
                        if (MyRandomArray[1] == Building_4) { Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[3] - 10, BuildingWidths[3] + 10)); }

                        if (MyRandomArray[2] == Building_1) { Canvas.SetLeft(MyRandomArray[2], rand.Next(BuildingWidths[0] - 10 + 40, BuildingWidths[0] + 60)); }
                        if (MyRandomArray[2] == Building_2) { Canvas.SetLeft(MyRandomArray[2], rand.Next(BuildingWidths[1] - 10 + 40, BuildingWidths[1] + 60)); }
                        if (MyRandomArray[2] == Building_3) { Canvas.SetLeft(MyRandomArray[2], rand.Next(BuildingWidths[2] - 10 + 40, BuildingWidths[2] + 60)); }
                        if (MyRandomArray[2] == Building_4) { Canvas.SetLeft(MyRandomArray[2], rand.Next(BuildingWidths[3] - 10 + 10, BuildingWidths[3] + 10)); }


                        if (MyRandomArray[3] == Building_1) { Canvas.SetLeft(MyRandomArray[3], 256 - 50); }
                        if (MyRandomArray[3] == Building_2) { Canvas.SetLeft(MyRandomArray[3], 256 - 70); }
                        if (MyRandomArray[3] == Building_3) { Canvas.SetLeft(MyRandomArray[3], 256 - 90); }
                        if (MyRandomArray[3] == Building_4) { Canvas.SetLeft(MyRandomArray[3], 256 - 120); }

                    }
                    SaveCanvasAsPng();
                }
                savedImg = 0;
            }
            // medium
            if (difficulty == 2)
            {
                Console.WriteLine("Medium: Gamemode 2");

                for (int i = 0; i < amountcards; i++)
                {

                    int a = rand.Next(1, 3);
                    switch (a){
                        case 1:
                            Backgroundo.Fill = Brushes.LightBlue;
                            break;
                        case 2:
                            Backgroundo.Fill = Brushes.DarkBlue;
                            break;
                    }

                    Canvas.SetLeft(Car, rand.Next(0, 150));

                    Canvas[] MyRandomArray = Buildings.OrderBy(x => rand.Next()).ToArray();
                    for (var e = 0; e < Buildings.Count; e++)
                    {
                        Canvas.SetLeft(MyRandomArray[0], 0);

                        if (MyRandomArray[1] == Building_1) { Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[0] - 10, BuildingWidths[0] + 10)); }
                        if (MyRandomArray[1] == Building_2) { Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[1] - 10, BuildingWidths[1] + 10)); }
                        if (MyRandomArray[1] == Building_3) { Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[2] - 10, BuildingWidths[2] + 10)); }
                        if (MyRandomArray[1] == Building_4) { Canvas.SetLeft(MyRandomArray[1], rand.Next(BuildingWidths[3] - 10, BuildingWidths[3] + 10)); }

                        if (MyRandomArray[2] == Building_1) { Canvas.SetLeft(MyRandomArray[2], rand.Next(BuildingWidths[0] - 10 + 40, BuildingWidths[0] + 60)); }
                        if (MyRandomArray[2] == Building_2) { Canvas.SetLeft(MyRandomArray[2], rand.Next(BuildingWidths[1] - 10 + 40, BuildingWidths[1] + 60)); }
                        if (MyRandomArray[2] == Building_3) { Canvas.SetLeft(MyRandomArray[2], rand.Next(BuildingWidths[2] - 10 + 40, BuildingWidths[2] + 60)); }
                        if (MyRandomArray[2] == Building_4) { Canvas.SetLeft(MyRandomArray[2], rand.Next(BuildingWidths[3] - 10 + 10, BuildingWidths[3] + 10)); }


                        if (MyRandomArray[3] == Building_1) { Canvas.SetLeft(MyRandomArray[3], 256 - 50); }
                        if (MyRandomArray[3] == Building_2) { Canvas.SetLeft(MyRandomArray[3], 256 - 70); }
                        if (MyRandomArray[3] == Building_3) { Canvas.SetLeft(MyRandomArray[3], 256 - 90); }
                        if (MyRandomArray[3] == Building_4) { Canvas.SetLeft(MyRandomArray[3], 256 - 120); }

                    }

                    Canvas.SetZIndex(moon, rand.Next(-1, 3));
                    Canvas.SetLeft(moon, rand.Next(20, 180));

                    detailPlacement();

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

                Backgroundo.Fill = Brushes.LightBlue;
                Canvas.SetLeft(Buildings[0], 0);
                Canvas.SetLeft(Buildings[1], 40);
                Canvas.SetLeft(Buildings[2], 100);
                Canvas.SetRight(Buildings[3], 0);
                
                for (int i = 0; i < amountcards; i++)
                {
                    Canvas.SetZIndex(moon, rand.Next(-1, 3));
                    Canvas.SetLeft(moon, rand.Next(20, 180));
                    detailPlacement();


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
            for (var i = 0; i < People.Count; i++)
            {
                Canvas.SetZIndex(People[i], -1);
            }
        }

        private void detailPlacement()
        {
            Canvas.SetLeft(Car, rand.Next(0, 150));
            Canvas.SetLeft(Cloud1, rand.Next(0, 150));
            Canvas.SetLeft(Cloud2, rand.Next(0, 150));
            Canvas.SetTop(Cloud1, rand.Next(0, 100));
            Canvas.SetTop(Cloud2, rand.Next(0, 100));
        }




        private void SaveCanvasAsPng()
        {
            Console.WriteLine("1: " + Canvas.GetLeft(Buildings[0]) +" 2: "+ Canvas.GetLeft(Buildings[1]) + " 3: " + Canvas.GetLeft(Buildings[2]) + " 4: " + Canvas.GetLeft(Buildings[3]));
            Console.WriteLine("sunpos: " + Canvas.GetLeft(Sun) + " moon: " + Canvas.GetLeft(moon));
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