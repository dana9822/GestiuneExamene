using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
        static string anUniversitarCurent;
        static string idSesiuneCurenta;
        static string dataInceputSesiuneCurenta;
        static string dataFinalSesiuneCurenta;
        static string denumireSesiuneCurenta;
        List<RadioButton> listRadioButtonModEvaluare = new List<RadioButton>();
        List<RadioButton> listRadioButtonSemestru = new List<RadioButton>();
        List<RadioButton> listRadioButtonsModEvaluareRestanta = new List<RadioButton>();
        static bool statusServerOk;
        static string idSesiuneRestante;
        static string dataInceputSesiuneRestante;
        static string dataFinalSesiuneRestante;
        static string denumireSesiuneRestante;
        #endregion

        #region backButton
        private void buttonScheduleExamBack_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Hide();
            this.Dispose();

            home.ShowDialog();
        }
        #endregion
        private void ScheduleExamForm_Load(object sender, EventArgs e)
        {
            conectare();
            showGUIServerStatus();
            completareDataSet();
            adaugaRadioButtonInList();
            getAnUniversitarCurent();
            getSesiuneCurenta();
            getSesiuneCurentaRestante();
            showCurrentAcademicYear();
            adaugaSpecializareToDropDownList();
            adaugaSalaToDropDownList();
            adaugaProfesorRestanta();
            createRadioButtons();
            completeazaGridExamen();
            seteazaProprietatiGridExamen();
            completeazaGridRestanta();
            seteazaProprietatiGridRestanta();
            labelExamenAnUniversitarCurent.Visible = true;
            labelExamenAnUniversitarCurent.Text = anUniversitarCurent.ToString();
            labelSesiuneCurentaExamen.Visible = true;
            labelSesiuneCurentaExamen.Text = denumireSesiuneCurenta.ToString() + " - " + dataInceputSesiuneCurenta.ToString();
            label_RestantaAnUnivCurent.Visible = true;
            label_RestantaAnUnivCurent.Text = anUniversitarCurent.ToString();
            label_RestantaSesiuneCurenta.Visible = true;
            label_RestantaSesiuneCurenta.Text = denumireSesiuneRestante.ToString() + " - " + dataInceputSesiuneRestante.ToString();
        }

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
            string selectExamen = "SELECT * FROM ProgramareExamen";
            string selectRestanta = "SELECT * FROM ProgramareRestanta";
            string joinAlocareAcoperire = "SELECT aloc.idSpecializare,aloc.idDisciplina,aloc.anStudiu,semestru,tipEvaluare,status,anUniversitar,marcaProfesor FROM AlocareDisciplina as aloc JOIN AcoperireDisciplina as acop ON aloc.idSpecializare=acop.idSpecializare AND aloc.idDisciplina=acop.idDisciplina AND aloc.anStudiu=acop.anStudiu";

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
            da = new SqlDataAdapter(joinAlocareAcoperire, con);
            da.Fill(ds, "DisciplinaAlocataAcoperita");
            da = new SqlDataAdapter(selectExamen, con);
            da.Fill(ds, "EXAMEN");
            da = new SqlDataAdapter(selectRestanta, con);
            da.Fill(ds, "RESTANTA");

            //Close connection
            con.Close();

        }
        void adaugaExamenToDataSet()
        {
            con.Open();
            string selectExamen = "SELECT * FROM ProgramareExamen";
            da = new SqlDataAdapter(selectExamen, con);
            da.Fill(ds, "EXAMEN");
            con.Close();
        }
        void adaugaRestantaToDataSet()
        {
            con.Open();
            string selectExamen = "SELECT * FROM ProgramareRestanta";
            da = new SqlDataAdapter(selectExamen, con);
            da.Fill(ds, "RESTANTA");
            con.Close();
        }
        #endregion

        #region ServerStatus
        public void showGUIServerStatus()
        {
            //verificare conexiune si afisare mesaj in label cu statusul conexiunii
            try
            {
                con.Open();
                labelScheduleExamServerStatus.Visible = true;
                labelScheduleExamServerStatus.ForeColor = Color.Green;
                labelScheduleExamServerStatus.Text = String.Format("Server online");
                statusServerOk = true;
            }
            catch (Exception e)
            {
                labelScheduleExamServerStatus.Visible = true;
                labelScheduleExamServerStatus.ForeColor = Color.Red;
                labelScheduleExamServerStatus.Text = String.Format("Server offline");
                MessageBox.Show(e.Message.ToString());
                statusServerOk = false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region currentAcademicalYearGUI
        public void showCurrentAcademicYear()
        {
            if (!String.IsNullOrEmpty(anUniversitarCurent))
            {
                labelScheduleExamCurrentAcademicalYear.Visible = true;
                labelScheduleExamCurrentAcademicalYear.Text = "Anul universitar in curs: " + anUniversitarCurent;
            }
            else
            {
                labelScheduleExamCurrentAcademicalYear.Visible = true;
                labelScheduleExamCurrentAcademicalYear.Text = "Datele nu sunt disponibile";
            }
        }
        #endregion

        #region getCurrentAcademicalYear
        public string getAnUniversitarCurent()
        {
            //SELECT top 1 * FROM AnUniversitar order by anUniversitar Desc; => obtine ultima inregistrare/ultimul anUniv adaugat in BD
            string anUniversitar = string.Empty;
            con.Open();
            string query = "SELECT top 1 anUniversitar FROM AnUniversitar order by anUniversitar Desc;";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader idAnUniv = cmd.ExecuteReader();
            if (idAnUniv.Read()) //=> true daca are randuri returnate
            {
                anUniversitar = idAnUniv.GetValue(0).ToString();
            }
            con.Close();
            anUniversitarCurent = anUniversitar;
            //MessageBox.Show("Anul universitar rezultat din metoda este: "+anUniversitar); //=>test functionare metoda
            //MessageBox.Show("Anul universitar curent(static) este: " + anUniversitarCurent);
            return anUniversitar;
        }
        #endregion

        #region getSesiuneCurenta + Sesiune restante
        public void getSesiuneCurenta()
        {
            con.Open();
            string query = "SELECT top 1 idSesiune,anUniversitar,dataInceput,dataFinal FROM An_Sesiune WHERE idSesiune IN (1,2) ORDER BY dataInceput Desc;";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader returnedRows = cmd.ExecuteReader();
            if (returnedRows.Read())
            {
                idSesiuneCurenta = returnedRows.GetValue(0).ToString();
                dataInceputSesiuneCurenta = returnedRows.GetValue(2).ToString();
                dataFinalSesiuneCurenta = returnedRows.GetValue(3).ToString();
            }

            foreach (DataRow dr in ds.Tables["SESIUNE"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString() == idSesiuneCurenta)
                    denumireSesiuneCurenta = dr.ItemArray.GetValue(1).ToString();
            }

            con.Close();
            //MessageBox.Show("Sesiune curenta id: "+ idSesiuneCurenta +" ,denumire: "+denumireSesiuneCurenta+ " ,data inceput: "+ dataInceputSesiuneCurenta+ " ,data final: "+ dataFinalSesiuneCurenta);
        }

        public void getSesiuneCurentaRestante()
        {
            con.Open();
            string query = "SELECT top 1 idSesiune,anUniversitar,dataInceput,dataFinal FROM An_Sesiune WHERE idSesiune IN (3) ORDER BY dataInceput Desc;";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader returnedRows = cmd.ExecuteReader();
            if (returnedRows.Read())
            {
                idSesiuneRestante = returnedRows.GetValue(0).ToString();
                dataInceputSesiuneRestante = returnedRows.GetValue(2).ToString();
                dataFinalSesiuneRestante = returnedRows.GetValue(3).ToString();
            }

            foreach (DataRow dr in ds.Tables["SESIUNE"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString() == idSesiuneRestante)
                    denumireSesiuneRestante = dr.ItemArray.GetValue(1).ToString();
            }

            con.Close();
            //MessageBox.Show("Sesiune curenta id: "+ idSesiuneCurenta +" ,denumire: "+denumireSesiuneCurenta+ " ,data inceput: "+ dataInceputSesiuneCurenta+ " ,data final: "+ dataFinalSesiuneCurenta);
        }
        #endregion

        #region RadioButtonMethods
        void adaugaRadioButtonInList()
        {

            foreach (Control c in groupBoxModEvaluare.Controls)
                listRadioButtonModEvaluare.Add((RadioButton)c);
            foreach (Control c in groupBoxDiscSemestru.Controls)
                listRadioButtonSemestru.Add((RadioButton)c);
            foreach (Control c in groupBoxModEvRestanta.Controls)
                listRadioButtonsModEvaluareRestanta.Add((RadioButton)c);
        }

        string returnRadioButtonName(List<RadioButton> listaRadioButtons)
        {
            foreach (RadioButton rb in listaRadioButtons)
                if (rb.Checked)
                    return rb.Text;
            return "";
        }
        #endregion

        #region PopulateDropDownLists + SelectedIndexChangedActions
        void adaugaDisciplinaToDropDownList()
        {
            comboBoxExamenDisciplina.Items.Clear();

            List<string> discipline = new List<string>();
            string idSpecializareSelectata = "";
            string anStudiuGrupa = "";

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenSpecializare.SelectedItem.ToString())
                    idSpecializareSelectata = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["GRUPA"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString() == idSpecializareSelectata && dr.ItemArray.GetValue(3).ToString() == anUniversitarCurent.ToString())
                {
                    if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExmenGrupa.SelectedItem.ToString())
                        anStudiuGrupa = dr.ItemArray.GetValue(2).ToString();
                }
            }

            foreach (DataRow drAloc in ds.Tables["DisciplinaAlocataAcoperita"].Rows)
            {
                if (drAloc.ItemArray.GetValue(0).ToString() == idSpecializareSelectata)  // daca disciplina este alocata specializarii selectate
                {
                    if (drAloc.ItemArray.GetValue(5).ToString() == "Activ")  // daca este activa pentru anul universitar in curs
                    {
                        if (drAloc.ItemArray.GetValue(6).ToString() == anUniversitarCurent)
                        {
                            if (drAloc.ItemArray.GetValue(2).ToString() == anStudiuGrupa)
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
                }
            }
            List<string> distinct = discipline.Distinct().ToList();
            foreach (String disc in distinct)
            {
                comboBoxExamenDisciplina.Items.Add(disc);
            }

            if (comboBoxExamenDisciplina.Items.Count > 0)
                comboBoxExamenDisciplina.SelectedIndex = 0;
        }

        void getTipEvaluareDisciplina()
        {
            string idDisciplinaSelectata = "";
            string idSpecializareSelectata = "";
            string anStudiuGrupaSelectata = "";

            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenDisciplina.SelectedItem.ToString())
                    idDisciplinaSelectata = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenSpecializare.SelectedItem.ToString())
                    idSpecializareSelectata = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["GRUPA"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() == idSpecializareSelectata && dr.ItemArray.GetValue(3).ToString() == anUniversitarCurent.ToString() && dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExmenGrupa.SelectedItem.ToString())
                    anStudiuGrupaSelectata = dr.ItemArray.GetValue(2).ToString();

            foreach (DataRow dr in ds.Tables["DisciplinaAlocataAcoperita"].Rows)
            {
                //preluare din cele 3 selectii : disciplina, specializarea, anul de studiu => afisare tip evaluare
                if (dr.ItemArray.GetValue(0).ToString() == idSpecializareSelectata && dr.ItemArray.GetValue(1).ToString() == idDisciplinaSelectata && dr.ItemArray.GetValue(2).ToString() == anStudiuGrupaSelectata)
                {
                    labelExamenTipEvaluare.Visible = true;
                    labelExamenTipEvaluare.Text = dr.ItemArray.GetValue(4).ToString();
                }
            }
        }
        void adaugaSpecializareToDropDownList()
        {
            comboBoxExamenSpecializare.Items.Clear();

            List<string> specializari = new List<string>();
            foreach (DataRow drAloc in ds.Tables["DisciplinaAlocataAcoperita"].Rows)  // doar specializarile care au materii alocate
            {
                if (drAloc.ItemArray.GetValue(5).ToString() == "Activ")  //daca disciplina este inca valida la specializarea x pentru anul in curs
                {
                    if (drAloc.ItemArray.GetValue(6).ToString() == anUniversitarCurent) // daca este activ si apartine anului Univ curent
                    {
                        //if (drAloc.ItemArray.GetValue(3).ToString() == returnRadioButtonName(listRadioButtonSemestru).ToString())  //daca semestrul corespunde cu cel bifat
                        //{
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
                        //}
                    }
                }
            }
            List<string> distinct = specializari.Distinct().ToList();
            foreach (String spec in distinct)
            {
                comboBoxExamenSpecializare.Items.Add(spec);
            }
            if (comboBoxExamenSpecializare.Items.Count > 0)
                comboBoxExamenSpecializare.SelectedIndex = 0;
        }

        void adaugaGrupaToDropDownList()
        {
            comboBoxExmenGrupa.Items.Clear();

            string idSpecializareSelectata = "";

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenSpecializare.SelectedItem.ToString())
                    idSpecializareSelectata = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["GRUPA"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString() == idSpecializareSelectata && dr.ItemArray.GetValue(3).ToString() == anUniversitarCurent.ToString())
                {
                    //daca grupa este la specializarea selectata si in anul universitar curent => adauga in lista de grupe
                    comboBoxExmenGrupa.Items.Add(dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString());
                }
            }

            if (comboBoxExmenGrupa.Items.Count > 0)
                comboBoxExmenGrupa.SelectedIndex = 0;

        }

        bool activareEvenimentDropDownListSpecializare = false;

        private void specializare_selectedIndexChanged(object sender,EventArgs e)
        {
            if (!activareEvenimentDropDownListSpecializare)
            {
                adaugaGrupaToDropDownList();
            }
        }

        bool activareEvenimentDropDownListGrupa = false;

        private void grupa_selectedIndexChanged(object sender,EventArgs e)
        {
            if (!activareEvenimentDropDownListGrupa)
                adaugaDisciplinaToDropDownList();
        }

        bool activareEvenimentDropDownListDisciplina = false;

        private void disciplina_selectedIndexChanged(object sender, EventArgs e)
        {
            if (!activareEvenimentDropDownListDisciplina)
            {
                getTipEvaluareDisciplina();
                adaugaProfesorTitularToDropDownList();
            }
        }
        void adaugaSalaToDropDownList()
        {
            comboBoxExamenSala.Items.Clear();
            comboBoxRestantaSala.Items.Clear();

            foreach (DataRow drSala in ds.Tables["SALA"].Rows)
            {
                foreach (DataRow drCorp in ds.Tables["CORP"].Rows)
                    if (drCorp.ItemArray.GetValue(0).ToString() == drSala.ItemArray.GetValue(0).ToString())
                    {
                        comboBoxExamenSala.Items.Add(drCorp.ItemArray.GetValue(1).ToString() + drSala.ItemArray.GetValue(2).ToString() + drSala.ItemArray.GetValue(1).ToString()); //corp + etaj + nrSala => I.2.4 , Y.1.01
                        comboBoxRestantaSala.Items.Add(drCorp.ItemArray.GetValue(1).ToString() + drSala.ItemArray.GetValue(2).ToString() + drSala.ItemArray.GetValue(1).ToString());
                    }
            }

            if (comboBoxExamenSala.Items.Count > 0)
                comboBoxExamenSala.SelectedIndex = 0;
            if (comboBoxRestantaSala.Items.Count > 0)
                comboBoxRestantaSala.SelectedIndex = 0;
        }

        void adaugaProfesorTitularToDropDownList()
        {
            comboBoxExamenProfTitular.Items.Clear();

            List<string> profesoriTitulari = new List<string>();
            string idDisciplinaSelectata = "";
            string idSpecializareSelectata = "";
            string anStudiuGrupa = "";

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenSpecializare.SelectedItem.ToString())
                    idSpecializareSelectata = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow dr in ds.Tables["GRUPA"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString() == idSpecializareSelectata && dr.ItemArray.GetValue(3).ToString() == anUniversitarCurent.ToString())
                {
                    if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExmenGrupa.SelectedItem.ToString())
                        anStudiuGrupa = dr.ItemArray.GetValue(2).ToString();
                }
            }

            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenDisciplina.SelectedItem.ToString())
                    idDisciplinaSelectata = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow drAloc in ds.Tables["DisciplinaAlocataAcoperita"].Rows)
            {
                if (drAloc.ItemArray.GetValue(0).ToString() == idSpecializareSelectata) //daca profesorul preda la specializarea selectata
                { 
                    if (drAloc.ItemArray.GetValue(1).ToString() == idDisciplinaSelectata)  //disciplina selectata
                    {
                        if (drAloc.ItemArray.GetValue(5).ToString() == "Activ") //daca este inca activ statusul pe anul univ curent
                        {
                            if (drAloc.ItemArray.GetValue(6).ToString() == anUniversitarCurent) //daca anul univ corespunde cu cel curent
                            {
                                if (drAloc.ItemArray.GetValue(2).ToString() == anStudiuGrupa) //daca anul de studiu al spec+gr este cel selectat
                                {
                                    if (drAloc.ItemArray.GetValue(3).ToString() == returnRadioButtonName(listRadioButtonSemestru).ToString())  //daca semestrul corespunde cu cel bifat
                                    {
                                        foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                                        {
                                            if (drAloc.ItemArray.GetValue(7).ToString() == dr.ItemArray.GetValue(0).ToString())
                                            {
                                                profesoriTitulari.Add(dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            List<string> distinct = profesoriTitulari.Distinct().ToList();
            foreach (String prof in distinct)
            {
                comboBoxExamenProfTitular.Items.Add(prof);
            }

            if (comboBoxExamenProfTitular.Items.Count > 0)
                comboBoxExamenProfTitular.SelectedIndex = 0;
        }

        bool activareEvenimentDropDownListProfTitular = false;

        private void profTitular_selectedIndexChanged(object sender, EventArgs e)
        {
            if (!activareEvenimentDropDownListProfTitular)
                adaugaProfesorSupraveghetorToDropDownList();
        }

        void adaugaProfesorSupraveghetorToDropDownList()
        {
            comboBoxExamenProfSuprav.Items.Clear();

            List<string> profesorSuprav = new List<string>();
            string marcaProfesorTitular = "";

            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                if (dr.ItemArray.GetValue(1).ToString()+" "+ dr.ItemArray.GetValue(2).ToString() == comboBoxExamenProfTitular.SelectedItem.ToString())
                    marcaProfesorTitular = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() != marcaProfesorTitular)
                    profesorSuprav.Add(dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString());

            List<string> distinct = profesorSuprav.Distinct().ToList();
            foreach (String prof in distinct)
            {
                comboBoxExamenProfSuprav.Items.Add(prof);
            }

            if (comboBoxExamenProfSuprav.Items.Count > 0)
                comboBoxExamenProfSuprav.SelectedIndex = 0;
        }

        void adaugaProfesorRestanta()
        {
            comboBoxRestantaProfesor.Items.Clear();

            List<string> profesoriTitulari = new List<string>();


            foreach (DataRow drAloc in ds.Tables["DisciplinaAlocataAcoperita"].Rows)
            {
                foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                {
                    if (drAloc.ItemArray.GetValue(7).ToString() == dr.ItemArray.GetValue(0).ToString())
                    {
                        profesoriTitulari.Add(dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString());
                    }
                }
            }

            List<string> distinct = profesoriTitulari.Distinct().ToList();
            foreach (String prof in distinct)
            {
                comboBoxRestantaProfesor.Items.Add(prof);
            }

            if (comboBoxRestantaProfesor.Items.Count > 0)
                comboBoxRestantaProfesor.SelectedIndex = 0;
        }

        bool activareEvenimentDropDownListProfesorRestanta = false;

        private void profTitularRestanta_selectedIndexChanged(object sender, EventArgs e)
        {
            if (!activareEvenimentDropDownListProfesorRestanta)
                adaugaDisciplinaRestanta();
        }

        void adaugaDisciplinaRestanta()
        {
            comboBoxRestantaDisciplina.Items.Clear();
            List<string> discipline = new List<string>();
            string codProfesor = "";

            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxRestantaProfesor.SelectedItem.ToString())
                    codProfesor = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow drAloc in ds.Tables["DisciplinaAlocataAcoperita"].Rows)
            {
                if (drAloc.ItemArray.GetValue(7).ToString() == codProfesor)
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

            List<string> distinct = discipline.Distinct().ToList();
            foreach (String disc in distinct)
            {
                comboBoxRestantaDisciplina.Items.Add(disc);
            }

            if (comboBoxRestantaDisciplina.Items.Count > 0)
                comboBoxRestantaDisciplina.SelectedIndex = 0;

        }
        #endregion

        #region ProgramareExamen

        private bool ValidareExamen()
        {
            if (statusServerOk == false)
            {
                MessageBox.Show("Aplicatia nu s-a putut conecta la serverul bazei de date!","Conexiune pierduta");
                return false;
            }
            if (comboBoxExamenSpecializare.Items.Count <= 0)
            {
                MessageBox.Show("Lista specializarilor este goala.\nProgramarea examenului nu se poate realiza!");
                return false;
            }
            if (comboBoxExmenGrupa.Items.Count <= 0)
            {
                MessageBox.Show("Lista grupelor este goala.\nProgramarea examenului nu se poate realiza!");
                return false;
            }
            if (comboBoxExamenDisciplina.Items.Count <= 0)
            {
                MessageBox.Show("Lista disciplinelor este goala.\nProgramarea examenului nu se poate realiza!");
                return false;
            }
            if (comboBoxExamenSala.Items.Count <= 0)
            {
                MessageBox.Show("Lista salilor este goala.\nProgramarea examenului nu se poate realiza!");
                return false;
            }
            if (comboBoxExamenProfTitular.Items.Count <= 0)
            {
                MessageBox.Show("Lista profesorilor titulari este goala.\nProgramarea examenului nu se poate realiza!");
                return false;
            }
            if (comboBoxExamenProfSuprav.Items.Count <= 0)
            {
                MessageBox.Show("Lista profesorilor supraveghetori este goala.\nProgramarea examenului nu se poate realiza!");
                return false;
            }
            if (dateTimePickerDataExamen.Value.Date > Convert.ToDateTime(dataFinalSesiuneCurenta))
            {
                MessageBox.Show("Nu puteti programa examene in afara sesiunii!\nData este prea tarzie!");
                return false;
            }
            if (dateTimePickerDataExamen.Value.Date < Convert.ToDateTime(dataInceputSesiuneCurenta) && labelExamenTipEvaluare.Text == "Examen")
            { 
                MessageBox.Show("Examenele nu pot avea loc la date care sunt inaintea inceperii sesiunii!");
                return false;
            }
            ds.Tables["EXAMEN"].Clear();
            adaugaExamenToDataSet();
            string codSpec = "";
            string nrGrupa = "";
            string anStudiu = "";
            int nrStudenti = 0;
            List<DateTime> listaDateExameneSpecGr = new List<DateTime>();
            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenSpecializare.SelectedItem.ToString())
                    codSpec = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["GRUPA"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString() == codSpec && dr.ItemArray.GetValue(3).ToString() == anUniversitarCurent.ToString())
                {
                    if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExmenGrupa.SelectedItem.ToString())
                    {
                        nrGrupa = dr.ItemArray.GetValue(1).ToString();
                        anStudiu = dr.ItemArray.GetValue(2).ToString();
                        nrStudenti = Convert.ToInt32(dr.ItemArray.GetValue(4));
                    }
                }
            }
            string codProfTitular = "";
            string codProfAsistentExamen = "";
            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
            {
                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExamenProfTitular.SelectedItem.ToString())
                    codProfTitular = dr.ItemArray.GetValue(0).ToString();
                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExamenProfSuprav.SelectedItem.ToString())
                    codProfAsistentExamen = dr.ItemArray.GetValue(0).ToString();
            }
            int capacitateSala = 0;
            string idCorp = "";
            string nrSala = "";
            string etaj = "";
            foreach (DataRow drSala in ds.Tables["SALA"].Rows)
            {
                foreach (DataRow drCorp in ds.Tables["CORP"].Rows)
                    if (drCorp.ItemArray.GetValue(0).ToString() == drSala.ItemArray.GetValue(0).ToString())
                        if (drCorp.ItemArray.GetValue(1).ToString() + drSala.ItemArray.GetValue(2).ToString() + drSala.ItemArray.GetValue(1).ToString() == comboBoxExamenSala.SelectedItem.ToString()) //corp + etaj + nrSala => I.2.4 , Y.1.01
                        {
                            idCorp = drCorp.ItemArray.GetValue(0).ToString();
                            nrSala = drSala.ItemArray.GetValue(1).ToString();
                            etaj = drSala.ItemArray.GetValue(2).ToString();
                            capacitateSala = Convert.ToInt32(drSala.ItemArray.GetValue(3));
                        }
            }
            string data;
            DateTime dataSelectataUserBefore = Convert.ToDateTime(dateTimePickerDataExamen.Value.AddDays(-3).ToShortDateString()); //before exam ,pentru minim 3 zile inainte/dupa examen
            DateTime dataSelectataUserAfter = Convert.ToDateTime(dateTimePickerDataExamen.Value.AddDays(+3).ToShortDateString()); //after exam
            foreach (DataRow dr in ds.Tables["EXAMEN"].Rows)
            {
                data = dr.ItemArray.GetValue(9).ToString();
                if (dr.ItemArray.GetValue(8).ToString() == anUniversitarCurent && dr.ItemArray.GetValue(3).ToString() == idSesiuneCurenta &&
                    dr.ItemArray.GetValue(5).ToString() == codSpec && dr.ItemArray.GetValue(6).ToString() == nrGrupa && dr.ItemArray.GetValue(7).ToString() == anStudiu &&
                    Convert.ToDateTime(data) == Convert.ToDateTime(dateTimePickerDataExamen.Value.ToShortDateString()))
                {
                    //grupa are deja examen=> Functioneaza
                    MessageBox.Show("Grupa " + nrGrupa + " de la specializarea " + comboBoxExamenSpecializare.SelectedItem.ToString() +
                        " are deja un examen programat la data :" + dateTimePickerDataExamen.Value.ToShortDateString());
                    return false;
                }
                if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta &&
                  Convert.ToDateTime(data) == Convert.ToDateTime(dateTimePickerDataExamen.Value.ToShortDateString()) && Convert.ToInt32(dr["ora"].ToString()) == numericUpDownExamenOra.Value
                   && dr["profTitular"].ToString() == codProfTitular)
                {
                    MessageBox.Show("Profesorul "+ comboBoxExamenProfTitular.SelectedItem.ToString()+" are deja programat un examen la data de "+ dateTimePickerDataExamen.Value.ToShortDateString()+" si ora "+ numericUpDownExamenOra.Value+" !");
                    return false;
                }
                if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta &&
                 Convert.ToDateTime(data) == Convert.ToDateTime(dateTimePickerDataExamen.Value.ToShortDateString()) && Convert.ToInt32(dr["ora"].ToString()) == numericUpDownExamenOra.Value
                  && dr["profSupraveghetor"].ToString() == codProfAsistentExamen)
                {
                    MessageBox.Show("Asistentul examinator " + comboBoxExamenProfSuprav.SelectedItem.ToString() + " are deja programat un examen la data de " + dateTimePickerDataExamen.Value.ToShortDateString() + " si ora " + numericUpDownExamenOra.Value + " !");
                    return false;
                }
                //---------------- Verificare => profesor titular sa nu fie asistent pentru alt examen si asistent examinator sa nu fie titular pentru alt examen deja programat
                if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta &&
                Convert.ToDateTime(data) == Convert.ToDateTime(dateTimePickerDataExamen.Value.ToShortDateString()) && Convert.ToInt32(dr["ora"].ToString()) == numericUpDownExamenOra.Value
                 && dr["profSupraveghetor"].ToString() == codProfTitular)
                {
                    MessageBox.Show("Profesorul titular " + comboBoxExamenProfTitular.SelectedItem.ToString() + " este asistent la un examen la data de " + dateTimePickerDataExamen.Value.ToShortDateString() + " si ora " + numericUpDownExamenOra.Value + " !");
                    return false;
                }
                if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta &&
                 Convert.ToDateTime(data) == Convert.ToDateTime(dateTimePickerDataExamen.Value.ToShortDateString()) && Convert.ToInt32(dr["ora"].ToString()) == numericUpDownExamenOra.Value
                  && dr["profTitular"].ToString() == codProfAsistentExamen)
                {
                    MessageBox.Show("Asistentul examinator " + comboBoxExamenProfSuprav.SelectedItem.ToString() + " este profesor titular la un examen la data de " + dateTimePickerDataExamen.Value.ToShortDateString() + " si ora " + numericUpDownExamenOra.Value + " !");
                    return false;
                }
                //----------------
                if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta &&
                   Convert.ToDateTime(data) == Convert.ToDateTime(dateTimePickerDataExamen.Value.ToShortDateString()) && Convert.ToInt32(dr["ora"].ToString()) == numericUpDownExamenOra.Value
                    && dr.ItemArray.GetValue(0).ToString()== idCorp && dr.ItemArray.GetValue(2).ToString() == etaj && dr.ItemArray.GetValue(1).ToString() == nrSala)
                {
                    //sala e deja ocupata
                    MessageBox.Show("Sala " + comboBoxExamenSala.SelectedItem.ToString() + " este ocupata la data " + dateTimePickerDataExamen.Value.ToShortDateString() +
                        " ora: " + numericUpDownExamenOra.Value.ToString());
                    return false;
                }
                if (capacitateSala < nrStudenti)
                {
                    //capacitatea salii este prea mica =>FUNCTIONEAZA
                    MessageBox.Show("Sala nu are suficiente locuri (" + capacitateSala + ") pentru numarul de studenti (" + nrStudenti +
                        ") de la grupa " + nrGrupa);
                    return false;
                }
                if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta &&
                    dr["idSpecializare"].ToString() == codSpec && dr["nrGrupa"].ToString() == nrGrupa && dr["anStudiu"].ToString() == anStudiu)
                {
                    //lista date examene pentru grupa selectata => folosita pentru verificare datei examenului la distanta de 3 zile fata de cele programate deja
                    listaDateExameneSpecGr.Add(Convert.ToDateTime(dr["data"].ToString()));
                    //if (dataSelectataUserB <= Convert.ToDateTime(data) && dataSelectataUserA >= Convert.ToDateTime(data))
                    //{
                    //    //limita de 3 zile nu este valida
                    //    MessageBox.Show("Intre examene trebuie sa existe minim 3 zile libere!");
                    //    return false;
                    //}
                }
            }
            string dataVerif = "";
            foreach (DataRow dr in ds.Tables["EXAMEN"].Rows)
            {
                dataVerif = dr.ItemArray.GetValue(9).ToString();
                foreach (DateTime d in listaDateExameneSpecGr)
                {
                    if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta &&
                    dr["idSpecializare"].ToString() == codSpec && dr["nrGrupa"].ToString() == nrGrupa && dr["anStudiu"].ToString() == anStudiu)
                    {
                        //    if (dateTimePicker1.Value.AddDays(-3) <= d && dateTimePicker1.Value.AddDays(+3) <= d) =>nu calculeaza bine
                        if (dataSelectataUserBefore <= Convert.ToDateTime(dataVerif) && dataSelectataUserAfter >= Convert.ToDateTime(dataVerif))
                        {
                            //limita de 3 zile nu este valida
                            MessageBox.Show("Intre examene trebuie sa existe minim 3 zile libere!");
                            //listaDateExameneSpecGr.Clear();
                            return false;
                        }
                    }
                }
            }
            listaDateExameneSpecGr.Clear();
            return true;
        }

        private void button_ValidareExamen_Click(object sender, EventArgs e)
        {
            if (ValidareExamen() == true)
                MessageBox.Show("Examenul este validat si poate fi programat!");
        }
        private void buttonProgrameazaExamen_Click(object sender, EventArgs e)
        {
            if (ValidareExamen() == true)
            {
                ds.Tables["EXAMEN"].Clear();
                SqlDataAdapter daExamen = new SqlDataAdapter("SELECT * FROM ProgramareExamen", con);
                con.Open();
                daExamen.Fill(ds, "EXAMEN");
                con.Close();
                DataTable dt = ds.Tables["EXAMEN"];
                DataRow dr1 = dt.NewRow();

                //----------Id-uri PK+FK---------------
                string codSpec = "";
                foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenSpecializare.SelectedItem.ToString())
                        codSpec = dr.ItemArray.GetValue(0).ToString();
                string nrGrupa = "";
                string anStudiu = "";
                foreach (DataRow dr in ds.Tables["GRUPA"].Rows)
                {
                    if (dr.ItemArray.GetValue(0).ToString() == codSpec && dr.ItemArray.GetValue(3).ToString() == anUniversitarCurent.ToString())
                    {
                        if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExmenGrupa.SelectedItem.ToString())
                        {
                            nrGrupa = dr.ItemArray.GetValue(1).ToString();
                            anStudiu = dr.ItemArray.GetValue(2).ToString();
                        }
                    }
                }

                string idDisciplina = "";
                foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenDisciplina.SelectedItem.ToString())
                        idDisciplina = dr.ItemArray.GetValue(0).ToString();

                string codProfTitular = "";
                foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExamenProfTitular.SelectedItem.ToString())
                        codProfTitular = dr.ItemArray.GetValue(0).ToString();

                string codProfSuprav = "";
                foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxExamenProfSuprav.SelectedItem.ToString())
                        codProfSuprav = dr.ItemArray.GetValue(0).ToString();

                string idCorp = "";
                string nrSala = "";
                string etaj = "";
                foreach (DataRow drSala in ds.Tables["SALA"].Rows)
                {
                    foreach (DataRow drCorp in ds.Tables["CORP"].Rows)
                        if (drCorp.ItemArray.GetValue(0).ToString() == drSala.ItemArray.GetValue(0).ToString())
                            if (drCorp.ItemArray.GetValue(1).ToString() + drSala.ItemArray.GetValue(2).ToString() + drSala.ItemArray.GetValue(1).ToString() == comboBoxExamenSala.SelectedItem.ToString()) //corp + etaj + nrSala => I.2.4 , Y.1.01
                            {
                                idCorp = drCorp.ItemArray.GetValue(0).ToString();
                                nrSala = drSala.ItemArray.GetValue(1).ToString();
                                etaj = drSala.ItemArray.GetValue(2).ToString();
                            }
                }
                //-------------------------------------
                dr1[0] = idCorp;
                dr1[1] = nrSala;
                dr1[2] = etaj;
                dr1[3] = idSesiuneCurenta;
                dr1[4] = idDisciplina;
                dr1[5] = codSpec;
                dr1[6] = nrGrupa;
                dr1[7] = anStudiu;
                dr1[8] = anUniversitarCurent;
                dr1[9] = dateTimePickerDataExamen.Value.Date;
                dr1[10] = Convert.ToInt32(numericUpDownExamenOra.Value);
                dr1[11] = Convert.ToInt32(numericUpDownExamenDurata.Value);
                dr1[12] = returnRadioButtonName(listRadioButtonModEvaluare);
                dr1[13] = codProfTitular;
                dr1[14] = codProfSuprav;

                dt.Rows.Add(dr1);
                SqlCommandBuilder cb = new SqlCommandBuilder(daExamen);
                cb.DataAdapter.Update(dt);
                MessageBox.Show("Examenul a fost programat cu succes!");
                completeazaGridExamen();
                seteazaProprietatiGridExamen();
            }
            else
                MessageBox.Show("Modificati greselile si incercati din nou!");
        }

        #endregion

        #region DataGrid Examen
        void completeazaGridExamen()
        {
            adaugaExamenJoinToDataSet();
            dataGridViewExamen.DataSource = ds.Tables["ExamenJoin"];
        }
        void adaugaExamenJoinToDataSet()
        {
            foreach (DataTable dt in ds.Tables)
                if (dt.TableName == "ExamenJoin")
                    ds.Tables["ExamenJoin"].Clear();

            con.Open();
            string selectExamenJoin = "SELECT spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor,gr.anUniversitar,ses.denumireSesiune,exm.modEvaluare FROM ProgramareExamen exm JOIN Specializare spec ON exm.idSpecializare=spec.idSpecializare JOIN Grupa gr ON gr.idSpecializare = exm.idSpecializare AND gr.nrGrupa = exm.nrGrupa AND gr.anStudiu = exm.anStudiu AND gr.anUniversitar = exm.anUniversitar JOIN Disciplina disc ON disc.idDisciplina = exm.idDisciplina JOIN Corp crp ON crp.idCorp = exm.idCorp JOIN Sala sl ON sl.idCorp = exm.idCorp AND sl.nrSala=exm.nrSala AND sl.etaj=exm.etaj JOIN Profesor profTit ON profTit.marcaProfesor=exm.profTitular JOIN Profesor profAsist ON profAsist.marcaProfesor=exm.profSupraveghetor JOIN Sesiune ses ON ses.idSesiune=exm.idSesiune WHERE exm.anUniversitar = '" + anUniv + "' GROUP BY spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor,gr.anUniversitar,ses.denumireSesiune,exm.modEvaluare";
            /*
                SELECT spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor,gr.anUniversitar,ses.denumireSesiune,exm.modEvaluare
                FROM ProgramareExamen exm
                JOIN Specializare spec
                ON exm.idSpecializare=spec.idSpecializare
                JOIN Grupa gr
                ON gr.idSpecializare = exm.idSpecializare AND gr.nrGrupa = exm.nrGrupa AND gr.anStudiu = exm.anStudiu AND gr.anUniversitar = exm.anUniversitar
                JOIN Disciplina disc
                ON disc.idDisciplina = exm.idDisciplina
                JOIN Corp crp
                ON crp.idCorp = exm.idCorp
                JOIN Sala sl
                ON sl.idCorp = exm.idCorp AND sl.nrSala=exm.nrSala AND sl.etaj=exm.etaj
                JOIN Profesor profTit
                ON profTit.marcaProfesor=exm.profTitular
                JOIN Profesor profAsist
                ON profAsist.marcaProfesor=exm.profSupraveghetor
                JOIN Sesiune ses
                ON ses.idSesiune=exm.idSesiune
                GROUP BY spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor,gr.anUniversitar,ses.denumireSesiune,exm.modEvaluare
             */
            da = new SqlDataAdapter(selectExamenJoin, con);
            da.Fill(ds, "ExamenJoin");
            con.Close();
        }
        void seteazaProprietatiGridExamen()
        {
            dataGridViewExamen.Columns[0].Visible = true;
            dataGridViewExamen.AllowUserToAddRows = false;
            dataGridViewExamen.Columns[0].HeaderText = "SPECIALIZARE";
            dataGridViewExamen.Columns[1].HeaderText = "GRUPA";
            dataGridViewExamen.Columns[2].HeaderText = "AN STUDIU";
            dataGridViewExamen.Columns[3].HeaderText = "DISCIPLINA";
            dataGridViewExamen.Columns[4].HeaderText = "DATA";
            dataGridViewExamen.Columns[5].HeaderText = "ORA";
            dataGridViewExamen.Columns[6].HeaderText = "SALA";
            dataGridViewExamen.Columns[7].HeaderText = "NUME PROFESOR TITULAR";
            dataGridViewExamen.Columns[8].HeaderText = "PRENUME PROFESOR TITULAR";
            dataGridViewExamen.Columns[9].HeaderText = "NUME ASISTENT EXAMINATOR";
            dataGridViewExamen.Columns[10].HeaderText = "PRENUME ASISTENT EXAMINATOR";
            dataGridViewExamen.Columns[11].HeaderText = "AN UNIVERSITAR";
            dataGridViewExamen.Columns[12].HeaderText = "SESIUNE";
            dataGridViewExamen.Columns[13].HeaderText = "MOD EVALUARE";

            dataGridViewExamen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewExamen.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 15, FontStyle.Regular);
            dataGridViewExamen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < dataGridViewExamen.Columns.Count; i++)
            {
                dataGridViewExamen.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewExamen.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 15, FontStyle.Regular);
                dataGridViewExamen.Columns[i].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        List<RadioButton> rbAnUnivListExamen = new List<RadioButton>();
        List<RadioButton> rbAnUnivListRestanta = new List<RadioButton>();

        void createRadioButtons()
        {
            int pozitieUp = 10;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT anUniversitar FROM AnUniversitar ORDER BY anUniversitar DESC", con);
            da.Fill(ds, "AnUniv");
            con.Close();

            foreach (DataRow dr in ds.Tables["AnUniv"].Rows)
            {
                rbAnUnivListExamen.Add(CreateNewControls.createRadioButton(dr.ItemArray.GetValue(0).ToString(), 10, pozitieUp));
                rbAnUnivListRestanta.Add(CreateNewControls.createRadioButton(dr.ItemArray.GetValue(0).ToString(), 10, pozitieUp));
                pozitieUp = pozitieUp + 30;
            }

            foreach (RadioButton rb in rbAnUnivListExamen)
            {
                panelAniExamen.Controls.Add(rb);
                rb.CheckedChanged += rb_arhiva_CheckedChanged;
            }
            rbAnUnivListExamen[0].Checked = true;
            foreach (RadioButton rb in rbAnUnivListRestanta)
            {
                panelAniRestanta.Controls.Add(rb);
                rb.CheckedChanged += rb_arhiva_CheckedChanged;
            }
            rbAnUnivListRestanta[0].Checked = true;
        }

        static string anUniv = "";
        void rb_arhiva_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                anUniv = rb.Text;
                adaugaExamenJoinToDataSet();
                addRestantaJoinToDataSet();
            }
        }
        #endregion

        #region ProgrameazaRestanta

        //void golestePanel()
        //{
        //    foreach (Control c in panelAlegeMarcaProf.Controls)
        //        panelAlegeMarcaProf.Controls.Remove(c);
        //}

        //string codProfSelectat = "";
        //List<string> listaCodProf = new List<string>();
        //List<RadioButton> listaRadioButtonsCodProf = new List<RadioButton>();

        //void gasesteCodProfSelectat()
        //{
        //    int pozTop = 10;
        //    golestePanel();
        //    listaCodProf.Clear();
        //    listaRadioButtonsCodProf.Clear();

        //    foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
        //        if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxRestantaProfesor.SelectedItem.ToString())
        //            listaCodProf.Add(dr.ItemArray.GetValue(0).ToString());

        //    if (listaCodProf.Count > 1) //daca sunt mai multi profesori cu acelasi nume, trebuie sa alegem codul aceceluia pentru care se programeaza restanta.
        //    {
        //        panelAlegeMarcaProf.Visible = true;
        //        foreach (string matr in listaCodProf)
        //        {
        //            listaRadioButtonsCodProf.Add(CreateNewControls.createRadioButton(matr, 10, pozTop));
        //            pozTop += 20;
        //        }

        //        foreach (RadioButton rb in listaRadioButtonsCodProf)
        //        {
        //            panelAlegeMarcaProf.Controls.Add(rb);
        //            rb.CheckedChanged += rb_CheckedChanged;
        //        }
        //    }
        //    else
        //    {
        //        foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
        //            if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxRestantaProfesor.SelectedItem.ToString())
        //                codProfSelectat = dr.ItemArray.GetValue(0).ToString();
        //    }
        //}

        //void rb_CheckedChanged(object sender, EventArgs e)
        //{
        //    RadioButton button = (RadioButton)sender;
        //    if (button.Checked == true)
        //    {
        //        codProfSelectat = button.Text;
        //    }
        //}

        private void buttonProgramareRestanta_Click(object sender, EventArgs e)
        {
            if (validareRestanta() == true)
            {
                ds.Tables["RESTANTA"].Clear();
                SqlDataAdapter daRestanta = new SqlDataAdapter("SELECT * FROM ProgramareRestanta", con);
                con.Open();
                daRestanta.Fill(ds, "RESTANTA");
                con.Close();
                DataTable dt = ds.Tables["RESTANTA"];
                DataRow dr1 = dt.NewRow();

                //----------Id-uri PK+FK---------------
                string codProf = "";
                foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxRestantaProfesor.SelectedItem.ToString())
                        codProf = dr.ItemArray.GetValue(0).ToString();

                string idDisciplina = "";
                foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxRestantaDisciplina.SelectedItem.ToString())
                        idDisciplina = dr.ItemArray.GetValue(0).ToString();

                string idCorp = "";
                string nrSala = "";
                string etaj = "";
                foreach (DataRow drSala in ds.Tables["SALA"].Rows)
                {
                    foreach (DataRow drCorp in ds.Tables["CORP"].Rows)
                        if (drCorp.ItemArray.GetValue(0).ToString() == drSala.ItemArray.GetValue(0).ToString())
                            if (drCorp.ItemArray.GetValue(1).ToString() + drSala.ItemArray.GetValue(2).ToString() + drSala.ItemArray.GetValue(1).ToString() == comboBoxRestantaSala.SelectedItem.ToString()) //corp + etaj + nrSala => I.2.4 , Y.1.01
                            {
                                idCorp = drCorp.ItemArray.GetValue(0).ToString();
                                nrSala = drSala.ItemArray.GetValue(1).ToString();
                                etaj = drSala.ItemArray.GetValue(2).ToString();
                            }
                }
                //-------------------------------------
                dr1[0] = idCorp;
                dr1[1] = nrSala;
                dr1[2] = etaj;
                dr1[3] = codProf;
                dr1[4] = idDisciplina;
                dr1[5] = idSesiuneRestante;
                dr1[6] = anUniversitarCurent;
                dr1[7] = dateTimePickerRestantaData.Value.ToShortDateString();
                dr1[8] = Convert.ToInt32(numericUpDownRestantaOra.Value);
                dr1[9] = Convert.ToInt32(numericUpDownRestantaDurata.Value);
                dr1[10] = returnRadioButtonName(listRadioButtonsModEvaluareRestanta);

                dt.Rows.Add(dr1);
                SqlCommandBuilder cb = new SqlCommandBuilder(daRestanta);
                cb.DataAdapter.Update(dt);
                MessageBox.Show("Restanta este programata!");
                completeazaGridRestanta();
                seteazaProprietatiGridRestanta();
            }
            else
                MessageBox.Show("Modificati greselile si incercati din nou!");
        }

        private void buttonValidareRestanta_Click(object sender, EventArgs e)
        {
            if (validareRestanta() == true)
                MessageBox.Show("Restanta este validata si se poate programa!");
        }
        bool validareRestanta()
        {
            if (statusServerOk == false)
            {
                MessageBox.Show("Aplicatia nu s-a putut conecta la serverul bazei de date!", "Conexiune pierduta");
                return false;
            }
            else
            if (comboBoxRestantaProfesor.Items.Count <= 0)
            {
                MessageBox.Show("Lista profesorilor este goala.\nProgramarea restantei nu se poate realiza!");
                return false;
            }
            else
            if (comboBoxRestantaDisciplina.Items.Count <= 0)
            {
                MessageBox.Show("Lista disciplinelor este goala.\nProgramarea restantei nu se poate realiza!");
                return false;
            }
            else
            if (comboBoxRestantaSala.Items.Count <= 0)
            {
                MessageBox.Show("Lista salilor este goala.\nProgramarea restantei nu se poate realiza!");
                return false;
            }
            else
            if (dateTimePickerRestantaData.Value > Convert.ToDateTime(dataFinalSesiuneRestante))
            {
                //functioneaza
                MessageBox.Show("Nu puteti programa examene in afara sesiunii!Data este prea tarzie!");
                return false;
            }
            else
            if (dateTimePickerRestantaData.Value < Convert.ToDateTime(dataInceputSesiuneRestante))
            {
                //functioneaza
                MessageBox.Show("Restantele nu pot avea loc la date care sunt inaintea inceperii sesiunii!");
                return false;
            }
            if (comboBoxRestantaProfesor.Items.Count > 0)
            {

                ds.Tables["RESTANTA"].Clear();
                adaugaRestantaToDataSet();
                string codProf = "";
                foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxRestantaProfesor.SelectedItem.ToString())
                        codProf = dr.ItemArray.GetValue(0).ToString();

                string idCorp = "";
                string nrSala = "";
                string etaj = "";
                string corpDenumire = "";
                foreach (DataRow drSala in ds.Tables["SALA"].Rows)
                {
                    foreach (DataRow drCorp in ds.Tables["CORP"].Rows)
                        if (drCorp.ItemArray.GetValue(0).ToString() == drSala.ItemArray.GetValue(0).ToString())
                            if (drCorp.ItemArray.GetValue(1).ToString() + drSala.ItemArray.GetValue(2).ToString() + drSala.ItemArray.GetValue(1).ToString() == comboBoxRestantaSala.SelectedItem.ToString()) //corp + etaj + nrSala => I.2.4 , Y.1.01
                            {
                                idCorp = drCorp.ItemArray.GetValue(0).ToString();
                                nrSala = drSala.ItemArray.GetValue(1).ToString();
                                etaj = drSala.ItemArray.GetValue(2).ToString();
                                corpDenumire = drCorp.ItemArray.GetValue(1).ToString();
                            }
                }
                string codSala = corpDenumire + etaj + nrSala;
                string data;
                DateTime dataSelectata = Convert.ToDateTime(dateTimePickerRestantaData.Value.ToShortDateString());
                foreach (DataRow dr in ds.Tables["RESTANTA"].Rows)
                {
                    data = dr.ItemArray.GetValue(7).ToString();
                    if (dr.ItemArray.GetValue(6).ToString() == anUniversitarCurent && dr.ItemArray.GetValue(5).ToString() == idSesiuneRestante &&
                        dr.ItemArray.GetValue(3).ToString() == codProf && dr.ItemArray.GetValue(8).ToString() == numericUpDownRestantaOra.Value.ToString() &&
                        Convert.ToDateTime(data) == Convert.ToDateTime(dateTimePickerRestantaData.Value.ToShortDateString()))
                    {
                        MessageBox.Show("Profesorul " + comboBoxRestantaProfesor.SelectedItem.ToString() + " are deja programata restanta la data " + dateTimePickerRestantaData.Value.ToShortDateString() +
                            " ora :" + numericUpDownRestantaOra.Value.ToString());
                        return false;
                    }
                    if (dr["anUniversitar"].ToString() == anUniversitarCurent)
                    {
                        if (dr["idSesiune"].ToString() == idSesiuneRestante)
                        {
                            if (Convert.ToDateTime(data) == dataSelectata)
                            {
                                if (Convert.ToInt32(dr["ora"].ToString()) == Convert.ToInt32(numericUpDownRestantaOra.Value))
                                {
                                    if (dr.ItemArray.GetValue(0).ToString() == idCorp && dr.ItemArray.GetValue(2).ToString() == etaj && dr.ItemArray.GetValue(1).ToString() == nrSala)
                                    {
                                        MessageBox.Show("Sala " + codSala + " este ocupata la data " + dateTimePickerRestantaData.Value.ToShortDateString() +
                                            " ora: " + numericUpDownRestantaOra.Value.ToString());
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        #region DataGridRestanta
        void completeazaGridRestanta()
        {
            addRestantaJoinToDataSet();
            dataGridViewRestanta.DataSource = ds.Tables["RestantaJoin"];
        }
        void addRestantaJoinToDataSet()
        {
            foreach (DataTable dt in ds.Tables)
                if (dt.TableName == "RestantaJoin")
                    ds.Tables["RestantaJoin"].Clear();

            con.Open();
            string selectRestantaJoin = "SELECT disc.denumireDisciplina,prof.numeProfesor,prof.prenumeProfesor,rest.data,rest.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,rest.anUniversitar,rest.modEvaluare FROM ProgramareRestanta rest JOIN Disciplina disc ON disc.idDisciplina = rest.idDisciplina JOIN Corp crp ON crp.idCorp = rest.idCorp JOIN Sala sl ON sl.idCorp = rest.idCorp AND sl.nrSala=rest.nrSala AND sl.etaj=rest.etaj JOIN Profesor prof ON prof.marcaProfesor=rest.marcaProfesor WHERE rest.anUniversitar='" + anUniv + "' GROUP BY disc.denumireDisciplina,prof.numeProfesor,prof.prenumeProfesor,rest.data,rest.ora,crp.denumireCorp+sl.etaj+sl.nrSala,rest.anUniversitar,rest.modEvaluare ORDER BY prof.numeProfesor,prof.prenumeProfesor";
            /*
             SELECT disc.denumireDisciplina,prof.numeProfesor,prof.prenumeProfesor,rest.data,rest.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,rest.anUniversitar,rest.modEvaluare
                FROM ProgramareRestanta rest
                JOIN Disciplina disc
                ON disc.idDisciplina = rest.idDisciplina
                JOIN Corp crp
                ON crp.idCorp = rest.idCorp
                JOIN Sala sl
                ON sl.idCorp = rest.idCorp AND sl.nrSala=rest.nrSala AND sl.etaj=rest.etaj
                JOIN Profesor prof
                ON prof.marcaProfesor=rest.marcaProfesor
              GROUP BY disc.denumireDisciplina,prof.numeProfesor,prof.prenumeProfesor,rest.data,rest.ora,crp.denumireCorp+sl.etaj+sl.nrSala,rest.anUniversitar,rest.modEvaluare
             */
            da = new SqlDataAdapter(selectRestantaJoin, con);
            da.Fill(ds, "RestantaJoin");
            con.Close();
        }
        void seteazaProprietatiGridRestanta()
        {
            dataGridViewRestanta.Columns[0].Visible = true;
            dataGridViewRestanta.AllowUserToAddRows = false;
            dataGridViewRestanta.Columns[0].HeaderText = "DISCIPLINA";
            dataGridViewRestanta.Columns[1].HeaderText = "NUME PROFESOR";
            dataGridViewRestanta.Columns[2].HeaderText = "PRENUME PROFESOR";
            dataGridViewRestanta.Columns[3].HeaderText = "DATA";
            dataGridViewRestanta.Columns[4].HeaderText = "ORA";
            dataGridViewRestanta.Columns[5].HeaderText = "SALA";
            dataGridViewRestanta.Columns[6].HeaderText = "AN UNIVERSITAR";
            dataGridViewRestanta.Columns[7].HeaderText = "MOD EVALUARE";


            dataGridViewRestanta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewRestanta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 15, FontStyle.Regular);
            dataGridViewRestanta.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < dataGridViewRestanta.Columns.Count; i++)
            {
                dataGridViewRestanta.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewRestanta.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 15, FontStyle.Regular);
                dataGridViewRestanta.Columns[i].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }
        #endregion

        #region Export date sub forma de tabel in format pdf
        private void button_descarcaTabelExamen_Click(object sender, EventArgs e)
        {
            if (dataGridViewExamen.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Examene - " + anUniv + ".pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Datele nu s-au putut scrie pe disc!.\n" + ex.Message, "Eroare");
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Paragraph title = new Paragraph("ARHIVA EXAMENE " + anUniv);
                            title.Alignment = Element.ALIGN_CENTER;
                            title.Font = FontFactory.GetFont("Arial", 32);
                            title.SpacingAfter = 25;
                            title.SetLeading(1, 1);

                            PdfPTable pdfTable = new PdfPTable(dataGridViewExamen.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfTable.DefaultCell.BorderWidth = 1;

                            foreach (DataGridViewColumn column in dataGridViewExamen.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = new iTextSharp.text.BaseColor(Color.LightBlue);
                                cell.HorizontalAlignment = 1;
                                cell.VerticalAlignment = 1;
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridViewExamen.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    //pdfTable.AddCell(cell.Value.ToString());
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value.ToString()));
                                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    pdfCell.VerticalAlignment = Element.ALIGN_CENTER;
                                    pdfTable.AddCell(pdfCell);
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                //Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                //PdfWriter.GetInstance(pdfDoc, stream);
                                Document pdfDoc = new Document(new iTextSharp.text.Rectangle(288f, 144f), 10, 10, 10, 10);
                                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(title);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Tabelul cu examene a fost exportat cu succes!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Eroare: " + ex.Message, "Eroare");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nu exista date pentru a fi exportate!", "Info");
            }
        }

        private void button_descarcaTabelRestanta_Click(object sender, EventArgs e)
        {
            if (dataGridViewRestanta.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Restante - " + anUniv + ".pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Datele nu s-au putut scrie pe disc!.\n" + ex.Message, "Eroare");
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            Paragraph title = new Paragraph("ARHIVA RESTANTE " + anUniv);
                            title.Alignment = Element.ALIGN_CENTER;
                            title.Font = FontFactory.GetFont("Arial", 32);
                            title.SpacingAfter = 25;
                            title.SetLeading(1, 1);

                            PdfPTable pdfTable = new PdfPTable(dataGridViewRestanta.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfTable.DefaultCell.BorderWidth = 1;

                            foreach (DataGridViewColumn column in dataGridViewRestanta.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = new iTextSharp.text.BaseColor(Color.LightBlue);
                                cell.HorizontalAlignment = 1;
                                cell.VerticalAlignment = 1;
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridViewRestanta.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value.ToString()));
                                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    pdfCell.VerticalAlignment = Element.ALIGN_CENTER;
                                    pdfTable.AddCell(pdfCell);
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(new iTextSharp.text.Rectangle(288f, 144f), 10, 10, 10, 10);
                                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(title);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Tabelul cu restante a fost exportat cu succes!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Eroare: " + ex.Message, "Eroare");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nu exista date pentru a fi exportate!", "Info");
            }
        }
        #endregion

        private void button_UpdateProfSuprav_Click(object sender, EventArgs e)
        {
            ModificaProfesorExaminator updateProfForm = new ModificaProfesorExaminator();
            this.Hide();
            updateProfForm.ShowDialog();
        }
    }
}
