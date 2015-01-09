using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example_ExportExcessCreditsBaseData
{
    /// <summary>
    /// 學生積分比序資料
    /// </summary>
    public class StudentExcessCredit
    {
        /// <summary>
        /// 學生編號
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// 班級
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 座號
        /// </summary>
        public int? SeatNo { get; set; }

        /// <summary>
        /// 學號
        /// </summary>
        public string StudentNumber { get; set; }

        /// <summary>
        /// 積分比序
        /// </summary>
        public Dictionary<string, string> ExcessCreditDict = new Dictionary<string, string>();

        /// <summary>
        /// 是否全輸入
        /// </summary>
        public bool InputPass { get; set; }

    }
}
