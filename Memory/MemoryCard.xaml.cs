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
        public MemoryCard()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            int first = RandomValue(0, 4);
            if (first == 0)
            {
                Canvas.SetLeft(Building_1, 0);
                Canvas.SetLeft(Building_2, RandomValue(40, 150));
                Canvas.SetLeft(Building_3, RandomValue(140, 200));
                Canvas.SetLeft(Building_4, RandomValue(190, 220));
            }
            else if (first == 1)
            {
                Canvas.SetLeft(Building_2, 0);
                Canvas.SetLeft(Building_3, RandomValue(40, 150));
                Canvas.SetLeft(Building_4, RandomValue(140, 200));
                Canvas.SetLeft(Building_1, RandomValue(190, 220));
            }
            else if (first == 2)
            {
                Canvas.SetLeft(Building_3, 0);
                Canvas.SetLeft(Building_4, RandomValue(40, 150));
                Canvas.SetLeft(Building_1, RandomValue(140, 200));
                Canvas.SetLeft(Building_2, RandomValue(190, 220));
            }
            else if (first == 3)
            {
                Canvas.SetLeft(Building_4, 0);
                Canvas.SetLeft(Building_1, RandomValue(40, 150));
                Canvas.SetLeft(Building_2, RandomValue(140, 200));
                Canvas.SetLeft(Building_3, RandomValue(190, 220));
            }
            else if (first == 4)
            {
                Canvas.SetLeft(Building_2, 0);
                Canvas.SetLeft(Building_4, RandomValue(40, 150));
                Canvas.SetLeft(Building_1, RandomValue(140, 200));
                Canvas.SetLeft(Building_3, RandomValue(190, 220));
            }


        }
        public int RandomValue(int min, int max)
        {
            Random random = new Random();
            int RandomNumber = random.Next(min, max);
            return RandomNumber;
        }
        public int RandomPlace(string name)
        {
            //int left = Canvas.GetLeft(name);
            Random random = new Random();
            int RandomNumber = random.Next(0, 100);
            return RandomNumber;
        }
    }
}
