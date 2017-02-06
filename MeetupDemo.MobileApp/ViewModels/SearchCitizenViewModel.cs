using System;
using System.Collections.Generic;
using MeetupDemo.MobileApp.ViewModels;
using ReactiveUI;

namespace MeetupDemo.MobileApp
{
    public class SearchCitizenViewModel : ViewModelBase
	{
		private Logic logic;
		private List<Visit> emptyList = new List<Visit>();

		private IDisposable peselSubscription;

        private ReactiveList<Visit> searchResult = new ReactiveList<Visit>();
		public ReactiveList<Visit> SearchResult
		{
			get { return this.searchResult; }
            //set { this.RaiseAndSetIfChanged(ref this.searchResult, value); }
		}

		private string pesel;
		public string Pesel
		{
			get { return this.pesel; }
            set { this.RaiseAndSetIfChanged(ref this.pesel, value); }
		}

		private string error;
		public string Error
		{
			get { return this.error; }
            set { this.RaiseAndSetIfChanged(ref this.error, value); }
		}

        public override string UrlPathSegment => "SearchCitizen";

		public ReactiveCommand PerformSearch { get; set; }

		public SearchCitizenViewModel()
		{
			this.logic = new Logic();

			this.peselSubscription = this.WhenAnyValue(t => t.Pesel).Subscribe(p => {
				var peselVerification = this.logic.IsPeselValid(p);
                if (peselVerification == PeselVerificationResult.Valid) {
                    this.searchResult.ChangeTrackingEnabled = false;
                    this.searchResult.Clear ();
                    this.searchResult.AddRange (this.logic.GetVisitsForPesel (p));
                    this.searchResult.ChangeTrackingEnabled = true;
                    this.Error = null;
                } else if (peselVerification == PeselVerificationResult.WrongLength) {
                    this.searchResult.Clear ();  
                    this.Error = "Pesel is to shor or too long. Should be 11 digits long. No less, no more.";
                } else {
                    this.searchResult.Clear();// = this.emptyList;
					this.Error = "Pesel is not a valid pesel.";
				}
			});

		}
	}
}
