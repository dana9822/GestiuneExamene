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
    public partial class Acoperire : Form
    {
        public Acoperire()
        {
            InitializeComponent();
            conectare();
        }

        public void Acoperire_Load(object sender, EventArgs e)
        {
            conectare();
            completareDataSet();
            adaugaSpecializareToDropDownList();
            adaugaAnStudiuToDropDownList();
            adaugaProfesorToDropDownList();
            labelAcoperireDiscAnUniv.Visible = true;
            labelAcoperireDiscAnUniv.Text = AddDataForm.anUniversitarCurent.ToString();
        }

        #region declarare variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
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
            string selectSpecializare = "SELECT * FROM Specializare";
            string selectAnStudiu = "SELECT * FROM AnStudiu";
            string selectAnUniversitar = "SELECT * FROM AnUniversitar";
            string selectGrupa = "SELECT * FROM GRUPA";
            string selectProfesor = "SELECT * FROM Profesor";
            string selectDisciplina = "SELECT * FROM Disciplina";
            string selectAlocareDisciplina = "SELECT * FROM AlocareDisciplina";
            string selectAcoperireDisciplina = "SELECT * FROM AcoperireDisciplina";
            string selectSesiune = "SELECT * FROM Sesiune";
            string selectAnSesiune = "SELECT * FROM An_Sesiune";
            string selectCorp = "SELECT * FROM Corp";
            string selectSala = "SELECT * FROM Sala";

            //DataAdapter+DataSet
            da = new SqlDataAdapter(selectFacultate, con);
            da.Fill(ds, "FACULTATE");
            da = new SqlDataAdapter(selectSpecializare, con);
            da.Fill(ds, "SPECIALIZARE");
            da = new SqlDataAdapter(selectAnStudiu, con);
            da.Fill(ds, "ANSTUDIU");
            da = new SqlDataAdapter(selectAnUniversitar, con);
            da.Fill(ds, "ANUNIVERSITAR");
            da = new SqlDataAdapter(selectGrupa, con);
            da.Fill(ds, "GRUPA");
            da = new SqlDataAdapter(selectProfesor, con);
            da.Fill(ds, "PROFESOR");
            da = new SqlDataAdapter(selectDisciplina, con);
            da.Fill(ds, "DISCIPLINA");
            da = new SqlDataAdapter(selectAlocareDisciplina, con);
            da.Fill(ds, "ALOCAREDISCIPLINA");
            da = new SqlDataAdapter(selectAcoperireDisciplina, con);
            da.Fill(ds, "ACOPERIREDISCIPLINA");
            da = new SqlDataAdapter(selectSesiune, con);
            da.Fill(ds, "SESIUNE");
            da = new SqlDataAdapter(selectAnSesiune, con);
            da.Fill(ds, "ANSESIUNE");
            da = new SqlDataAdapter(selectCorp, con);
            da.Fill(ds, "CORP");
            da = new SqlDataAdapter(selectSala, con);
            da.Fill(ds, "SALA");

            //Close connection
            con.Close();

        }
        #endregion

        #region PopulateDropDownList
        void adaugaSpecializareToDropDownList()
        {
            comboBoxDropDownListAcoperireDiscSpec.Items.Clear();

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
            {
                if (dr.ItemArray.GetValue(3).ToString() == Form1.idFacultateSelectata.ToString())
                {
                    comboBoxDropDownListAcoperireDiscSpec.Items.Add(dr.ItemArray.GetValue(1).ToString());
                }
            }
            if (comboBoxDropDownListAcoperireDiscSpec.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscSpec.SelectedIndex = 0;
        }

        void adaugaAnStudiuToDropDownList()
        {
            comboBoxDropDownListAcoperireDiscAnStudiu.Items.Clear();

            foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
            {
                comboBoxDropDownListAcoperireDiscAnStudiu.Items.Add(dr.ItemArray.GetValue(0).ToString());
            }

            if (comboBoxDropDownListAcoperireDiscAnStudiu.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscAnStudiu.SelectedIndex = 0;
        }

        void adaugaProfesorToDropDownList()
        {
            comboBoxDropDownListAcoperireDiscProf.Items.Clear();

            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                comboBoxDropDownListAcoperireDiscProf.Items.Add(dr.ItemArray.GetValue(3).ToString() + " " + dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString());
            if (comboBoxDropDownListAcoperireDiscProf.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscProf.SelectedIndex = 0;
        }
        #endregion

        private void buttonAcoperireDisciplina_Click(object sender, EventArgs e)
        {
            string codSpec = "";
            string idDisc = "";
            string marcaProf = "";
            string anStudiuId = "";
            bool exista = false;
            //foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
            //    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAlocareDisSpecList.SelectedItem.ToString())
            //        codSpec = dr.ItemArray.GetValue(0).ToString();
            //foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
            //    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAlocareDiscDiscList.SelectedItem.ToString())
            //        idDisc = dr.ItemArray.GetValue(0).ToString();
            //foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
            //    if (dr.ItemArray.GetValue(3).ToString() + " " + dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxDropDownListAcoperireDiscProf.SelectedItem.ToString())
            //        marcaProf = dr.ItemArray.GetValue(0).ToString();
            //foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
            //    if (dr.ItemArray.GetValue(0).ToString() == comboBoxDropDownListAlocareDiscAnStudiuList.SelectedItem.ToString())
            //        anStudiuId = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow dr in ds.Tables["ACOPERIREDISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() == codSpec.ToString() && dr.ItemArray.GetValue(1).ToString() == idDisc.ToString() && dr.ItemArray.GetValue(2).ToString() == marcaProf.ToString() && dr.ItemArray.GetValue(3).ToString() == anStudiuId.ToString() && dr.ItemArray.GetValue(4).ToString() == AddDataForm.anUniversitarCurent.ToString())
                {
                    exista = true; // acoperirea exista deja                 
                    break;
                }
            if (exista == false)
            {
                string insertAcoperire = "INSERT INTO AcoperireDisciplina VALUES ('" + codSpec.ToString() + "', '" + idDisc.ToString() + "','" + marcaProf.ToString() + "','" + anStudiuId.ToString() + "','" + AddDataForm.anUniversitarCurent.ToString() + "')";
                con.Open();
                SqlCommand cmdInsertAcoperire = new SqlCommand(insertAcoperire, con);
                cmdInsertAcoperire.ExecuteNonQuery();
                ds.Tables["ACOPERIREDISCIPLINA"].Clear();
                SqlDataAdapter daAcoperire = new SqlDataAdapter("SELECT * FROM AcoperireDisciplina", con);
                daAcoperire.Fill(ds, "ACOPERIREDISCIPLINA");
                con.Close();
                MessageBox.Show("Disciplina " + comboBoxDropDowListAcoperireDiscDisc.SelectedItem.ToString() + " a fost acoperita cu succes, avand urmatoarele specificatii:" + "\nSpecializarea: " + comboBoxDropDownListAcoperireDiscSpec.SelectedItem.ToString() + "\nPredata de: " + comboBoxDropDownListAcoperireDiscProf.SelectedItem.ToString() + " \nAnul de studiu: " + comboBoxDropDownListAcoperireDiscAnStudiu.SelectedItem.ToString() + "\nAnul universitar: " + AddDataForm.anUniversitarCurent.ToString());
                // reset drop down numeric fields to their default values?
            }
            else
                MessageBox.Show("Acoperirea exista deja in baza de date!");
        }
    }
}
