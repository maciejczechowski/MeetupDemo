using System;
using MvvmCross.Core.ViewModels;

namespace MeetupDemo.MobileApp
{
	public class MeetupDemoMobileApp : MvxApplication
	{
		public override void Initialize()
		{
			this.RegisterAppStart(new MeetupDemoAppStart());
		}

		class MeetupDemoAppStart : MvxNavigatingObject, IMvxAppStart
		{
			public void Start(object hint = null)
			{
				this.ShowViewModel<SearchCitizenViewModel>();
			}
		}
	}
}
