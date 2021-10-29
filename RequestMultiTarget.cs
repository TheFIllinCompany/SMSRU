using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fillin.SMSRU
{
	public class RequestMultiTarget:RequestBase
	{

		/// <summary>
		/// Номер телефона получателя (либо несколько номеров, через запятую — до 100 штук за один запрос). Вы также можете указать номера в виде массива to[номер получателя]=текст&to[номер получателя]=текст. Если вы указываете несколько номеров и один из них указан неверно, то вместо идентификатора сообщения в выдаче вы получите трехзначный код ошибки. Если вы отправляете более, чем на 10 номеров за раз, то рекомендуем параметр to передавать в теле запроса методом POST, а не в адресной строке.
		/// </summary>
		public string[] to { get; set; }
		/// <summary>
		/// Текст сообщения в кодировке UTF-8
		/// </summary>
		public string msg { get; set; }

		internal RequestMultiTarget() : base()
		{

		}

		public RequestMultiTarget (string[] to, string message, SMS_Service_Options options = default) : base(options)
		{
			this.to = to;
			this.msg = message;
		}

	}
}