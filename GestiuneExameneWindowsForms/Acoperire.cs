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
            adaugaRadioButtonInList();
            adaugaSpecializareToDropDownList();
            adaugaDisciplinaToDropDownList();
            adaugaAnStudiuToDropDownList();
            adaugaProfesorToDropDownList();
            labelAcoperireDiscAnUniv.Visible = true;
            labelAcoperireDiscAnUniv.Text = AddDataForm.anUniversitarCurent.ToString();
        }

        #region declarare variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        List<RadioButton> listRadioButtonSemestru = new List<RadioButton>();
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
            List<string> specializari = new List<string>();
            foreach (DataRow drAloc in ds.Tables["ALOCAREDISCIPLINA"].Rows)  // doar specializarile care au materii alocate
            {
                if (drAloc.ItemArray.GetValue(5).ToString() == "Activ")  //daca disciplina este inca valida la specializarea x pentru anul in curs
                {
                    if (drAloc.ItemArray.GetValue(3).ToString() == returnRadioButtonName(listRadioButtonSemestru).ToString())  //daca semestrul corespunde cu cel bifat
                    {
                        foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                        {
                            if (drAloc.ItemArray.GetValue(0).ToString() == dr.ItemArray.GetValue(0).ToString()) //daca specializarea are disciplina alocata
                            {
                                if (dr.ItemArray.GetValue(3).ToString() == Form1.idFacultateSelectata.ToString())  // doar specializarile care apartin de facultatea selectata la deschiderea aplicatiei
                                {
                                    specializari.Add(dr.ItemArray.GetValue(1).ToString());
                                }
                            }
                        }
                    }
                }
            }
            List<string> distinct = specializari.Distinct().ToList();
            foreach (String spec in distinct)
            {
                comboBoxDropDownListAcoperireDiscSpec.Items.Add(spec);
            }
            if (comboBoxDropDownListAcoperireDiscSpec.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscSpec.SelectedIndex = 0;
        }

        bool activareEvenimentDropDownListSpecializare = false;

        private void specializare_selectedIndexChanged(object sender, EventArgs e)
        {
            //false => se modifica interactiv lista in functie de selectie
            if (!activareEvenimentDropDownListSpecializare)
            {
                adaugaDisciplinaToDropDownList();
                //adaugaAnStudiuToDropDownList(); E necesar sa apelez ptr ambele liste sau eventul de la lista disc se triggeruieste si actualizeaza anStudiu singur?
            }
        }
        void adaugaDisciplinaToDropDownList()
        {
            comboBoxDropDowListAcoperireDiscDisc.Items.Clear();
            List<string> discipline = new List<string>();
            string idSpecializareSelectata = "";

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAcoperireDiscSpec.SelectedItem.ToString())
                    idSpecializareSelectata = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow drAloc in ds.Tables["ALOCAREDISCIPLINA"].Rows)
            {
                if (drAloc.ItemArray.GetValue(0).ToString() == idSpecializareSelectata)  // daca disciplina este alocata specializarii selectate
                {
                    if (drAloc.ItemArray.GetValue(5).ToString() == "Activ")  // daca este activa pentru anul universitar in curs
                    {
                        if (drAloc.ItemArray.GetValue(3).ToString() == returnRadioButtonName(listRadioButtonSemestru).ToString())  //daca semestrul corespunde cu cel bifat
                        {
                            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                            {
                                if (drAloc.ItemArray.GetValue(1).ToString() == dr.ItemArray.GetValue(0).ToString())
                                {
                                    discipline.Add(dr.ItemArray.GetValue(1).ToString());
                                    //comboBoxDropDowListAcoperireDiscDisc.Items.Add(dr.ItemArray.GetValue(1).ToString());
                                }
                            }
                        }
                    }
                }
            }
            List<string> distinct = discipline.Distinct().ToList();
            foreach (String disc in distinct)
            {
                comboBoxDropDowListAcoperireDiscDisc.Items.Add(disc);
            }
            if (comboBoxDropDowListAcoperireDiscDisc.Items.Count > 0)
                comboBoxDropDowListAcoperireDiscDisc.SelectedIndex = 0;
        }

        bool activareEvenimentDropDownListDisciplina = false;

        private void disciplina_selectedIndexChanged(object sender, EventArgs e)
        {
            if (!activareEvenimentDropDownListDisciplina)
                adaugaAnStudiuToDropDownList();
        }

        void adaugaAnStudiuToDropDownList()
        {
            comboBoxDropDownListAcoperireDiscAnStudiu.Items.Clear();

            List<string> aniStudiu = new List<string>();
            string idSpecializareSelectata = "";
            string idDisciplinaSelectata = "";

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAcoperireDiscSpec.SelectedItem.ToString())
                    idSpecializareSelectata = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDowListAcoperireDiscDisc.SelectedItem.ToString())
                    idDisciplinaSelectata = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow drAloc in ds.Tables["ALOCAREDISCIPLINA"].Rows)
            {
                if (drAloc.ItemArray.GetValue(0).ToString() == idSpecializareSelectata)  // daca anul corespunde pe inregistrarea care este alocata specializarii selectate
                {
                    if (drAloc.ItemArray.GetValue(1).ToString() == idDisciplinaSelectata)  // daca si disciplina corespunde
                    {
                        if (drAloc.ItemArray.GetValue(5).ToString() == "Activ")  // daca este activ pentru anul universitar in curs
                        {
                            if (drAloc.ItemArray.GetValue(3).ToString() == returnRadioButtonName(listRadioButtonSemestru).ToString())  //daca semestrul corespunde cu cel bifat
                            {
                                foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                                {
                                    if (drAloc.ItemArray.GetValue(2).ToString() == dr.ItemArray.GetValue(0).ToString())
                                    {
                                        aniStudiu.Add(dr.ItemArray.GetValue(0).ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            List<string> distinct = aniStudiu.Distinct().ToList();
            foreach (String spec in distinct)
            {
                comboBoxDropDownListAcoperireDiscAnStudiu.Items.Add(spec);
            }
            if (comboBoxDropDownListAcoperireDiscAnStudiu.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscAnStudiu.SelectedIndex = 0;
        }

        void adaugaProfesorToDropDownList()
        {
            comboBoxDropDownListAcoperireDiscProf.Items.Clear();

            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                comboBoxDropDownListAcoperireDiscProf.Items.Add(dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString());
            if (comboBoxDropDownListAcoperireDiscProf.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscProf.SelectedIndex = 0;
        }
        #endregion

        #region RadioButtonMethod
        void adaugaRadioButtonInList()
        {
            foreach (Control c in groupBoxAcoperireDiscSemestru.Controls)
                listRadioButtonSemestru.Add((RadioButton)c);

        }

        string returnRadioButtonName(List<RadioButton> listaRadioButtons)
        {
            foreach (RadioButton rb in listaRadioButtons)
                if (rb.Checked)
                    return rb.Text;
            return "";
        }
        #endregion
        private void buttonAcoperireDisciplina_Click(object sender, EventArgs e)
        {
            if (comboBoxDropDownListAcoperireDiscSpec.Items.Count <= 0)
                MessageBox.Show("Lista specializarilor este goala.\nAcoperirea nu se poate realiza!");
            else
                if (comboBoxDropDowListAcoperireDiscDisc.Items.Count <= 0)
                MessageBox.Show("Lista disciplinelor este goala.\nAcoperirea nu se poate realiza!\nAlocati discipline specializarii, apoi reveniti pentru a asocia un profesor titular!");
            else
                if (comboBoxDropDownListAcoperireDiscProf.Items.Count <= 0)
                MessageBox.Show("Lista profesorilor este goala.\nAcoperirea nu se poate realiza!\nVerificati daca in baza de date existe profesori inregistrati!");
            else
                if (comboBoxDropDownListAcoperireDiscAnStudiu.Items.Count <= 0)
                MessageBox.Show("Lista anilor de studiu este goala.\nAcoperirea nu se poate realiza!");
            else
            {
                string codSpec = "";
                string idDisc = "";
                string marcaProf = "";
                string anStudiuId = "";
                bool exista = false;
                foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAcoperireDiscSpec.SelectedItem.ToString())
                        codSpec = dr.ItemArray.GetValue(0).ToString();
                foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDowListAcoperireDiscDisc.SelectedItem.ToString())
                        idDisc = dr.ItemArray.GetValue(0).ToString();
                foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxDropDownListAcoperireDiscProf.SelectedItem.ToString())
                        marcaProf = dr.ItemArray.GetValue(0).ToString();
                foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                    if (dr.ItemArray.GetValue(0).ToString() == comboBoxDropDownListAcoperireDiscAnStudiu.SelectedItem.ToString())
                        anStudiuId = dr.ItemArray.GetValue(0).ToString();

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

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_back_toAddData_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = Application.OpenForms["AddDataForm"];
            form.Show();
        }
    }
}
