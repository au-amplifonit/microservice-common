using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fox.Microservices.Common.Models.Entities;
using Microsoft.EntityFrameworkCore;
using WebAPITools.EntityMapper;
using WebAPITools.Models;

namespace Fox.Microservices.Common.Models
{
	public class Clinic: ModelBase
	{
		[FieldMapper("SHOP_CODE")]
		public string Code { get; set; }
		[FieldMapper("SHOP_DESCR")]
		public string Description { get; set; }
		[FieldMapper("LEGAL_DESCR")]
		public string LegalDescription { get; set; }
		[FieldMapper("SHOP_TYPE_CODE")]
		public string ClinicTypeCode { get; set; }
		public string ClinicTypeDecription { get; set; }
		[FieldMapper("FLG_ACTIVE")]
		public bool IsActive { get; set; }

		public override void LoadData<T>(DbContext context, dynamic entity)
		{
			base.LoadData<T>(context, (T)entity);
			if (entity is CM_B_SHOP)
				ClinicTypeDecription = entity.SY_SHOP_TYPE?.SHOP_TYPE_DESCR;
		}
	}
}
