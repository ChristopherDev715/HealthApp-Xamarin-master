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
    [Activity(Label = "PerfilActivity")]
    public class PerfilActivity : Activity
    {
        private ListView lstPacientes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Perfil);

            Button button = FindViewById<Button>(Resource.Id.button001);

            DataBase db = new DataBase();
            db.CriarDatabase("perfil");
            AlertDialog.Builder alert = new AlertDialog.Builder(this);

            button.Click += delegate {
                Perfil perfil = new Perfil();

                string aux = FindViewById<EditText>(Resource.Id.editText001).Text;
                perfil.SetPaciente(aux);

                aux = FindViewById<EditText>(Resource.Id.editText002).Text;
                perfil.SetResponsavel(aux);

                db.AddRegistro(perfil);
                alert.SetTitle("Sucessful Registered!1");
                alert.SetPositiveButton("Yes", (senderAlert, args) =>
                {
                });
                RunOnUiThread(() =>
                {
                    alert.Show();
                });
            };

            List<Perfil> lPerfil = db.GetListPerfil();
            List<string> info = new List<string>();

            foreach (Perfil obj in lPerfil)
            {
                info.Add(obj.Getpaciente() + " - " + obj.GetResponsavel());
            }

            lstPacientes = FindViewById<ListView>(Resource.Id.listView17);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, info);

            lstPacientes.Adapter = adapter;

        }
    }
}