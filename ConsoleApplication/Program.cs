using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using ConsoleApplication.Components;
using ConsoleApplication.Services;
using Newtonsoft.Json;
using Tweetinvi;
using Tweetinvi.Parameters;

namespace ConsoleApplication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Change to your number of menuitems.
			const int maxMenuItems = 99;
			var selector = 0;

			while (selector != maxMenuItems)
			{
				Console.Clear();
				DrawTitle();
				DrawMenu(maxMenuItems);
				var good = int.TryParse(Console.ReadLine(), out selector);
				if (good)
				{
					switch (selector)
					{
						case 1:
							CheckFileInUse();
							break;
						case 2:
							Fibonacci();
							break;
						case 3:
							GetMatchEvents();
							break;
						case 4:
							GetEvent();
							break;
						case 5:
							TestDeserializer();
							break;
						case 6:
							ArticlePreview();
							break;
						case 7:
							TwitterManage();
							break;
						case 8:
							FromStringToGuid();
							break;
						case 9:
							TrySqlDataReader();
							break;
						case 10:
							FromXmlDocumentToFile();
							break;
						case 11:
							RaedAspxFileIntoXdocument();
							break;
						case 12:
							Blacklist();
							break;
						case 13:
							DatetimeInIso8601();
							break;
						case 14:
							ObjectToReplace();
							break;
						case 15:
							GetListOfAirlines();
							break;
						case 99:
							Environment.Exit(0);
							break;
						// possibly more cases here
						default:
							if (selector != maxMenuItems)
							{
								ErrorMessage();
							}
							break;
					}
				}
				else
				{
					ErrorMessage();
				}
				Console.ReadKey();
			}
		}

		#region "Draw menu"

		private static void ErrorMessage()
		{
			Console.WriteLine("Typing error, press key to continue.");
		}

		private static void DrawStarLine()
		{
			Console.WriteLine("************************************************************************");
		}

		private static void DrawTitle()
		{
			DrawStarLine();
			Console.WriteLine("+++                CONSOLE APPLICATION USED TO TEST                  +++");
			DrawStarLine();
		}

		private static void DrawMenu(int maxitems)
		{
			DrawStarLine();
			Console.WriteLine(" 1. CheckFileInUse: Check if a file is in use from another process.");
			Console.WriteLine(" 2. Fibonacci test.");
			Console.WriteLine(" 3. Get Match Events - prepare DataSource for LiveBlogging.");
			Console.WriteLine(" 4. Get Events - prepare DataSource for LiveBlogging.");
			Console.WriteLine(" 5. Newtonsoft.Json Deserializer.");
			Console.WriteLine(" 6. Article Preview - FIFA Museum.");
			Console.WriteLine(" 7. Try Twitter APIs.");
			Console.WriteLine(" 8. From String To GUID.");
			Console.WriteLine(" 9. Test SqlDataReader.");
			Console.WriteLine(" 10. From XmlDocument To File.");
			Console.WriteLine(" 11. Raed Aspx File Into Xdocument.");
			Console.WriteLine(" 12. Blacklist.");
			Console.WriteLine(" 13. Datetime in ISO8601 format.");
			Console.WriteLine(" 14. Object to replace.");
			Console.WriteLine(" 15. FlightStats APIs.");
			Console.WriteLine(" ");
			// more here
			Console.WriteLine(" 99. Exit program");
			DrawStarLine();
			Console.WriteLine("Make your choice: type 1, 2,... or {0} for exit", maxitems);
			DrawStarLine();
		}

		#endregion

		private static void TrySqlDataReader()
		{
			//try
			//{
			//	var conn = new SqlConnection(@"server=DB05\BE;database=EBO;Connection Timeout=200;uid=d3cmsadm;pwd=d3cmsadm");
			//	using (var comm = new SqlCommand("wNews_RequestBitlyGet", conn))
			//	{
			//		conn.Open();
			//		comm.CommandType = CommandType.StoredProcedure;
			//		using (SqlDataReader dr = comm.ExecuteReader())
			//		{
			//			while (dr.Read())
			//			{
			//				var reqId = int.Parse(dr["Id"].ToString());
			//				var wNewsId = int.Parse(dr["wNewsId"].ToString());
			//				//string wNewsUrl = retrieveFullUrl(dr["Url"].ToString(), int.Parse(dr["SiteId"].ToString()), dr["Lang"].ToString());
			//				var wNewsLang = dr["Lang"].ToString();
			//				var siteId = int.Parse(dr["SiteId"].ToString());
			//				//string shortUrl = shortUrlGet(wNewsUrl);
			//				//if (!shortUrl.Equals(String.Empty))
			//				//{
			//				//	if (urlDataSet(wNewsId, wNewsLang, shortUrl))
			//				//		requestStatusSet(reqId, 1);
			//				//	else
			//				//		// Saving data error case
			//				//		requestStatusSet(reqId, 2);
			//				//}
			//				//System.Threading.Thread.Sleep(3000);
			//			}
			//		}
			//		conn.Close();
			//	}
			//}
			//catch (Exception exception)
			//{
			//	Console.WriteLine(exception.Message);
			//}

		}

		#region "Check if a file is in use from another process"

		public static void CheckFileInUse()
		{
			string fileUrl = @"C:\D3 Forge\_MyApp\ConsoleApplicationTest\Doc.xml";
			try
			{
				XmlTextReader xmlRead = new XmlTextReader(fileUrl);
				xmlRead.Read();

				XmlDocument doc = new XmlDocument();
				XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
				doc.AppendChild(docNode);

				doc.AppendChild(docNode);
				XmlNode root = doc.CreateElement("root");
				// /////////////  root timestamp  //////////////////////////
				XmlAttribute timestampAttribute = doc.CreateAttribute("timestamp");
				timestampAttribute.Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
				root.Attributes.Append(timestampAttribute);
				doc.AppendChild(root);

				if (!FileInUse(fileUrl))
				{
					doc.Save(fileUrl);
				}

			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
			}
			finally
			{
				Console.Write("... End");
			}
		}

		public static bool FileInUse(string file)
		{
			try
			{
				if (!System.IO.File.Exists(file)) // The path might also be invalid.
				{
					return false;
				}

				using (var stream = new System.IO.FileStream(file, System.IO.FileMode.Open))
				{
					return false;
				}
			}
			catch
			{
				return true;
			}
		}

		#endregion

		#region "Try Fibonacci in C#"

		public static void Fibonacci()
		{
			for (Byte n = 0; n < 21; n++)
			{
				Console.WriteLine("F({0}) = {1}", n, Fib(n));
			}
			Console.ReadKey();
		}

		/// <summary>
		/// Calculates the Nth(starting from zero) Fibonacci number
		/// no overflow error checking
		/// </summary>
		/// <param name="n">n can range from 0 to 93</param>
		/// <returns>F(n)</returns>
		public static UInt64 Fib(Byte n)
		{
			double sqrt5 = Math.Sqrt(5);
			double phi = (sqrt5 + 1) / 2;
			return Convert.ToUInt64((1 / sqrt5) * Math.Pow(phi, n));
		}

		#endregion

		public static void GetListOfAirlines()
		{
			var getAirlines = new FlightStatsComponent();
			getAirlines.GetListOfAirlines("EZY%206723");
		}

		public static void GetMatchEvents()
		{
			var matchEvent = new DaasComponent();
			matchEvent.GetMatchEvent();
		}

		public static void GetEvent()
		{
			var matchEvent = new DaasComponent();
			matchEvent.GetEvent();
		}

		public static void TestDeserializer()
		{
			var test = new Deserializer();
			test.Startdeserialize();
		}

		public static void ArticlePreview()
		{
			var postArticle = new ArticlePreviewComponent();
			postArticle.PostArticle();
		}

		public static void TwitterManage()
		{
			var consumerKey = "GHuMdw7zVKK71501RP26az43u";
			var consumerSecret = "cBvcdrNJdC0hHUF9rXpFgSwd9GFZpCciPw5i7T4hDtWpFeLFiX";
			var accessToken = "163515256-JYrwCz6T5mpk07S5NOBUlj2bbpDeUQImcrpZnBBy";
			var accessTokenSecret = "bvpTKiGeloCPOjSidp8psI6MlsOlmbGa86Tnrjt9OBinu";

			var userCredential = Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);

			//var matchingTweets = Search.SearchTweets("#espcze");

			var searchParameters = new SearchTweetsParameters("The Tweet Of God")
			{
				MaximumNumberOfResults = 50,
				TweetSearchType = TweetSearchType.OriginalTweetsOnly
			};

			var tweets = Search.SearchTweets(searchParameters);

			Console.WriteLine(" ");
			foreach (var tweet in tweets)
			{
				Console.WriteLine($"Text: {tweet.FullText}");
				Console.WriteLine($"Url: {tweet.Url}");
				Console.WriteLine($"CreatedAt: {tweet.CreatedAt}");
				Console.WriteLine($"CreatedBy: {tweet.CreatedBy}");
				Console.WriteLine(" ");
			}

			Console.Write("Twitter!");
		}

		public static void FromStringToGuid()
		{
			var newsletter =
				"Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat @@@useremail@@@. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur @@@user_uid@@@. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

			var result = new StringBuilder(newsletter);

			var email = "andrea.fonsati@gmail.com";

			if (email != null)
			{
				var guid = Guid.NewGuid();
				result = result.Replace("@@@useremail@@@", email).Replace("@@@user_uid@@@", guid.ToString());
			}

			Console.WriteLine(result);
		}

		private static void FromXmlDocumentToFile()
		{
			Console.WriteLine(Environment.CurrentDirectory);

			try
			{
				var filePath = Path.Combine(Environment.CurrentDirectory, "index.xml");
				var xmlDoc = new XmlDocument();
				xmlDoc.Load(filePath);

				var readXml = xmlDoc.InnerXml;

				using (var outputWriter = new StreamWriter(filePath))
				{
					outputWriter.Write(readXml);
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);
			}
		}

		private static void RaedAspxFileIntoXdocument()
		{
			var filePath = @"C:\FAME2\Project04\EBS\WebApp\PageMapping\PM\DOC\BO\Tree\Browse.aspx";

			var fileContent = File.ReadAllText(filePath);

			int startIndex = -1;
			startIndex = fileContent.IndexOf("xnetUI:PageParamsContainer");

			fileContent = fileContent.Substring(startIndex);

			startIndex = fileContent.IndexOf("ModuleId=\"");
			string appFunctionNames;
			if (-1 == startIndex)
			{
				appFunctionNames = string.Empty;
			}
			else
			{
				appFunctionNames = fileContent.Substring(startIndex + "ModuleId=\"".Length);
				appFunctionNames = appFunctionNames.Remove(appFunctionNames.IndexOf("\""));
			}
		}

		private static void Blacklist()
		{
			bool isBlacklist;
			var link = @"http://uefa.develop.fame.uefa.deltatre.it/EBS/Reserved.ReportViewerWebControl.axd?OpType=Resource&Version=9.0.30729.1&Name=Microsoft.Reporting.WebForms.Scripts.ReportViewer.js&_cb_=20170623102639";
			var blacklistsParam = ".ascx?|.axd?";
			var blacklists = blacklistsParam.Split(Convert.ToChar("|"));

			foreach (var blacklist in blacklists)
			{
				if (link.ToLower().Contains(blacklist))
				{
					isBlacklist = true;
				}
			}
			// return isBlacklist
		}

		private static void DatetimeInIso8601()
		{
			var dateTime = DateTime.UtcNow.ToString("s");
			//dateTime = DateTime.UtcNow.ToString("O");
		}

		private static void ObjectToReplace()
		{
			var strReplace = "D\'Hooge -- pippoforza";
			var json3 = ConfigurationManager.AppSettings["htmlToEncodeList"];
			var htmlObj = JsonConvert.DeserializeObject<Deserializer.HtmlObjectNeedeToReplace>(json3);
			//var result = htmlObj.HtmlToEncodeList.ForEach(a=>{strToReplace.Replace(a.HtmlTag, a.HtmlEncode)});

			var strToReplace = htmlObj.HtmlToEncodeList.Aggregate(strReplace, (current, html) => current.Replace(html.HtmlTag, html.HtmlEncode));

			Console.WriteLine(strToReplace);
		}

	}
}
