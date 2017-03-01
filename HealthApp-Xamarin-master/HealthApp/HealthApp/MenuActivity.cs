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
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Menu);

            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate
            {
                StartActivity(typeof(LoginActivity));
            };

            button = FindViewById<Button>(Resource.Id.button2);

            button.Click += delegate
            {
                StartActivity(typeof(AlarmActivity));
            };

            button = FindViewById<Button>(Resource.Id.button3);

            button.Click += delegate
            {
                StartActivity(typeof(RegisterActivity));
            };

            button = FindViewById<Button>(Resource.Id.button4);

            button.Click += delegate
            {
                StartActivity(typeof(PerfilActivity));
            };

            button = FindViewById<Button>(Resource.Id.button5);

            button.Click += delegate
            {
                StartActivity(typeof(RemedioActivity));
            };
            // Create your application here
        }
    }
}