﻿using System;
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
    public partial class InstructorHomeForm : Form
    {
        public InstructorHomeForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            InstructorDataUpdate insupdate = new InstructorDataUpdate();
            insupdate.ShowDialog();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            InstructorControlCourse course = new InstructorControlCourse();
            course.ShowDialog();
            this.Hide();
        }
    }
}
