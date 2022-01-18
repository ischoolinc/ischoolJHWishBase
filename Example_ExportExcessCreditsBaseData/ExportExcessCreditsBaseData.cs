using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Xml.Linq;
using K12.Data;
using K12.Data.Configuration;
using Aspose.Cells;
using System.IO;

namespace ExportExcessCreditsBaseData
{
    /// <summary>
    /// 產生志願學生基本資料ExportExcessCreditsBaseData_Load
    /// </summary>
    public partial class ExportExcessCreditsBaseData : BaseForm
    {
        BackgroundWorker _bgWorkerLoad;
        BackgroundWorker _bgWorkerRun;
        List<UDTConfig> _UDTConfigList;
        DataTable _dtTable;
        // 資料對照用
        Dictionary<string, string> _SelectMappingDict1;
        Dictionary<string, string> _SelectMappingDict2;
        Dictionary<string, string> _SelectMappingDict3;

        // 資料存取
        List<string> _StudGradeList;
        Dictionary<string, StudentRecord> _StudentDict;
        Dictionary<string, PhoneRecord> _PhoneDict;
        Dictionary<string, ParentRecord> _ParentDict;

        Dictionary<string, AddressRecord> _AddressRecDict;
        Dictionary<string, string> _ClassNameDict;
        Dictionary<string, List<string>> _StudTagDict;

        string conf_name = "輔導志願比序學生基本資料設定";
        string rootName = "輔導志願比序基本資料設定";

        string strType1, strType2, strType3, strType4, strType5, strType6, strType7;
        Dictionary<string, string> _strStudTagMappingDict1;
        Dictionary<string, string> _strStudTagMappingDict2;

        List<string> _SelectStudentList;
        bool _isStudent = false;

        // 設定檔
        XElement _ConfigXML = null;

        List<string> _StudentTagList;


        public ExportExcessCreditsBaseData(bool isStudent)
        {
            InitializeComponent();
            _isStudent = isStudent;

            _StudGradeList = new List<string>();
            _dtTable = new DataTable();
            _StudentDict = new Dictionary<string, StudentRecord>();
            _PhoneDict = new Dictionary<string, PhoneRecord>();
            _ParentDict = new Dictionary<string, ParentRecord>();
            _AddressRecDict = new Dictionary<string, AddressRecord>();
            _ClassNameDict = new Dictionary<string, string>();
            _StudTagDict = new Dictionary<string, List<string>>();
            _strStudTagMappingDict1 = new Dictionary<string, string>();
            _strStudTagMappingDict2 = new Dictionary<string, string>();

            dgSel1cbo1.DropDownStyle = dgSel1cbo2.DropDownStyle = dgSel2cbo1.DropDownStyle = dgSel2cbo2.DropDownStyle = ComboBoxStyle.DropDownList;
            _UDTConfigList = new List<UDTConfig>();
            _StudentTagList = new List<string>();

            _bgWorkerLoad = new BackgroundWorker();
            _bgWorkerLoad.DoWork += new DoWorkEventHandler(_bgWorkerLoad_DoWork);
            _bgWorkerLoad.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorkerLoad_RunWorkerCompleted);

            _bgWorkerRun = new BackgroundWorker();
            _bgWorkerRun.DoWork += new DoWorkEventHandler(_bgWorkerRun_DoWork);
            _bgWorkerRun.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorkerRun_RunWorkerCompleted);
        }

        private void ExportExcessCreditsBaseData_Load(object sender, EventArgs e)
        {
            btnExport.Enabled = false;

            int school = 108;
            if (int.TryParse(School.DefaultSchoolYear, out school))
            {
                integerInput1.Value = school + 1;
            }

            _bgWorkerLoad.RunWorkerAsync();
        }

        void _bgWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            // 取得學生類別
            _StudentTagList = QueryTransfer.GetStudentTagList();

            _SelectMappingDict1 = tool.GetExcessCreditsBase1();
            _SelectMappingDict2 = tool.GetExcessCreditsBase2();
            _SelectMappingDict3 = tool.GetExcessCreditsBase3();

            // 取得設定檔           
            _UDTConfigList = UDTTransfer.UDTConfigSelectByName(conf_name);
            if (_UDTConfigList.Count > 0)
            {
                UDTConfig cd = _UDTConfigList[0];
                if (!string.IsNullOrWhiteSpace(cd.Data))
                {
                    try
                    {
                        _ConfigXML = XElement.Parse(cd.Data);
                    }
                    catch
                    {

                    }

                }
            }
        }

        void _bgWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 填入可選項目
            cboType1.Items.Clear();
            cboType2.Items.Clear();
            cboType3.Items.Clear();
            cboType4.Items.Clear();
            cboType5.Items.Clear();
            cboType6.Items.Clear();
            cboType7.Items.Clear();
            cboType1.Items.Add("");
            cboType2.Items.Add("");
            cboType3.Items.Add("");
            cboType4.Items.Add("");
            cboType5.Items.Add("");
            cboType6.Items.Add("");
            cboType7.Items.Add("");
            dgSel1cbo1.Items.Clear();
            dgSel1cbo2.Items.Clear();
            dgSel2cbo1.Items.Clear();
            dgSel2cbo2.Items.Clear();

            cboType5.Items.Add("戶籍");
            cboType5.Items.Add("聯絡");

            cboType6.Items.Add("戶籍電話");
            cboType6.Items.Add("聯絡電話");

            cboType7.Items.Add("父親");
            cboType7.Items.Add("母親");
            cboType7.Items.Add("監護人");

            // 地區
            foreach (string name in _SelectMappingDict1.Keys)
                cboType1.Items.Add(name);

            // 低收選項
            foreach (string name in _StudentTagList)
            {
                cboType2.Items.Add(name);
                cboType3.Items.Add(name);
                cboType4.Items.Add(name);
                dgSel1cbo1.Items.Add(name);
                dgSel2cbo1.Items.Add(name);
            }

            foreach (string name in _SelectMappingDict2.Keys)
                dgSel1cbo2.Items.Add(name);

            foreach (string name in _SelectMappingDict3.Keys)
                dgSel2cbo2.Items.Add(name);

            // 放入設定值
            LoadConfigData();

            btnExport.Enabled = true;
        }

        // 載入解析 XML
        private void LoadConfigData()
        {
            if (_ConfigXML != null)
            {
                XElement elm = _ConfigXML;
                cboType1.Text = tool.xmlParse1(elm, "地區代碼");
                cboType2.Text = tool.xmlParse1(elm, "低收入戶");
                cboType3.Text = tool.xmlParse1(elm, "中低收入戶");
                cboType4.Text = tool.xmlParse1(elm, "失業勞工");
                cboType5.Text = tool.xmlParse1(elm, "地址");
                cboType6.Text = tool.xmlParse1(elm, "電話");
                cboType7.Text = tool.xmlParse1(elm, "家長");

                // 學生身分填入資料
                dgStudD1.Rows.Clear();
                if (elm.Element("學生身分") != null)
                {
                    foreach (XElement elmss1 in elm.Element("學生身分").Elements("item"))
                    {
                        int rowIdx = dgStudD1.Rows.Add();
                        dgStudD1.Rows[rowIdx].Cells[dgSel1cbo1.Index].Value = elmss1.Attribute("name").Value;
                        dgStudD1.Rows[rowIdx].Cells[dgSel1cbo2.Index].Value = elmss1.Attribute("value").Value;
                    }
                }

                // 身心障礙填入資料
                dgStudD2.Rows.Clear();
                if (elm.Element("身心障礙") != null)
                {
                    foreach (XElement elmss2 in elm.Element("身心障礙").Elements("item"))
                    {
                        int rowIdx = dgStudD2.Rows.Add();
                        dgStudD2.Rows[rowIdx].Cells[dgSel2cbo1.Index].Value = elmss2.Attribute("name").Value;
                        dgStudD2.Rows[rowIdx].Cells[dgSel2cbo2.Index].Value = elmss2.Attribute("value").Value;
                    }
                }

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // 儲存畫面資料
                if (SaveConfigData())
                {

                    // 記錄畫面設定
                    strType1 = strType2 = strType3 = strType4 = strType5 = strType6 = strType7 = "";
                    strType1 = cboType1.Text;
                    strType2 = cboType2.Text;
                    strType3 = cboType3.Text;
                    strType4 = cboType4.Text;
                    strType5 = cboType5.Text;
                    strType6 = cboType6.Text;
                    strType7 = cboType7.Text;

                    _strStudTagMappingDict1.Clear();
                    _strStudTagMappingDict2.Clear();

                    // 學生身分
                    foreach (DataGridViewRow dr in dgStudD1.Rows)
                    {
                        if (dr.IsNewRow)
                            continue;

                        string key = dr.Cells[dgSel1cbo1.Index].Value.ToString();
                        string val = dr.Cells[dgSel1cbo2.Index].Value.ToString();

                        if (!_strStudTagMappingDict1.ContainsKey(key))
                            _strStudTagMappingDict1.Add(key, "");

                        if (_SelectMappingDict2.ContainsKey(val))
                            _strStudTagMappingDict1[key] += _SelectMappingDict2[val];
                    }

                    // 身心障礙
                    foreach (DataGridViewRow dr in dgStudD2.Rows)
                    {
                        if (dr.IsNewRow)
                            continue;

                        string key = dr.Cells[dgSel2cbo1.Index].Value.ToString();
                        string val = dr.Cells[dgSel2cbo2.Index].Value.ToString();

                        if (!_strStudTagMappingDict2.ContainsKey(key))
                            _strStudTagMappingDict2.Add(key, "");

                        if (_SelectMappingDict3.ContainsKey(val))
                            _strStudTagMappingDict2[key] += _SelectMappingDict3[val];
                    }

                    // 產生資料
                    this.btnExport.Enabled = false;
                    _bgWorkerRun.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show("產生資料過程發生錯誤: " + ex.Message);
                btnExport.Enabled = true;
            }

        }
        void _bgWorkerRun_DoWork(object sender, DoWorkEventArgs e)
        {
            // 學生基本資料與相關資料
            _AddressRecDict.Clear();
            _ParentDict.Clear();
            _PhoneDict.Clear();
            _StudentDict.Clear();
            _dtTable.Clear();
            _ClassNameDict.Clear();

            // 學生畫面上所選，再排序過
            _SelectStudentList = QueryTransfer.StudentSortByClassSeatNo(K12.Presentation.NLDPanels.Student.SelectedSource);

            // 三,九年級，一般狀態學生
            _StudGradeList = QueryTransfer.GetStudeGrade3List();

            // 學生,來自學生所選
            if (_isStudent)
            {
                foreach (StudentRecord stud in Student.SelectByIDs(_SelectStudentList))
                    _StudentDict.Add(stud.ID, stud);
            }
            else
            {
                foreach (StudentRecord stud in Student.SelectByIDs(_StudGradeList))
                    _StudentDict.Add(stud.ID, stud);
            }

            // 班級
            foreach (ClassRecord rec in Class.SelectAll())
                _ClassNameDict.Add(rec.ID, rec.Name.Substring(1, rec.Name.Length - 1));

            // 地址
            foreach (AddressRecord rec in Address.SelectByStudentIDs(_StudGradeList))
                _AddressRecDict.Add(rec.RefStudentID, rec);

            // 父母
            foreach (ParentRecord rec in K12.Data.Parent.SelectByStudentIDs(_StudGradeList))
                _ParentDict.Add(rec.RefStudentID, rec);

            // 電話
            foreach (PhoneRecord rec in Phone.SelectByStudentIDs(_StudGradeList))
                _PhoneDict.Add(rec.RefStudentID, rec);

            // 學生類別
            _StudTagDict = QueryTransfer.GetStduentTagDict();

            // 填入DataColumn name 資料
            foreach (string name in tool.GetDataTableColumnsName())
                _dtTable.Columns.Add(name);

            List<string> tmptagList1 = new List<string>();
            List<string> tmptagList2 = new List<string>();

            List<string> exportStudentIDList = new List<string>();

            if (_isStudent)
                exportStudentIDList = _SelectStudentList;
            else
                exportStudentIDList = _StudGradeList;

            // 填入 DataTable
            foreach (string id in exportStudentIDList)
            {
                // 地區代碼、集報單位代碼、序號、學號、班級、座號、學生姓名、身分證統一編號、性別、出生年、出生月、出生日、
                // 畢業學校代碼、畢業年、畢肄業、學生身分、身心障礙、就學區、低收入戶、中低收入戶、失業勞工、資料授權、
                // 家長姓名、室內電話、行動電話、郵遞區號、地址

                //2022-01-18
                //考區代碼	集報單位代碼	序號	學號	班級	座號	考生姓名	身分證統一編號	性別	出生年(民國年)	出生月	出生日
                //畢(結)業學校代碼	畢(結)業年(民國年)	畢(結)業	考生身分	身心障礙	免試就學區	低收入戶	中低收入戶	失業勞工子女	
                //資料授權	家長姓名	市內電話	行動電話	郵遞區號	通訊地址
                DataRow dr = _dtTable.NewRow();

                if (_StudentDict.ContainsKey(id))
                {
                    dr["考區代碼"] = "";
                    if (_SelectMappingDict1.ContainsKey(strType1))
                        dr["考區代碼"] = _SelectMappingDict1[strType1];

                    dr["集報單位代碼"] = K12.Data.School.Code;

                    dr["學號"] = _StudentDict[id].StudentNumber;
                    dr["班級"] = "";
                    if (_ClassNameDict.ContainsKey(_StudentDict[id].RefClassID))
                        dr["班級"] = _ClassNameDict[_StudentDict[id].RefClassID].PadLeft(2, '0');

                    dr["座號"] = "";
                    if (_StudentDict[id].SeatNo.HasValue)
                        dr["座號"] = _StudentDict[id].SeatNo.Value.ToString().PadLeft(2, '0');

                    dr["考生姓名"] = _StudentDict[id].Name;
                    dr["身分證統一編號"] = _StudentDict[id].IDNumber.ToUpper();

                    dr["性別"] = "";
                    if (_StudentDict[id].Gender == "男")
                        dr["性別"] = "1";

                    if (_StudentDict[id].Gender == "女")
                        dr["性別"] = "2";

                    dr["出生年(民國年)"] = dr["出生月"] = dr["出生日"] = "";
                    if (_StudentDict[id].Birthday.HasValue)
                    {
                        dr["出生年(民國年)"] = (_StudentDict[id].Birthday.Value.Year - 1911).ToString().PadLeft(3, '0');
                        dr["出生月"] = (_StudentDict[id].Birthday.Value.Month).ToString().PadLeft(2, '0');
                        dr["出生日"] = (_StudentDict[id].Birthday.Value.Day).ToString().PadLeft(2, '0');
                    }

                    dr["畢(結)業學校代碼"] = K12.Data.School.Code;

                    dr["畢(結)業年(民國年)"] = integerInput1.Value;
                    dr["畢(結)業"] = "1";
                    dr["考生身分"] = "0";
                    dr["身心障礙"] = "0";
                    dr["低收入戶"] = "0";
                    dr["中低收入戶"] = "0";
                    dr["失業勞工子女"] = "0";

                    tmptagList1.Clear();
                    tmptagList2.Clear();

                    if (_StudTagDict.ContainsKey(id))
                    {

                        foreach (string name in _StudTagDict[id])
                        {
                            if (_strStudTagMappingDict1.ContainsKey(name))
                                tmptagList1.Add(_strStudTagMappingDict1[name]);

                            if (_strStudTagMappingDict2.ContainsKey(name))
                                tmptagList2.Add(_strStudTagMappingDict2[name]);

                        }

                        if (tmptagList1.Count > 0)
                            dr["考生身分"] = string.Join(",", tmptagList1.ToArray());

                        if (tmptagList2.Count > 0)
                            dr["身心障礙"] = string.Join(",", tmptagList2.ToArray());


                        if (_StudTagDict[id].Contains(strType2))
                            dr["低收入戶"] = "1";

                        if (_StudTagDict[id].Contains(strType3))
                            dr["中低收入戶"] = "1";

                        if (_StudTagDict[id].Contains(strType4))
                            dr["失業勞工子女"] = "1";
                    }

                    dr["資料授權"] = "1";

                    //室內電話,行動電話
                    dr["市內電話"] = "";
                    dr["行動電話"] = "";
                    if (_PhoneDict.ContainsKey(id))
                    {
                        if (strType6 == "戶籍電話")
                        {
                            dr["市內電話"] = tool.ParseTelStr(_PhoneDict[id].Permanent);
                        }
                        if (strType6 == "聯絡電話")
                        {
                            dr["市內電話"] = tool.ParseTelStr(_PhoneDict[id].Contact);
                        }
                        dr["行動電話"] = tool.ParseTelStr(_PhoneDict[id].Cell);
                    }

                    // 監護人
                    dr["家長姓名"] = "";
                    if (_ParentDict.ContainsKey(id))
                    {
                        if (strType7 == "父親")
                        {
                            dr["家長姓名"] = _ParentDict[id].FatherName;
                        }

                        if (strType7 == "母親")
                        {
                            dr["家長姓名"] = _ParentDict[id].MotherName;
                        }

                        if (strType7 == "監護人")
                        {
                            dr["家長姓名"] = _ParentDict[id].CustodianName;
                        }
                    }

                    // 通訊地址
                    dr["郵遞區號"] = "";
                    dr["通訊地址"] = "";
                    if (_AddressRecDict.ContainsKey(id))
                    {
                        if (strType5 == "聯絡")
                        {
                            dr["郵遞區號"] = _AddressRecDict[id].MailingZipCode;

                            dr["地址"] = _AddressRecDict[id].MailingCounty + _AddressRecDict[id].MailingTown + _AddressRecDict[id].MailingDistrict + _AddressRecDict[id].MailingArea + _AddressRecDict[id].MailingDetail;
                        }

                        if (strType5 == "戶籍")
                        {
                            dr["郵遞區號"] = _AddressRecDict[id].PermanentZipCode;
                            dr["通訊地址"] = _AddressRecDict[id].PermanentCounty + _AddressRecDict[id].PermanentTown + _AddressRecDict[id].PermanentDistrict + _AddressRecDict[id].PermanentArea + _AddressRecDict[id].PermanentDetail;
                        }

                    }
                }

                _dtTable.Rows.Add(dr);
            }

            // 取得樣板
            Workbook wb = new Workbook();
            wb.Open(new MemoryStream(Properties.Resources.基本資料樣板));

            // 取得樣板欄位索引
            Dictionary<string, int> ColNameDict = new Dictionary<string, int>();
            for (int idx = 0; idx <= wb.Worksheets[0].Cells.MaxDataColumn; idx++)
            {
                string name = wb.Worksheets[0].Cells[0, idx].StringValue;
                if (!ColNameDict.ContainsKey(name))
                    ColNameDict.Add(name, idx);
            }

            // 填入資料
            int rowIdx = 1;
            foreach (DataRow dr in _dtTable.Rows)
            {
                foreach (string name in tool.GetDataTableColumnsName())
                {
                    if (ColNameDict.ContainsKey(name))
                        wb.Worksheets[0].Cells[rowIdx, ColNameDict[name]].PutValue(dr[name].ToString());
                }

                rowIdx++;
            }

            e.Result = wb;
        }

        void _bgWorkerRun_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Workbook wb = (Workbook)e.Result;
            Utility.CompletedXls(string.Format("{0} 學生會考報名檔", integerInput1.Value), wb);
            this.Close();
        }

        // 儲存畫面資料轉 XML
        private bool SaveConfigData()
        {
            bool pass = true;
            // 檢查畫面資料是否有選
            foreach (DataGridViewRow row in dgStudD1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        row.ErrorText = "不允許空值!";
                        pass = false;
                    }
                }
            }

            // 檢查畫面資料是否有選
            foreach (DataGridViewRow row in dgStudD2.Rows)
            {
                if (row.IsNewRow)
                    continue;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        row.ErrorText = "不允許空值!";
                        pass = false;
                    }
                }
            }

            if (pass == false)
            {
                MsgBox.Show("畫面設定有錯誤，請檢查!");
                return pass;
            }

            XElement elm = new XElement(rootName);
            if (string.IsNullOrEmpty(cboType1.Text))
                elm.SetElementValue("地區代碼", "");
            else
                elm.SetElementValue("地區代碼", cboType1.Text);

            if (string.IsNullOrEmpty(cboType2.Text))
                elm.SetElementValue("低收入戶", "");
            else
                elm.SetElementValue("低收入戶", cboType2.Text);

            if (string.IsNullOrEmpty(cboType3.Text))
                elm.SetElementValue("中低收入戶", "");
            else
                elm.SetElementValue("中低收入戶", cboType3.Text);

            if (string.IsNullOrEmpty(cboType4.Text))
                elm.SetElementValue("失業勞工", "");
            else
                elm.SetElementValue("失業勞工", cboType4.Text);

            if (string.IsNullOrEmpty(cboType5.Text))
                elm.SetElementValue("地址", "");
            else
                elm.SetElementValue("地址", cboType5.Text);

            if (string.IsNullOrEmpty(cboType6.Text))
                elm.SetElementValue("電話", "");
            else
                elm.SetElementValue("電話", cboType6.Text);

            if (string.IsNullOrEmpty(cboType7.Text))
                elm.SetElementValue("家長", "");
            else
                elm.SetElementValue("家長", cboType7.Text);

            // 學生身分
            if (dgStudD1.Rows.Count > 0)
            {
                XElement elm1 = new XElement("學生身分");
                foreach (DataGridViewRow dr in dgStudD1.Rows)
                {
                    if (dr.IsNewRow)
                        continue;

                    string name = "", value = "";
                    if (dr.Cells[dgSel1cbo1.Index].Value != null)
                        name = dr.Cells[dgSel1cbo1.Index].Value.ToString();

                    if (dr.Cells[dgSel1cbo2.Index].Value != null)
                        value = dr.Cells[dgSel1cbo2.Index].Value.ToString();

                    if (name != "" && value != "")
                    {
                        XElement elm1s = new XElement("item");
                        elm1s.SetAttributeValue("name", name);
                        elm1s.SetAttributeValue("value", value);
                        elm1.Add(elm1s);
                    }
                }
                elm.Add(elm1);
            }
            // 身心障礙
            if (dgStudD2.Rows.Count > 0)
            {
                XElement elm2 = new XElement("身心障礙");
                foreach (DataGridViewRow dr in dgStudD2.Rows)
                {
                    if (dr.IsNewRow)
                        continue;

                    string name = "", value = "";
                    if (dr.Cells[dgSel2cbo1.Index].Value != null)
                        name = dr.Cells[dgSel2cbo1.Index].Value.ToString();

                    if (dr.Cells[dgSel2cbo2.Index].Value != null)
                        value = dr.Cells[dgSel2cbo2.Index].Value.ToString();

                    if (name != "" && value != "")
                    {
                        XElement elm2s = new XElement("item");
                        elm2s.SetAttributeValue("name", name);
                        elm2s.SetAttributeValue("value", value);
                        elm2.Add(elm2s);
                    }
                }
                elm.Add(elm2);
            }

            // 儲存資料
            UDTConfig conf = new UDTConfig();
            conf.Name = conf_name;
            conf.Data = elm.ToString();

            // 更新
            if (_UDTConfigList.Count > 0)
            {
                _UDTConfigList[0].Name = conf.Name;
                _UDTConfigList[0].Data = conf.Data;
                UDTTransfer.UDTConfigUpdate(_UDTConfigList);
            }
            else
            {
                // 新增
                List<UDTConfig> addList = new List<UDTConfig>();
                addList.Add(conf);
                UDTTransfer.UDTConfigInsert(addList);
            }
            return pass;
        }

        private void dgStudD1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                dgStudD1.Rows[e.RowIndex].ErrorText = "";
        }

        private void dgStudD2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                dgStudD2.Rows[e.RowIndex].ErrorText = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
