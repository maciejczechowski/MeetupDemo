
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
using MvvmCross.Droid.Views;

namespace MeetupDemo.Droid
{
	[Activity(Label = "Meetup", MainLauncher = true, NoHistory = true, Icon = "@drawable/Icon")]
	public class SplashScreenActivity : MvxSplashScreenActivity
	{
		public SplashScreenActivity() : base(Resource.Layout.SplashScreen)
        {
		}
	}
}
