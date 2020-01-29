using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class SY_LANGUAGE
    {
        public SY_LANGUAGE()
        {
            US_B_USER = new HashSet<US_B_USER>();
        }

        public string LANGUAGE_CODE { get; set; }
        public string LANGUAGE_DESCR { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public string FLG_APPLICATION { get; set; }

        public virtual ICollection<US_B_USER> US_B_USER { get; set; }
    }
}
