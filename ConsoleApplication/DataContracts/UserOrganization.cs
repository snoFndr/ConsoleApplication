using System;

namespace ConsoleApplication.DataContracts
{
	public class UserOrganization
	{
		public string Id { get; set; }
		public string UserId { get; set; }
		public string OrganizationId { get; set; }
		public bool Active { get; set; } = true;
		public string EventId { get; set; }
		public DateTime PublishingDate { get; set; }
	}
}