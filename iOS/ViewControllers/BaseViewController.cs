using System;
using ReactiveUI;
using MeetupDemo.MobileApp;
using MeetupDemo.MobileApp.ViewModels;

namespace MeetupDemo.iOS.ViewControllers
{
    public abstract class BaseViewController<TViewModel> : ReactiveViewController, IViewFor<TViewModel>, IActivatable where TViewModel : ViewModelBase
    {
        private TViewModel viewModel;
        public TViewModel ViewModel {
            get { return this.viewModel; }
            set { this.RaiseAndSetIfChanged (ref this.viewModel, value); }
        }

        object IViewFor.ViewModel {
            get { return this.ViewModel; }
            set { throw new NotImplementedException (); }
        }

        public BaseViewController ()
        {
            this.ViewModel = this.CreateViewModel ();
        }

        protected abstract TViewModel CreateViewModel ();
    }
}
