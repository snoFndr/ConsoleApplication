// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

using System;
using System.Collections.Generic;

public class Author
{
	public string fullName { get; set; }
}

public class Destinations
{
}

public class PostSharing
{
	public bool enabled { get; set; }
	public Destinations destinations { get; set; }
}

public class Presentation
{
	public bool keyMomentsVisible { get; set; }
	public bool showBlogDefinition { get; set; }
	public string paginationType { get; set; }
	public PostSharing postSharing { get; set; }
}

public class Root
{
	public string id { get; set; }
	public string title { get; set; }
	public string slug { get; set; }
	public string description { get; set; }
	public List<object> tags { get; set; }
	public DateTime dateFrom { get; set; }
	public DateTime dateTo { get; set; }
	public string language { get; set; }
	public DateTime lastUpdateDate { get; set; }
	public Author author { get; set; }
	public string lastContributor { get; set; }
	public string timeZone { get; set; }
	public object coverImage { get; set; }
	public Presentation presentation { get; set; }
}