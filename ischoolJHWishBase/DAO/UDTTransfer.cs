using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;

namespace ischoolJHWishBase.DAO
{
    public class UDTTransfer
    {
        /// <summary>
        /// 新增開放填寫時間
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTEnrolmentExcessInputDateInsert(List<UDT_EnrolmentExcessInputDate> dataList)
        {
            if (dataList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.InsertValues(dataList);
            }
        }

        /// <summary>
        /// 更新開放填寫時間
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTEnrolmentExcessInputDateUpdate(List<UDT_EnrolmentExcessInputDate> dataList)
        {
            if (dataList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.UpdateValues(dataList);
            }
        }

        /// <summary>
        /// 刪除開放填寫時間
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTEnrolmntExcessInputDateDelete(List<UDT_EnrolmentExcessInputDate> dataList)
        {
            if (dataList.Count > 0)
            {
                foreach (UDT_EnrolmentExcessInputDate data in dataList)
                    data.Deleted = true;

                AccessHelper accessHelper = new AccessHelper();
                accessHelper.DeletedValues(dataList);
            }
        }

        /// <summary>
        /// 取得開放填寫時間
        /// </summary>
        /// <returns></returns>
        public static List<UDT_EnrolmentExcessInputDate> UDTEnrolmentExcessInputDateSelect()
        {
            AccessHelper accessHelper = new AccessHelper();
            return accessHelper.Select<UDT_EnrolmentExcessInputDate>();
        }


        /// <summary>
        /// 新增比序績分主檔
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTEnrolmentExcessCreditsInsert(List<UDT_EnrolmentExcessCredits> dataList)
        {
            if (dataList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.InsertValues(dataList);
            }
        }

        /// <summary>
        /// 更新比序績分主檔
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTEnrolmentExcessCreditsUpdate(List<UDT_EnrolmentExcessCredits> dataList)
        {
            if (dataList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.UpdateValues(dataList);
            }
        }

        /// <summary>
        /// 刪除比序績分主檔
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTEnrolmentExcessCreditsDelete(List<UDT_EnrolmentExcessCredits> dataList)
        {
            if (dataList.Count > 0)
            {
                foreach (UDT_EnrolmentExcessCredits data in dataList)
                    data.Deleted = true;

                AccessHelper accessHelper = new AccessHelper();
                accessHelper.DeletedValues(dataList);
            }
        }

        /// <summary>
        /// 取得比序績分主檔
        /// </summary>
        /// <returns></returns>
        public static List<UDT_EnrolmentExcessCredits> UDTEnrolmentExcessCreditsSelect()
        {
            AccessHelper accessHelper = new AccessHelper();
            return accessHelper.Select<UDT_EnrolmentExcessCredits>();
        }

        /// <summary>
        /// 新增設定檔
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTConfigInsert(List<UDTConfig> dataList)
        {
            if (dataList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.InsertValues(dataList);
            }        
        }

        /// <summary>
        /// 更新設定檔
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTConfigUpdate(List<UDTConfig> dataList)
        {
            if (dataList.Count > 0)
            {
                AccessHelper accessHelper = new AccessHelper();
                accessHelper.UpdateValues(dataList);
            }
        }

        /// <summary>
        /// 刪除設定檔
        /// </summary>
        /// <param name="dataList"></param>
        public static void UDTConfigDelete(List<UDTConfig> dataList)
        {
            if (dataList.Count > 0)
            {
                foreach (UDTConfig data in dataList)
                    data.Deleted = true;

                AccessHelper accessHelper = new AccessHelper();
                accessHelper.DeletedValues(dataList);
            }
        }

        /// <summary>
        /// 透過名稱取得設定檔
        /// </summary>
        /// <param name="dataList"></param>
        public static List<UDTConfig> UDTConfigSelectByName(string name)
        {
            List<UDTConfig> retVal = new List<UDTConfig>();
            if (!string.IsNullOrEmpty(name))
            {
                AccessHelper accessHelper = new AccessHelper();
                string query = "name='"+name+"'";
                retVal = accessHelper.Select<UDTConfig>(query);
            }
            return retVal;
        }
    }
}
