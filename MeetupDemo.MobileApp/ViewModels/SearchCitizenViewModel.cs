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

		private string error;
		public string Error
		{
			get { return this.error; }
			set { this.SetProperty(ref this.error, value); }
		}

		public ReactiveCommand PerformSearch { get; set; }

		public SearchCitizenViewModel()
		{
			this.logic = new Logic();

			this.peselSubscription = this.WhenAnyValue(t => t.Pesel).Subscribe(p => {
				var peselVerification = this.logic.IsPeselValid(p);
				if (peselVerification == PeselVerificationResult.Valid)
				{
					this.SearchResult = this.logic.GetVisitsForPesel(p);
					this.Error = null;
				}
				else if (peselVerification == PeselVerificationResult.WrongLength)
					this.Error = "Pesel is to shor or too long. Should be 11 digits long. No less, no more.";
				else
				{
					this.SearchResult = this.emptyList;
					this.Error = "Pesel is not a valid pesel.";
				}
			});

		}
	}
}
