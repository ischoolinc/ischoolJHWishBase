using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ischoolJHWishBase.Calc
{
    /// <summary>
    /// 代表一個學生的體適能常模資料。
    /// </summary>
    class FitnessDegree : Dictionary<string, string>
    {
        //height
        //height_degree
        //weight
        //weight_degree
        //sit_and_reach
        //sit_and_reach_degree
        //standing_long_jump
        //standing_long_jump_degree
        //sit_up
        //sit_up_degree
        //cardiorespiratory
        //cardiorespiratory_degree

        //這兩項不用。
        //public string Height { get; set; }
        //public string Weight { get; set; }

        public string SitAndReach { get; set; }

        public string StandingLongJump { get; set; }

        public string SitUp { get; set; }

        public string Cardiorespiratory { get; set; }

        /// <summary>
        /// 轉換為 Dictionary。
        /// </summary>
        public void Collect()
        {
            Add("SitAndReach", SitAndReach);
            Add("StandingLongJump", StandingLongJump);
            Add("SitUp", SitUp);
            Add("Cardiorespiratory", Cardiorespiratory);
        }
    }
}
