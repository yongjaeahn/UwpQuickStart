// MainPage.xaml.cs

using System;

using Hello_UWP_World.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Hello_UWP_World.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;
        //private MainViewModel ViewModel { get => DataContext as MainViewModel; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void viewGreetngs_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            viewGreetngs.Opacity = 0;
            //((TextBlock)sender).Opacity = 0;
        }

        // MainPage.xaml.cs : viewModelGreetngs.Opacity = 0; 문장의 주석을 해제하세요.
        private void viewModelGreetngs_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            viewModelGreetngs.Opacity = 0;
            //((TextBlock)sender).Opacity = 0;
        }

        private void codeBehindGreetngs_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //codeBehindGreetngs.Text = "Hello UWP World(Code Behind Program Code)";
            ((TextBlock)sender).Opacity = 0;
        }
    }
}
