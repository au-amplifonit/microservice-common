using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class AG_S_SERVICE_EXT_AUS
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string SERVICE_PARENT_CODE { get; set; }
        public string SERVICE_CODE { get; set; }
        public string CHARGEABLE { get; set; }
        public string DEFAULT_DURATION { get; set; }
        public string BOOKING_BY { get; set; }
        public string COMPLETED_BY { get; set; }
        public int? NUMBER_OF_OCCURENCE { get; set; }
        public string MAXIMUM_DURATION { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
    }
}
