
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
using MeetupDemo.MobileApp.ViewModels;
using ReactiveUI;
using Splat;
using MeetupDemo.MobileApp;
using System.Reactive.Linq;
using MeetupDemo.Droid.Activities;

namespace MeetupDemo.Droid
{
	[Activity(Label = "Meetup", MainLauncher = true, NoHistory = true, Icon = "@drawable/Icon")]
    public class SplashScreen : Activity
	{
		public SplashScreen() : base()
        {
            
		}

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            this.SetContentView (Resource.Layout.SplashScreen);

            Observable.Timer (TimeSpan.FromSeconds (3)).Subscribe (_ => {
                this.StartActivity (typeof (SearchCitizenActivity));
            });
        }
	}
}
