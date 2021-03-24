﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestiuneExameneWindowsForms
{
    public partial class ScheduleExamForm : Form
    {
        public ScheduleExamForm()
        {
            InitializeComponent();
            conectare();
        }

#region declarare variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
#endregion

        private void buttonScheduleExamBack_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Hide();
            this.Dispose();

            home.ShowDialog();
        }

        private void ScheduleExamForm_Load(object sender, EventArgs e)
        {
            conectare();
        }

        void conectare()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=GestiuneExamene;Integrated Security=True"; //connection string pentru BD de pe SQL Server
        }
    }
}
