using FISCA.Presentation;
using FISCA.Presentation.Controls;
using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ischoolJHWishBase.DAO;
using ExcessCredits = ischoolJHWishBase.DAO.UDT_EnrolmentExcessCredits;
using FISCA.UDT;
using DevComponents.DotNetBar.Controls;

namespace ischoolJHWishBase.Calc
{
    public partial class CalcMainForm : BaseForm
    {
        private BackgroundWorker MainWorker = null;

        private List<string> StudentIDArray;

        public CalcMainForm(List<string> studentIds)
        {
            InitializeComponent();
            StudentIDArray = studentIds;

            dataGridViewX1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridViewX1);
            row.Cells[0].Value = "均衡學習";
            row.Cells[1].Value = @"健體、藝術、綜合及科技四個領域擇優三個領域，5學期平均成績達60分者，3個領域10分，2個領域6分，1個領域3分。";
            row.Cells[2].Value = "10分";
           
            dataGridViewX1.Rows.Add(row);

            row = new DataGridViewRow();
            row.CreateCells(dataGridViewX1);
            row.Cells[0].Value = "體適能";
            row.Cells[1].Value = @"單項中等以上每學年3分。身心障礙、重大傷病及體弱學生，比照單項中等以上計分。";
            row.Cells[2].Value = "20分";
            dataGridViewX1.Rows.Add(row);

            row = new DataGridViewRow();
            row.CreateCells(dataGridViewX1);
            row.Cells[0].Value = "服務學習";
            // row.Cells[1].Value = "以學年為單位，每3小時計1分，每學年上限4分，未滿3小時部份不予採計。\n\n(目前系統計算方式為：因疫情影響，110學年度入學學生採計以學年為單位，每滿3小時調整為採計2分，未滿3小時仍維持不予採計，並取消每一學年採計上限，惟三學年採計上限仍為10分)\n\n★非110學年度入學學生，請先自行計算，系統將於113學年度調整為原計算方式)";
             row.Cells[1].Value = "以學年為單位，每3小時計1分，每學年上限4分，未滿3小時部份不予採計。";
            row.Cells[2].Value = "10分";
            dataGridViewX1.Rows.Add(row);

            row = new DataGridViewRow();
            row.CreateCells(dataGridViewX1);
            row.Cells[0].Value = "幹部任期";
            row.Cells[1].Value = @"班級、社團（社長）或全校性幹部任滿1學期2分。";
            row.Cells[2].Value = "10分";
            dataGridViewX1.Rows.Add(row);
        }

        private void CalcMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                MainWorker = new BackgroundWorker();
                MainWorker.WorkerReportsProgress = true;
                MainWorker.DoWork += MainWorker_DoWork;
                MainWorker.RunWorkerCompleted += MainWorker_RunWorkerCompleted;
                MainWorker.ProgressChanged += MainWorker_ProgressChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("啟動發生錯誤：" + ex.Message);
                Close();
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            MainWorker.RunWorkerAsync();
            btnCalc.Enabled = false;
        }

        private void MainWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (StudentIDArray.Count <= 0)
                return;

            List<StudentExcess> students = StudentIDArray.ConvertAll(x => new StudentExcess() { StudentID = x });

            // 取得學生年級 (用來判斷服務學習時數要怎麼計算)
            students.GetGradeYear();
            MainWorker.ReportProgress(5);
            //下載相關計算所需資料。
            students.FillSemesterHistory();
            MainWorker.ReportProgress(10);
            students.FillServiceLearning(); //下載服務學習資料。
            MainWorker.ReportProgress(20);
            students.FillCadre();   //下載幹部資料。
            MainWorker.ReportProgress(30);
            students.FillFitness(); //下載體適能資料。
            MainWorker.ReportProgress(40);
            students.FillDomainScore(); //下載領域成績資料。
            MainWorker.ReportProgress(50);

            //開始計算比序積分。
            students.CalcServiceLearning(); //計算服務學習比序積分。
            students.CalcCadre();   //計算幹部比序積分。
            students.CalcFitness(); //計算體適能比序積分。 
            students.CalcDomainScore(); //計算領域成績比序積分。
            MainWorker.ReportProgress(55);

            //載入積分table資料
            AccessHelper access = new AccessHelper();
            string cond = string.Format("ref_student_id in ({0})", students.ToPrimaryKeyStringList());
            List<ExcessCredits> credits = access.Select<ExcessCredits>(cond);

            // Dictionary<string, ExcessCredits> creditLookup = credits.ToDictionary(x => x.StudentID.ToString());
            Dictionary<string, ExcessCredits> creditLookup = new Dictionary<string, ExcessCredits>();
            List<ExcessCredits> saveList = new List<ExcessCredits>();

          
            foreach (ExcessCredits data in credits)
            {
                string StudentID = data.StudentID.ToString();
                if (!creditLookup.ContainsKey(StudentID))
                    creditLookup.Add(StudentID, data);
                else
                {
                    // 如果有重覆刪除資料
                    data.Deleted = true;
                    saveList.Add(data);
                }
            }
           
            //本次計算結果 
            foreach (StudentExcess student in students)
            {
                ExcessCredits credit = new ExcessCredits();
                //如果table包含本次計算的student_id
                if (creditLookup.ContainsKey(student.StudentID))
                    credit = creditLookup[student.StudentID];
                //如果table裡沒有包含計算結果資料>>>>加入  
                else
                    credit.StudentID = int.Parse(student.StudentID);

                credit.Balanced = student.DomainScoreFinal.ToString();
                credit.Services = student.ServiceLearningFinal.ToString();
                credit.Term = student.CadreFinal.ToString();
                credit.Fitness = student.FitnessFinal.ToString();

                saveList.Add(credit);
            }
           
            List<string> changeUid = saveList.SaveAll();
        }

        private void MainWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MotherForm.SetStatusBarMessage("積分計算中…", e.ProgressPercentage);
        }

        private void MainWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MotherForm.SetStatusBarMessage("積分計算完成。", 100);
                if (e.Error != null)
                    throw e.Error;

                MessageBox.Show("計算完成！");
                //後續處理工作。
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnCalc.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
