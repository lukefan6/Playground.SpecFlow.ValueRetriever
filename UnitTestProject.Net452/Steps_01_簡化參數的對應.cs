using System.Collections.Generic;
using ClassLibrary;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace UnitTestProject.Net452
{
	[Binding]
	public class Steps_01_簡化參數的對應
	{
		private IEnumerable<string> _allTableNames;

		[Given(@"在 VirtualTableNames 加入一筆資料 ""(.*)""")]
		public void Given在VirtualTableNames加入一筆資料(string tableName)
		{
			VirtualTableNames.Add(tableName);
		}

		[When(@"取得 VirtualTableNames 的所有資料")]
		public void When取得VirtualTableNames的所有資料()
		{
			this._allTableNames = VirtualTableNames.All;
		}

		[Then(@"結果應該包含 ""(.*)""")]
		[Scope(Tag = "BindAsString")]
		public void Then結果應該包含(string commaSeparatedValues)
		{
			var expectations = commaSeparatedValues.Split(',');

			this._allTableNames.Should().Contain(expectations);
		}

		[Then(@"結果不應該包含 ""(.*)""")]
		[Scope(Tag = "BindAsString")]
		public void Then結果不應該包含(string commaSeparatedValues)
		{
			var unexpected = commaSeparatedValues.Split(',');

			this._allTableNames.Should().NotContain(unexpected);
		}

		[Then(@"結果應該包含 ""(.*)""")]
		[Scope(Tag = "BindAsStepArgument")]
		public void Then結果應該包含(IEnumerable<string> expectations)
		{
			this._allTableNames.Should().Contain(expectations);
		}

		[Then(@"結果不應該包含 ""(.*)""")]
		[Scope(Tag = "BindAsStepArgument")]
		public void Then結果不應該包含(IEnumerable<string> unexpected)
		{
			this._allTableNames.Should().NotContain(unexpected);
		}

		[StepArgumentTransformation]
		public IEnumerable<string> TransformCommaSeparatedValues(string commaSeparatedValues)
		{
			return commaSeparatedValues.Split(',');
		}
	}
}
