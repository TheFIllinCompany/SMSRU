using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fillin.SMSRU
{
	public abstract class RequestBase
	{
		public string api_id { get; set; }
		/// <summary>
		/// Данный параметр вызывает ответ сервера в формате JSON, в котором предоставлено больше данных об отправленных сообщениях
		/// </summary>
		public int json { get; set; }


		/// <summary>
		/// Имя отправителя (должно быть согласовано с администрацией). Если не заполнено, в качестве отправителя будет указан ваш отправитель по умолчанию.
		/// </summary>
		public string from { get; set; }
		/// <summary>
		/// Если СМС сообщение отправляется в ответ на действия пользователя (например сообщение содержит код авторизации), то мы можем защитить вас на случай от действий злоумышленников, которые вынуждают вас отправлять много сообщений на один или разные номера (к примеру, регистрируясь много раз подряд на вашем сайте с одного IP адреса). В этом параметре вы можете передать нам IP адрес вашего пользователя, и, если мы заметим, что с этим IP связано большое количество сообщений, то мы их начнем блокировать (ограничение настраивается в разделе "Настройки").
		/// </summary>
		public string ip { get; set; }

		/// <summary>
		/// Если вам нужна отложенная отправка, то укажите время отправки. Указывается в формате UNIX TIME (пример: 1280307978). Должно быть не больше 2 месяцев с момента подачи запроса. Если время меньше текущего времени, сообщение отправляется моментально.
		/// </summary>
		public DateTime time { get; set; }


		/// <summary>
		/// Срок жизни сообщения в минутах (от 1 до 1440). Если сообщение не доставится за этот период (к примеру, телефон абонента не в сети), то оно будет уничтожено оператором. Если используется этот параметр, то стоимость недоставленного сообщения не компенсируется.
		/// </summary>
		public int ttl { get; set; } = 0;

		public int translit { get; set; } = 1;

		public int test { get; set; } = 0;

		public int partner_id { get; set; }


		public RequestBase()
		{

		}
		protected RequestBase(SMS_Service_Options options = default) : this()
		{
			json = options.isJson ? 1 : 0;
			test = options.test ? 1 : 0;
			partner_id = options.partner_id;
			api_id = options.apiKey;
			translit = options.useTranslit ? 1 : 0;
			ttl = options.TTL;
			from = options.From;

		}
	}
}