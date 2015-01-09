using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace Example_ExportExcessCreditsBaseData
{
    /// <summary>
    /// 比序績分主檔
    /// </summary>
    [TableName("kh.enrolment_excess.credits")]
    public class UDT_EnrolmentExcessCredits:ActiveRecord
    {
        ///<summary>
        /// 學生系統編號
        ///</summary>
        [Field(Field = "ref_student_id", Indexed = false)]
        public int StudentID { get; set; }     

        ///<summary>
        /// 均衡學習
        ///</summary>
        [Field(Field = "balanced", Indexed = false)]
        public string Balanced { get; set; }

        ///<summary>
        /// 服務學習
        ///</summary>
        [Field(Field = "services", Indexed = false)]
        public string Services { get; set; }

        ///<summary>
        /// 體適能
        ///</summary>
        [Field(Field = "fitness", Indexed = false)]
        public string Fitness { get; set; }

        ///<summary>
        /// 競賽表現
        ///</summary>
        [Field(Field = "competition", Indexed = false)]
        public string Competition { get; set; }

        ///<summary>
        /// 檢定證照
        ///</summary>
        [Field(Field = "verification", Indexed = false)]
        public string Verification { get; set; }

        ///<summary>
        /// 獎勵紀錄
        ///</summary>
        [Field(Field = "merit", Indexed = false)]
        public string Merit { get; set; }

        ///<summary>
        /// 幹部任期
        ///</summary>
        [Field(Field = "term", Indexed = false)]
        public string Term { get; set; }

        ///<summary>
        /// 詳細資料
        ///</summary>
        [Field(Field = "detail", Indexed = false)]
        public string Detail { get; set; }

    }
}
