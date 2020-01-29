using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class SY_SHOP_TYPE
    {
        public SY_SHOP_TYPE()
        {
            CM_B_SHOP = new HashSet<CM_B_SHOP>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string SHOP_TYPE_CODE { get; set; }
        public string SHOP_TYPE_DESCR { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CM_B_SHOP> CM_B_SHOP { get; set; }
    }
}
