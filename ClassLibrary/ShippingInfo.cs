using System;
using System.Collections.Generic;

namespace ClassLibrary
{
	public class ShippingInfo
	{
		public string ShipCode { get; set; }

		public string RecipientZipCode { get; set; }

		public int SupplierId { get; set; }

		public DateTime CreatedTime { get; set; }

		public IEnumerable<string> OrderNumbers { get; set; }
	}
}
