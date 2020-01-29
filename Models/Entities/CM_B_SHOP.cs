using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class CM_B_SHOP
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string SHOP_CODE { get; set; }
        public string SHOP_DESCR { get; set; }
        public string LEGAL_DESCR { get; set; }
        public string SHOP_TYPE_CODE { get; set; }
        public string OBJ_CODE { get; set; }
        public string ORGANIZATION_CODE { get; set; }
        public string EXTRA_INFO { get; set; }
        public string FLG_ACTIVE { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual SY_SHOP_TYPE SY_SHOP_TYPE { get; set; }
    }
}
