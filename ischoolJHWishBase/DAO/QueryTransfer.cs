using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Data;
using System.Data;

namespace ischoolJHWishBase.DAO
{
    public class QueryTransfer
    {
        /// <summary>
        /// 取得三年級狀態為一般學生
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int,StudentExcessCredit> GetStudentExcessCreditDict()
        {
            Dictionary<int, StudentExcessCredit> retVal = new Dictionary<int, StudentExcessCredit>();
            QueryHelper qh = new QueryHelper();
            string query = "select student.id,class_name,seat_no,student_number from student inner join class on student.ref_class_id=class.id where student.status=1 and class.grade_year in(3,9) order by class.class_name,student.seat_no;";
            
            DataTable dt = qh.Select(query);
            foreach (DataRow dr in dt.Rows)
            {
                int sid = int.Parse(dr["id"].ToString());
                
                if (retVal.ContainsKey(sid))
                    continue;

                StudentExcessCredit sec = new StudentExcessCredit();
                sec.StudentID = sid;
                sec.ClassName = dr["class_name"].ToString();
                int i_sno;
                if (int.TryParse(dr["seat_no"].ToString(), out i_sno))
                    sec.SeatNo = i_sno;

                sec.StudentNumber = dr["student_number"].ToString();
                
                retVal.Add(sid,sec);
            }
            return retVal;
        }


        /// <summary>
        /// 取得三年級狀態為一般，志願比序資料
        /// </summary>
        /// <returns></returns>
        public static DataTable GetStudentExcessCreditDataTable(int gradeYear=3)
        {
            DataTable dt = new DataTable();
            QueryHelper qh = new QueryHelper();
            string strSQL = $"select student.id as sid,student.name as 學生姓名,class_name,seat_no,student_number,id_number as 身分證號統一編號,student.birthdate as 出生年月日,balanced as 均衡學習,services as 服務學習,fitness as 體適能,competition as 競賽表現,verification as 檢定證照,merit as 獎勵紀錄,term as 幹部任期 from student inner join class on student.ref_class_id=class.id left join $kh.enrolment_excess.credits on student.id=$kh.enrolment_excess.credits.ref_student_id where student.status=1 and class.grade_year in({gradeYear},{6+ gradeYear}) order by class.class_name,student.seat_no;";
            dt = qh.Select(strSQL);
            return dt;
        }



        /// <summary>
        /// 取得學生類別 p:name
        /// </summary>
        /// <returns></returns>
        public static List<string> GetStudentTagList()
        {
            List<string> retVal = new List<string>();
            QueryHelper qh = new QueryHelper();
            string strSQL = "select case when prefix is null then name else prefix||':'||name end from tag where category='Student' order by prefix,name;";
            DataTable dt = qh.Select(strSQL);
            
            foreach (DataRow dr in dt.Rows)
                retVal.Add(dr[0].ToString());

            return retVal;
        }

        /// <summary>
        /// 取得學生id,類別
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, List<string>> GetStduentTagDict()
        {
            Dictionary<string, List<string>> retVal = new Dictionary<string, List<string>>();
            QueryHelper qh = new QueryHelper();
            string strSQL = "select student.id, case when prefix is null then tag.name else prefix||':'||tag.name end as tagname from  student inner join tag_student on student.id=tag_student.ref_student_id inner join tag on tag_student.ref_tag_id=tag.id order by student.id,tagname;";
            DataTable dt = qh.Select(strSQL);

            foreach (DataRow dr in dt.Rows)
            { 
                string id =dr["id"].ToString();
                if (!retVal.ContainsKey(id))
                    retVal.Add(id, new List<string>());

                retVal[id].Add(dr["tagname"].ToString());
            }

            return retVal;
        }

        /// <summary>
        /// 取得三年級一般狀態學生
        /// </summary>
        /// <returns></returns>
        public static List<string> GetStudeGrade3List()
        {
            List<string> retVal = new List<string>();
            QueryHelper qh = new QueryHelper();
            string strSQL = "select student.id from student inner join class on student.ref_class_id=class.id where student.status=1 and class.grade_year in(3,9) order by class.class_name,student.seat_no;";
            DataTable dt = qh.Select(strSQL);
            foreach (DataRow dr in dt.Rows)
                retVal.Add(dr["id"].ToString());

            return retVal;        
        }

        /// <summary>
        /// 傳入學生ID，年級、班級、座號排序
        /// </summary>
        /// <param name="StudentIDList"></param>
        /// <returns></returns>
        public static List<string> StudentSortByClassSeatNo(List<string> StudentIDList)
        {
            List<string> retVal = new List<string>();
            if (StudentIDList.Count > 0)
            {
                QueryHelper qh = new QueryHelper();
                string strSQL = "select student.id from student left join class on student.ref_class_id=class.id where student.id in(" + string.Join(",", StudentIDList.ToArray()) + ") order by class.grade_year,class_name,seat_no;";
                DataTable dt = qh.Select(strSQL);
                foreach (DataRow dr in dt.Rows)
                    retVal.Add(dr[0].ToString());
            }
            return retVal;
        }

    }
}
