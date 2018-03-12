using System;
using System.Collections.Generic;
using TechTalk.SpecFlow.Assist;

namespace UnitTestProject.Net452.ValueRetrievers
{
	public class _03_NullStringRetriever : IValueRetriever
	{
		public bool CanRetrieve(
			KeyValuePair<string, string> keyValuePair,
			Type targetType,
			Type propertyType)
		{
			return propertyType == typeof(string);
		}

		public object Retrieve(
			KeyValuePair<string, string> keyValuePair,
			Type targetType,
			Type propertyType)
		{
			return keyValuePair.Value == "<null>"
				? null
				: keyValuePair.Value;
		}
	}
}
