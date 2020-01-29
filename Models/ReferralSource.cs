using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class ReferralSource: ModelBase
	{
		[FieldMapper("DAYCENTER_CODE")]
		public string Code { get; set; }

		[FieldMapper("DAYCENTER_DESCR")]
		public string Description { get; set; }

		[FieldMapper("LOCATION_TYPE")]
		public string LocationType { get; set; }
	}
}
