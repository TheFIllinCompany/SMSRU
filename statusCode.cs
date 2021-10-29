using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fillin.SMSRU
{
	public enum statusCode
	{
		notFound = -1,
		sucess = 100,
		goingToOperator = 101,
		onRoute = 102,
		delivered = 103,
		ttlExpired = 104,
		removedByOperator= 105,
		phoneException = 106,
		unsendUnknown= 107,
		declined = 108,
		read = 110,
		unableToSendToThisNomber = 150,
		wrongApiId = 200,
		lowBallance = 201,
		phoneNumberMistake =202,
		noMessage = 203,
		wrongSenderName = 204,
		toLongMessage = 205,
		sendLimit = 206,
		noRouteForThisNumber = 207,
		wrongTimeParameter = 208,
		numberInStopList = 209,
		usePostInstadeOfGet=210,
		methodNotFound = 211,
		wrongEncoding = 212,
		moreThan100Recipients = 213,
		serviceUnavailable = 220,
		limitFoNumberPerDay = 230,
		limitOfEquelSmsForSingleNumberPerMinute = 231,
		limitOfEquelSmsForSingleNumberPerDay = 232,
		limitOfEquelSmsForSingleIpPerDay = 233,
		wrongToken = 300,
		wrongApiIdOrCredentials = 301,
		accauntUnVerified = 302,
		wrongVerificationKey = 303,
		toManyVerifications = 304,
		toManyMissVerifications = 305,
		serverError = 500,
		wrongUrl = 901,
		callbackMethodNotFound = 902

	}
}