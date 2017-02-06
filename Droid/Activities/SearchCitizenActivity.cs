using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MeetupDemo.Droid.Activities;
using MeetupDemo.MobileApp;
using ReactiveUI;
using Android.Content;
using System.Diagnostics;

namespace MeetupDemo.Droid
{
    [Activity(Label = "MeetupDemo", Icon = "@mipmap/icon")]
    public class SearchCitizenActivity : ReactiveActivityBase<SearchCitizenViewModel>
	{
        private ListView activityList;
        //private IListAdapter adapter;
        private SearchView searchView;
        private TextView errorLabel;

        private string queryText;
        private string SearchText
        {
            get { return this.queryText; }
            set { this.RaiseAndSetIfChanged (ref this.queryText, value); }
        }

        protected override void CreateViewModel ()
        {
            this.ViewModel = new SearchCitizenViewModel ();
        }

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			this.SetContentView(Resource.Layout.SearchCitizen);

            this.activityList = this.FindViewById<ListView>(Resource.Id.visitList);

            this.WireUpControls ();

            var adapter = new ReactiveListAdapter<Visit>(this.ViewModel.SearchResult, (viewModel, parent) => new VisitListItem(this, viewModel, parent));

            this.activityList.Adapter = adapter;

			var button = FindViewById<Button>(Resource.Id.myButton);
			this.searchView = this.FindViewById<SearchView>(Resource.Id.search);
			this.errorLabel = this.FindViewById<TextView>(Resource.Id.error);

            this.Bind (this.ViewModel, vm => vm.Pesel, v => v.SearchText);
            this.OneWayBind (this.ViewModel, vm => vm.Error, v => v.activityList.Visibility, new Func<string, ViewStates>((error) => {
                var visibility = error == null ? ViewStates.Visible : ViewStates.Gone;
                System.Diagnostics.Debug.WriteLine ($"Setting Activtiy List visibility to {visibility}");
                return visibility;
            }));
            this.OneWayBind (this.ViewModel, vm => vm.Error, v => v.errorLabel.Visibility, new Func<string, ViewStates>((error) => {
                var visibility = error != null ? ViewStates.Visible : ViewStates.Gone;
                System.Diagnostics.Debug.WriteLine ($"Setting Error Label visibility to {visibility}");
                return visibility;
            }));
            this.OneWayBind (this.ViewModel, vm => vm.Error, v => v.errorLabel.Text);

            // from search view to view model only, no need to bind the other way
            this.searchView.QueryTextChange += (sender, e) => { this.SearchText = e.NewText; };
		}
	}

    public class VisitListItem : ReactiveViewHost<Visit>
    {
        public TextView Title { get; set; }
        public TextView Start { get; set; }
        public TextView End { get; set; }
        //public TextView Person { get; set; }
        //public TextView Pesel { get; set; }

        //private Visit visit;
        public VisitListItem (Context c, Visit viewModel, ViewGroup parent) : base(c, Resource.Layout.VisitListItem, parent)
        {
            this.ViewModel = viewModel;

            this.OneWayBind (this.ViewModel, vm => vm.Title, v => v.Title.Text);
            this.OneWayBind (this.ViewModel, vm => vm.StartTime, v => v.Start.Text, d => d.ToString ("g"));
            this.OneWayBind (this.ViewModel, vm => vm.EndTime, v => v.End.Text, d => d.ToString("g"));
            //this.OneWayBind (this.ViewModel, vm => vm.Person, v => v.Person.Text, p => $"{p.Name}, {p.Age}");
            //this.OneWayBind (this.ViewModel, vm => vm.Pesel, v => v.Pesel.Text);

        
        }
    }
}

