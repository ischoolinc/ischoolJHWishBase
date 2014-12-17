using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using ischoolJHWishBase.DAO;
using Aspose.Cells;

namespace ischoolJHWishBase
{
    public partial class CheckExcessCreditsForm : BaseForm
    {
        BackgroundWorker _bgWorker;
        DataTable _dtTable;
        DataTable _dtTableNonPass;
        Dictionary<int, StudentExcessCredit> _StudentExcessCreditDict;
        Dictionary<int, UDT_EnrolmentExcessCredits> _EnrolmentExcessCreditsDict;
        private int _TotalCount=0,_passCount=0,_noPassCount=0;
        public CheckExcessCreditsForm()
        {
            InitializeComponent();
            _StudentExcessCreditDict = new Dictionary<int, StudentExcessCredit>();
            _EnrolmentExcessCreditsDict = new Dictionary<int, UDT_EnrolmentExcessCredits>();
            _dtTable = new DataTable();
            _dtTableNonPass = new DataTable();
            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);            
        }

        void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnExport.Enabled = true;
            LoadDataTableToDataGrid();

            lblMsg.Text = "總人數： " + _TotalCount + " 人，未輸入人數： " + (_TotalCount-_passCount) + " 人，已輸入人數： " + _passCount + " 人";
        }

        private void LoadDataTableToDataGrid()
        {
            if (chkInput.Checked)
                dgData.DataSource = _dtTableNonPass;
            else
                dgData.DataSource = _dtTable;
        }

        void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // 取得三年級學生一般生
            _StudentExcessCreditDict = QueryTransfer.GetStudentExcessCreditDict();
    
            // 取得比序資料
            List<UDT_EnrolmentExcessCredits> EnrolmentExcessCreditsList = UDTTransfer.UDTEnrolmentExcessCreditsSelect();
            _EnrolmentExcessCreditsDict.Clear();
            foreach (UDT_EnrolmentExcessCredits data in EnrolmentExcessCreditsList)
                if (!_EnrolmentExcessCreditsDict.ContainsKey(data.StudentID))
                    _EnrolmentExcessCreditsDict.Add(data.StudentID, data);

            // 比對資料放入DataTable
            _dtTable.Clear();
            _dtTableNonPass.Clear();
            List<string> nameList = new List<string>();

            nameList.Add("學號");
            nameList.Add("班級");
            nameList.Add("座號");

            List<string> ColNameList = new List<string>();
            ColNameList.Add("均衡學習");
            ColNameList.Add("服務學習");
            ColNameList.Add("體適能");
            ColNameList.Add("競賽表現");
            ColNameList.Add("檢定證照");
            ColNameList.Add("獎勵紀錄");
            ColNameList.Add("幹部任期");

            foreach (string name in ColNameList)
                nameList.Add(name);

            // 填入 DataTable
            foreach (string name in nameList)
            {
                _dtTable.Columns.Add(name);
                _dtTableNonPass.Columns.Add(name);
            }

            _TotalCount = _passCount = _noPassCount = 0;
            foreach (int sid in _StudentExcessCreditDict.Keys)
            {
                DataRow dr = _dtTable.NewRow();
                dr["學號"] = _StudentExcessCreditDict[sid].StudentNumber;
                dr["班級"] = _StudentExcessCreditDict[sid].ClassName;
                dr["座號"] = _StudentExcessCreditDict[sid].SeatNo;

                // 填入比序資料
                if (_EnrolmentExcessCreditsDict.ContainsKey(sid))
                {
                    UDT_EnrolmentExcessCredits udata = _EnrolmentExcessCreditsDict[sid];
                    foreach (string colName in ColNameList)
                    {
                        switch (colName)
                        {
                            case "均衡學習":
                                _StudentExcessCreditDict[sid].ExcessCreditDict.Add(colName, udata.Balanced);
                                dr[colName] = udata.Balanced;
                                break;
                            case "服務學習":
                                _StudentExcessCreditDict[sid].ExcessCreditDict.Add(colName, udata.Services);
                                dr[colName] = udata.Services;
                                break;
                            case "體適能":
                                _StudentExcessCreditDict[sid].ExcessCreditDict.Add(colName, udata.Fitness);
                                dr[colName] = udata.Fitness;
                                break;
                            case "競賽表現": 
                                _StudentExcessCreditDict[sid].ExcessCreditDict.Add(colName, udata.Competition);
                                dr[colName] = udata.Competition;
                                break;
                            case "檢定證照": 
                                _StudentExcessCreditDict[sid].ExcessCreditDict.Add(colName, udata.Verification);
                                dr[colName] = udata.Verification;
                                break;
                            case "獎勵紀錄":
                                _StudentExcessCreditDict[sid].ExcessCreditDict.Add(colName, udata.Merit);
                                dr[colName] = udata.Merit;
                                break;
                            case "幹部任期":
                                _StudentExcessCreditDict[sid].ExcessCreditDict.Add(colName, udata.Term);
                                dr[colName] = udata.Term;
                                break;                        
                        }
                    }

                    bool pass = true;

                    // 檢查是否有全部輸入
                    foreach (string str in _StudentExcessCreditDict[sid].ExcessCreditDict.Values)
                    {
                        if (string.IsNullOrEmpty(str))
                        {
                            pass = false;
                            break;
                        }
                    }
                    _StudentExcessCreditDict[sid].InputPass = pass;

                    if (pass)
                        _passCount++;
                    else
                        _noPassCount++;
                }
                _TotalCount++;

                if (_StudentExcessCreditDict[sid].InputPass == false)
                {
                    DataRow dr1 = _dtTableNonPass.NewRow();
                    foreach (string name in nameList)
                    {
                        dr1[name] = dr[name];
                    }
                    _dtTableNonPass.Rows.Add(dr1);
                }                    

                _dtTable.Rows.Add(dr);
            }
                    
        }

        private void CheckExcessCreditsForm_Load(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            _bgWorker.RunWorkerAsync();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            ExportData();
            btnExport.Enabled = true;
        }

        /// <summary>
        /// 匯出資料
        /// </summary>
        private void ExportData()
        { 
            Workbook wb = new Workbook ();

            if(chkInput.Checked)
                wb.Worksheets[0].Cells.ImportDataTable(_dtTableNonPass, true, "A1");
            else
                wb.Worksheets[0].Cells.ImportDataTable(_dtTable,true,"A1");
            Utility.CompletedXls("比序積分檢查", wb);
        
        }

        private void chkInput_CheckedChanged(object sender, EventArgs e)
        {
            LoadDataTableToDataGrid();
        }
    }
}
