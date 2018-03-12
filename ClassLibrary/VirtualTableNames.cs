using System.Collections.Generic;

namespace ClassLibrary
{
	public static class VirtualTableNames
	{
		private static readonly IList<string> _tableNames = new List<string>();

		public static IEnumerable<string> All => _tableNames;

		public static void Add(string tableName)
		{
			_tableNames.Add(tableName);
		}
	}
}
