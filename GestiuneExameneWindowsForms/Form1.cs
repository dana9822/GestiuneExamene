using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            conectare();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conectare();
            completareDataSet();
            adaugaFacultateToDropDownList();
            setFacultateSelectata();
            showCurrentFaculty();
        }

        #region declarare variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        static string idFacultateSelectata;
        static string denumireFacultateSelectata;
        #endregion

        #region conectare
        void conectare()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=GestiuneExamene;Integrated Security=True"; //connection string pentru BD de pe SQL Server
        }
        #endregion

        #region DataSet
        void completareDataSet()
        {
            //Open connection
            con.Open();

            //Query strings
            string selectFacultate = "SELECT * FROM Facultate";

            //DataAdapter+DataSet
            da = new SqlDataAdapter(selectFacultate, con);
            da.Fill(ds, "FACULTATE");

            //Close connection
            con.Close();

        }
        #endregion

        #region PopulateDropDownLists
        void adaugaFacultateToDropDownList()
        {
            comboBoxListaFacultati.Items.Clear();

            foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
                comboBoxListaFacultati.Items.Add(dr.ItemArray.GetValue(1).ToString());

            if (comboBoxListaFacultati.Items.Count > 0)
                comboBoxListaFacultati.SelectedIndex = 0;
        }
        #endregion

        #region SET_FacultateSelectata
        public void setFacultateSelectata()
        {
            denumireFacultateSelectata = comboBoxListaFacultati.SelectedItem.ToString();

            foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxListaFacultati.SelectedItem.ToString())
                    idFacultateSelectata = dr.ItemArray.GetValue(0).ToString();
        }

        bool activareEvenimentDropDownListFacultate = false;

        private void facultateForm1_selectedIndexChanged(object sender, EventArgs e)
        {
            //false => se modifica interactiv lista in functie de selectie
            if (!activareEvenimentDropDownListFacultate)
            {
                setFacultateSelectata();
                showCurrentFaculty();
            }

        }
        #endregion

        #region selectieCurentaFacultate_GUI
        public void showCurrentFaculty()
        {
            if (!String.IsNullOrEmpty(denumireFacultateSelectata))
            {
                labelFacultateCurentSelectata.Visible = true;
                labelFacultateCurentSelectata.Text = "Selectia curenta: " + denumireFacultateSelectata;

                label_IDFacultateCurentSelectata.Visible = true;
                label_IDFacultateCurentSelectata.Text = "COD: " + idFacultateSelectata;
            }
            else
            {
                labelFacultateCurentSelectata.Visible = true;
                labelFacultateCurentSelectata.Text = "Eroare selectie";

                label_IDFacultateCurentSelectata.Visible = true;
                label_IDFacultateCurentSelectata.Text = "EROARE";
            }
        }
        #endregion

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
