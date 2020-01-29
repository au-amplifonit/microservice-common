using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class CU_S_CATEGORY
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string CATEGORY_CODE { get; set; }
        public string CATEGORY_DESCR { get; set; }
        public string MARKET_TYPE_CODE { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
    }
}
