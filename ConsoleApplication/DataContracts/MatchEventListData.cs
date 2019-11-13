using System.Collections.Generic;
using ConsoleApplication.DataContracts;

namespace ConsometaleApplication.DataContracts
{
	public class MatchEventListData
	{
		public IEnumerable<MatchEvent> MatchEventItems { get; set; }
		public MetaData Meta { get; set; }

	}
}
