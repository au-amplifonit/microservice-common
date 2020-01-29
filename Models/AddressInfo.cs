using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Common.Models
{
	public class AddressInfo
	{
		public string Description { get; set; }
		public string Address { get; set; }
		public string Locality { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
	}
}
