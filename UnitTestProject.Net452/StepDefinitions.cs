using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace UnitTestProject.Net452
{
	[Binding]
	public sealed class StepDefinitions
	{
		private IEnumerable<ShippingInfo> _shippingInfoSet;

		public class StringSetRetriever : IValueRetriever
		{
			public bool CanRetrieve(
				KeyValuePair<string, string> keyValuePair,
				Type targetType,
				Type propertyType)
			{
				return propertyType == typeof(IEnumerable<string>);
			}

			public object Retrieve(
				KeyValuePair<string, string> keyValuePair,
				Type targetType,
				Type propertyType)
			{
				return keyValuePair.Value.Split(',');
			}
		}

		[BeforeScenario]
		public void BeforeEachScenario()
		{
			Service.Instance.RegisterValueRetriever(new StringSetRetriever());
		}

		[StepArgumentTransformation]
		public IEnumerable<string> TransformStringSet(Table table)
		{
			return table.Rows.Select(x => x.First().Value);
		}

		[When(@"I map following table to a set of shipping info")]
		public void WhenIMapFollowingTableToASetOfShippingInfo(Table table)
		{
			this._shippingInfoSet = table.CreateSet<ShippingInfo>();
		}

		[Then(@"the order numbers for ship code ""(.*)"" should be")]
		public void ThenTheOrderNumbersForShipCodeShouldBe(
			string shipCode,
			IEnumerable<string> expectation)
		{
			this._shippingInfoSet
				.Single(x => x.ShipCode == shipCode)
				.OrderNumbers
				.ShouldAllBeEquivalentTo(expectation);
		}
	}
}
