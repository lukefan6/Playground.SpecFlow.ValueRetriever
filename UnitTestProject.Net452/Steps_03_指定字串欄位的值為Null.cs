using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.ValueRetrievers;
using UnitTestProject.Net452.ValueRetrievers;

namespace UnitTestProject.Net452
{
	[Binding]
	[Scope(Feature = "03-指定字串欄位的值為null")]
	public class Steps_03_指定字串欄位的值為Null
	{
		private List<ShippingInfo> _shippingInfos;

		[BeforeScenario]
		public void BeforeEachScenario()
		{
			ShippingInfo.VirtualDb.Clear();

			var defaultStringValueRetriever = Service.Instance.ValueRetrievers
				.FirstOrDefault(x => x is StringValueRetriever);

			if (defaultStringValueRetriever != null)
			{
				Service.Instance.UnregisterValueRetriever(defaultStringValueRetriever);
			}

			Service.Instance.RegisterValueRetriever(new _03_NullStringRetriever());
		}

		[Given(@"把以下表格的資料存到 ShippingInfo\.VirtualDb 裡面")]
		public void Given把以下表格的資料存到ShippingInfo_VirtualDb裡面(Table table)
		{
			var data = table.CreateSet<ShippingInfo>();

			ShippingInfo.VirtualDb.AddRange(data);
		}

		[When(@"取得 ShippingInfo\.VirtualDb 的所有資料")]
		public void When取得ShippingInfo_VirtualDb的所有資料()
		{
			this._shippingInfos = ShippingInfo.VirtualDb;
		}

		[Then(@"貨運單號為 ""(.*)"" 的資料，他的郵遞區號是 ""(.*)""")]
		public void Then貨運單號為的資料他的郵遞區號是(string shipCode, string expectedZipCode)
		{
			this._shippingInfos
				.Single(x => x.ShipCode == shipCode)
				.ZipCode
				.Should().Be(expectedZipCode);
		}

		[Then(@"貨運單號為 ""(.*)"" 的資料，他的供應商序號是 null")]
		public void Then貨運單號為的資料他的供應商序號是Null(string shipCode)
		{
			this._shippingInfos
				.Single(x => x.ShipCode == shipCode)
				.SupplierId
				.Should().BeNull();
		}

		[Then(@"貨運單號為 ""(.*)"" 的資料，他的建立時間是 null")]
		public void Then貨運單號為的資料他的建立時間是Null(string shipCode)
		{
			this._shippingInfos
				.Single(x => x.ShipCode == shipCode)
				.CreatedTime
				.Should().BeNull();
		}

		[Then(@"貨運單號為 ""(.*)"" 的資料，他的供應商序號是 (.*)")]
		public void Then貨運單號為的資料他的供應商序號是(string shipCode, int expectedSupplierId)
		{
			this._shippingInfos
				.Single(x => x.ShipCode == shipCode)
				.SupplierId
				.Should().Be(expectedSupplierId);
		}

		[Then(@"貨運單號為 ""(.*)"" 的資料，他的建立時間是 ""(.*)""")]
		public void Then貨運單號為的資料他的建立時間是(string shipCode, DateTime expectedTime)
		{
			this._shippingInfos
				.Single(x => x.ShipCode == shipCode)
				.CreatedTime
				.Should().Be(expectedTime);
		}

		[Then(@"貨運單號為 ""(.*)"" 的資料，他的郵遞區號是 null")]
		public void Then貨運單號為的資料他的郵遞區號是Null(string shipCode)
		{
			this._shippingInfos
				.Single(x => x.ShipCode == shipCode)
				.ZipCode
				.Should().BeNull();
		}
	}
}
