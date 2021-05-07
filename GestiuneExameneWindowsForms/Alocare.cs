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
    public partial class Alocare : Form
    {
        public Alocare()
        {
            InitializeComponent();
            conectare();
        }

        public void Alocare_Load(object sender, EventArgs e)
        {
            conectare();
            completareDataSet();
            adaugaRadioButtonInList();
            getDenumireDisciplinaAdaugata();
            checkboxListSpecializari();
            adaugaAnStudiuToDropDownList();
            adaugaCheckBoxInList();
            label_DisciplinaAdaugata.Text = denumiDisciplinaAdaugata.ToString();
        }

        #region declarare variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        List<RadioButton> listRadioButtonSemestru = new List<RadioButton>();
        List<RadioButton> listRadioButtonTipEvaluare = new List<RadioButton>();
        List<RadioButton> listRadioButtonStatusDisciplina = new List<RadioButton>();
        public static string denumiDisciplinaAdaugata = "";
        List<CheckBox> listCheckBoxesSpecializari = new List<CheckBox>();
        List<CheckBox> listPanelCheckBoxSpecializari = new List<CheckBox>();
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
        void adaugaAnStudiuToDropDownList()
        {
            comboBoxDropDownListAlocareDiscAnStudiuList.Items.Clear();

            foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
            {
                comboBoxDropDownListAlocareDiscAnStudiuList.Items.Add(dr.ItemArray.GetValue(0).ToString());
            }

            if (comboBoxDropDownListAlocareDiscAnStudiuList.Items.Count > 0)
                comboBoxDropDownListAlocareDiscAnStudiuList.SelectedIndex = 0;
        }
        #endregion

        #region RadioButtonMethods
        void adaugaRadioButtonInList()
        {
            foreach (Control c in groupBoxAlocDiscSemestru.Controls)
                listRadioButtonSemestru.Add((RadioButton)c);
            foreach (Control c in groupBoxAlocDiscTipEvaluare.Controls)
                listRadioButtonTipEvaluare.Add((RadioButton)c);
            foreach (Control c in groupBoxAlocareDiscStatus.Controls)
                listRadioButtonStatusDisciplina.Add((RadioButton)c);
        }

        string returnRadioButtonName(List<RadioButton> listaRadioButtons)
        {
            foreach (RadioButton rb in listaRadioButtons)
                if (rb.Checked)
                    return rb.Text;
            return "";
        }
        #endregion

        #region getDenumireDisciplinaAdaugata
        public void getDenumireDisciplinaAdaugata()
        {
            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() == AddDataForm.idDisciplinaAdaugata.ToString())
                    denumiDisciplinaAdaugata = dr.ItemArray.GetValue(1).ToString();
        }
        #endregion

        #region CheckList Specializari
        private void checkboxListSpecializari()
        {
            int pozTop = 10;
            cleanPanel();
            listCheckBoxesSpecializari.Clear();
            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
            {
                if (dr.ItemArray.GetValue(3).ToString() == Form1.idFacultateSelectata.ToString())
                {
                    listCheckBoxesSpecializari.Add(CreateNewControls.createCheckBox(dr.ItemArray.GetValue(1).ToString(), 10, pozTop));
                    pozTop += 20;
                }
            }

            foreach (CheckBox cb in listCheckBoxesSpecializari)
            {
                panel_CheckList_Alocare_Disciplina_Spec.Controls.Add(cb);
            }
        }

        void cleanPanel()
        {
            foreach (Control c in panel_CheckList_Alocare_Disciplina_Spec.Controls)
                panel_CheckList_Alocare_Disciplina_Spec.Controls.Remove(c);
        }

        void adaugaCheckBoxInList()
        {
            foreach (Control c in panel_CheckList_Alocare_Disciplina_Spec.Controls)
                listPanelCheckBoxSpecializari.Add((CheckBox)c);
        }
        #endregion

        private void buttonAlocaDisciplina_Click(object sender, EventArgs e)
        {
            string idDisc = AddDataForm.idDisciplinaAdaugata.ToString();
            if (listPanelCheckBoxSpecializari.Count > 0)
            {
                foreach (CheckBox c in listPanelCheckBoxSpecializari)
                {
                    if (c.Checked == true)
                    {
                        string codSpec = "";
                        string anStudiuId = "";
                        bool exista = false;
                        foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                        {
                            if (dr.ItemArray.GetValue(1).ToString() == c.Text.ToString())
                                codSpec = dr.ItemArray.GetValue(0).ToString();
                        }
                        foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                        {
                            if (dr.ItemArray.GetValue(0).ToString() == comboBoxDropDownListAlocareDiscAnStudiuList.SelectedItem.ToString())
                                anStudiuId = dr.ItemArray.GetValue(0).ToString();
                        }

                        foreach (DataRow dr in ds.Tables["ALOCAREDISCIPLINA"].Rows)
                        {
                            if (dr.ItemArray.GetValue(0).ToString() == codSpec.ToString() && dr.ItemArray.GetValue(1).ToString() == idDisc.ToString() && dr.ItemArray.GetValue(2).ToString() == anStudiuId.ToString())
                            {
                                exista = true; // alocarea exista deja                 
                                break;
                            }
                        }
                        if (exista == false)
                        {
                            string insertAlocare = "INSERT INTO AlocareDisciplina VALUES ('" + codSpec.ToString() + "', '" + idDisc.ToString() + "','" + anStudiuId.ToString() + "','" + returnRadioButtonName(listRadioButtonSemestru).ToString() + "','" + returnRadioButtonName(listRadioButtonTipEvaluare).ToString() + "','" + returnRadioButtonName(listRadioButtonStatusDisciplina).ToString() + "')";
                            con.Open();
                            SqlCommand cmdInsertAlocare = new SqlCommand(insertAlocare, con);
                            cmdInsertAlocare.ExecuteNonQuery();
                            ds.Tables["ALOCAREDISCIPLINA"].Clear();
                            SqlDataAdapter daAlocare = new SqlDataAdapter("SELECT * FROM AlocareDisciplina", con);
                            daAlocare.Fill(ds, "ALOCAREDISCIPLINA");
                            con.Close();
                            MessageBox.Show("Disciplina " + denumiDisciplinaAdaugata + " a fost alocata cu succes, avand urmatoarele specificatii:" + "\nSpecializarea: " + c.Text.ToString() + " \nAnul de studiu: " + comboBoxDropDownListAlocareDiscAnStudiuList.SelectedItem.ToString() + "\nSemestrul: " + returnRadioButtonName(listRadioButtonSemestru).ToString() + " \nTip Evaluare: " + returnRadioButtonName(listRadioButtonTipEvaluare).ToString() + "\nStatus: " + returnRadioButtonName(listRadioButtonStatusDisciplina).ToString());
                        }
                        else
                            MessageBox.Show("Alocarea exista deja in baza de date!");
                    }
                }
            }
            else 
            {
                MessageBox.Show("Selectati cel putin o specializare pentru care alocati disciplina "+ denumiDisciplinaAdaugata+" !");
            }
        }

        private void buttonIesire_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_back_AddDataForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = Application.OpenForms["AddDataForm"];
            form.Show();
        }

        Acoperire acoperireForm = new Acoperire();
        private void button_toAcoperireForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            acoperireForm.ShowDialog();
        }
    }
}
