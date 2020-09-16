using System.Collections.Generic;
using ConsoleApplication.DataContracts;

namespace ConsoleApplication.Components
{
	public class OrganizationComponent
	{
		public List<UserOrganization> GetUserOrganizationsWithoutEvent()
		{
			var result = new List<UserOrganization>();

			result.Add(new UserOrganization {EventId = null, OrganizationId = "ORGZ-AAAAAAAA-AAAA-AAAA-AAAA-000000000001" });
			result.Add(new UserOrganization {EventId = "", OrganizationId = "ORGZ-AAAAAAAA-AAAA-AAAA-AAAA-000000000002" });
			result.Add(new UserOrganization {EventId = null, OrganizationId = "ORGZ-AAAAAAAA-AAAA-AAAA-AAAA-000000000003" });
			result.Add(new UserOrganization {EventId = "EVN-AAAAAAAA-AAAA-AAAA-AAAA-000000000001", OrganizationId = "ORGZ-AAAAAAAA-AAAA-AAAA-AAAA-000000000004" });

			return result;
		}

		public List<UserOrganization> GetUserOrganizationsEvent()
		{
			var result = new List<UserOrganization>();

			result.Add(new UserOrganization { EventId = "EVN-AAAAAAAA-AAAA-AAAA-AAAA-000000000001", OrganizationId = "ORGZ-AAAAAAAA-AAAA-AAAA-AAAA-000000000005" });
			result.Add(new UserOrganization { EventId = "EVN-AAAAAAAA-AAAA-AAAA-AAAA-000000000001", OrganizationId = "ORGZ-AAAAAAAA-AAAA-AAAA-AAAA-000000000006" });
			result.Add(new UserOrganization { EventId = "EVN-AAAAAAAA-AAAA-AAAA-AAAA-000000000001", OrganizationId = "ORGZ-AAAAAAAA-AAAA-AAAA-AAAA-000000000001" });
			result.Add(new UserOrganization { EventId = "EVN-AAAAAAAA-AAAA-AAAA-AAAA-000000000002", OrganizationId = "ORGZ-AAAAAAAA-AAAA-AAAA-AAAA-000000000007" });

			return result;
		}
	}
}