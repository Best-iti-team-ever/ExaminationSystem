using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EXAMINATIONSYSTEM
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ServerReport.ReportPath = "/report1withproc/Report1";
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ServerReport.ReportPath = "/Report3withproc/Report2";
            this.reportViewer1.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ServerReport.ReportPath = "/Report3withproc/Report3---";
            this.reportViewer1.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ServerReport.ReportPath = "/Report3withproc/Report4";
            this.reportViewer1.RefreshReport();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ServerReport.ReportPath = "/project5withproc/Report5wproc";
            this.reportViewer1.RefreshReport();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.reportViewer1.ServerReport.ReportPath = "/Report3withproc/Report6";
            this.reportViewer1.RefreshReport();
        }

       
    }
}
