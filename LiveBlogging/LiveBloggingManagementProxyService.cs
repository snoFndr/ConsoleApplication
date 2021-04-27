using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using GaaTwitterIngestionApi.Business;
using RestSharp;

namespace LiveBlogging
{
	public class LiveBloggingManagementProxyService
	{
		public void GetBlogs()
		{
			using (var httpClient = new HttpClient())
			{
				var baseUrl = "https://liveblogging.gaa-dev.deltatre.digital/api/management/v1/Blogs";
				httpClient.DefaultRequestHeaders.Add("Authorization", "LiveBlogging key=6a2bf452-60e4-47d5-8e2f-87711818ce3f");
				var client = new LiveBloggingManagementApi(baseUrl, httpClient);
				var result = client.Blogs5Async("605491030603af8110fb6ed7");
			}
		}

		public async void GetRestBlog()
		{
			var baseUrl = "https://liveblogging.gaa-dev.deltatre.digital";

			var client = new RestClient(baseUrl);
			var request = new RestRequest("api/management/v1/Blogs", Method.GET);
			request.AddHeader("Authorization", "LiveBlogging key=6a2bf452-60e4-47d5-8e2f-87711818ce3f");

			var response = client.Execute(request);
			var encoding = Encoding.GetEncoding("utf-8");
			var result = encoding.GetString(response.RawBytes);


			Console.WriteLine("");


			//var client = new RestClient(baseUrl);
			var request1 =
				new RestRequest("api/management/v1/Blogs").AddHeader("Authorization", "LiveBlogging key=6a2bf452-60e4-47d5-8e2f-87711818ce3f");
			////.AddParameter("foo", "bar");
			////var response = await client.GetAsync<SearchResponse>(request);
			var response1 = await client.GetAsync<List<Root>>(request1);

			//var dasd = client.Get(request);




			//var client = new RestClient("https://liveblogging.gaa-dev.deltatre.digital/");
			//var request = new RestRequest("api/management/v1/Blogs", Method.GET);
			////var queryResult = client.Execute<List<Items>>(request).Data;
			//var queryResult = client.Execute<string>(request).Data;
		}
	}
}
