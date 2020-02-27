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

namespace Horizonx2.Droid
{
    [Activity(Label = "Tatlı Cümle", Theme = "@style/Theme.Splash", MainLauncher = true, Icon = "@drawable/Splash")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            this.StartActivity(typeof(MainActivity));
        }
    }
}