// MainViewModel.cs
using System;

using Prism.Windows.Mvvm;

using Hello_UWP_World.Core.Models;
using Hello_UWP_World.Core.Helpers;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

namespace Hello_UWP_World.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _helloGreetings;
        public string helloGreetings {
            get => _helloGreetings;
            set => SetProperty(ref _helloGreetings, value);
        }

        // MainViewModel.cs
        /*
        private IList<string> _users;
        public IList<string> users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }
        */
        private IList<User> _users;
        public IList<User> users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public MainViewModel()
        {
            //helloGreetings = "Hello UWP World (ViewModel)";

            //getUserAsync();

            //string[] tempUsers = { "홍길동", "유관순", "안정복" };
            //users = tempUsers.ToList();

            getUsersAsync();
        }

        private async void getUserAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string httpResponse = await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/users/1");
                User user = await Json.ToObjectAsync<User>(httpResponse);
                helloGreetings = "Hello UWP World (Model) -  " + user.name;
            }
        }

        private async void getUsersAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string httpResponse = await httpClient.GetStringAsync("http://jsonplaceholder.typicode.com/users");
                User[] tempUsers = await Json.ToObjectAsync<User[]>(httpResponse);
                users = tempUsers.ToList();
            }
        }
    }
}
