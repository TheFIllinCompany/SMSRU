using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fillin.SMSRU
{
	public class RequestMultiMessage:RequestBase
	{

		/// <summary>
		/// Pair to/msg
		/// </summary>
		public Dictionary<string, string> multi { get; set; }

		internal RequestMultiMessage() : base()
		{

		}

		public RequestMultiMessage(Dictionary<string, string> multi, SMS_Service_Options options = default) : base(options)
		{
			this.multi = multi;
		}

	}
}