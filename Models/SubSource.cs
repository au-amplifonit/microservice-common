using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class SubSource: ModelBase
	{
		[FieldMapper("CODE")]
		public string Code { get; set; }
		[FieldMapper("DESCRIPTION")]
		public string Description { get; set; }

		[FieldMapper("REF_CODE")]
		public string SourceCode { get; set; }
	}
}
