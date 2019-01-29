using FISCA.Presentation.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ischoolJHWishBase.ExportGradeSelect
{
    public partial class SelectGradeToExport : BaseForm
    {

        private int _gradeYear;

        public SelectGradeToExport()
        {
            InitializeComponent();

        }

        private void SelectGradeToExport_Load(object sender, EventArgs e)
        {

            comboGrade.Items.Add("1");
            comboGrade.Items.Add("2");
            comboGrade.Items.Add("3");

            comboGrade.SelectedIndex = 2;
            _gradeYear = Convert.ToInt32(comboGrade.SelectedItem.ToString());
        }

        private void comboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            _gradeYear = Convert.ToInt32(comboGrade.SelectedItem.ToString());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            ExportExcessCreditsData eecd = new ExportExcessCreditsData(_gradeYear);
            eecd.Run(btnExport);
        }

    }
}
