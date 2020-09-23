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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        StackPanel panel = new StackPanel();
        JSONWriter writer = new JSONWriter();

        public MainMenu()
        {
            InitializeComponent();
            writer.CreateFile("test.json");
            this.setText();
            this.Content = panel;
        }

        private void setText() {
            Label title = new Label();
            title.Content = "Hello World";
            panel.Children.Add(title);
        }
    }
}
