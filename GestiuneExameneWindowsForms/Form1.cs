using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestiuneExameneWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AddDataForm addDataForm = new AddDataForm();
        private void buttonAdaugaDate_Click(object sender, EventArgs e)
        {
            this.Hide();
            addDataForm.ShowDialog();
        }

        ScheduleExamForm scheduleExamForm = new ScheduleExamForm();
        private void buttonProgramareExamene_Click(object sender, EventArgs e)
        {
            this.Hide();
            scheduleExamForm.ShowDialog();
        }

        StatisticsForm statisticsForm = new StatisticsForm();
        private void buttonStatistici_Click(object sender, EventArgs e)
        {
            this.Hide();
            statisticsForm.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
