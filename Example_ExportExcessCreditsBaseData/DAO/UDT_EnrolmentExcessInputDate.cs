using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ExportExcessCreditsBaseData
{
    /// <summary>
    /// 開放填寫時間
    /// </summary>
    [TableName("kh.enrolment_excess.input_date")]
    public class UDT_EnrolmentExcessInputDate:ActiveRecord
    {
        ///<summary>
        /// 開始日期
        ///</summary>
        [Field(Field = "start_date", Indexed = false)]
        public DateTime? StartDate { get; set; }

        ///<summary>
        /// 結束日期
        ///</summary>
        [Field(Field = "end_date", Indexed = false)]
        public DateTime? EndDate { get; set; }

    }
}
