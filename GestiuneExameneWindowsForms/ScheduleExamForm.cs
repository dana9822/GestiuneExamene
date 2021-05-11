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

            //Close connection
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
                getTipEvaluareDisciplina();
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
        #endregion

        #region ProgramareButtons

        private void buttonProgrameazaExamen_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
