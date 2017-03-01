using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;



namespace HealthApp
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.loginButton);
            Button button2 = FindViewById<Button>(Resource.Id.RegisterButton);

            button2.Click += delegate {
                StartActivity(typeof(RegisterActivity));
            };

            button.Click += delegate {

                DataBase db = new DataBase();
                db.CriarDatabase("Users");
                string password = db.GetUserPassword(FindViewById<EditText>(Resource.Id.usernameText).Text);
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                if (password.Equals(FindViewById<EditText>(Resource.Id.passwordText).Text))
                {
                    alert.SetTitle("Worked");
                }
                else
                {
                    alert.SetTitle("Fail");
                }
                alert.SetPositiveButton("OK", (senderAlert, args) =>
                {
                });
                RunOnUiThread(() =>
                {
                    alert.Show();
                });

            };
        }
    }
}

