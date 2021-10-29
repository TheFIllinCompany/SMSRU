using Fillin.SMSRU.Exceptions;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace Fillin.SMSRU
{
	public class SMS_Service
	{
		public const int _MaxMessageLength = 67;

		public static string From { get; }


		public static event EventHandler<string> Log;

		public static string baseUrl => "https://sms.ru/sms/";
		private SMS_Service_Options options;
		public string apiKey
		{
			get; set;
		}

		public SMS_Service(SMS_Service_Options options)
		{
			this.options = options;
		}

		/// <summary>
		/// Send new message
		/// </summary>
		/// <param name="to">Recipient</param>
		/// <param name="">Content</param>
		/// <exception cref="PhoneInvalidException">when to parameter is invalid formated</exception>
		/// <returns></returns>
		public bool SendSMS(string to, string message, out int smsOutCount)
		{
			if (!to.IsPhoneValid())
			{
				throw new PhoneInvalidException();
			}

			smsOutCount = (int)Math.Floor((double)(message.Length / _MaxMessageLength));

			using (HttpClient client = new HttpClient())
			{
				var content = new StringContent(JsonConvert.SerializeObject(new Request(to, message, options)), Encoding.UTF8, "application/json");
				var callback = Task.Run(async () => await client.PostAsync($@"{baseUrl}/sms/send", content)).Result;
			}

			return true;
		}

		/// <summary>
		/// Send new message
		/// </summary>
		/// <param name="to">Recipients</param>
		/// <param name="message">Content</param>
		/// <returns>True if sent ok</returns>
		public bool SendSMS(string[] to, string message)
		{
			foreach (var recipient in to)
			{
				if (!recipient.IsPhoneValid())
				{
					throw new PhoneInvalidException();
				}
			}

			//smsOutCount = (int)Math.Floor((double)(message.Length / _MaxMessageLength));

			using (HttpClient client = new HttpClient())
			{
				var content = new StringContent(JsonConvert.SerializeObject(new RequestMultiTarget(to, message, options)), Encoding.UTF8, "application/json");
				var callback = Task.Run(async () => await client.PostAsync($@"{baseUrl}/sms/send", content)).Result;
			}

			return true;
		}

		/// <summary>
		/// Send new message
		/// </summary>
		/// <param name="PhoneMessagePair">Pair of phone and number</param>
		/// <returns>True if sent ok</returns>
		public bool SendSMS(Dictionary<string, string> PhoneMessagePair)
		{
			foreach (var recipient in PhoneMessagePair.Keys)
			{
				if (!recipient.IsPhoneValid())
				{
					throw new PhoneInvalidException();
				}
			}

			//smsOutCount = (int)Math.Floor((double)(message.Length / _MaxMessageLength));

			using (HttpClient client = new HttpClient())
			{
				var content = new StringContent(JsonConvert.SerializeObject(new RequestMultiMessage(PhoneMessagePair, options)), Encoding.UTF8, "application/json");
				var callback = Task.Run(async () => await client.PostAsync($@"{baseUrl}/sms/send", content)).Result;
			}

			return true;
		}


		public bool SendSMS(string to, string message)
		{
			return SendSMS(to, message, out _);
		}

		public bool RegisterWebhook(string url)
		{
			string callUrl = $"https://sms.ru/callback/add";

			using (HttpClient client = new HttpClient())
			{
				var content = new StringContent(JsonConvert.SerializeObject(new { url = callUrl, api_id = apiKey, json = 1 }), Encoding.UTF8, "application/json");

				var callback = Task.Run(async () => await client.PostAsync(callUrl, content)).Result;
			}


			return true;
		}
	}
}