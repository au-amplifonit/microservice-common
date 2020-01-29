using System;
using System.Collections.Generic;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class US_B_USER
    {
        public string COMPANY_CODE { get; set; }
        public string DIVISION_CODE { get; set; }
        public string USER_NAME { get; set; }
        public string USER_DESCR { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string GROUP_CODE { get; set; }
        public string DEPARTMENT_CODE { get; set; }
        public string LANGUAGE_CODE { get; set; }
        public string STATUS_CODE { get; set; }
        public string EMAIL { get; set; }
        public string MOBILE { get; set; }
        public DateTime? DT_START { get; set; }
        public DateTime? DT_END { get; set; }
        public DateTime? DT_INSERT { get; set; }
        public string USERINSERT { get; set; }
        public DateTime? DT_UPDATE { get; set; }
        public string USERUPDATE { get; set; }
        public Guid ROWGUID { get; set; }
        public string ORGANIZATION_CODE { get; set; }
        public string PRACTITIONER_NUMBER { get; set; }

        public virtual SY_LANGUAGE LANGUAGE_CODENavigation { get; set; }
    }
}
