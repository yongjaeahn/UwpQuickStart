using System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using XAML_Test.ViewModels;

using System.ComponentModel;    // INotifyPropertyChanged
using Windows.UI.Xaml;          // ElementSoundPlayer
using Microsoft.Toolkit.Uwp.UI.Animations;  // Offset().StartAsync()
using Windows.UI.Xaml.Media.Animation;      // EasingMode.EaseInOut

namespace XAML_Test.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        Person person = new Person("Tom", 11);

        public MainPage()
        {
            InitializeComponent();

            //nameTextBox.Text = person.Name;
            //ageTextBox.Text = person.Age.ToString();

            //person.PropertyChanged += personPropertyChanged;

            //nameTextBox.TextChanged += nameTextBox_TextChanged;
            //ageTextBox.TextChanged += ageTextBox_TextChanged;

            //birhdayButton.Click += birhdayButton_Click;

            //grid.DataContext = person;
        }

        void personPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Name":
                    //nameTextBox.Text = person.Name;
                    break;

                case "Age":
                    //ageTextBox.Text = person.Age.ToString();
                    break;
            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            speak();
        }

        private async void speak()
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("Hello World! 안녕하세요?");
            mediaElement.SetSource(stream, stream.ContentType);

            mediaElement.Play();
        }

        private void Rectangle_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //Rectangle clickedRectangle = sender as Rectangle;
            //clickedRectangle.Width += 10;
            ((Rectangle)sender).Width += 10;

            e.Handled = true;
        }

        private void StackPanel_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Rectangle clickedRectangle = e.OriginalSource as Rectangle;
            clickedRectangle.Width += 10;
            //((Rectangle)e.OriginalSource).Width += 10;
        }

        // 초기값을 설정하는 코드
        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //TextBoxName.Text = "홍길동";
        }

        // 변경된 값을 사용하는 코드
        private async void TextBoxName_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                string name = ((TextBox)sender).Text;
                MessageDialog messageDialog
                    = new MessageDialog("입력된 이름은 " + name + "입니다.");
                await messageDialog.ShowAsync();
            }
        }

        // 초기값을 설정하는 코드
        private void CalendarDatePickerEnteredDate_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //CalendarDatePickerEnteredDate.Date = DateTime.Now;
            //CalendarDatePickerEnteredDate.Date = new DateTime(2004, 1, 1);
        }

        // 변경된 값을 사용하는 코드
        private async void CalendarDatePickerEnteredDate_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            string dateString = sender.Date.Value.Year.ToString() + "/"
                                    + sender.Date.Value.Month.ToString() + "/"
                                    + sender.Date.Value.Day.ToString();
            MessageDialog messageDialog
                = new MessageDialog("입력된 입사일자는 " + dateString + "입니다.");
            await messageDialog.ShowAsync();
        }

        private void CalendarViewEnteredDate_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //CalendarViewEnteredDate.SelectedDates.Clear();
            //CalendarViewEnteredDate.SelectedDates.Add(new DateTime(1977, 1, 5));
        }

        private async void SelectedDatesChangedEventHandler(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            string dateString = sender.SelectedDates[0].Year.ToString() + "/"
                                    + sender.SelectedDates[0].Month.ToString() + "/"
                                    + sender.SelectedDates[0].Day.ToString();
            MessageDialog messageDialog
                = new MessageDialog("입력된 입사일자는 " + dateString + "입니다.");
            await messageDialog.ShowAsync();
        }

        private void DatePickerEnteredDate_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //DatePickerEnteredDate.Date = DateTime.Now;
            //DatePickerEnteredDate.Date = new DateTime(2004, 1, 1);
        }

        private async void DatePickerEnteredDate_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            string dateString = ((DatePicker)sender).Date.Year.ToString() + "/"
                                    + ((DatePicker)sender).Date.Month.ToString() + "/"
                                    + ((DatePicker)sender).Date.Day.ToString();
            MessageDialog messageDialog
                = new MessageDialog("입력된 입사일자는 " + dateString + "입니다.");
            await messageDialog.ShowAsync();
        }

        private void StackPanel_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //TimePickerDepartureTime.Time = new TimeSpan(08, 30, 00);
            //TimePickerArrivalTime.Time = new TimeSpan(21, 30, 00);
        }

        private async void TimePickerDepartureTime_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            string timeString = ((TimePicker)sender).Time.Hours.ToString() + ":"
                                + ((TimePicker)sender).Time.Minutes.ToString();
            MessageDialog messageDialog
                = new MessageDialog("입력된 출발시간은 " + timeString + "입니다.");
            await messageDialog.ShowAsync();
        }

        private async void TappedEventHandler(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            /*
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "저장",
                PrimaryButtonText = "Yes",
                SecondaryButtonText = "No",
                CloseButtonText = "Cancel",
                DefaultButton = ContentDialogButton.Primary,
                //Content = "작업한 내역을 저장하시겠습니까?"
                Content= @"
""Stretch""
""Upload your content to the cloud.""
""Lorem ipsum dolor sit amet, adipisicing elit.""
""Wrap""
                         "
            };
            */
            //contentDialog.DefaultButton = ContentDialogButton.Primary;

            //ContentDialogResult result = await contentDialog.ShowAsync();


            ContentDialogExample contentDialogExample = new ContentDialogExample();
            ContentDialogResult result = await contentDialogExample.ShowAsync();

            switch (result)
            {
                case ContentDialogResult.Primary:     // Yes 버튼 누른 로직 구현
                    MessageDialog messageDialog = new MessageDialog("Yes 버튼");
                    await messageDialog.ShowAsync();
                    break;
                case ContentDialogResult.Secondary:   // No 버튼 누른 로직 구현
                    messageDialog = new MessageDialog("No 버튼");
                    await messageDialog.ShowAsync();
                    break;
                case ContentDialogResult.None:        // Cancel 버튼 누른 로직 구현
                    messageDialog = new MessageDialog("Cancel 버튼");
                    await messageDialog.ShowAsync();
                    break;
            }
        }

        private void fileDownloadProgressBar_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // 편의상 Loaded 이벤트 핸들러에서 Vlue 속성의 초기값을 지정하였습니다.
            // 실제 업무 환경에서 ProgressBar를 활용할 때에는
            // 특정 작업의 상태를 알 수 있는 위치에서
            // 1~100사이의 값을 작업의 진도에 맞게 설정하여야 합니다.
            //fileDownloadProgressBar.Value = 50;
        }

        private void colorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color color = (Color)XamlBindingHelper.ConvertValue(typeof(Color), ((ListBox)sender).SelectedItems[0].ToString());
            SolidColorBrush colorBrush = new SolidColorBrush(color);
            //colorEllipse.Fill = colorBrush;

            if (((ListBox)sender).SelectedItems.Count > 1)
            {
                color = (Color)XamlBindingHelper.ConvertValue(typeof(Color), ((ListBox)sender).SelectedItems[1].ToString());
                colorBrush = new SolidColorBrush(color);
                //colorEllipseLower.Fill = colorBrush;
            }
        }

        private async void birhdayButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //person.Age++;
            //ageTextBox.Text = person.Age.ToString();

            MessageDialog messageDialog = new MessageDialog(string.Format("Happy Birthday, {0}, age {1}!", person.Name, person.Age));
            await messageDialog.ShowAsync();
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //person.Name = nameTextBox.Text;
        }

        private void ageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int age = 0;

            //if(int.TryParse(ageTextBox.Text, out age))
            //    person.Age = age;
        }

        private async void birhdayButton_Click_DataBinding(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //MessageDialog messageDialog = new MessageDialog(string.Format("Happy Birthday, {0}, age {1}!", nameTextBox.Text, ageTextBox.Text));
            //MessageDialog messageDialog = new MessageDialog(string.Format("Happy Birthday, {0}, age {1}!", person.Name, person.Age));
            //await messageDialog.ShowAsync();
        }

        private void mainStackPanel_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Ellipse ellipse = e.OriginalSource as Ellipse;
            Rectangle rectangle = e.OriginalSource as Rectangle;

            if (ellipse != null)
                ellipse.Width *= 2;

            if (rectangle != null)
                rectangle.Rotation += 90;
        }

        private void playFocusSound_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //ElementSoundPlayer.State = ElementSoundPlayerState.On;
            //ElementSoundPlayer.Play(ElementSoundKind.);
        }

        private async void lockImage_Loaded(object sender, RoutedEventArgs e)
        {
            //lockImage.Opacity = 1;
            //lockImage.Opacity = 0;

            //lockImage.Rotation = 360;

            //lockImage.Scale = new System.Numerics.Vector3(1, 1, 0);
            //lockImage.Scale = new System.Numerics.Vector3(2, 2, 0);

            //lockImage.Translation = new System.Numerics.Vector3(0, 0, 0);

            //lockImageAnimationStoryboard.Begin();

            /*
            await lockImage.Offset(offsetX: -100.0f,
                                   offsetY: 0.0f,
                                   duration: 1000,
                                   easingMode: EasingMode.EaseInOut
                                  ).StartAsync();
            */
        }

        private void animationContentPresenter_Loaded(object sender, RoutedEventArgs e)
        {
            //Color color = (Color)XamlBindingHelper.ConvertValue(typeof(Color), "Blue");
            //animationContentPresenter.Background = new SolidColorBrush(color);
        }

        private void colorAnimationButton_Loaded(object sender, RoutedEventArgs e)
        {
            //colorAnimationButtonStoryboard.Begin();
        }

        private void combinedAnimationStackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            //combinedAnimationStoryboard.Begin();
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            Style reveal = Resources.ThemeDictionaries["ButtonRevealStyle"] as Style;

            //button2.Style = reveal;
        }
    }
}
