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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {

        private MediaPlayer sceneMusic = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            sceneMusic.Open(new Uri("../../music/Prophectical_-_Time.mp3", UriKind.Relative));
			sceneMusic.Play();
            Console.WriteLine(((MainWindow)this).CurrentSource);
        }
    }
}
