using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ExportExcessCreditsBaseData
{
    static public class tool
    {
        /// <summary>
        /// 將電話消除特定字元
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string ParseTelStr(string str)
        {
            if (str.Contains("("))
                str = str.Replace("(", "");

            if (str.Contains(")"))
                str = str.Replace(")", "");

            if (str.Contains("-"))
                str = str.Replace("-", "");

            return str;
        }

        static public string xmlParse1(XElement elm, string name)
        {
            string retVal = "";
            if (elm.Element(name) != null)
                retVal = elm.Element(name).Value;

            return retVal;
        }

        /// <summary>
        /// 欄位名稱
        /// </summary>
        /// <returns></returns>
        static public List<string> GetDataTableColumnsName()
        {
            List<string> retVal = new List<string>();
            retVal.Add("地區代碼");
            retVal.Add("集報單位代碼");
            retVal.Add("序號");
            retVal.Add("學號");
            retVal.Add("班級");
            retVal.Add("座號");
            retVal.Add("學生姓名");
            retVal.Add("身分證統一編號");
            retVal.Add("性別");
            retVal.Add("出生年");
            retVal.Add("出生月");
            retVal.Add("出生日");
            retVal.Add("畢業學校代碼");
            retVal.Add("畢業年");
            retVal.Add("畢肄業");
            retVal.Add("學生身分");
            retVal.Add("身心障礙");
            retVal.Add("就學區");
            retVal.Add("低收入戶");
            retVal.Add("中低收入戶");
            retVal.Add("失業勞工");
            retVal.Add("資料授權");
            retVal.Add("家長姓名");
            retVal.Add("室內電話");
            retVal.Add("行動電話");
            retVal.Add("郵遞區號");
            retVal.Add("地址");
            return retVal;
        }


        /// <summary>
        /// 取得基本資料-地區代碼對照
        /// </summary>
        /// <returns></returns>
        static public Dictionary<string, string> GetExcessCreditsBase1()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add("臺北地區", "01");
            retVal.Add("新北地區", "02");
            retVal.Add("宜蘭地區", "03");
            retVal.Add("基隆地區", "04");
            retVal.Add("桃園地區", "05");
            retVal.Add("竹苗地區", "06");
            retVal.Add("中投地區", "07");
            retVal.Add("彰化地區", "08");
            retVal.Add("雲林地區", "09");
            retVal.Add("嘉義地區", "10");
            retVal.Add("臺南地區", "11");
            retVal.Add("屏東地區", "12");
            retVal.Add("高雄地區", "13");
            retVal.Add("花蓮地區", "14");
            retVal.Add("臺東地區", "15");
            retVal.Add("澎湖地區", "16");
            retVal.Add("金門地區", "17");
            retVal.Add("馬祖地區", "18");
            retVal.Add("大陸考場", "19");
            return retVal;
        }


        /// <summary>
        /// 取得基本資料-學生身分對照
        /// </summary>
        /// <returns></returns>
        static public Dictionary<string, string> GetExcessCreditsBase2()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add("一般生", "0");
            retVal.Add("原住民", "1");
            retVal.Add("派外人員子女", "2");
            retVal.Add("蒙藏生", "3");
            retVal.Add("回國僑生", "4");
            retVal.Add("港澳生", "5");
            retVal.Add("退伍軍人", "6");
            retVal.Add("境外優秀科學技術人才子女", "7");
            return retVal;
        }

        /// <summary>
        /// 取得基本資料-身心障礙
        /// </summary>
        /// <returns></returns>
        static public Dictionary<string, string> GetExcessCreditsBase3()
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            retVal.Add("非身心障礙考生", "0");
            retVal.Add("智能障礙", "1");
            retVal.Add("視覺障礙", "2");
            retVal.Add("聽覺障礙", "3");
            retVal.Add("語言障礙", "4");
            retVal.Add("肢體障礙", "5");
            retVal.Add("腦性麻痺", "6");
            retVal.Add("身體病弱", "7");
            retVal.Add("情緒行為障礙", "8");
            retVal.Add("學習障礙", "9");
            retVal.Add("多重障礙", "A");
            retVal.Add("自閉症", "B");
            retVal.Add("發展遲緩", "C");
            retVal.Add("其他障礙", "D");
            return retVal;
        }
    }
}
