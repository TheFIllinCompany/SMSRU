using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fillin.SMSRU
{
	public class SMS_Service_Options
	{
		public string From { get; set; }
		public int TTL { get; set; }

		public bool isJson { get; set; } = true;
		public string apiKey { get; set; }

		public bool test { get; set; } = false;

		public int partner_id { get; set; }

		public bool useTranslit { get; set; }
	}
}