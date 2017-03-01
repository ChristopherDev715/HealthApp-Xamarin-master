using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HealthApp
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public User(string username, string password, string fullname)
        {
            Username = username;
            Password = password;
            FullName = fullname;
        }
    }
}