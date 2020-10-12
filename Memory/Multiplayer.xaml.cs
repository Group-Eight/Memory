using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Memory
{
    /// <summary>
    /// Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Page {

        Host host = new Host();
        Client client = new Client();

        StackPanel panel = new StackPanel();

        public Multiplayer() {
            InitializeComponent();
            this.host.creation();
            Console.WriteLine(this.host.receive());
            this.host.send("boodschap!");
            this.host.CloseConnection();
        }
    }
}
