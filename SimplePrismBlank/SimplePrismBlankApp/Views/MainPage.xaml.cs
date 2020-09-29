// MainPage.xaml.cs
using System;
using SimplePrismBlankApp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace SimplePrismBlankApp.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.newGame();
        }

        private void rowCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox rowCount = sender as TextBox;
            validateRowAndColumnCount(rowCount.Name, rowCount.Text);
        }

        private void columnCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox columnCount = sender as TextBox;
            validateRowAndColumnCount(columnCount.Name, columnCount.Text);
        }

        private void validateRowAndColumnCount(string elementName, string enteredCount)
        {
            int count;

            if (!int.TryParse(enteredCount, out count))
            {
                errorMessageElement.Text = elementName + " : " + "정수값이 입력되어야 합니다.";
                return;
            }

            if(count < 1 || count > 10)
            {
                errorMessageElement.Text = elementName + " : " + "1에서 10까지의 정수가 입력되어야 합니다.";
                return;
            }

            errorMessageElement.Text = "";
        }

        private void drawButton_Click(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ViewModel.newGame();
        }
    }
}
