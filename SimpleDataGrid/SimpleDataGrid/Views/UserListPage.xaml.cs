using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Uwp.UI.Controls;
using SimpleDataGrid.Core.Models;
using SimpleDataGrid.ViewModels;

using Windows.UI.Xaml.Controls;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace SimpleDataGrid.Views
{
    public sealed partial class UserListPage : Page
    {
        private UserListViewModel ViewModel => DataContext as UserListViewModel;

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on UserListPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public UserListPage()
        {
            InitializeComponent();
        }

        // UserListPage.xaml.cs
        private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = e.AddedItems[0] as User;
            string userId = user.id.ToString();

            ViewModel.NavigationService.Navigate(PageTokens.UserDetailPage, userId);
        }

        DataGridColumn previousSortColumn = null;

        private void userList_Sorting(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridColumnEventArgs e)
        {
            DataGridColumn curentSortColumn = e.Column;

            if(curentSortColumn == previousSortColumn)
            {
                if(curentSortColumn.SortDirection == DataGridSortDirection.Ascending)
                {
                    curentSortColumn.SortDirection = DataGridSortDirection.Descending;
                } else
                {
                    curentSortColumn.SortDirection = null;

                    previousSortColumn = null;
                }
            }
            else
            {
                curentSortColumn.SortDirection = DataGridSortDirection.Ascending;

                if (previousSortColumn != null)
                    previousSortColumn.SortDirection = null;

                previousSortColumn = curentSortColumn;
            }

            if (curentSortColumn.SortDirection == null)
                userList.ItemsSource = ViewModel.users;
            else
                userList.ItemsSource = sortUserList(curentSortColumn);           
        }

        private ObservableCollection<User> sortUserList(DataGridColumn sortColumn)
        {
            string sortColumnName = "";

            switch (sortColumn.Header)
            {
                case "사용자ID":
                    sortColumnName = "id";
                    break;
                case "이름":
                    sortColumnName = "name";
                    break;
                case "회사":
                    sortColumnName = "company.name";
                    break;
                case "도시":
                    sortColumnName = "address.city";
                    break;
                case "위도":
                    sortColumnName = "address.geo.lat";
                    break;
                default:
                    break;
            }

            string sortOrder = "ascending";

            if (sortColumn.SortDirection == DataGridSortDirection.Descending)
                sortOrder = "descending";

            return new ObservableCollection<User>(ViewModel.users.AsQueryable().OrderBy($"{sortColumnName} {sortOrder}"));

            // Dynamic LINQ
            //return new ObservableCollection<User>(ViewModel.users.AsQueryable().OrderBy($"{sortColumnName}, id {sortOrder}"));
            //return new ObservableCollection<User>(ViewModel.users.AsQueryable().OrderBy("name"));

            // Static LINQ
            //return new ObservableCollection<User>(ViewModel.users.OrderByDescending(user => user.name));
            //return new ObservableCollection<User>(ViewModel.users.OrderBy(user => user.name));
            //return new ObservableCollection<User>(ViewModel.users.Where(user => user.id > 5));
            //return new ObservableCollection<User>(from user in ViewModel.users
            //                                      orderby user.name ascending
            //                                      select user);
            //return = new ObservableCollection<User>(from user in ViewModel.users
            //                                        orderby user.name descending
            //                                        select user);
            //return new ObservableCollection<User>(ViewModel.users.Where(user => user.name.Contains("Ch")));
            //return new ObservableCollection<User>(ViewModel.users.Where(user => user.id > 5));
        }

        private void northernHemisphereCheckBox_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CheckBox northernHemisphereCheckBox = sender as CheckBox;

            if (northernHemisphereCheckBox.IsChecked == true)
                userList.ItemsSource =
                    new ObservableCollection<User>(ViewModel.users.Where(user => !user.address.geo.lat.Contains("-")));
                    //new ObservableCollection<User>(from user in ViewModel.users
                    //                               where !user.address.geo.lat.Contains("-")
                    //                               select user);
            else
                userList.ItemsSource = ViewModel.users;
        }

        private void southernHemisphereCheckBox_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CheckBox northernHemisphereCheckBox = sender as CheckBox;

            if (northernHemisphereCheckBox.IsChecked == true)
                userList.ItemsSource =
                    new ObservableCollection<User>(from user in ViewModel.users
                                                   where user.address.geo.lat.Contains("-")
                                                   select user);
            else
                userList.ItemsSource = ViewModel.users;
        }
    }
}
