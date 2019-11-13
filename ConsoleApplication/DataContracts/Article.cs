using System;

namespace ConsoleApplication.DataContracts
{
	public class Article
	{
		public int ID { get; set; }
		public string	RooflineText { get; set; }
		public string	Title { get; set; }
		public DateTime	Date { get; set; }
		public string	Author { get; set; }
		public string	Summary { get; set; }
		public string	Body { get; set; }

	}
}
