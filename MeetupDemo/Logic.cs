using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetupDemo
{
	public class Logic
	{
		private static List<Visit> visits;
		private List<Visit> Visits
		{
			get
			{
				if (visits == null)
					visits = new List<Visit>();

				return visits;
			}
		}

		public Logic()
		{
		}

		public bool IsPeselValid(string id)
		{
			if (id?.Length != 11)
				return false;

			long aNumber;

			if (!long.TryParse(id, out aNumber))
				return false;

			int checkSum = 0;

			for (int i = 0; i < 10; i++)
			{
				var weight = ((2 * ((i % 4) + 1)) - 1) + (i % 4) - (i % 2);
				checkSum += weight * int.Parse(id[i].ToString());
			}

			if (checkSum % 10 == 0)
				return int.Parse(id[10].ToString()) == 0;

			return (10 - (checkSum % 10)) == int.Parse(id[10].ToString());
		}

		public List<Visit> GetVisitsForPesel(string pesel)
		{
			visits = new List<Visit>
			{
				new Visit { Id = 0, Pesel = pesel, Title = "Visit 0" },
				new Visit { Id = 1, Pesel = pesel, Title = "Visit 1" },
				new Visit { Id = 2, Pesel = pesel, Title = "Visit 2" },
				new Visit { Id = 3, Pesel = pesel, Title = "Visit 3" },
				new Visit { Id = 5, Pesel = pesel, Title = "Visit 5" },
				new Visit { Id = 6, Pesel = pesel, Title = "Visit 6" },
				new Visit { Id = 7, Pesel = pesel, Title = "Visit 7" }
			};

			return visits;
		}

		public Visit GetVisitById(int visitId)
		{
			return visits.First(v => v.Id == visitId);
		}
	}
}
