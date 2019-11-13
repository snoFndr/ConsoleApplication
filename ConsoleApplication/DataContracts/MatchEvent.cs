using System;

namespace ConsoleApplication.DataContracts
{
	public class MatchEvent
	{
		// ReSharper disable once InconsistentNaming
		/// <summary>
		/// Event GUID
		/// </summary>
		public string EventGUID { get; set; }

		/// <summary>
		/// Event minute
		/// </summary>
		public int Minute { get; set; }

		/// <summary>
		/// Event second
		/// </summary>
		public int Second { get; set; }

		/// <summary>
		/// Event name
		/// </summary>
		public string Event { get; set; }

		/// <summary>
		/// Event sub kind name
		/// </summary>
		public string Kind { get; set; }

		/// <summary>
		/// Web name of the Team
		/// </summary>
		public string TeamWebName { get; set; }

		/// <summary>
		/// Web name of the Player
		/// </summary>
		public string PlayerWebName { get; set; }

		/// <summary>
		/// Web name of the TeamTo (TeamTo is different from Team)
		/// </summary>
		public string TeamToWebName { get; set; }

		/// <summary>
		/// Web name of the PlayerTo (PlayerTo  is different from Player)
		/// </summary>
		public string PlayerToWebName { get; set; }

		/// <summary>
		/// Local event date and time
		/// </summary>
		public DateTime EventDateLocal { get; set; }

		// ReSharper disable once InconsistentNaming
		/// <summary>
		/// CET event date and time
		/// </summary>
		public DateTime EventDateCET { get; set; }
	}
}
