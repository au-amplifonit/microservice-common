using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class Category: ModelBase
	{
		[FieldMapper("CATEGORY_CODE")]
		public string Code { get; set; }

		[FieldMapper("CATEGORY_DESCR")]
		public string Description { get; set; }

		[FieldMapper("MARKET_TYPE_CODE")]
		public string MarketTypeCode { get; set; }
	}
}
