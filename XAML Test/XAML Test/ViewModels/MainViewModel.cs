using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Windows.UI.Popups;

using System.ComponentModel;    // INotifyPropertyChanged

namespace XAML_Test.ViewModels
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        string _name;
        public string Name
        {
            get { return this._name; }
            set
            {
                if (this._name == value) return;
                this._name = value;
                notify("Name");
            }
        }

        int _age;
        public int Age
        {
            get { return this._age; }
            set
            {
                if (this._age == value) return;
                this._age = value;
                notify("Age");
            }
        }

        public Person() { }
        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
    }

    public class MainViewModel : ViewModelBase
    {
        public ICommand clickMeButtonCommand { get; set; }

        /*
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _age;
        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
        */

        public MainViewModel()
        {
            clickMeButtonCommand = new DelegateCommand(onClickMeButtonCommand);

            //Name = "Tom";
            //Age = 11;
        }

        private async void onClickMeButtonCommand()
        {
            MessageDialog messageDialog = new MessageDialog("버튼을 클릭하였습니다.");
            await messageDialog.ShowAsync();
        }
    }
}

namespace WithBinding
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void notify(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        string _name;
        public string Name
        {
            get { return this._name; }
            set
            {
                if (this._name == value) return;
                this._name = value;
                notify("Name");
            }
        }

        int _age;
        public int Age
        {
            get { return this._age; }
            set
            {
                if (this._age == value) return;
                this._age = value;
                notify("Age");
            }
        }

        public Person() { }
        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }
    }
}
