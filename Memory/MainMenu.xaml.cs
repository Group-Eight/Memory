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
        public MainMenu()
        {
            InitializeComponent();
            this.setText();
            this.setButton();
            this.Content = panel;
        }

        private void setText() {
            Label title = new Label();
            title.Content = "Hello World";
            panel.Children.Add(title);
        }
        private void setButton()
        {
            Button button = new Button();
            button.Content = "Hello World";
            button.Width = 200;
            button.Click += btn1Click;
            panel.Children.Add(button);
            
        }
        private void btn1Click(object sender, RoutedEventArgs e)
        {
            MemoryCard memorycard = new MemoryCard();
            this.NavigationService.Navigate(memorycard);
        }
    }
}
