using System;
using ReactiveUI;
using System.Reactive.Linq;
using UIKit;
using Foundation;
using CoreGraphics;

namespace MeetupDemo.iOS.ViewControllers
{
    public class VisitCell : ReactiveTableViewCell, IViewFor<Visit>
    {
        private UILabel TitleLabel, StartDateLabel, EndDateLabel;

        private Visit viewModel;
        public Visit ViewModel {
            get { return this.viewModel; }
            set { this.RaiseAndSetIfChanged (ref this.viewModel, value); }
        }

        object IViewFor.ViewModel {
            get { return this.ViewModel; }
            set { this.ViewModel = (Visit)value; }
        }

        public VisitCell () : base()
        {
            this.Setup ();
        }

        public VisitCell (UITableViewCellStyle style, string reuseIdentifier) : base (style, reuseIdentifier)
        {
            this.Setup ();
        }

        protected VisitCell (IntPtr handle) : base (handle)
        {
            this.Setup ();
        }

        public VisitCell (UITableViewCellStyle style, NSString reuseIdentifier) : base (style, reuseIdentifier)
        {
            this.Setup ();
        }

        public VisitCell (NSCoder coder) : base (NSObjectFlag.Empty)
        {
            this.Setup ();
        }

        public VisitCell (NSObjectFlag t) : base (t)
        {
            this.Setup ();
        }

        public VisitCell (CGRect frame) : base (frame)
        {
            this.Setup ();
        }

        private void Setup()
        {
            this.CreateControls ();
            this.CreateLayout ();

            this.WhenAnyValue (dis => dis.ViewModel).Where (vm => vm != null).Subscribe (_ => {
                this.OneWayBind (this.ViewModel, vm => vm.Title, v => v.TitleLabel.Text);
                this.OneWayBind (this.ViewModel, vm => vm.StartTime, v => v.StartDateLabel.Text, new Func<DateTime, string> ((date) => date.ToString ("g")));
                this.OneWayBind (this.ViewModel, vm => vm.EndTime, v => v.EndDateLabel.Text, new Func<DateTime, string> ((date) => date.ToString ("g")));
            });
        }

        private void CreateControls()
        {
            this.TitleLabel = new UILabel () { TranslatesAutoresizingMaskIntoConstraints = false };
            this.StartDateLabel = new UILabel () { TranslatesAutoresizingMaskIntoConstraints = false };
            this.EndDateLabel = new UILabel () { TranslatesAutoresizingMaskIntoConstraints = false };
        }

        private void CreateLayout()
        {
            this.ContentView.AddSubview (this.TitleLabel);
            this.ContentView.AddSubview (this.StartDateLabel);
            this.ContentView.AddSubview (this.EndDateLabel);

            this.ContentView.TranslatesAutoresizingMaskIntoConstraints = false;

            NSLayoutConstraint titleTop = NSLayoutConstraint.Create (this.ContentView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this.TitleLabel, NSLayoutAttribute.Top, 1, -2);
            NSLayoutConstraint titleLeft = NSLayoutConstraint.Create (this.ContentView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this.TitleLabel, NSLayoutAttribute.Left, 1, -10);
            NSLayoutConstraint titleRight = NSLayoutConstraint.Create (this.ContentView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this.TitleLabel, NSLayoutAttribute.Right, 1, 10);
            NSLayoutConstraint titleHeight = NSLayoutConstraint.Create (this.TitleLabel, NSLayoutAttribute.Height, NSLayoutRelation.GreaterThanOrEqual, 1, 25);


            NSLayoutConstraint firstTop = NSLayoutConstraint.Create (this.TitleLabel, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this.StartDateLabel, NSLayoutAttribute.Top, 1, -2);
            NSLayoutConstraint firstLeft = NSLayoutConstraint.Create (this.ContentView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this.StartDateLabel, NSLayoutAttribute.Left, 1, -10);
            NSLayoutConstraint firstRight = NSLayoutConstraint.Create (this.ContentView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this.StartDateLabel, NSLayoutAttribute.Right, 1, 10);
            NSLayoutConstraint firstHeight = NSLayoutConstraint.Create (this.StartDateLabel, NSLayoutAttribute.Height, NSLayoutRelation.GreaterThanOrEqual, 1, 25);

            NSLayoutConstraint secondTop = NSLayoutConstraint.Create (this.StartDateLabel, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this.EndDateLabel, NSLayoutAttribute.Top, 1, -2);
            NSLayoutConstraint secondLft = NSLayoutConstraint.Create (this.ContentView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this.EndDateLabel, NSLayoutAttribute.Left, 1, -10);
            NSLayoutConstraint secondRight = NSLayoutConstraint.Create (this.ContentView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, this.EndDateLabel, NSLayoutAttribute.Right, 1, 10);
            NSLayoutConstraint secondHeight = NSLayoutConstraint.Create (this.EndDateLabel, NSLayoutAttribute.Height, NSLayoutRelation.GreaterThanOrEqual, 1, 25);

            NSLayoutConstraint contentHeight = NSLayoutConstraint.Create (this.ContentView, NSLayoutAttribute.Bottom, NSLayoutRelation.GreaterThanOrEqual, this.EndDateLabel, NSLayoutAttribute.Bottom, 1, 5);

            this.ContentView.AddConstraints (new NSLayoutConstraint [] { titleTop, titleLeft, titleRight, titleHeight, firstTop, firstLeft, firstRight, firstHeight, secondTop, secondLft, secondRight, secondHeight
                , contentHeight
            });
        }
    }
}
