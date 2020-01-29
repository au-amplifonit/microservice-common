using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class CU_S_TYPE
    {
        public CU_S_TYPE()
        {
            CM_S_REFERENCE_SOURCE_EXT_AUS = new HashSet<CM_S_REFERENCE_SOURCE_EXT_AUS>();
        }

        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string TYPE_CODE { get; set; }
        public string TYPE_DESCR { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CM_S_REFERENCE_SOURCE_EXT_AUS> CM_S_REFERENCE_SOURCE_EXT_AUS { get; set; }
    }
}
