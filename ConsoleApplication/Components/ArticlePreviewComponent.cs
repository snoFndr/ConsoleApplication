using System;
using System.IO;
using System.Net;
using System.Text;
using ConsoleApplication.DataContracts;
using Newtonsoft.Json;

namespace ConsoleApplication.Components
{
	public class ArticlePreviewComponent
	{
		private static string _articleEndPoint;
		private static string _articleEndPointUser;
		private static string _articleEndPointPassword;

		public ArticlePreviewComponent()
		{
			_articleEndPoint = "http://en.static.dev.museum.fifa.deltatre.net/preview/article";
			_articleEndPointUser = "FifaMus.User";
			_articleEndPointPassword = "Pwd!F1F4";
		}

		public void PostArticle()
		{
			var article = GetForgeArticle();
			var jsonData = JsonConvert.SerializeObject(article);
			var http = (HttpWebRequest)WebRequest.Create(new Uri(_articleEndPoint));

			http.Accept = "application/json";
			http.ContentType = "application/json";
			http.Method = "POST";
			http.Credentials = new NetworkCredential
			{
				UserName = _articleEndPointUser,
				Password = _articleEndPointPassword
			};

			//string parsedContent = << PUT HERE YOUR JSON PARSED CONTENT >>;
			ASCIIEncoding encoding = new ASCIIEncoding();
			Byte[] bytes = encoding.GetBytes(jsonData);

			Stream newStream = http.GetRequestStream();
			newStream.Write(bytes, 0, bytes.Length);
			newStream.Close();

			var response = http.GetResponse();

			var stream = response.GetResponseStream();
			var sr = new StreamReader(stream);
			var content = sr.ReadToEnd();
		}

		public void PostArticle_01()
		{
			var article = GetForgeArticle();
			var jsonData = JsonConvert.SerializeObject(article);

			try
			{
				using (var client = new WebClient())
				{
					client.Headers[HttpRequestHeader.ContentType] = "application/json";

					if (!string.IsNullOrEmpty(_articleEndPointUser) || !string.IsNullOrEmpty(_articleEndPointPassword))
					{
						client.Credentials = new NetworkCredential
						{
							UserName = _articleEndPointUser,
							Password = _articleEndPointPassword
						};
					}

					var result = client.UploadString(_articleEndPoint, "POST", jsonData);
				}

			}
			catch (Exception exception)
			{
				Console.Write(exception.ToString());
			}
		}

		private Article GetForgeArticle()
		{
			return new Article
			{
				ID = 2609838,
				RooflineText = "",
				Title = "Wanda Group",
				Date = DateTime.UtcNow,
				Author = "Andrea Fonsati",
				Summary = "Wanda Group was founded in 1988 and is engaged in three key business activities - commercial properties, culture, and finance. Wanda Commercial Properties is the world's largest real estate enterprise and the biggest five-star hotel owner in the world. Wanda Cultural Industry Group, meanwhile, is the largest cultural enterprise in China, and the world's largest cinema operator. The conglomerate is led by Wang Jianlin, who has served as Chairman of the Wanda Group since 1989.",
				Body = "<a href='[LINK]' title='Wandagroup' target='_blank'><img width='160px' height='32px' alt='Wandagroup' class='sponsorMedium' src='http://img.fifamuseum.com/img/logo/partners/wandagroup.jpg' /></a><br /><br />Wanda Group was founded in 1988 and is engaged in three key business activities - commercial properties, culture, and finance. Wanda Commercial Properties is the world's largest real estate enterprise and the biggest five-star hotel owner in the world. Wanda Cultural Industry Group, meanwhile, is the largest cultural enterprise in China, and the world's largest cinema operator. The conglomerate is led by Wang Jianlin, who has served as Chairman of the Wanda Group since 1989.<br /><br />A long-standing heritage in the sport sector<br /><br />Wanda has a long-standing heritage in the sport sector. Having played a first-hand role in the transformation of Chinese football in 1993, including the establishment of Dalian Wanda F.C., the nation's number one professional football club, the Group has had a long affiliation with football. Wanda has also shown a constant support to the development of football in China, with a special focus on the growth of grassroots football through China&rsquo;s Future Star Program.<br /><br />Teaming up for the next successful football chapter<br /><br />By supporting FIFA until 2030, the Wanda Group showcases its commitment to the sustainable growth of the sport and to a lasting partnership. Complementing FIFA, the aim is clear: team up for the next chapter of success in football.<br /><br />By using its international appeal, the Wanda Group aims to bring youth from all around the world closer to the game. Through a series of unique &ldquo;as close as it gets&rdquo; initiatives across all FIFA competitions &ndash; both online and on-site &ndash; a few lucky fans will get the once in a lifetime opportunity to see the action unfold right in front of them.<br /><br />A central element will be the &ldquo;FIFA Flag Bearers&rdquo; programme, where a selection of children will get the chance to carry the FIFA Flag at the start of a FIFA match. Additionally, further experiential &ldquo;money can&rsquo;t buy&rdquo; opportunities will be carried out, such as the team training view and the post-match team bench visit.<br /><br />In addition to the global exposure and benefits this partnership delivers, the Wanda Group will benefit from the promotion of FIFA Competitions across Wanda properties, which will be implemented through various activation tools such as the awarding of FIFA World Cup&trade; tickets, the use of the Official FIFA mascot and the implementation of a FIFA youth development program in China."
			};
		}
	}
}
