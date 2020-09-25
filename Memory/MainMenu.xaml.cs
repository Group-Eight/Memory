using System;
using System.Collections.Generic;
using Newtonsoft.Json;
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
using Newtonsoft.Json.Linq;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        StackPanel panel = new StackPanel();
        JSONParser parser = new JSONParser("template.json");

        public MainMenu()
        {
            InitializeComponent();
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
