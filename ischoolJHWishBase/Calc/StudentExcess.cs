using JHSchool.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ischoolJHWishBase.Calc
{
    /// <summary>
    /// 保存學生比序計算的相關資料與計算結果。
    /// </summary>
    internal class StudentExcess
    {
        public StudentExcess()
        {
            SemesterScores = new Dictionary<SemesterData, ExpandoObject>();
        }

        public Dictionary<SemesterData, ExpandoObject> SemesterScores { get; set; }

        /// <summary>
        /// 服務學習，資料表：K12.Service.Learning.Record。
        /// </summary>
        public Dictionary<SemesterData, List<ExpandoObject>> ServiceLearning { get; set; }

        //體適能
        //ischool_student_fitness
        public Dictionary<SemesterData, List<ExpandoObject>> Fitness { get; set; }

        // 取得學生幹部紀錄
        //_itemCountDict = Util.GetStudentCount1ByStudentIDList(studenIDList);
        public Dictionary<SemesterData, List<ExpandoObject>> Cadre { get; set; }

        //獎勵明細 (不需計算)
        //JHMeritRecord
    }
}
