using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.Models.Configuration;

namespace Fox.Microservices.Common.Models.Configuration
{
	public class CustomAppSettings: AppSettings
	{
		public string GoogleKey { get; set; }
	}
}
