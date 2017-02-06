using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using ReactiveUI;
using Splat;

namespace MeetupDemo.MobileApp.ViewModels
{
    public class MainViewModel : ViewModelBase, IScreen
    {
        public RoutingState Router {
            get; private set;
        }

        public IScreen HostScreen => this;

        public MainViewModel ()
        {
            this.Router = new RoutingState ();
            //this.HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            this.Router.Navigate.Execute (new SearchCitizenViewModel ()).Subscribe();
        }
    }
}
