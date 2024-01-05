using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using K12.Presentation;
using FISCA.Presentation;
using FISCA.Permission;
using System.ComponentModel;
using ischoolJHWishBase.DAO;
using System.Windows.Forms;
using K12.Data;
using System.Data;
using ischoolJHWishBase.ExportGradeSelect;

namespace ischoolJHWishBase
{
    /// <summary>
    /// 十二年國教
    /// </summary>
    /// 
    public class Program
    {
        private static BackgroundWorker _bgWorker;

        [MainMethod()]
        public static void Main()
        {
            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);
            _bgWorker.RunWorkerAsync();

            // 更新 UDS方式
            if (!FISCA.RTContext.IsDiagMode)
                FISCA.ServerModule.AutoManaged("http://module.ischool.com.tw/module/137/KH_JH_EnrolmentExcessUDM/udm.xml");

            // 檢查學校名稱是否是高雄，主要是部分功能只有高雄使用
            //2021-02-09 Cyn，增加一所學校j.ccafps.kh.edu.tw
            bool isLoadKh = false;
            if (K12.Data.School.ChineseName.Contains("高雄") || K12.Data.School.ChineseName.Contains("附中") || K12.Data.School.ChineseName.Contains("中正國防幹部預備學校"))
                isLoadKh = true;

            // 高雄特有功能
            if (isLoadKh)
            {
                #region 志願比序開放時間、比序積分查詢
                // 志願比序開放時間
                MotherForm.RibbonBarItems["教務作業", "十二年國教"]["志願比序開放時間"].Enable = UserAcl.Current["ischoolJHWishBase.WishJoinForm"].Executable;
                MotherForm.RibbonBarItems["教務作業", "十二年國教"]["志願比序開放時間"].Click += delegate
                {
                    WishJoinForm wf = new WishJoinForm();
                    wf.ShowDialog();
                };

                // 比序積分查詢
                MotherForm.RibbonBarItems["教務作業", "十二年國教"]["志願比序輸入檢查"].Enable = UserAcl.Current["ischoolJHWishBase.CheckExcessCreditsForm"].Executable;
                MotherForm.RibbonBarItems["教務作業", "十二年國教"]["志願比序輸入檢查"].Click += delegate
                {
                    CheckExcessCreditsForm cecf = new CheckExcessCreditsForm();
                    cecf.ShowDialog();
                };

                // 志願比序開放時間
                Catalog catalog01 = RoleAclSource.Instance["教務作業"]["功能按鈕"];
                catalog01.Add(new RibbonFeature("ischoolJHWishBase.WishJoinForm", "志願比序開放時間"));

                // 比序積分查詢
                Catalog catalog02 = RoleAclSource.Instance["教務作業"]["功能按鈕"];
                catalog02.Add(new RibbonFeature("ischoolJHWishBase.CheckExcessCreditsForm", "志願比序輸入檢查"));
                #endregion

                #region 產生志願比序資料
                // 產生志願比序資料
                MotherForm.RibbonBarItems["教務作業", "十二年國教"]["產生志願比序資料"].Enable = UserAcl.Current["ischoolJHWishBase.ExportExcessCreditsData"].Executable;
                MotherForm.RibbonBarItems["教務作業", "十二年國教"]["產生志願比序資料"].Click += delegate
                {

                    //產生可選擇年級Form
                    SelectGradeToExport selectGradeForm = new SelectGradeToExport();
                    selectGradeForm.ShowDialog();
                    // ExportExcessCreditsData eecd = new ExportExcessCreditsData();
                    //eecd.Run();
                };

                // 產生志願比序資料
                Catalog catalog03 = RoleAclSource.Instance["教務作業"]["功能按鈕"];
                catalog03.Add(new RibbonFeature("ischoolJHWishBase.ExportExcessCreditsData", "產生志願比序資料"));
                #endregion

                #region 計算比序積分
                // 產生志願比序資料
                MotherForm.RibbonBarItems["教務作業", "十二年國教"]["計算比序積分"].Enable = UserAcl.Current["ischoolJHWishBase.ExportExcessCreditsDataCalc"].Executable;
                MotherForm.RibbonBarItems["教務作業", "十二年國教"]["計算比序積分"].Click += delegate
                {
                    string sql = "select id from student where status in (1)";
                    DataTable table = Utility.Q.Select(sql);
                    List<string> ids = new List<string>();
                    foreach (DataRow row in table.Rows)
                        ids.Add(row["id"] + "");

                    MotherForm.SetStatusBarMessage("");
                    if (Control.ModifierKeys == Keys.Shift)
                    {
                        MotherForm.SetStatusBarMessage("只算選擇的學生喔!!!");
                        ids = NLDPanels.Student.SelectedSource;
                    }

                    new ischoolJHWishBase.Calc.CalcMainForm(ids).ShowDialog();
                };

                // 產生志願比序資料
                Catalog catalog04 = RoleAclSource.Instance["教務作業"]["功能按鈕"];
                catalog04.Add(new RibbonFeature("ischoolJHWishBase.ExportExcessCreditsDataCalc", "計算比序積分"));
                #endregion
            }
        }

        static void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        static void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UDTTransfer.UDTEnrolmentExcessCreditsSelect();
            UDTTransfer.UDTEnrolmentExcessInputDateSelect();
        }
    }
}
