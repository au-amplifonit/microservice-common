using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class Language : ModelBase
	{
		[FieldMapper("LANGUAGE_CODE")]
		public string Code { get; set; }
		[FieldMapper("LANGUAGE_DESCR")]
		public string Description { get; set; }
	}
}
