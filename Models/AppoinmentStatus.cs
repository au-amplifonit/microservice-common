using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class AppointmentStatus: ModelBase
	{
		[FieldMapper("STATUS_CODE")]
		public string Code { get; set; }
		[FieldMapper("STATUS_DESCR")]
		public string Description { get; set; }
	}
}
