using JHSchool.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using FISCA.Data;
using System.Data;
using System.Xml.Linq;

namespace ischoolJHWishBase.Calc
{
    /// <summary>
    /// 保存學生比序計算的相關資料與計算結果。
    /// </summary>
    internal class StudentExcess
    {
        public StudentExcess()
        {
            DomainScore = new Dictionary<SemesterData, DomainScore>();
            ServiceLearning = new Dictionary<SemesterData, decimal>();
            Fitness = new Dictionary<int, FitnessDegree>();
            Cadre = new Dictionary<SemesterData, int>();
            Semesters = new SemesterDataCollection();
        }

        public string StudentID { get; set; }

        /// <summary>
        /// 全部的學期歷程。
        /// </summary>
        public SemesterDataCollection Semesters { get; set; }

        /// <summary>
        /// 取得前五學期。
        /// </summary>
        public SemesterDataCollection FiveSemester
        {
            get
            {
                return Semesters.GetSemesters(new List<int>(new int[] { 1, 2, 3, 4, 5 }));
            }
        }

        public SemesterDataCollection SixSemester
        {
            get
            {
                return Semesters.GetSemesters(new List<int>(new int[] { 1, 2, 3, 4, 5, 6 }));
            }
        }

        /// <summary>
        /// 領域成績。SemesterData 中不含年級資訊，年級統一為0。
        /// </summary>
        public Dictionary<SemesterData, DomainScore> DomainScore { get; set; }

        /// <summary>
        /// 領域成績積分。
        /// </summary>
        public decimal DomainScoreFinal { get; set; }

        /// <summary>
        /// 服務學習，資料表：K12.Service.Learning.Record。SemesterData 中不含年級資訊，年級統一為0。
        /// </summary>
        public Dictionary<SemesterData, decimal> ServiceLearning { get; set; }

        /// <summary>
        /// 服務學習積分。
        /// </summary>
        public decimal ServiceLearningFinal { get; set; }

        /// <summary>
        /// 體適能(ischool_student_fitness)。
        /// </summary>
        public Dictionary<int, FitnessDegree> Fitness { get; set; }
        /// <summary>
        /// 體適能積分。
        /// </summary>
        public decimal FitnessFinal { get; set; }

        /// <summary>
        /// 學生幹部紀錄，每學期擔任了多少幹部。SemesterData 中不含年級資訊，年級統一為0。
        ///_itemCountDict = Util.GetStudentCount1ByStudentIDList(studenIDList);
        /// </summary>
        public Dictionary<SemesterData, int> Cadre { get; set; }

        /// <summary>
        /// 幹部紀錄積分。
        /// </summary>
        public decimal CadreFinal { get; set; }

        //獎勵明細 (不需計算)
        //JHMeritRecord
    }


}
