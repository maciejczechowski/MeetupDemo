using System;
namespace MeetupDemo
{
	public class Visit : ResourceBase
	{
		public string Pesel { get; set; }
		public string Title { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public Person Person { get; set; }

		public Visit()
		{
		}
	}
}
