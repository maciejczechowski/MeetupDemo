using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using MvvmCross.Droid.Views;
using MeetupDemo.MobileApp;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using Android.Views;

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
			var errorLabel = this.FindViewById<TextView>(Resource.Id.error);

			var bindings = this.CreateBindingSet<SearchCitizenActivity, SearchCitizenViewModel>();

			bindings.Bind(list)
			        .For(v => v.ItemsSource)
					.To(vm => vm.SearchResult);

			bindings.Bind(searchView)
			        .To(vm => vm.Pesel);

			bindings.Bind(list)
					.For(v => v.Visibility)
					.To(vm => vm.Error)
					.WithConversion(new InlineConverter<string, ViewStates>((error) => { return error == null ? ViewStates.Visible : ViewStates.Gone; }));

			bindings.Bind(errorLabel)
					.For(v => v.Visibility)
					.To(vm => vm.Error)
			        .WithConversion(new InlineConverter<string, ViewStates>((error) => { return error != null ? ViewStates.Visible : ViewStates.Gone; }));

			bindings.Bind(errorLabel)
					.For(v => v.Text)
					.To(vm => vm.Error);
			
			bindings.Apply();
		}
	}
}

