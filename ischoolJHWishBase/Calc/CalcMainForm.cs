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
        }

        private void CalcMainForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
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
    }
}
