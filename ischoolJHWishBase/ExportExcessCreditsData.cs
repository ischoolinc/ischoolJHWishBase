using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using Aspose.Cells;
using System.ComponentModel;
using ischoolJHWishBase.DAO;

namespace ischoolJHWishBase
{
    /// <summary>
    /// 產生三年級狀態為一般，志願比序資料
    /// </summary>
    public class ExportExcessCreditsData
    {
        BackgroundWorker _bgWorker;
        DataTable _dtTable;
        Workbook _wb;
        List<string> _ColNameList;
        Dictionary<string, int> _ColNameDict;
        Dictionary<string, int> _formatMappingDict;
        int _gradeYear;

        public ExportExcessCreditsData(int gradeYear=2)
        {
            _gradeYear = gradeYear;
            _dtTable = new DataTable();
            _wb = new Workbook();
            _ColNameList = new List<string>();
            _formatMappingDict = new Dictionary<string, int>();
            _ColNameDict = new Dictionary<string, int>();
            _ColNameList.Add("學生姓名");
            _ColNameList.Add("身分證號統一編號");
            _ColNameList.Add("出生年");
            _ColNameList.Add("出生月");
            _ColNameList.Add("出生日");
            _ColNameList.Add("均衡學習");
            _ColNameList.Add("服務學習");
            _ColNameList.Add("體適能");
            _ColNameList.Add("競賽表現");
            _ColNameList.Add("檢定證照");
            _ColNameList.Add("獎勵紀錄");
            _ColNameList.Add("幹部任期");

            _formatMappingDict.Add("出生年", 3);
            _formatMappingDict.Add("出生月", 2);
            _formatMappingDict.Add("出生日", 2);
            _formatMappingDict.Add("均衡學習", 2);
            _formatMappingDict.Add("服務學習", 4);
            _formatMappingDict.Add("體適能", 2);
            _formatMappingDict.Add("競賽表現", 5);
            _formatMappingDict.Add("檢定證照", 2);
            _formatMappingDict.Add("獎勵紀錄", 4);
            _formatMappingDict.Add("幹部任期", 2);

            
           
            int i = 0;
            foreach (string str in _ColNameList)
            {
                _ColNameDict.Add(str, i);
                i++;
            }

            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);
        
        }






        void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 產生 Excel
            Utility.CompletedXls("志願比序資料", _wb);
        }

        /// <summary>
        /// 執行
        /// </summary>
        public void Run()
        {
            _bgWorker.RunWorkerAsync();
        }

        void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // 取得特定年級資料
            _dtTable = QueryTransfer.GetStudentExcessCreditDataTable(_gradeYear);

            // 讀取樣板            
            _wb.Open(new MemoryStream(Properties.Resources.比序資料樣板));

            int row = 1, col = 0;
            foreach (DataRow dr in _dtTable.Rows)
            {
                // 出生年月日解析
                DateTime dt;
                string sYY = "", sMM = "", sDD = "";                

                if (DateTime.TryParse(dr["出生年月日"].ToString(), out dt))
                {
                    sYY =(dt.Year-1911).ToString();
                    sMM =dt.Month.ToString();
                    sDD =dt.Day.ToString();
                }                                

                col = 0;
                foreach (string colName in _ColNameList)
                {                    
                    if (colName == "出生年")
                    {
                        _wb.Worksheets[0].Cells[row, col].PutValue(strParse(sYY,colName));
                    }
                    else if(colName == "出生月")
                    {
                        _wb.Worksheets[0].Cells[row, col].PutValue(strParse(sMM,colName));
                    }
                    else if (colName == "出生日")
                    {
                        _wb.Worksheets[0].Cells[row, col].PutValue(strParse(sDD,colName));
                    }
                    //else if (colName == "服務學習" || colName=="獎勵紀錄")
                    //{ 
                    //    _wb.Worksheets[0].Cells[row, col].PutValue(string.Format("{0:00.0}",dr[colName]));
                    //}
                    //else if (colName == "競賽表現")
                    //{
                    //    _wb.Worksheets[0].Cells[row, col].PutValue(string.Format("{0:00.00}", dr[colName]));
                    //}
                    else
                    {
                        // 轉換格式
                        if (_formatMappingDict.ContainsKey(colName))
                            _wb.Worksheets[0].Cells[row, col].PutValue(strParse(dr[colName].ToString(), colName));
                        else
                        {
                            string value = dr[colName].ToString();

                            // 身分證號統一編號，英文字母轉大寫
                            if (colName == "身分證號統一編號")
                                value = value.ToUpper();

                            _wb.Worksheets[0].Cells[row, col].PutValue(value);
                        }
                    }
                    col++;
                }
                row++;
            }
        }

        /// <summary>
        /// 字串轉換
        /// </summary>
        /// <param name="value"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        private string strParse(string value,string colName)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            else
                return value.PadLeft(_formatMappingDict[colName],'0');
        }
    }
}
