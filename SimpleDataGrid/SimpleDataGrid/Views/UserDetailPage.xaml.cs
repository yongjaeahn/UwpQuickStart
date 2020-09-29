using System;

using SimpleDataGrid.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SimpleDataGrid.Views
{
    public sealed partial class UserDetailPage : Page
    {
        private UserDetailViewModel ViewModel => DataContext as UserDetailViewModel;

        public UserDetailPage()
        {
            InitializeComponent();
        }

        private void backButton_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ViewModel.NavigationService.GoBack();
        }

        private void changeMailId_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ViewModel.user.email = "honggildong@company.com";
        }
    }
}
