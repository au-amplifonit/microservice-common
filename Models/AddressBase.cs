using Fox.Microservices.Common.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class AddressBase : ModelBase
	{
		[FieldMapper(nameof(CM_B_ADDRESS.OBJ_CODE), typeof(CM_B_ADDRESS))]
		public string ObjCode { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.ADDRESS_COUNTER), typeof(CM_B_ADDRESS))]
		public int AddressCounter { get; set; }

		[FieldMapper("ADDRESS_LINE", IsArray = true, ArrayMaxRank = 4)]
		public string[] Address { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.COUNTRY_CODE))]
		public string CountryCode { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.AREA_CODE))]
		public string AreaCode { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.ZIP_CODE))]
		public string ZipCode { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.CITY_NAME))]
		public string City { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.LOCALITY))]
		public string Locality { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.PO_BOX))]
		public string POBox { get; set; }

		[FieldMapper("PHONE", typeof(CM_B_ADDRESS), IsArray = true, ArrayMaxRank = 3)]
		public string[] Phones { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.MOBILE))]
		public string Mobile { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.EMAIL))]
		public string EMail { get; set; }

		[FieldMapper(nameof(CM_B_ADDRESS.EXTRA_INFO))]
		public string ExtraInfo { get; set; }

		public AddressBase()
		{
		}
	}
}
