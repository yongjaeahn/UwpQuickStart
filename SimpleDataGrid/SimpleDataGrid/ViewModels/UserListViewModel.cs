// UserListViewModel.cs
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SimpleDataGrid.Core.Helpers;
using SimpleDataGrid.Core.Models;
using SimpleDataGrid.Core.Services;

namespace SimpleDataGrid.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        //private readonly ISampleDataService _sampleDataService;
        //public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();
        //public ObservableCollection<User> Source { get; } = new ObservableCollection<User>();
        /*
        private IList<User> _users;
        public IList<User> users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }
        */       
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        public ObservableCollection<User> users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }
        
        // UserListViewModel.cs
        private INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get => _navigationService;
            //set => SetProperty(ref _navigationService, value);
        }

        /*
        public UserListViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }
        */

        public UserListViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
           /*
           base.OnNavigatedTo(e, viewModelState);


           Source.Clear();

           // TODO WTS: Replace this with your actual data
           var data = await _sampleDataService.GetGridDataAsync();

           foreach (var item in data)
           {
               Source.Add(item);
           }
           */

            base.OnNavigatedTo(e, viewModelState);

            using (HttpClient httpClient = new HttpClient())
            {
                string httpResponse = await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/users");
                User[] tempUsers = await Json.ToObjectAsync<User[]>(httpResponse);
                //users = tempUsers.ToList();               
                users.Clear();
                foreach (User user in tempUsers)
                {
                    users.Add(user);
                }
            }
        }
    }
}
