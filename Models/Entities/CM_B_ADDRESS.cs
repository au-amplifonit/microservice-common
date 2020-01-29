using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class CM_B_ADDRESS
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string OBJ_CODE { get; set; }
        public string OBJ_TYPE { get; set; }
        public int ADDRESS_COUNTER { get; set; }
        public string LETTER_DEFAULT { get; set; }
        public string ADDRESS_LINE1 { get; set; }
        public string ADDRESS_LINE2 { get; set; }
        public string ADDRESS_LINE3 { get; set; }
        public string ADDRESS_LINE4 { get; set; }
        public string AREA_CODE { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string ZIP_CODE { get; set; }
        public string CITY_NAME { get; set; }
        public short? CITY_COUNTER { get; set; }
        public string LOCALITY { get; set; }
        public string PO_BOX { get; set; }
        public string PHONE1 { get; set; }
        public string PHONE2 { get; set; }
        public string PHONE3 { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        public string FLGNORMALIZED { get; set; }
        public string INVOICEDEFAULT { get; set; }
        public string EXTRA_INFO { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }

        public virtual CM_S_CITY_BOOK CM_S_CITY_BOOK { get; set; }
    }
}
