using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class AppointmentType: ModelBase
	{
		[FieldMapper("SERVICE_CODE")]
		public string Code { get; set; }
		[FieldMapper("SERVICE_DESCR")]
		public string Description { get; set; }
		[FieldMapper("SERVICE_TYPE_CODE")]
		public string ServiceTypeCode { get; set; }
		public string ServiceTypeDescription { get; set; }

		[FieldMapper("DEFAULT_DURATION")]
		public int DefaultDuration { get; set; }
		[FieldMapper("BACKGROUND_COLOR")]
		public int BackgroundColor { get; set; }
		[FieldMapper("FOREGROUND_COLOR")]
		public int ForegroundColor { get; set; }
	}
}
