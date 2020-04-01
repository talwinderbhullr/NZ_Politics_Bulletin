using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.Timers;

namespace NZ_Politics_Bulletin
{
    [Activity(Label = "NZ_Politics_Bulletin", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : Activity
    {
        ImageView splashScreen;
        int timerCount = 0;
        private static System.Timers.Timer alphaTimer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.SplashScreenLayout);

            splashScreen = FindViewById<ImageView>(Resource.Id.imageViewSplash);
            splashScreen.Alpha = 0;
            alphaTimer = new System.Timers.Timer(100);
            alphaTimer.Elapsed += OnTimedEvent;
            alphaTimer.Enabled = true;
        }



        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            RunOnUiThread(() => timerSplash());
        }

        private void timerSplash()
        {
            timerCount++;
            if (timerCount <= 10)
            {
                splashScreen.Alpha += 0.1f;
            }
            else if (timerCount >= 20 && timerCount < 30)
            {
                splashScreen.Alpha -= 0.1f;
            }
            else if (timerCount >= 40 && timerCount < 50)
            {
                splashScreen.Alpha -= 0.1f;

            }
            else if (timerCount >= 60 && timerCount < 70)
            {
                splashScreen.Alpha -= 0.1f;
            }
            else if (timerCount == 80)
            {
                StartActivity(typeof(MainActivity));
                Finish();
            }
        }
    }
}
