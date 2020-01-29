using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class Gender: ModelBase
	{
		[FieldMapper("GENDER_CODE")]
		public string Code { get; set; }
		[FieldMapper("GENDER_DESCR")]
		public string Description { get; set; }
	}
}
