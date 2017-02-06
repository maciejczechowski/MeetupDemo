using System;
using MeetupDemo.iOS.ViewControllers;
using MeetupDemo.MobileApp;
using UIKit;
using ReactiveUI;
using Foundation;

namespace MeetupDemo.iOS
{
    public class SearchCitizenViewController : BaseViewController<SearchCitizenViewModel>
    {
        private UISearchBar searchView;
        private UITableView activityList;
        private UITextView errorLabel;

        public SearchCitizenViewController () : base()
        {
        }

        protected override SearchCitizenViewModel CreateViewModel ()
        {
            return new SearchCitizenViewModel ();
        }

        public override void ViewWillAppear (bool animated)
        {
            base.ViewWillAppear (animated);

            this.EdgesForExtendedLayout = UIRectEdge.None;
            this.View.BackgroundColor = UIColor.White;

            this.CreateControls ();
            this.CreateLayout ();
            this.BindThings ();
        }

        private void BindThings()
        {
            this.Bind (this.ViewModel, vm => vm.Pesel, v => v.searchView.Text);

            this.OneWayBind (this.ViewModel, vm => vm.Error, v => v.activityList.Hidden, new Func<string, bool> ((error) => {
                var visibility = error != null;
                System.Diagnostics.Debug.WriteLine ($"Setting Activtiy List visibility to {visibility}");
                return visibility;
            }));
            this.OneWayBind (this.ViewModel, vm => vm.Error, v => v.errorLabel.Hidden, new Func<string, bool> ((error) => {
                var visibility = error == null;
                System.Diagnostics.Debug.WriteLine ($"Setting Error Label visibility to {visibility}");
                return visibility;
            }));
            this.OneWayBind (this.ViewModel, vm => vm.Error, v => v.errorLabel.Text);

        }

        private void CreateControls()
        {
            this.searchView = new UISearchBar () { TranslatesAutoresizingMaskIntoConstraints = false, ShowsCancelButton = true };

            this.activityList = new UITableView () { TranslatesAutoresizingMaskIntoConstraints = false };
            this.activityList.RowHeight = UITableView.AutomaticDimension;
            this.activityList.EstimatedRowHeight = 100;
            this.activityList.RegisterClassForCellReuse (typeof(VisitCell), new NSString("visitCell"));
            this.activityList.Source = new ReactiveTableViewSource<Visit> (this.activityList, this.ViewModel.SearchResult, new NSString("visitCell"), -1, _ => { });

            this.errorLabel = new UITextView () { TranslatesAutoresizingMaskIntoConstraints = false };
        }

        private void CreateLayout()
        {
            // search
            this.View.AddSubview (searchView);

            NSLayoutConstraint searchViewTop = NSLayoutConstraint.Create (this.View, NSLayoutAttribute.Top, NSLayoutRelation.Equal, searchView, NSLayoutAttribute.Top, 1, -20);
            NSLayoutConstraint searchViewLeft = NSLayoutConstraint.Create (this.View, NSLayoutAttribute.Left, NSLayoutRelation.Equal, searchView, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint searchViewRight = NSLayoutConstraint.Create (this.View, NSLayoutAttribute.Right, NSLayoutRelation.Equal, searchView, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint searchViewHeight = NSLayoutConstraint.Create (this.searchView, NSLayoutAttribute.Height, NSLayoutRelation.GreaterThanOrEqual, 1, 34);

            this.View.AddConstraints (new NSLayoutConstraint [] { searchViewTop, searchViewLeft, searchViewRight, searchViewHeight });

            // activity list
            this.View.AddSubview (this.activityList);

            NSLayoutConstraint activityListTop = NSLayoutConstraint.Create (this.searchView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, activityList, NSLayoutAttribute.Top, 1, 0);
            NSLayoutConstraint activityListLeft = NSLayoutConstraint.Create (this.View, NSLayoutAttribute.Left, NSLayoutRelation.Equal, activityList, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint activityListRight = NSLayoutConstraint.Create (this.View, NSLayoutAttribute.Right, NSLayoutRelation.Equal, activityList, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint activityListBottom = NSLayoutConstraint.Create (this.View, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, activityList, NSLayoutAttribute.Bottom, 1, -5);

            this.View.AddConstraints (new NSLayoutConstraint [] { activityListTop, activityListLeft, activityListRight, activityListBottom });

            // error label
            this.View.AddSubview (this.errorLabel);

            NSLayoutConstraint errorLabelTop = NSLayoutConstraint.Create (this.searchView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, errorLabel, NSLayoutAttribute.Top, 1, 0);
            NSLayoutConstraint errorLabelLeft = NSLayoutConstraint.Create (this.View, NSLayoutAttribute.Left, NSLayoutRelation.Equal, errorLabel, NSLayoutAttribute.Left, 1, 0);
            NSLayoutConstraint errorLabelRight = NSLayoutConstraint.Create (this.View, NSLayoutAttribute.Right, NSLayoutRelation.Equal, errorLabel, NSLayoutAttribute.Right, 1, 0);
            NSLayoutConstraint errorLabelHeight = NSLayoutConstraint.Create (this.errorLabel, NSLayoutAttribute.Height, NSLayoutRelation.GreaterThanOrEqual, 1, 34);

            this.View.AddConstraints (new NSLayoutConstraint [] { errorLabelTop, errorLabelLeft, errorLabelRight, errorLabelHeight });
        }
    }
}
