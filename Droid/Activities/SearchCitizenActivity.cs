using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using MvvmCross.Droid.Views;
using MeetupDemo.MobileApp;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;

namespace MeetupDemo.Droid
{
	[Activity(Label = "MeetupDemo", Icon = "@mipmap/icon")]
	public class SearchCitizenActivity : MvxActivity<SearchCitizenViewModel>
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			this.SetContentView(Resource.Layout.SearchCitizen);

			var list = this.FindViewById<MvxListView>(Resource.Id.visitList);
			var button = FindViewById<Button>(Resource.Id.myButton);
			var searchView = this.FindViewById<SearchView>(Resource.Id.search);

			var bindings = this.CreateBindingSet<SearchCitizenActivity, SearchCitizenViewModel>();

			bindings.Bind(list)
			        .For(v => v.ItemsSource)
					.To(vm => vm.SearchResult);

			bindings.Bind(searchView)
			        .To(vm => vm.Pesel);

			bindings.Apply();

			//button.Click += delegate {
			//	var pesel = searchView.Query;
			//	if (logic.IsPeselValid(pesel))
			//	{
			//		var visits = logic.GetVisitsForPesel(pesel);
			//		list.Adapter = new VisitListAdapter(this, visits.ToArray());
			//	} else {
			//		list.Adapter = new VisitListAdapter(this, new Visit[] { });
			//	}
			//};

			//list.ItemClick += (sender, e) =>
			//{
			//	var intent = new Intent(this, typeof(VisitDetailsActivity));
			//	var visit = ((VisitListAdapter)list.Adapter).Visits[e.Position];
			//	intent.PutExtra("visitId", visit.Id);
			//	this.StartActivity(intent);
			//};
		}
	}
}

