using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;
using Android.Util;
using System;
using Android.Graphics;
using Android.Media;


namespace HealthApp
{
    [BroadcastReceiver]
    class AlarmReciver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Intent secondIntent = new Intent(context, typeof(RemedioActivity));

            // Pass some information to SecondActivity:
            secondIntent.PutExtra("message", "Greetings from MainActivity!");

            // Create a task stack builder to manage the back stack:
            TaskStackBuilder stackBuilder = TaskStackBuilder.Create(context);

            // Add all parents of SecondActivity to the stack: 
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(RemedioActivity)));

            // Push the intent that starts SecondActivity onto the stack:
            stackBuilder.AddNextIntent(secondIntent);

            // Obtain the PendingIntent for launching the task constructed by
            // stackbuilder. The pending intent can be used only once (one shot):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =
                stackBuilder.GetPendingIntent(pendingIntentId, PendingIntentFlags.OneShot);

            Notification.Builder builder = new Notification.Builder(context).
                SetContentTitle("Notificação remédio").
                SetContentIntent(pendingIntent).
                SetContentText("Lmebre-se de tomar o remédio")
                .SetSmallIcon(Resource.Drawable.Icon);

            builder.SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis());
            
            Notification notification = builder.Build();
            NotificationManager notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            
            notificationManager.Notify(0, notification);
            //Toast.MakeText(context, "Alarme", ToastLength.Short).Show();

        }/*
        public override void OnReceive(Context context, Intent intent)
        {
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock w1 = pm.NewWakeLock(WakeLockFlags.Partial, "NotificationReceiver");
            w1.Acquire();
            var nMgr = (NotificationManager)context.GetSystemService(Context.NotificationService);
            var notification = new Notification(Resource.Drawable.Icon, "Arrival");
            var pendingIntent = PendingIntent.GetActivity(context, 0, new Intent(context, typeof(MainActivity)), 0);
            notification.SetLatestEventInfo(context, "Arrival", "Arrival", pendingIntent);
            nMgr.Notify(0, notification);
            w1.Release();
        }

        public void CancelAlarm(Context context)
        {
            Intent intent = new Intent(context, this.Class);
            PendingIntent sender = PendingIntent.GetBroadcast(context, 0, intent, 0);
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            alarmManager.Cancel(sender);
        }

        public void SetAlarm(Context context, int alertTime)
        {
            long now = SystemClock.ElapsedRealtime();
            AlarmManager am = (AlarmManager)context.GetSystemService(Context.AlarmService);
            Intent intent = new Intent(context, this.Class);
            PendingIntent pi = PendingIntent.GetBroadcast(context, 0, intent, 0);
            am.Set(AlarmType.ElapsedRealtimeWakeup, now + ((long)(alertTime * 10000)), pi);
        }*/
    }
    
}