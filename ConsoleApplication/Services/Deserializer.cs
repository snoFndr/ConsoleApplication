using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;

namespace ConsoleApplication.Services
{
	public class Deserializer
	{
		public void Startdeserialize()
		{
			var json1 = "{ \"LanguageEntities\": [ { \"1\": \"en\" }, { \"2\" : \"de\" } ] }";
			var obj = JsonConvert.DeserializeObject<SomeData>(json1);

			var json2 = "{ LangMapping: [ { LiveBlogId: 1, UefaCode: 'en' }, { LiveBlogId: 2, 'UefaCode':'de' } ] }";
			var obj2 = JsonConvert.DeserializeObject<SomeData2>(json2);

			var json3 = ConfigurationManager.AppSettings["htmlToEncodeList"];
			var htmlObj = JsonConvert.DeserializeObject<HtmlObjectNeedeToReplace>(json3);

			var json4 = @"{""request"":{""carrier"":{""requestedCode"":""EZY"",""fsCode"":""U2""},""codeType"":{},""flightNumber"":{""requested"":""6723"",""interpreted"":""6723""},""departing"":true,""date"":{""year"":""2018"",""month"":""6"",""day"":""13"",""interpreted"":""2018-06-13""},""url"":""https://api.flightstats.com/flex/schedules/rest/v1/json/flight/EZY/6723/departing/2018/6/13""},""scheduledFlights"":[{""carrierFsCode"":""U2"",""flightNumber"":""6723"",""departureAirportFsCode"":""BFS"",""arrivalAirportFsCode"":""CDG"",""stops"":0,""departureTime"":""2018-06-13T14:00:00.000"",""arrivalTime"":""2018-06-13T16:45:00.000"",""flightEquipmentIataCode"":""319"",""isCodeshare"":false,""isWetlease"":false,""serviceType"":""J"",""serviceClasses"":[""Y""],""trafficRestrictions"":[""B""],""codeshares"":[],""referenceCode"":""519-529624--""}],""appendix"":{""airlines"":[{""fs"":""U2"",""iata"":""U2"",""icao"":""EZY"",""name"":""easyJet"",""phoneNumber"":""+08 71 244 2366"",""active"":true}],""airports"":[{""fs"":""CDG"",""iata"":""CDG"",""icao"":""LFPG"",""name"":""Charles de Gaulle Airport"",""street1"":""95711, Roissy Charles de Gaulle"",""city"":""Paris"",""cityCode"":""PAR"",""countryCode"":""FR"",""countryName"":""France"",""regionName"":""Europe"",""timeZoneRegionName"":""Europe/Paris"",""localTime"":""2018-06-13T10:22:23.814"",""utcOffsetHours"":2.0,""latitude"":49.003196,""longitude"":2.567023,""elevationFeet"":387,""classification"":1,""active"":true},{""fs"":""BFS"",""iata"":""BFS"",""icao"":""EGAA"",""name"":""Belfast International Airport"",""city"":""Belfast"",""cityCode"":""BFS"",""stateCode"":""NI"",""countryCode"":""GB"",""countryName"":""United Kingdom"",""regionName"":""Europe"",""timeZoneRegionName"":""Europe/London"",""localTime"":""2018-06-13T09:22:23.814"",""utcOffsetHours"":1.0,""latitude"":54.662397,""longitude"":-6.217616,""elevationFeet"":267,""classification"":3,""active"":true}],""equipments"":[{""iata"":""319"",""name"":""Airbus A319"",""turboProp"":false,""jet"":true,""widebody"":false,""regional"":false}]}}";
		}

		//public class 
		public class SomeData
		{
			public IEnumerable<IDictionary<string, string>> LanguageEntities { get; set; }
		}

		public class SomeData2
		{
			public IEnumerable<LangMapping> LangMapping { get; set; }
		}

		public class LangMapping
		{
			public int LiveBlogId { get; set; }
			public string UefaCode { get; set; }
		}

		public class HtmlObjectNeedeToReplace
		{
			public IEnumerable<HtmlToEncodeList> HtmlToEncodeList { get; set; }
		}

		public class HtmlToEncodeList
		{
			public string HtmlTag { get; set; }
			public string HtmlEncode { get; set; }
		}
	}
}
