using System;
using System.Diagnostics;
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
            var bootstrapper = new MeetupAppBootstrapper ();

            RxApp.SuspensionHost.CreateNewAppState = () => bootstrapper;
            RxApp.SuspensionHost.SetupDefaultSuspendResume ();
            RxApp.SuspensionHost.IsResuming.Subscribe (_ => {
                Debug.WriteLine ("IsResuming");
            });
            RxApp.SuspensionHost.IsLaunchingNew.Subscribe (_ => {
                Debug.WriteLine ("IsResuming");
            });
            RxApp.SuspensionHost.IsUnpausing.Subscribe (_ => {
                Debug.WriteLine ("IsResuming");
            });
            RxApp.SuspensionHost.ShouldPersistState.Subscribe (_ => {
                Debug.WriteLine ("IsResuming");
            });
            this.ConfigureViews ();

            //bootstrapper.Initialize ();
        }

        private void ConfigureViews ()
        {
            //Locator.CurrentMutable.Register (() => new SearchCitizenActivity (), typeof (IViewFor<SearchCitizenViewModel>));

        }
    }
}
