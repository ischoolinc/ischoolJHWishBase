using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Permission;
using FISCA.Presentation;

namespace Example_ExportExcessCreditsBaseData
{
    public class Program
    {
        [MainMethod()]
        public static void Main()
        {

            // 學生會考報名檔
            MotherForm.RibbonBarItems["教務作業", "十二年國教"]["學生會考報名檔"].Enable = UserAcl.Current["ischoolJHWishBase.ExportExcessCreditsBaseData"].Executable;
            MotherForm.RibbonBarItems["教務作業", "十二年國教"]["學生會考報名檔"].Click += delegate
            {
                ExportExcessCreditsBaseData eecbd = new ExportExcessCreditsBaseData(false);
                eecbd.ShowDialog();
            };

            // 
            K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"]["報表"]["學籍相關報表"]["學生會考報名檔"].Enable = UserAcl.Current["ischoolJHWishBase.ExportExcessCreditsBaseDataS"].Executable;
            K12.Presentation.NLDPanels.Student.RibbonBarItems["資料統計"]["報表"]["學籍相關報表"]["學生會考報名檔"].Click += delegate
            {
                ExportExcessCreditsBaseData eecbd = new ExportExcessCreditsBaseData(true);
                eecbd.ShowDialog();
            };

            // 學生會考報名檔
            Catalog catalog04 = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            catalog04.Add(new RibbonFeature("ischoolJHWishBase.ExportExcessCreditsBaseData", "學生會考報名檔"));

            // 學生會考報名檔
            Catalog catalog05 = RoleAclSource.Instance["學生"]["報表"];
            catalog05.Add(new RibbonFeature("ischoolJHWishBase.ExportExcessCreditsBaseDataS", "學生會考報名檔"));
        }
    }
}
