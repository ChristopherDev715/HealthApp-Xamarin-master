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
    [Activity(Label = "RemediosTomadosActivity")]
    public class RemediosTomadosActivity : Activity
    {
        private ListView lstRemedio;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RemediosTomados);

            DataBase db = new DataBase();
            db.CriarDatabase("remedio");

            List<Remedio> lRemedio = db.GetListRemedio();
            List<string> info = new List<string>();

            foreach (Remedio obj in lRemedio)
            {
                info.Add(obj.data);
            }

            lstRemedio = FindViewById<ListView>(Resource.Id.listView1);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, info);

            lstRemedio.Adapter = adapter;
        }
    }
}