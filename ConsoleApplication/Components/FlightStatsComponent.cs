using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication.Components
{
	public class FlightStatsComponent
	{
		private static string _apiBaseUrl;
		private static string _apiEndPoint;
		private static string _iataCode;
		private static string _apiApplicationId;
		private static string _apiApplicationKey;

		public FlightStatsComponent()
		{
			_apiBaseUrl = @"https://api.flightstats.com/flex/airlines/rest/v1/json/iata/{IATA_CODE}?appId={APP_ID}&appKey={APP_KEY}";
			_apiEndPoint = "/iata";
			_iataCode = "AA";
			_apiApplicationId = "ff6087c2";
			_apiApplicationKey = "fa571a44c8b9f83283f757f7da3c1eef";
		}

		private void TestRegEx()
		{
			var input = "ASD1234";
			Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
			Match result = re.Match(input);

			string alphaPart = result.Groups[1].Value;
			string numberPart = result.Groups[2].Value;
		}
		public void GetListOfAirlines(string iataCode)
		{
			if (!string.IsNullOrEmpty(iataCode)) _iataCode = iataCode;

			var urlToCall = _apiBaseUrl.Replace("{IATA_CODE}", _iataCode).Replace("{APP_ID}", _apiApplicationId).Replace("{APP_KEY}", _apiApplicationKey);
			urlToCall = @"https://api.flightstats.com/flex/schedules/rest/v1/json/flight/EZY/6723/departing/2018/6/13?appId=ff6087c2&appKey=fa571a44c8b9f83283f757f7da3c1eef";
			var request = WebRequest.Create(new Uri(urlToCall)) as HttpWebRequest;

			try
			{
				HttpWebResponse response = null;
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				string stream;
				StreamReader streamReader = null;

				using (response = request.GetResponse() as HttpWebResponse)
				{
					if (response != null)
					{
						var responseStream = response.GetResponseStream();
						if (responseStream != null)
						{
							streamReader = new StreamReader(responseStream, Encoding.UTF8);
							stream = streamReader.ReadToEnd();

						}
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("[FlightStatsComponent] GetListOfAirlines.");
				Console.WriteLine(e);
			}

		}
	}
}
