using Android.App;
using Android.Widget;
using Android.OS;

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

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			var searchView = this.FindViewById<SearchView>(Resource.Id.searchView1);
			searchView.SearchClick += (s, e) => {
				System.Diagnostics.Debug.WriteLine(searchView.Query);
			};

			button.Click += delegate {
				var pesel = searchView.Query;
				if (logic.IsPeselValid(pesel))
				{
					var visits = logic.GetVisitsForPesel(pesel);
					foreach (var visit in visits)
					{
						System.Diagnostics.Debug.WriteLine($"visit: {visit.Title}");
					}
				} else {
					System.Diagnostics.Debug.WriteLine("Pesel is wrong!");
				}
			};
		}
	}
}

