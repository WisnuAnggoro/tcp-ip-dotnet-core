using System;

namespace WebApi.Engines
{
    // https://stackoverflow.com/a/906055
    public static class EpochTimestamp
    {
        public static double GetUnixEpoch(this DateTime dateTime)
        {
            var unixTime = dateTime.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return unixTime.TotalSeconds;
        }
    }
}