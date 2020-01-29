using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class State: ModelBase
	{
		[FieldMapper("STATE_CODE")]
		public string Code { get; set; }

		[FieldMapper("STATE_NAME")]
		public string Name { get; set; }

		[FieldMapper("STATE_COUNTER", DefaultValue = 0)]
		public int StateCounter { get; set; }

		[FieldMapper("DEFAULT_AREA_CODE")]
		public string DefaultAreaCode { get; set; }
	}
}
