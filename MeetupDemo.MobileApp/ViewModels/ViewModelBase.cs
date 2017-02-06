using System;
using ReactiveUI;
using Splat;
namespace MeetupDemo.MobileApp.ViewModels
{
    public class ViewModelBase : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen {
            get;set;
        }

        private string urlPathSegment;
        public virtual string UrlPathSegment {
            get {
                return urlPathSegment;
            }
        }
    }
}
