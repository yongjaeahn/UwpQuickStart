using System;
using System.Collections.Generic;
using System.Net.Http;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using SimpleDataGrid.Core.Helpers;
using SimpleDataGrid.Core.Models;

namespace SimpleDataGrid.ViewModels
{
    public class UserDetailViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get => _navigationService;
            //set => SetProperty(ref _navigationService, value);
        }

        private User _user;
        public User user
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private string _address;
        public string address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }

        public UserDetailViewModel()
        {
        }

        public UserDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            string userId = e.Parameter as string;

            using (HttpClient httpClient = new HttpClient())
            {
                string httpResponse = await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/users/" + userId);
                user = await Json.ToObjectAsync<User>(httpResponse);
                address = user.address.street + ", " + user.address.suite + ", " + user.address.city + ", " + user.address.zipcode;
            }
        }













        /*
        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);

            string userId = e.Parameter as string;

            using (HttpClient httpClient = new HttpClient())
            {
                string httpResponse = await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/users/" + userId);
                user = await Json.ToObjectAsync<User>(httpResponse);
                address = user.address.street + ", " + user.address.suite + ", " + user.address.city + ", " + user.address.zipcode;
            }
        }
        */
    }
}
