using System;
using Android.Content;
using MeetupDemo.MobileApp;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;

namespace MeetupDemo.Droid
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new MeetupDemoMobileApp();
		}
	}
}
