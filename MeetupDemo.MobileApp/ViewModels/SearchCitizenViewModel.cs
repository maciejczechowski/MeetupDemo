using System;
using System.Collections.Generic;
using System.Reactive;
using MvvmCross.Core.ViewModels;
using ReactiveUI;

namespace MeetupDemo.MobileApp
{
	public class SearchCitizenViewModel : MvxViewModel
	{
		private Logic logic;
		private List<Visit> emptyList = new List<Visit>();

		private IDisposable peselSubscription;

		private List<Visit> searchResult;
		public List<Visit> SearchResult
		{
			get { return this.searchResult; }
			set { this.SetProperty(ref this.searchResult, value); }
		}

		private string pesel;
		public string Pesel
		{
			get { return this.pesel; }
			set { this.SetProperty(ref this.pesel, value); }
		}

		public ReactiveCommand PerformSearch { get; set; }

		public SearchCitizenViewModel()
		{
			this.logic = new Logic();

			this.peselSubscription = this.WhenAnyValue(t => t.Pesel).Subscribe(p => {
				if (this.logic.IsPeselValid(p))
					this.SearchResult = this.logic.GetVisitsForPesel(p);
				else
					this.SearchResult = this.emptyList;
			});

		}
	}
}
