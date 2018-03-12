using System;
using System.Collections.Generic;
using ClassLibrary;
using TechTalk.SpecFlow.Assist;

namespace UnitTestProject.Net452.ValueRetrievers
{
	public class _02_OrderNumbersRetriever : IValueRetriever
	{
		public bool CanRetrieve(
			KeyValuePair<string, string> keyValuePair,
			Type targetType,
			Type propertyType)
		{
			return keyValuePair.Key == nameof(ShippingInfo.OrderNumbers) &&
				   targetType == typeof(ShippingInfo) &&
				   propertyType == typeof(IEnumerable<string>);
		}

		public object Retrieve(
			KeyValuePair<string, string> keyValuePair,
			Type targetType,
			Type propertyType)
		{
			return keyValuePair.Value.Split(',');
		}
	}
}
