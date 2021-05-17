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
        // Selectia pe facultati pentru specializari si materii...??? Profesorii au legatura cu facultatea x doar prin specializare din acoperireDisciplina.
        private void ScheduleExamForm_Load(object sender, EventArgs e)
        {
            conectare();
            showGUIServerStatus();
            completareDataSet();
            adaugaRadioButtonInList();
            getAnUniversitarCurent();
            getSesiuneCurenta();
            showCurrentAcademicYear();
            adaugaSpecializareToDropDownList();
            adaugaSalaToDropDownList();
            //completeazaGridExamen();
            //seteazaProprietatiGridExamen();
            //createRadioButtons();
            labelExamenAnUniversitarCurent.Visible = true;
            labelExamenAnUniversitarCurent.Text = anUniversitarCurent.ToString();
            labelSesiuneCurentaExamen.Visible = true;
            labelSesiuneCurentaExamen.Text = denumireSesiuneCurenta.ToString() + " - " + dataInceputSesiuneCurenta.ToString();
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
                labelScheduleExamServerStatus.Text = String.Format("Connected to database.");
            }
            catch (Exception e)
            {
                labelScheduleExamServerStatus.Visible = true;
                labelScheduleExamServerStatus.ForeColor = Color.Red;
                labelScheduleExamServerStatus.Text = String.Format("Not connected to database.");
                MessageBox.Show(e.Message.ToString());
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

        #region getSesiuneCurenta
        public void getSesiuneCurenta()
        {
            con.Open();
            string query = "SELECT top 1 idSesiune,anUniversitar,dataInceput,dataFinal FROM An_Sesiune order by dataInceput Desc;";
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
            MessageBox.Show("Sesiune curenta id: " + idSesiuneCurenta + " ,denumire: " + denumireSesiuneCurenta + " ,data inceput: " + dataInceputSesiuneCurenta + " ,data final: " + dataFinalSesiuneCurenta);
        }
        #endregion

        #region RadioButtonMethods
        void adaugaRadioButtonInList()
        {

            foreach (Control c in groupBoxModEvaluare.Controls)
                listRadioButtonModEvaluare.Add((RadioButton)c);
            foreach (Control c in groupBoxDiscSemestru.Controls)
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

            foreach (DataRow drSala in ds.Tables["SALA"].Rows)
            {
                foreach (DataRow drCorp in ds.Tables["CORP"].Rows)
                    if (drCorp.ItemArray.GetValue(0).ToString() == drSala.ItemArray.GetValue(0).ToString())
                        comboBoxExamenSala.Items.Add(drCorp.ItemArray.GetValue(1).ToString() + drSala.ItemArray.GetValue(2).ToString() + drSala.ItemArray.GetValue(1).ToString()); //corp + etaj + nrSala => I.2.4 , Y.1.01
            }

            if (comboBoxExamenSala.Items.Count > 0)
                comboBoxExamenSala.SelectedIndex = 0;
        }

        void adaugaProfesorTitularToDropDownList()
        {
            comboBoxExamenProfTitular.Items.Clear();

            List<string> profesoriTitulari = new List<string>();
            string idDisciplinaSelectata = "";

            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxExamenDisciplina.SelectedItem.ToString())
                    idDisciplinaSelectata = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow drAloc in ds.Tables["DisciplinaAlocataAcoperita"].Rows)
            {
                if (drAloc.ItemArray.GetValue(1).ToString() == idDisciplinaSelectata)
                {
                    if (drAloc.ItemArray.GetValue(5).ToString() == "Activ")
                    {
                        if (drAloc.ItemArray.GetValue(6).ToString() == anUniversitarCurent)
                        {
                            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                            {
                                if (drAloc.ItemArray.GetValue(7).ToString() == dr.ItemArray.GetValue(0).ToString())
                                {
                                    profesoriTitulari.Add(dr.ItemArray.GetValue(1).ToString()+" "+ dr.ItemArray.GetValue(2).ToString());
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
        #endregion

        #region ProgramareExamen

        private bool ValidareExamen()
        {

            if (dateTimePickerDataExamen.Value.Date > Convert.ToDateTime(dataFinalSesiuneCurenta))
            {
                //functioneaza
                MessageBox.Show("Nu puteti programa examene in afara sesiunii!\nData este prea tarzie!");
                return false;
            }
            if (dateTimePickerDataExamen.Value.Date < Convert.ToDateTime(dataInceputSesiuneCurenta) && labelExamenTipEvaluare.Text == "Examen")

            { //functioneaza
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
                    && dr.ItemArray.GetValue(0).ToString() + dr.ItemArray.GetValue(2).ToString() + dr.ItemArray.GetValue(1).ToString() == comboBoxExamenSala.SelectedItem.ToString())
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
                //completeazaGridExamen();
                //seteazaProprietatiGridExamen(); //ptr arhiva
            }
            else
                MessageBox.Show("Modificati greselile si incercati din nou!");
        }

        #endregion

        #region DataGrid Examen
        //void completeazaGridExamen()
        //{
        //    adaugaExamenJoinToDataSet();
        //    dataGridViewExamen.DataSource = ds.Tables["ExamenJoin"];
        //}
        //void adaugaExamenJoinToDataSet()
        //{
        //    foreach (DataTable dt in ds.Tables)
        //        if (dt.TableName == "ExamenJoin")
        //            ds.Tables["ExamenJoin"].Clear();

        //    con.Open();
        //    string selectExamenJoin = "Select p.nume,p.prenume,m.denumireMaterie,s.denumireSpec,gr.idGr,e.data,e.ora,e.anUniv,ses.denumireSesiune,sl.codSala,ps.nume,ps.prenume from examen e join profesor p on e.codProf=p.codProf join materie m on e.idMat=m.idMat join specializare s on e.idSpec=s.idSpec join grupa gr on e.idGr=gr.idGr join sesiune ses on e.idSesiune=ses.idSesiune join sala sl on e.codSala=sl.codSala join profesor ps on e.codProfSuprav=ps.codProf group by p.nume,p.prenume,m.denumireMaterie,s.denumireSpec,gr.idGr,e.data,e.ora,e.anUniv,ses.denumireSesiune,sl.codSala,ps.nume,ps.prenume";
        //    da = new SqlDataAdapter(selectExamenJoin, con);
        //    da.Fill(ds, "ExamenJoin");
        //    con.Close();
        //}
        //void seteazaProprietatiGridExamen()
        //{
        //    dataGridViewExamen.Columns[0].Visible = true;
        //    dataGridViewExamen.AllowUserToAddRows = false;
        //    dataGridViewExamen.Columns[0].HeaderText = "Nume profesor";
        //    dataGridViewExamen.Columns[1].HeaderText = "Prenume profesor";
        //    dataGridViewExamen.Columns[2].HeaderText = "Materie";
        //    dataGridViewExamen.Columns[3].HeaderText = "Specializare";
        //    dataGridViewExamen.Columns[4].HeaderText = "Grupa";
        //    dataGridViewExamen.Columns[5].HeaderText = "Data";
        //    dataGridViewExamen.Columns[6].HeaderText = "Ora";
        //    dataGridViewExamen.Columns[7].HeaderText = "An Universitar";
        //    dataGridViewExamen.Columns[8].HeaderText = "Sesiunea";
        //    dataGridViewExamen.Columns[9].HeaderText = "Sala";
        //    dataGridViewExamen.Columns[10].HeaderText = "Nume supraveghetor";
        //    dataGridViewExamen.Columns[11].HeaderText = "Prenume supraveghetor";

        //    dataGridViewExamen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        //    dataGridViewExamen.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 11, FontStyle.Regular);
        //    dataGridViewExamen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    for (int i = 0; i < dataGridViewExamen.Columns.Count; i++)
        //    {
        //        dataGridViewExamen.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        dataGridViewExamen.Columns[i].DefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Regular);
        //        dataGridViewExamen.Columns[i].DefaultCellStyle.ForeColor = Color.Blue;
        //    }
        //}

        //List<RadioButton> rbAnUnivListExamen = new List<RadioButton>();
        ////List<RadioButton> rbAnUnivListRestanta = new List<RadioButton>();

        //void createRadioButtons()
        //{
        //    int pozitieUp = 10;
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT anUniversitar FROM AnUniversitar Order By anUniversitar DESC", con);
        //    da.Fill(ds, "AnUniv");
        //    con.Close();

        //    foreach (DataRow dr in ds.Tables["AnUniv"].Rows)
        //    {
        //        rbAnUnivListExamen.Add(CreateNewControls.createRadioButton(dr.ItemArray.GetValue(0).ToString(), 10, pozitieUp));
        //        //rbAnUnivListRestanta.Add(CreateNewControls.createRadioButton(dr.ItemArray.GetValue(0).ToString(), 10, pozitieUp));
        //        pozitieUp = pozitieUp + 30;
        //    }

        //    foreach (RadioButton rb in rbAnUnivListExamen)
        //    {
        //        panelAniExamen.Controls.Add(rb);
        //        rb.CheckedChanged += rb_CheckedChanged;
        //    }
        //    rbAnUnivListExamen[0].Checked = true;
        //    //foreach (RadioButton rb in rbAnUnivListRestanta)
        //    //{
        //    //    panel2.Controls.Add(rb);
        //    //    rb.CheckedChanged += rb_CheckedChanged;
        //    //}
        //    //rbAnUnivListRestanta[0].Checked = true;
        //}

        //static string anUniv = "";
        //void rb_CheckedChanged(object sender, EventArgs e)
        //{
        //    RadioButton rb = (RadioButton)sender;
        //    if (rb.Checked)
        //    {
        //        anUniv = rb.Text;
        //        adaugaExamenJoinToDataSet();
        //        //addRestantaJoinToDataSet();
        //    }
        //}
        ////void completeazaGridExamen()
        ////{
        ////    adaugaExamenJoinToDataSet();
        ////    dataGridViewExamen.DataSource = ds.Tables["ExamenJoin"];
        ////    seteazaProprietatiGridExamen();
        ////}
        #endregion

        #region ProgrameazaRestanta
        private void buttonProgramareRestanta_Click(object sender, EventArgs e)
        {

        }

        private void buttonValidareRestanta_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
