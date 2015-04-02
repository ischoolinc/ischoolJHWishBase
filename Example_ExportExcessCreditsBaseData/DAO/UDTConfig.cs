using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ExportExcessCreditsBaseData
{
    /// <summary>
    /// 十二年國教輔導志願序設定
    /// </summary>
    [TableName("ischool_jh_wishbase.config")]
    public class UDTConfig:ActiveRecord
    {
        ///<summary>
        /// 名稱
        ///</summary>
        [Field(Field = "name", Indexed = false)]
        public string Name { get; set; }

        ///<summary>
        /// 內容
        ///</summary>
        [Field(Field = "data", Indexed = false)]
        public string Data { get; set; }
    }
}
