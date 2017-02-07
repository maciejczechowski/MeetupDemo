using System;
using Splat;
using ReactiveUI;
using MeetupDemo.MobileApp;
using MeetupDemo.MobileApp.ViewModels;

namespace MeetupDemo.MobileApp
{
    public class MeetupAppBootstrapper : ReactiveObject //, IScreen
    {
        //public RoutingState Router {
        //    get;
        //    protected set;
        //}

        public MeetupAppBootstrapper ()
        {
            //this.Router = new RoutingState ();

            this.RegisterServices ();

            this.RegisterViews ();

            //var searchCitizenViewModel = new SearchCitizenViewModel ();

            // go to first view
            // does not work
            //this.Router.Navigate.Execute (new SearchCitizenViewModel ()).Subscribe();
        }

        private void RegisterServices()
        {
            //Locator.CurrentMutable.RegisterConstant (new Service (), typeof (IService));
        }

        private void RegisterViews()
        {
            //Locator.CurrentMutable.RegisterConstant (this, typeof (IScreen));
            //Locator.CurrentMutable.Register (() => new SearchCitizenActivity (), typeof (IViewFor<SearchCitizenViewModel>));
        }

        //public void Initialize () => this.Router
        //                                 .NavigateAndReset
        //                                 .Execute (this.getFirstViewModel ())
        //                                 .Subscribe ();
    }
}
