using System;
using System.Collections.Generic;

namespace ClassLibrary
{
	public class ShippingInfo
	{
		public static readonly List<ShippingInfo> VirtualDb = new List<ShippingInfo>();

		public string ShipCode { get; set; }

		public string ZipCode { get; set; }

		public int? SupplierId { get; set; }

		public DateTime? CreatedTime { get; set; }

		public IEnumerable<string> OrderNumbers { get; set; }
	}
}
