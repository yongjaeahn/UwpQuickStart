// MainViewModel.cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Windows.Mvvm;
using SimplePrismBlank.Core.Models;
using Windows.UI.Xaml.Controls;
using Windows.Media.SpeechSynthesis;

namespace SimplePrismBlankApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private int _rowCount = 3;
        public int rowCount
        {
            get => _rowCount;
            set => SetProperty(ref _rowCount, value);
        }

        private int _columnCount = 3;
        public int columnCount
        {
            get => _columnCount;
            set => SetProperty(ref _columnCount, value);
        }

        //private List<int> _cells = new List<int>();
        //public List<int> cells
        //private ObservableCollection<int> _cells = new ObservableCollection<int>();
        //public ObservableCollection<int> cells
        private ObservableCollection<Cell> _cells = new ObservableCollection<Cell>();
        public ObservableCollection<Cell> cells
        {
            get => _cells;
        }

        private string _errorMessagePage = "";
        public string errorMessagePage
        {
            get => _errorMessagePage;
            set => SetProperty(ref _errorMessagePage, value);
        }

        public MainViewModel()
        {
            newGame();
        }

        public void newGame()
        {
            int cellNumber = 0;

            if (!validateRowAndColumnCount()) return;

            cells.Clear();

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    //cells.Add(0);
                    cellNumber++;
                    cells.Add(new Cell(cellNumber));
                }
            }
        }

        private bool validateRowAndColumnCount()
        {
           if (rowCount > columnCount)
            {
                errorMessagePage = "행의 수가 열의 수보다 작거나 같아야 합니다.";

                textToSpeech(errorMessagePage);

                return false;
            }

            errorMessagePage = "";

            return true;
        }

        private async void textToSpeech(string text)
        {
            MediaElement mediaElement = new MediaElement();

            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            SpeechSynthesisStream speechSynthesizerStream = await speechSynthesizer.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(speechSynthesizerStream, speechSynthesizerStream.ContentType);
            mediaElement.Play();
        }
    }
}
