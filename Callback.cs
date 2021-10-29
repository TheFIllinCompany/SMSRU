using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fillin.SMSRU
{
	public class Callback
	{
		public string status { get; set; }

		public statusCode status_code { get; set; }

		public Dictionary<string, sms_callback> sms { get; set; }

		public double balance { get; set; }

		public bool IsSuccesCode()
		{
			return status_code == statusCode.sucess || status_code == (statusCode)101 || status_code == (statusCode)102 || status_code == statusCode.delivered;
		}
		public bool IsDelivered() => status_code == statusCode.delivered;
	}
}