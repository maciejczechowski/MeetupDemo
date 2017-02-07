using System;
using ReactiveUI;
using MeetupDemo.MobileApp.ViewModels;
using Android.App;
using Android.Content.PM;

namespace MeetupDemo.Droid.Activities
{
    [Activity (
        Label = "Main",
        Icon = "@drawable/icon",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : ReactiveActivityBase<MainViewModel>
    {
        public MainActivity ()
        {
        }

        protected override MainViewModel CreateViewModel ()
        {
            return new MainViewModel();
        }

        protected override void OnCreate (Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            this.SetContentView (Resource.Layout.Main);
        }
    }
}
