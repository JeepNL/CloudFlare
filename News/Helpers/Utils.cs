using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Helpers
{
    public static class Utils
    {
		public static DateTime UtcTicks2Local(long ticks)
		{
			DateTime dt = new DateTime(ticks).ToLocalTime();
			return dt;
		}
	}
}
