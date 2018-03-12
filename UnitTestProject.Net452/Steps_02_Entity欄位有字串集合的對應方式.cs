using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UnitTestProject.Net452.ValueRetrievers;

namespace UnitTestProject.Net452
{
	[Binding]
	[Scope(Feature = "02-Entity欄位有字串集合的對應方式")]
	public class Steps_02_Entity欄位有字串集合的對應方式
	{
		private IList<string> _orderNumbers;

		[BeforeScenario]
		public void BeforeEachScenario()
		{
			ShippingInfo.VirtualDb.Clear();

			Service.Instance.RegisterValueRetriever(new _02_OrderNumbersRetriever());
		}

		[Given(@"把以下表格的資料存到 ShippingInfo\.VirtualDb 裡面")]
		public void Given把以下表格的資料存到ShippingInfo_VirtualDb裡面(Table table)
		{
			var data = table.CreateSet<ShippingInfo>();

			ShippingInfo.VirtualDb.AddRange(data);
		}

		[When(@"取得貨運單號為 ""(.*)"" 的訂單編號清單")]
		public void When取得貨運單號為的訂單編號清單(string shipCode)
		{
			this._orderNumbers = ShippingInfo.VirtualDb
				.Single(x => x.ShipCode == shipCode)
				.OrderNumbers
				.ToList();
		}

		[Then(@"第 (.*) 筆訂單編號是 ""(.*)""")]
		public void Then第筆訂單編號是(int zeroBasedIndex, string expectated)
		{
			this._orderNumbers[zeroBasedIndex].Should().Be(expectated);
		}
	}
}
