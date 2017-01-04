using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetupDemo
{
	public class Logic
	{
		private static readonly int[] libras = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
		private static List<Visit> visits = CreateVisitList();

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
				checkSum += libras[i] * int.Parse(id[i].ToString());
			}

			return checkSum % 10 == int.Parse(id[10].ToString());
		}

		public List<Visit> GetVisitsForPesel(string id)
		{
			return visits;
		}

		public Visit GetVisitById(int visitId)
		{
			return visits.First(v => v.Id == visitId);
		}

		private static List<Visit> CreateVisitList()
		{
			return new List<Visit>
			{
				new Visit { Id = 0, Pesel = "1234567890", Title = "Visit 1" }
			};
		}
	}
}
