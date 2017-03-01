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
    [Activity(Label = "Register", MainLauncher = false)]
    public class RegisterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate
            {
                User user = new User(
                    (FindViewById<TextView>(Resource.Id.editText2)).Text,
                    (FindViewById<TextView>(Resource.Id.editText3)).Text,
                    (FindViewById<TextView>(Resource.Id.id12030499)).Text);

                DataBase db = new DataBase();
                db.CriarDatabase("Users");
                AlertDialog.Builder alert = new AlertDialog.Builder(this);

                if (db.AddRegistro(user))
                {
                    alert.SetTitle("Sucessful Registered!1");
                    alert.SetPositiveButton("Yes", (senderAlert, args) =>
                    {
                    });
                    RunOnUiThread(() =>
                    {
                        alert.Show();
                    });
                }
                else
                {
                    alert.SetTitle("Problem!!1");
                    alert.SetPositiveButton("Yes", (senderAlert, args) =>
                    {
                    });
                    RunOnUiThread(() =>
                    {
                        alert.Show();
                    });
                }
            };
            // Create your application here
        }
    }
}