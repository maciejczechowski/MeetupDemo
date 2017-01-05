using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MeetupDemo.Droid
{
	[Activity(Label = "MeetupDemo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private Logic logic;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			this.logic = new Logic();

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			var list = this.FindViewById<ListView>(Resource.Id.visitList);
			var button = FindViewById<Button>(Resource.Id.myButton);
			var searchView = this.FindViewById<SearchView>(Resource.Id.search);

			button.Click += delegate {
				var pesel = searchView.Query;
				if (logic.IsPeselValid(pesel))
				{
					var visits = logic.GetVisitsForPesel(pesel);
					list.Adapter = new VisitListAdapter(this, visits.ToArray());
				} else {
					list.Adapter = new VisitListAdapter(this, new Visit[] { });
				}
			};

			list.ItemClick += (sender, e) =>
			{
				var intent = new Intent(this, typeof(VisitDetailsActivity));
				var visit = ((VisitListAdapter)list.Adapter).Visits[e.Position];
				intent.PutExtra("visitId", visit.Id);
				this.StartActivity(intent);
			};
		}
	}
}

