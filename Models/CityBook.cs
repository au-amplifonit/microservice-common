using Fox.Microservices.Common.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class CityBook : ModelBase
	{
		[FieldMapper(nameof(CM_S_CITY_BOOK.COUNTRY_CODE))]
		public string CountryCode { get; set; }

		[FieldMapper(nameof(CM_S_CITY_BOOK.AREA_CODE))]
		public string AreaCode { get; set; }

		[FieldMapper(nameof(CM_S_CITY_BOOK.ZIP_CODE))]
		public string ZipCode { get; set; }

		[FieldMapper(nameof(CM_S_CITY_BOOK.CITY_COUNTER))]
		public short CityCounter { get; set; }

		[FieldMapper(nameof(CM_S_CITY_BOOK.CITY_NAME))]
		public string CityName { get; set; }

		[FieldMapper(nameof(CM_S_CITY_BOOK.ZIP_CODE_UNIQUE_ID))]
		public string ZipCodeUID { get; set; }
	}
}
