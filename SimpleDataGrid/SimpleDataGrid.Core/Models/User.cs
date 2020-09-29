using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleDataGrid.Core.Models
{

    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }

        //public string email { get; set; }
        private string _email;
        public string email
        {
            get => _email;
            set
            {
                _email = value;

                if(PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("email"));
            }
        }

        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }

}
