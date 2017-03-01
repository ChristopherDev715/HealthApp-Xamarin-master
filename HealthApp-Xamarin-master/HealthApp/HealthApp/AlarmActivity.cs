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
    [Activity(Label = "AlarmActivity")]
    public class AlarmActivity : Activity
    {
        private EditText edtHorario;
        private EditText edtData;
        private Button btnSalvar,btnCancelar;
        private PendingIntent pndIntent;
        private AlarmManager almManager;
        private AlarmReciver all;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Alarm);

            Intent it = new Intent(ApplicationContext, typeof(AlarmReciver));

            pndIntent = PendingIntent.GetBroadcast(ApplicationContext, 0, it,PendingIntentFlags.UpdateCurrent);

            edtData = FindViewById<EditText>(Resource.Id.main_edt_data);
            edtHorario = FindViewById<EditText>(Resource.Id.main_edt_tempo);
            btnSalvar = FindViewById<Button>(Resource.Id.main_btn_salvar);
            btnCancelar = FindViewById<Button>(Resource.Id.main_btn_cancelar);
            //all.SetAlarm(ApplicationContext, 3);
            almManager = (AlarmManager)ApplicationContext.GetSystemService(Context.AlarmService);
            
            almManager.SetRepeating(AlarmType.ElapsedRealtimeWakeup , Java.Lang.JavaSystem.CurrentTimeMillis(), 2000, pndIntent);


            btnSalvar.Click += delegate
            {
                int minuto = 0,hora=0,segundo=0;

                string[] horario = new string[3];

                //horario = edtHorario.Text.Split(':');

                //hora = int.Parse(horario[0]);
                //minuto = int.Parse(horario[1]);
                //segundo = int.Parse(horario[2]);

                //almManager.Set(AlarmType.ElapsedRealtime, Java.Lang.JavaSystem.CurrentTimeMillis(), pndIntent);
                almManager.SetRepeating(AlarmType.RtcWakeup,Java.Lang.JavaSystem.CurrentTimeMillis(), 1000, pndIntent);

            };
            btnCancelar.Click += delegate {
                if (almManager != null)
                    almManager.Cancel(pndIntent);
            };
        }
    }
}
 