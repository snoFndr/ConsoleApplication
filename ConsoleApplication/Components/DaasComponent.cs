using System;
using System.IO;
using System.Net;
using System.Text;
using ConsoleApplication.DataContracts;
using ConsometaleApplication.DataContracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ConsoleApplication.Components
{
	public class DaasComponent
	{
		private static string _daasEndPoint;
		private static string _daasGetMatchEvents;
		private static string _daasGetEvent;
		private static string _matchId;
		private static string _eventId;

		public DaasComponent()
		{
			_daasEndPoint = "http://daas.stg.euro2016.infra.uefa.com/";
			_daasGetMatchEvents = "api/v2/matchevent/en/matches/{matchId}/events";
			_daasGetEvent = "api/v2/matchevent/en/matches/events/{eventId}";
			_matchId = "2017169";
			_eventId = "9be4ad948f75448c975c5b17fff0bbc8";

			_daasGetMatchEvents = _daasGetMatchEvents.Replace("{matchId}", _matchId);
			_daasGetMatchEvents = string.Concat(_daasEndPoint, _daasGetMatchEvents);

			_daasGetEvent = _daasGetEvent.Replace("{eventId}", _eventId);
			_daasGetEvent = string.Concat(_daasEndPoint, _daasGetEvent);
		}

		public string GetMatchEvent()
		{
			var result = string.Empty;

			var request = WebRequest.Create(new Uri(_daasGetMatchEvents)) as HttpWebRequest;

			if (request != null)
			{
				request.Headers.Add("Authorization", "SportDataLayer key=D05BD07B-8B07-414E-AF74-CF30B9926BE6");
				request.Method = "GET";
				request.ContentType = "application/json";
			}

			try
			{
				HttpWebResponse response = null;
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

							var jsonSerializerSettings = new JsonSerializerSettings
							{
								ContractResolver = new CamelCasePropertyNamesContractResolver()
							};
							var matchEventItems = JsonConvert.DeserializeObject<MatchEventListData>(stream);
							stream = JsonConvert.SerializeObject(matchEventItems, jsonSerializerSettings);

							result = stream;
						}
					}
				}
			}
			catch (Exception exception)
			{
				result = exception.ToString();
			}


			return result;
		}

		public string GetEvent()
		{
			var result = string.Empty;

			var request = WebRequest.Create(new Uri(_daasGetEvent)) as HttpWebRequest;

			if (request != null)
			{
				request.Headers.Add("Authorization", "SportDataLayer key=D05BD07B-8B07-414E-AF74-CF30B9926BE6");
				request.Method = "GET";
				request.ContentType = "application/json";
			}

			try
			{
				HttpWebResponse response = null;
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

							var jsonSerializerSettings = new JsonSerializerSettings
							{
								ContractResolver = new CamelCasePropertyNamesContractResolver()
							};
							var item = JsonConvert.DeserializeObject<MatchEventData>(stream);
							stream = JsonConvert.SerializeObject(item, jsonSerializerSettings);

							result = stream;
						}
					}
				}
			}
			catch (Exception exception)
			{
				result = exception.ToString();
			}


			return result;
		}
	}
}
