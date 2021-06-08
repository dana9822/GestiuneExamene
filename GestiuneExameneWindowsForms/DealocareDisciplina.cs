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
    public partial class DealocareDisciplina : Form
    {
        public DealocareDisciplina()
        {
            InitializeComponent();
            conectare();
        }

        public void DealocareDisciplina_Load(object sender, EventArgs e)
        {
            conectare();
            completareDataSet();
            adaugaRadioButtonInList();
            adaugaSpecializareToDropDownList();
            adaugaDisciplinaToDropDownList();
            adaugaAnStudiuToDropDownList();
        }

        #region declarare variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        List<RadioButton> listRadioButtonSemestru = new List<RadioButton>();
        List<RadioButton> listRadioButtonTipEvaluare = new List<RadioButton>();
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
            comboBoxDropDownListDealocareSpecList.Items.Clear();
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
                comboBoxDropDownListDealocareSpecList.Items.Add(spec);
            }
            if (comboBoxDropDownListDealocareSpecList.Items.Count > 0)
                comboBoxDropDownListDealocareSpecList.SelectedIndex = 0;
        }

        bool activareEvenimentDropDownListSpecializare = false;

        private void specializare_selectedIndexChanged(object sender, EventArgs e)
        {
            //false => se modifica interactiv lista in functie de selectie
            if (!activareEvenimentDropDownListSpecializare)
            {
                adaugaDisciplinaToDropDownList();
            }
        }
        void adaugaDisciplinaToDropDownList()
        {
            comboBoxDropDownListDealocareDiscList.Items.Clear();
            List<string> discipline = new List<string>();
            string idSpecializareSelectata = "";

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListDealocareSpecList.SelectedItem.ToString())
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
                                }
                            }
                        }
                    }
                }
            }
            List<string> distinct = discipline.Distinct().ToList();
            foreach (String disc in distinct)
            {
                comboBoxDropDownListDealocareDiscList.Items.Add(disc);
            }
            if (comboBoxDropDownListDealocareDiscList.Items.Count > 0)
                comboBoxDropDownListDealocareDiscList.SelectedIndex = 0;
        }

        bool activareEvenimentDropDownListDisciplina = false;

        private void disciplina_selectedIndexChanged(object sender, EventArgs e)
        {
            if (!activareEvenimentDropDownListDisciplina)
                adaugaAnStudiuToDropDownList();
        }

        void adaugaAnStudiuToDropDownList()
        {
            comboBoxDropDownListDealocareAnStudiuList.Items.Clear();

            List<string> aniStudiu = new List<string>();
            string idSpecializareSelectata = "";
            string idDisciplinaSelectata = "";

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListDealocareSpecList.SelectedItem.ToString())
                    idSpecializareSelectata = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListDealocareDiscList.SelectedItem.ToString())
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
                comboBoxDropDownListDealocareAnStudiuList.Items.Add(spec);
            }
            if (comboBoxDropDownListDealocareAnStudiuList.Items.Count > 0)
                comboBoxDropDownListDealocareAnStudiuList.SelectedIndex = 0;
        }

        #endregion

        #region RadioButtonMethods
        void adaugaRadioButtonInList()
        {
            foreach (Control c in groupBoxDealocDiscSemestru.Controls)
                listRadioButtonSemestru.Add((RadioButton)c);
            foreach (Control c in groupBoxDealocDiscTipEvaluare.Controls)
                listRadioButtonTipEvaluare.Add((RadioButton)c);
        }

        string returnRadioButtonName(List<RadioButton> listaRadioButtons)
        {
            foreach (RadioButton rb in listaRadioButtons)
                if (rb.Checked)
                    return rb.Text;
            return "";
        }
        #endregion
        private void buttonDealocDisciplina_Click(object sender, EventArgs e)
        {
            if (comboBoxDropDownListDealocareSpecList.Items.Count <= 0)
                MessageBox.Show("Lista specializarilor este goala!\nDealocarea nu se poate realiza!");
            else
                if (comboBoxDropDownListDealocareDiscList.Items.Count <= 0)
                MessageBox.Show("Lista disciplinelor este goala!\nDealocarea nu se poate realiza!");
            else
                if (comboBoxDropDownListDealocareAnStudiuList.Items.Count <= 0)
                MessageBox.Show("Lista anilor de studiu este goala!\nDealocarea nu se poate realiza!");
            else
            {
                string semestru = returnRadioButtonName(listRadioButtonSemestru);
                string tipEvaluare = returnRadioButtonName(listRadioButtonTipEvaluare);
                string codSpec = "";
                string idDisc = "";
                string anStudiuId = "";
                string updateStatus = "Inactiv";
                string updateQueryDealocare = "";
                bool exista = false;

                foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListDealocareSpecList.SelectedItem.ToString())
                        codSpec = dr.ItemArray.GetValue(0).ToString();
                foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListDealocareDiscList.SelectedItem.ToString())
                        idDisc = dr.ItemArray.GetValue(0).ToString();
                foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                    if (dr.ItemArray.GetValue(0).ToString() == comboBoxDropDownListDealocareAnStudiuList.SelectedItem.ToString())
                        anStudiuId = dr.ItemArray.GetValue(0).ToString();

                foreach (DataRow dr in ds.Tables["ALOCAREDISCIPLINA"].Rows)
                    if (dr.ItemArray.GetValue(0).ToString() == codSpec.ToString() && dr.ItemArray.GetValue(1).ToString() == idDisc.ToString() && dr.ItemArray.GetValue(2).ToString() == anStudiuId.ToString())
                    {
                        exista = true; // alocarea exista in tabel, deci se poate realiza update-ul               
                        break;
                    }
                if (exista == true)
                {
                    if (MessageBox.Show("Statusul 'inactiv' va fi actualizat pentru disciplina: " + comboBoxDropDownListDealocareDiscList.SelectedItem.ToString() + " la specializarea: " + comboBoxDropDownListDealocareSpecList.SelectedItem.ToString() + " pentru anul de studiu: " + comboBoxDropDownListDealocareAnStudiuList.SelectedItem.ToString(), "Validare dealocare disciplina",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        updateQueryDealocare = "UPDATE AlocareDisciplina SET status = '" + updateStatus + "' WHERE idSpecializare = '" + codSpec + "' AND idDisciplina = '" + idDisc + "' AND anStudiu = '" + anStudiuId + "' AND semestru = '" + semestru + "' AND tipEvaluare = '" + tipEvaluare + "'";
                        con.Open();
                        SqlCommand cmdUpdate = new SqlCommand(updateQueryDealocare, con);
                        cmdUpdate.ExecuteNonQuery();
                        foreach (DataTable dt in ds.Tables)
                            if (dt.TableName == "ALOCAREDISCIPLINA")
                                ds.Tables["ALOCAREDISCIPLINA"].Clear();
                        string selectAlocareDisciplina = "SELECT * FROM AlocareDisciplina";
                        da = new SqlDataAdapter(selectAlocareDisciplina, con);
                        da.Fill(ds, "ALOCAREDISCIPLINA");
                        con.Close();
                        MessageBox.Show("Statusul a fost actualizat!\nDisciplina a fost dealocata cu succes!");
                        adaugaSpecializareToDropDownList();
                        adaugaDisciplinaToDropDownList();
                        adaugaAnStudiuToDropDownList();
                    }
                    else
                        MessageBox.Show("Eroare!", "Actualizarea nerealizata!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Aceasta inregistrare nu mai exista in baza de date! Modificarea nu se poate realiza!"); // in cazul in care in timp ce aplicatia este deschisa, se modifica baza de date din managerul de db ca admin sau alte cazuri care previn eroarea incercarii realizarii de update pe o inregistrare inexistenta
            }
        }

        private void button_Iesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_backToAddData_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = Application.OpenForms["AddDataForm"];
            form.Show();
        }
    }
}
