using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ischoolJHWishBase.Calc
{
    internal static class StudentExcessLoadExtend
    {
        /// <summary>
        /// 取得學期歷程資料。
        /// </summary>
        /// <param name="students"></param>
        public static void FillSemesterHistory(this List<StudentExcess> students)
        {
            Dictionary<string, XElement> dicSemsHistory = GetSemesterHistory(students);

            students.ForEach(x => //將學生的學期歷程 Xml 轉換為 SemesterDataCollection。
            {
                SemesterDataCollection semester = new SemesterDataCollection();

                if (dicSemsHistory.ContainsKey(x.StudentID))
                {
                    XElement xmlsems = dicSemsHistory[x.StudentID];

                    foreach (XElement sems in xmlsems.Elements("History"))
                    {
                        //<History GradeYear="2" SchoolYear="96" Semester="2"/>
                        int sy = int.Parse(sems.Attribute("SchoolYear").Value);
                        int ss = int.Parse(sems.Attribute("Semester").Value);
                        int gy = int.Parse(sems.Attribute("GradeYear").Value);

                        semester.Add(new SemesterData(gy, sy, ss));
                    }
                }

                x.Semesters = semester;
            });
        }

        private static Dictionary<string, XElement> GetSemesterHistory(List<StudentExcess> students)
        {
            if (students == null || students.Count <= 0)
                return new Dictionary<string, XElement>();

            string sql = "select id, sems_history from student where id in ({0}) ";
            sql = string.Format(sql, students.ToPrimaryKeyStringList());

            DataTable table = Utility.Q.Select(sql);
            Dictionary<string, XElement> dicSemsHistory = new Dictionary<string, XElement>();
            foreach (DataRow row in table.Rows)
            {
                string id = row["id"] + "";
                string xml = row["sems_history"] + "";

                if (string.IsNullOrWhiteSpace(xml))
                    continue;

                dicSemsHistory.Add(id, XElement.Parse(string.Format("<R>{0}</R>", xml)));
            }

            return dicSemsHistory;
        }

        /// <summary>
        /// 取得學生服務學習時數。
        /// </summary>
        public static void FillServiceLearning(this List<StudentExcess> students)
        {
            //資料表：K12.Service.Learning.Record
            if (students == null || students.Count <= 0)
                return;

            string sql = @"select ref_student_id, school_year, semester, sum(hours) hours
                                        from $k12.service.learning.record 
                                        where ref_student_id in ({0}) and not school_year is null and not semester is null
                                        group by ref_student_id,school_year,semester 
                                        order by ref_student_id, school_year, semester";

            sql = string.Format(sql, students.ToPrimaryKeyStringList());

            DataTable table = Utility.Q.Select(sql);

            //服務學期資料 Lookup
            //Dictionary<string, StudentExcess> StudentLookup = students.ToDictionary(x => x.StudentID);

            Dictionary<string, StudentExcess> StudentLookup = new Dictionary<string, StudentExcess>();
            foreach (StudentExcess data in students)
                if (!StudentLookup.ContainsKey(data.StudentID))
                    StudentLookup.Add(data.StudentID, data);

            foreach (DataRow row in table.Rows)
            {
                string id = row["ref_student_id"] + "";
                int syear = int.Parse(row["school_year"] + "");
                int sems = int.Parse(row["semester"] + "");
                decimal hours = decimal.Parse(row["hours"] + "");

                if (!StudentLookup.ContainsKey(id))
                    continue;

                StudentExcess se = StudentLookup[id];
                SemesterData sd = new SemesterData(0, syear, sems);

                se.ServiceLearning[sd] = hours;
            }
        }

        /// <summary>
        /// 取得學生幹部資料計數。
        /// </summary>
        public static void FillCadre(this List<StudentExcess> students)
        {
            //資料表：K12.Service.Learning.Record
            if (students == null || students.Count <= 0)
                return;

            string sql = @"select ref_student_id,school_year,semester,count(id) as count 
                                        from discipline where ref_student_id in({0}) and reason like '%[幹部]%' 
                                        group by ref_student_id,school_year,semester";

            sql = string.Format(sql, students.ToPrimaryKeyStringList());
            DataTable table = Utility.Q.Select(sql);

//            Dictionary<string, StudentExcess> StudentLookup = students.ToDictionary(x => x.StudentID);

            Dictionary<string, StudentExcess> StudentLookup = new Dictionary<string, StudentExcess>();
            foreach (StudentExcess data in students)
                if (!StudentLookup.ContainsKey(data.StudentID))
                    StudentLookup.Add(data.StudentID, data);


            foreach (DataRow row in table.Rows)
            {
                string id = row["ref_student_id"].ToString();
                int sy = int.Parse(row["school_year"].ToString());
                int ss = int.Parse(row["semester"].ToString());
                int count = int.Parse(row["count"].ToString());

                if (!StudentLookup.ContainsKey(id))
                    continue;

                StudentExcess stu = StudentLookup[id];
                SemesterData sd = new SemesterData(0, sy, ss);

                stu.Cadre[sd] = count;
            }
        }

        /// <summary>
        /// 取得學生體適能資料。
        /// </summary>
        public static void FillFitness(this List<StudentExcess> students)
        {
            //資料表：ischool_student_fitness
            if (students == null || students.Count <= 0)
                return;

            string sql = @"select ref_student_id,school_year, height_degree,weight_degree,
                                            sit_and_reach_degree,standing_long_jump_degree,sit_up_degree,cardiorespiratory_degree
                                        from $ischool_student_fitness 
                                        where ref_student_id in({0})
                                        order by school_year";

            sql = string.Format(sql, students.ToPrimaryKeyStringList());
            DataTable table = Utility.Q.Select(sql);

         //   Dictionary<string, StudentExcess> StudentLookup = students.ToDictionary(x => x.StudentID);

            Dictionary<string, StudentExcess> StudentLookup = new Dictionary<string, StudentExcess>();
            foreach (StudentExcess data in students)
                if (!StudentLookup.ContainsKey(data.StudentID))
                    StudentLookup.Add(data.StudentID, data);


            foreach (DataRow row in table.Rows)
            {
                string id = row["ref_student_id"] + "";
                int school_year = int.Parse(row["school_year"] + "");
                string height = row["height_degree"] + "";
                string weight = row["weight_degree"] + "";
                string sit_and_reach = row["sit_and_reach_degree"] + "";
                string standing_long_jump = row["standing_long_jump_degree"] + "";
                string sit_up = row["sit_up_degree"] + "";
                string cardiorespiratory = row["cardiorespiratory_degree"] + "";

                if (!StudentLookup.ContainsKey(id))
                    continue;

                StudentExcess stu = StudentLookup[id];

                FitnessDegree fitness = new FitnessDegree();
                //fitness.Height = height;
                //fitness.Weight = weight;
                fitness.SitAndReach = sit_and_reach;
                fitness.StandingLongJump = standing_long_jump;
                fitness.SitUp = sit_up;
                fitness.Cardiorespiratory = cardiorespiratory;
                fitness.Collect();

                stu.Fitness[school_year] = fitness;
            }
        }

        public static void FillDomainScore(this List<StudentExcess> students)
        {
            //資料表：ischool_student_fitness
            if (students == null || students.Count <= 0)
                return;

            string sql = @"select ref_student_id,school_year,semester,score_info
                                        from sems_subj_score
                                        where ref_student_id in({0})
                                        order by school_year, semester";

            sql = string.Format(sql, students.ToPrimaryKeyStringList());
            DataTable table = Utility.Q.Select(sql);

          //  Dictionary<string, StudentExcess> StudentLookup = students.ToDictionary(x => x.StudentID);

            Dictionary<string, StudentExcess> StudentLookup = new Dictionary<string, StudentExcess>();
            foreach (StudentExcess data in students)
                if (!StudentLookup.ContainsKey(data.StudentID))
                    StudentLookup.Add(data.StudentID, data);

            foreach (DataRow row in table.Rows)
            {
                string id = row["ref_student_id"] + "";
                int school_year = int.Parse(row["school_year"] + "");
                int semester = int.Parse(row["semester"] + "");
                string score_info = row["score_info"] + "";

                if (!StudentLookup.ContainsKey(id))
                    continue;

                StudentExcess stu = StudentLookup[id];
                SemesterData sd = new SemesterData(0, school_year, semester);
                DomainScore ds = ParseDomainScore(score_info);

                stu.DomainScore[sd] = ds;
            }
        }

        private static DomainScore ParseDomainScore(string rawData)
        {
            DomainScore objDS = new DomainScore();
            string xmlString = string.Format("<root>{0}</root>", rawData);
            XElement xmlDom = XElement.Parse(xmlString);

            foreach (XElement ds in xmlDom.XPathSelectElements("Domains/Domain"))
            {
                if (string.IsNullOrWhiteSpace(ds.Attribute("成績").Value))
                    continue;

                string name = ds.Attribute("領域").Value;
                decimal score = decimal.Parse(ds.Attribute("成績").Value);

                objDS[name] = score;
            }

            //解析領域成績。
            return objDS;
        }
        /// <summary>
        /// 轉換成 PrimaryKey 的清單，例：'1','3','5'
        /// </summary>
        /// <param name="students"></param>
        public static string ToPrimaryKeyStringList(this List<StudentExcess> students)
        {
            List<string> pks = students.ConvertAll(x => x.StudentID);

            if (pks.Count <= 0)
                return string.Empty;
            else
                return "'" + string.Join("','", pks.ToArray()) + "'";
        }

        /// <summary>
        /// 計算服務學期時數積分。
        /// </summary>
        /// <param name="students"></param>
        public static void CalcServiceLearning(this List<StudentExcess> students)
        {
            foreach (StudentExcess student in students)
            {
                SemesterDataCollection allSems = student.SixSemester.ToSemesterOnly();

                //每學年的時數。
                Dictionary<int, decimal> yearScore = new Dictionary<int, decimal>();
                foreach (SemesterData sems in allSems)
                {
                    if (student.ServiceLearning.ContainsKey(sems))
                    {
                        if (!yearScore.ContainsKey(sems.SchoolYear))
                            yearScore[sems.SchoolYear] = 0;

                        yearScore[sems.SchoolYear] += student.ServiceLearning[sems];
                    }
                }

                //計算積分。
                foreach (int year in yearScore.Keys.ToArray())
                    yearScore[year] = Math.Floor(yearScore[year] / 3);

                //限制每學年積分上限。
                foreach (int year in yearScore.Keys.ToArray())
                {
                    if (yearScore[year] > 4)
                        yearScore[year] = 4;
                }

                //計算總分。
                decimal score = 0;
                foreach (int year in yearScore.Keys)
                {
                    score += yearScore[year];
                }

                //限制總分上限。
                if (score > 10)
                    score = 10;

                student.ServiceLearningFinal = score;
            }
        }

        public static void CalcCadre(this List<StudentExcess> students)
        {
            foreach (StudentExcess student in students)
            {
                SemesterDataCollection allSems = student.SixSemester.ToSemesterOnly();

                //每學期的成績。
                decimal score = 0;
                foreach (SemesterData sems in allSems)
                {
                    if (student.Cadre.ContainsKey(sems))
                        score += student.Cadre[sems] * 2;
                }

                //限制總分上限。
                if (score > 10)
                    score = 10;

                student.CadreFinal = score;
            }
        }

        public static void CalcFitness(this List<StudentExcess> students)
        {
            //得分項目。
            HashSet<string> lookup = new HashSet<string>(new string[] {
                "金牌",
                "銀牌",
                "銅牌",
                "中等",
                "免測"
            });

            foreach (StudentExcess student in students)
            {
                SemesterDataCollection allSems = student.SixSemester.ToSemesterOnly();

                HashSet<int> years = new HashSet<int>();
                foreach (SemesterData sems in allSems)
                {
                    if (!years.Contains(sems.SchoolYear))
                        years.Add(sems.SchoolYear);
                }

                decimal score = 0;
                foreach (int year in years) //每個年度。
                {
                    if (!student.Fitness.ContainsKey(year))
                        continue;

                    //指定學年度的所有常模項目。
                    foreach (string item in student.Fitness[year].Values)
                    {
                        if (lookup.Contains(item))
                            score += 3;
                    }
                }

                //限制總分上限。
                if (score > 20)
                    score = 20;

                student.FitnessFinal = score;
            }
        }

        public static void CalcDomainScore(this List<StudentExcess> students)
        {
            //得分項目。
            HashSet<string> lookup = new HashSet<string>(new string[] {
                "健康與體育",
                "藝術與人文", //藝術與人文
                "綜合活動"
            });

            foreach (StudentExcess student in students) //所有學生。
            {
                SemesterDataCollection allSems = student.FiveSemester.ToSemesterOnly();
                Dictionary<string, DomainAvgCalculator> calculate = new Dictionary<string, DomainAvgCalculator>();

                foreach (SemesterData sems in allSems) //所有學期
                {
                    if (!student.DomainScore.ContainsKey(sems))
                        continue;

                    DomainScore ds = student.DomainScore[sems];

                    foreach (string dn in ds.Keys) //所有領域成績
                    {
                        string name = dn.Trim();

                        if (!lookup.Contains(name)) //非需要的領域不處理。
                            continue;

                        if (!calculate.ContainsKey(name))
                            calculate[dn] = new DomainAvgCalculator();

                        //將指定領域的成績加入到計算機中。
                        calculate[name].AddScore(ds[name]);
                    }
                }

                int passCount = 0;
                foreach (DomainAvgCalculator avg in calculate.Values)
                {
                    if (avg.IsPassed)
                        passCount++;
                }

                decimal score = 0;

                switch (passCount)
                {
                    case 1:
                        score = 3;
                        break;
                    case 2:
                        score = 6;
                        break;
                    case 3:
                        score = 10;
                        break;
                }

                student.DomainScoreFinal = score;
            }
        }

        class DomainAvgCalculator
        {
            public DomainAvgCalculator()
            {
                Count = 0;
                Score = 0;
            }

            public int Count { get; set; }

            public decimal Score { get; set; }

            public void AddScore(decimal s)
            {
                Score += s;
                Count++;
            }

            public bool IsPassed
            {
                get
                {
                    decimal avg = Score / Count;

                    return avg >= 60;
                }
            }
        }
    }
}
