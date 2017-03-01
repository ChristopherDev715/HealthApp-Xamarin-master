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
    [Activity(Label = "RemedioActivity")]
    public class RemedioActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Remedio);

            Button btnSalvar = FindViewById<Button>(Resource.Id.remedio_btn_salvar);

            btnSalvar.Click += delegate
            {
                Java.Util.Calendar calendar = Java.Util.Calendar.GetInstance(Java.Util.Locale.Default);
                string data = calendar.Time.Day + "/" + calendar.Time.Month + "/" + calendar.Time.Year + " " + calendar.Time.Hours + ":" + calendar.Time.Minutes;
                Remedio remedio = new Remedio(0, data);

                DataBase db = new DataBase();
                db.CriarDatabase("remedio");
                AlertDialog.Builder alert = new AlertDialog.Builder(this);

                if (db.AddRegistro(remedio))
                {
                    alert.SetTitle("Sucessful Registered!1");
                    alert.SetPositiveButton("Yes", (senderAlert, args) =>
                    {
                        StartActivity(typeof(RemediosTomadosActivity));
                        Finish();
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
        }
    }
}