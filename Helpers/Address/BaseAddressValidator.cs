using Fox.Microservices.Common.Models;
using Fox.Microservices.Common.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fox.Microservices.Common.Helpers.Address
{
	public abstract class BaseAddressValidator
	{
		protected CustomAppSettings Settings { get; private set; }

		public BaseAddressValidator(CustomAppSettings settings)
		{
			Settings = settings;
		}

		public abstract List<AddressInfo> GetAddresses(string searchString);

	}
}
