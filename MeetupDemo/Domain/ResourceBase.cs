using System;
using ReactiveUI;

namespace MeetupDemo
{
	public abstract class ResourceBase : ReactiveObject
	{
        private int id;
		public int Id {
            get { return this.id; }
            set { this.RaiseAndSetIfChanged (ref this.id, value); }
        }
	}
}
