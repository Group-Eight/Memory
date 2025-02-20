﻿using System;
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
    /// Interaction logic for Play.xaml
    /// </summary>
    public partial class Play : Page
    {
        public Play()
        {
            InitializeComponent();
        }
        private void onClickPlayLocal(object sender, RoutedEventArgs e)
        {
            if(difficultyChoice.Text == "Easy") { App.difficulty = 1; }
            if (difficultyChoice.Text == "Medium") { App.difficulty = 2; }
            if (difficultyChoice.Text == "Hard") { App.difficulty = 3; }

            Uri uri = new Uri("MemoryCard.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void onClickBack(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("MainMenu.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void onClickPlayMultiplayer(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Multiplayer.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
