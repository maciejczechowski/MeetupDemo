using System;
using Android.App;
using Android.Runtime;
using MeetupDemo.MobileApp;
using ReactiveUI;
using Splat;

namespace MeetupDemo.Droid
{
    [Application(Label = "Meetup App")]
    public class MeetupApp : Application
    {
        AutoSuspendHelper suspendHelper;

        MeetupApp (IntPtr handle, JniHandleOwnership owner) : base(handle, owner) { }

        public override void OnCreate ()
        {
            base.OnCreate ();

            suspendHelper = new AutoSuspendHelper (this);
            var bootstrapper = new MeetupAppBootstrapper (() => new SearchCitizenViewModel());

            RxApp.SuspensionHost.CreateNewAppState = () => bootstrapper;
            RxApp.SuspensionHost.SetupDefaultSuspendResume ();

            this.ConfigureViews ();

            //bootstrapper.Initialize ();
        }

        private void ConfigureViews ()
        {
            //Locator.CurrentMutable.Register (() => new SearchCitizenActivity (), typeof (IViewFor<SearchCitizenViewModel>));

        }
    }
}
