using System;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace MeetupDemo.Droid
{
	public class VisitListAdapter : ArrayAdapter<Visit>
	{
		public Visit[] Visits { get; private set; }

		public VisitListAdapter(Context context, Visit[] visits) : base(context, -1, visits)
		{
			this.Visits = visits;
		}

		public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			LayoutInflater inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);
			View rowView = inflater.Inflate(Resource.Layout.visitListItem, parent, false);
			var title = rowView.FindViewById<TextView>(Resource.Id.title);
			var startTime = rowView.FindViewById<TextView>(Resource.Id.start);
			var endTime = rowView.FindViewById<TextView>(Resource.Id.start);

			var visit = Visits[position];

			title.Text = visit.Title;
			startTime.Text = visit.StartTime.ToString("g");
			endTime.Text = visit.EndTime.ToString("g");

			return rowView;
		}
	}
}
