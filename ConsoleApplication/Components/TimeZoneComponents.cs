using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using NodaTime.TimeZones;

namespace ConsoleApplication.Components
{
	public static class TimeZoneComponents
	{
		public static IEnumerable<TimeZoneModel> GetTimezones()
		{
			return TimeZoneInfo.GetSystemTimeZones().Select(x => new TimeZoneModel()
			{
				Name = x.DisplayName,
				Id = x.Id
			});
		}

		public static IEnumerable<ZoneInterval> GetTimeZoneIntervals(string timezoneId, DateTime? dateTime = null)
		{
			var dateTimeZone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(timezoneId);

			if (dateTimeZone == null)
			{
				var tz = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
				var tzdbSource = TzdbDateTimeZoneSource.Default;
				var tzid = tzdbSource.MapTimeZoneId(tz);

				if (String.IsNullOrEmpty(tzid)) return new List<ZoneInterval>();

				dateTimeZone = DateTimeZoneProviders.Tzdb[tzid];

				var yearStart = Instant.FromDateTimeUtc(DateTime.SpecifyKind(DateTime.Parse("1/1/2018"), DateTimeKind.Utc));
				var yearEnd = Instant.FromDateTimeUtc(DateTime.SpecifyKind(DateTime.Parse("1/1/2019"), DateTimeKind.Utc));
				var zoneIntervals = dateTimeZone.GetZoneIntervals(yearStart, yearEnd);

				return zoneIntervals;
			}

			var dateTimeUtc = new DateTime((dateTime ?? DateTime.UtcNow).Ticks, DateTimeKind.Utc);
			var zoneInterval = dateTimeZone.GetZoneInterval(Instant.FromDateTimeUtc(dateTimeUtc));

			return new List<ZoneInterval> { zoneInterval };
		}

		public class TimeZoneModel
		{
			public string Id { get; set; }
			public string Name { get; set; }
		}
	}
}