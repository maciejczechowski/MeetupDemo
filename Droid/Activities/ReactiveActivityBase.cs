using System;
using ReactiveUI;
using MeetupDemo.MobileApp.ViewModels;
namespace MeetupDemo.Droid.Activities
{
    public abstract class ReactiveActivityBase<TViewModel> : ReactiveActivity<TViewModel>, IViewFor<TViewModel> where TViewModel : ViewModelBase
    {
        public ReactiveActivityBase () : base()
        {
            this.ViewModel = this.CreateViewModel ();
        }

        protected abstract TViewModel CreateViewModel ();
    }
}
