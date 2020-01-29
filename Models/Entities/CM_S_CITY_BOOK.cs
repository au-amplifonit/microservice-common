using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class CM_S_CITY_BOOK
    {
        public CM_S_CITY_BOOK()
        {
            CM_B_ADDRESS = new HashSet<CM_B_ADDRESS>();
        }

        public string COUNTRY_CODE { get; set; }
        public string AREA_CODE { get; set; }
        public string ZIP_CODE { get; set; }
        public short CITY_COUNTER { get; set; }
        public string CITY_NAME { get; set; }
        public string ZIP_CODE_UNIQUE_ID { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual ICollection<CM_B_ADDRESS> CM_B_ADDRESS { get; set; }
    }
}
