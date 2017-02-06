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

		public PeselVerificationResult IsPeselValid(string id)
		{
			if (id?.Length != 11)
				return PeselVerificationResult.WrongLength;

			long aNumber;

			if (!long.TryParse(id, out aNumber))
				return PeselVerificationResult.Invalid;

			int checkSum = 0;

			for (int i = 0; i < 10; i++)
			{
				var weight = ((2 * ((i % 4) + 1)) - 1) + (i % 4) - (i % 2);
				checkSum += weight * int.Parse(id[i].ToString());
			}

			if (checkSum % 10 == 0)
				return int.Parse(id[10].ToString()) == 0 ? PeselVerificationResult.Valid : PeselVerificationResult.Invalid;

			return (10 - (checkSum % 10)) == int.Parse(id[10].ToString()) ? PeselVerificationResult.Valid : PeselVerificationResult.Invalid;
		}

		public List<Visit> GetVisitsForPesel(string pesel)
		{
			visits = new List<Visit>
			{
                new Visit { Id = 0, Pesel = pesel, Title = "Visit 0", StartTime = DateTime.Now, EndTime = DateTime.Now.AddMinutes(15) },
                new Visit { Id = 1, Pesel = pesel, Title = "Visit 1", StartTime = DateTime.Now.AddMinutes(15 * 1), EndTime = DateTime.Now.AddMinutes(15 * 2) },
                new Visit { Id = 2, Pesel = pesel, Title = "Visit 2", StartTime = DateTime.Now.AddMinutes(15 * 2), EndTime = DateTime.Now.AddMinutes(15 * 3) },
                new Visit { Id = 3, Pesel = pesel, Title = "Visit 3", StartTime = DateTime.Now.AddMinutes(15 * 3), EndTime = DateTime.Now.AddMinutes(15 * 4) },
                new Visit { Id = 5, Pesel = pesel, Title = "Visit 5", StartTime = DateTime.Now.AddMinutes(15 * 4), EndTime = DateTime.Now.AddMinutes(15 * 5) },
                new Visit { Id = 6, Pesel = pesel, Title = "Visit 6", StartTime = DateTime.Now.AddMinutes(15 * 5), EndTime = DateTime.Now.AddMinutes(15 * 6) },
                new Visit { Id = 7, Pesel = pesel, Title = "Visit 7", StartTime = DateTime.Now.AddMinutes(15 * 6), EndTime = DateTime.Now.AddMinutes(15 * 7) }
			};

			return visits;
		}

		public Visit GetVisitById(int visitId)
		{
			return visits.First(v => v.Id == visitId);
		}
	}
}
