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
    public partial class ModificaProfesorExaminator : Form
    {
        public ModificaProfesorExaminator()
        {
            InitializeComponent();
            conectare();
        }

        #region Declarare Variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        static string anUniversitarCurent;
        static string idSesiuneCurenta;
        #endregion

        private void ModificaProfesorExaminator_Load(object sender, EventArgs e)
        {
            conectare();
            completareDataSet();
            getAnUniversitarCurent();
            getSesiuneCurenta();
            adaugaProfesorSupraveghetorToDropDownList();
            adaugaExamenToDataSet();
            completeazaGridExamen();
            seteazaProprietatiGridExamen();
        }

        #region AnUnivCurent + SesiuneCurenta
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

        public void getSesiuneCurenta()
        {
            con.Open();
            string query = "SELECT top 1 idSesiune,anUniversitar,dataInceput,dataFinal FROM An_Sesiune WHERE idSesiune IN (1,2) ORDER BY dataInceput Desc;";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader returnedRows = cmd.ExecuteReader();
            if (returnedRows.Read())
            {
                idSesiuneCurenta = returnedRows.GetValue(0).ToString();
            }

            con.Close();
            //MessageBox.Show("Sesiune curenta id: "+ idSesiuneCurenta +" ,denumire: "+denumireSesiuneCurenta+ " ,data inceput: "+ dataInceputSesiuneCurenta+ " ,data final: "+ dataFinalSesiuneCurenta);
        }
#endregion

        #region Conectare si DataSet
        void conectare()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=GestiuneExamene;Integrated Security=True"; //connection string pentru BD de pe SQL Server
        }
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
        #endregion

        #region DataGridView
        void completeazaGridExamen()
        {
            adaugaExamenJoinToDataSet();
            dataGridViewUpdateProf.DataSource = ds.Tables["ExamenJoin"];
        }
        void adaugaExamenJoinToDataSet()
        {
            foreach (DataTable dt in ds.Tables)
                if (dt.TableName == "ExamenJoin")
                    ds.Tables["ExamenJoin"].Clear();

            con.Open();
            string selectExamenJoin = "SELECT spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,profTit.numeProfesor+' '+profTit.prenumeProfesor AS profesorTitular,profAsist.numeProfesor+' '+profAsist.prenumeProfesor AS profesorAsistent,gr.anUniversitar,ses.denumireSesiune,exm.modEvaluare FROM ProgramareExamen exm JOIN Specializare spec ON exm.idSpecializare=spec.idSpecializare JOIN Grupa gr ON gr.idSpecializare = exm.idSpecializare AND gr.nrGrupa = exm.nrGrupa AND gr.anStudiu = exm.anStudiu AND gr.anUniversitar = exm.anUniversitar JOIN Disciplina disc ON disc.idDisciplina = exm.idDisciplina JOIN Corp crp ON crp.idCorp = exm.idCorp JOIN Sala sl ON sl.idCorp = exm.idCorp AND sl.nrSala=exm.nrSala AND sl.etaj=exm.etaj JOIN Profesor profTit ON profTit.marcaProfesor=exm.profTitular JOIN Profesor profAsist ON profAsist.marcaProfesor=exm.profSupraveghetor JOIN Sesiune ses ON ses.idSesiune=exm.idSesiune WHERE exm.anUniversitar = '" + anUniversitarCurent + "' GROUP BY spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor,gr.anUniversitar,ses.denumireSesiune,exm.modEvaluare";
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
            dataGridViewUpdateProf.Columns[0].Visible = true;
            dataGridViewUpdateProf.AllowUserToAddRows = false;
            dataGridViewUpdateProf.Columns[0].HeaderText = "SPECIALIZARE";
            dataGridViewUpdateProf.Columns[1].HeaderText = "GRUPA";
            dataGridViewUpdateProf.Columns[2].HeaderText = "AN STUDIU";
            dataGridViewUpdateProf.Columns[3].HeaderText = "DISCIPLINA";
            dataGridViewUpdateProf.Columns[4].HeaderText = "DATA";
            dataGridViewUpdateProf.Columns[5].HeaderText = "ORA";
            dataGridViewUpdateProf.Columns[6].HeaderText = "SALA";
            dataGridViewUpdateProf.Columns[7].HeaderText = "PROFESOR TITULAR";
            dataGridViewUpdateProf.Columns[8].HeaderText = "ASISTENT EXAMINATOR";
            dataGridViewUpdateProf.Columns[9].HeaderText = "AN UNIVERSITAR";
            dataGridViewUpdateProf.Columns[10].HeaderText = "SESIUNE";
            dataGridViewUpdateProf.Columns[11].HeaderText = "MOD EVALUARE";

            dataGridViewUpdateProf.Rows[0].Selected = true;

            dataGridViewUpdateProf.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewUpdateProf.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 15, FontStyle.Regular);
            dataGridViewUpdateProf.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < dataGridViewUpdateProf.Columns.Count; i++)
            {
                dataGridViewUpdateProf.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewUpdateProf.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 15, FontStyle.Regular);
                dataGridViewUpdateProf.Columns[i].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }
        #endregion

        #region PopulateDropDownList
        void adaugaProfesorSupraveghetorToDropDownList()
        {
            comboBoxUpdateProf.Items.Clear();

            List<string> profesorSuprav = new List<string>();
            string marcaProfesorTitular = "";
            string marcaAsistentExaminator = "";
            foreach (DataGridViewRow row in dataGridViewUpdateProf.Rows)
            {
                if (row.Selected)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        int index = cell.ColumnIndex;
                        string value = cell.Value.ToString();
                        foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                        {
                            if (index == 7)
                            {
                                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == value)
                                    marcaProfesorTitular = dr.ItemArray.GetValue(0).ToString();
                            }
                            if (index == 8)
                            {
                                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == value)
                                    marcaAsistentExaminator = dr.ItemArray.GetValue(0).ToString();
                            }
                        }
                    }
                }
            }          
            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() != marcaProfesorTitular && dr.ItemArray.GetValue(0).ToString() != marcaAsistentExaminator)
                    profesorSuprav.Add(dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString());

            List<string> distinct = profesorSuprav.Distinct().ToList();
            foreach (String prof in distinct)
            {
                comboBoxUpdateProf.Items.Add(prof);
            }

            if (comboBoxUpdateProf.Items.Count > 0)
                comboBoxUpdateProf.SelectedIndex = 0;
        }

        bool activareEvenimentDropDownListProfesorUpdate = false;

        private void cellRowClick_selectedIndexChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!activareEvenimentDropDownListProfesorUpdate)
                adaugaProfesorSupraveghetorToDropDownList();
        }
        #endregion

        private void buttonScheduleExamBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = Application.OpenForms["ScheduleExamForm"];
            form.Show();
        }

        #region UpdateProfesorAsistent
        void UpdateProfesorTable(string sqlUpdate)
        {
            con.Open();
            SqlCommand cmdUpdateProf = new SqlCommand(sqlUpdate, con);
            cmdUpdateProf.ExecuteNonQuery();
            con.Close();
            ds.Tables["Profesor"].Clear();
            completeazaGridExamen();
        }

        private void button_UpdateProfSuprav_Click(object sender, EventArgs e)
        {
            ds.Tables["EXAMEN"].Clear();
            adaugaExamenToDataSet();

            string codProfSuprav = "";
            string idDisc = "";
            string codSpec = "";
            string nrGrupa = "";
            string anStudiu = "";

            string idCorp = "";
            string nrSala = "";
            string etaj = "";

            string codProfTitular = "";
            string codProfAsistentExamen = "";
            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
            {
                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == dataGridViewUpdateProf.CurrentRow.Cells[7].ToString())
                    codProfTitular = dr.ItemArray.GetValue(0).ToString();
                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == dataGridViewUpdateProf.CurrentRow.Cells[8].ToString())
                    codProfAsistentExamen = dr.ItemArray.GetValue(0).ToString();
            }

            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
            {
                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxUpdateProf.SelectedItem.ToString())
                    codProfSuprav = dr.ItemArray.GetValue(0).ToString();
            }

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == dataGridViewUpdateProf.CurrentRow.Cells[0].ToString())
                    codSpec = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["GRUPA"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString() == codSpec && dr.ItemArray.GetValue(3).ToString() == anUniversitarCurent.ToString())
                {
                    if (dr.ItemArray.GetValue(1).ToString() == dataGridViewUpdateProf.CurrentRow.Cells[1].ToString())
                    {
                        nrGrupa = dr.ItemArray.GetValue(1).ToString();
                    }
                }
            }

            foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() == dataGridViewUpdateProf.CurrentRow.Cells[2].ToString())
                    anStudiu = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == dataGridViewUpdateProf.CurrentRow.Cells[3].ToString())
                    idDisc = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow drSala in ds.Tables["SALA"].Rows)
            {
                foreach (DataRow drCorp in ds.Tables["CORP"].Rows)
                    if (drCorp.ItemArray.GetValue(0).ToString() == drSala.ItemArray.GetValue(0).ToString())
                        if (drCorp.ItemArray.GetValue(1).ToString() + drSala.ItemArray.GetValue(2).ToString() + drSala.ItemArray.GetValue(1).ToString() == dataGridViewUpdateProf.CurrentRow.Cells[6].Value.ToString()) //corp + etaj + nrSala => I.2.4 , Y.1.01
                        {
                            idCorp = drCorp.ItemArray.GetValue(0).ToString();
                            nrSala = drSala.ItemArray.GetValue(1).ToString();
                            etaj = drSala.ItemArray.GetValue(2).ToString();
                        }
            }
            if (MessageBox.Show("Se modifica asistentul examinator pentru examenul de la specializarea :\n" + dataGridViewUpdateProf.CurrentRow.Cells[0].Value.ToString() +
                " grupa" +dataGridViewUpdateProf.CurrentRow.Cells[1].Value.ToString() + " anul de studiu " +
                dataGridViewUpdateProf.CurrentRow.Cells[2].Value.ToString() + "\nDisciplina: " +
                dataGridViewUpdateProf.CurrentRow.Cells[3].Value.ToString() + "\n\nNoul asistent examinator este: " + comboBoxUpdateProf.SelectedItem.ToString() + "\nConfirmati?",
                "Modificare asistent examinator", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sqlUpdateProf = "UPDATE ProgramareExamen SET profSupraveghetor = '" + codProfSuprav + "' WHERE idCorp = '" + idCorp + "' AND nrSala = '"+ nrSala + "' AND etaj = '" + etaj + "' AND idSesiune = '" + idSesiuneCurenta + "' AND idDisciplina = '" + idDisc + "' AND idSpecializare = '" + codSpec + "' AND nrGrupa = '" + nrGrupa
                    + "' AND anStudiu = '" + anStudiu + "' AND nrSala = '" + anUniversitarCurent +"'";
                if (validareModificareProfesorAsistentExaminator() == true)
                {
                    UpdateProfesorTable(sqlUpdateProf);
                    completeazaGridExamen();
                    adaugaProfesorSupraveghetorToDropDownList();
                    MessageBox.Show("Asistentul examinator a fost schimbat cu succes!");
                }
                else
                    MessageBox.Show("Eroare! Modificarea nu s-a realizat");               
            }
            else
                MessageBox.Show("Modificarea nu s-a realizat");
        }

        private bool validareModificareProfesorAsistentExaminator()
        {
            string data;
            string codProf = "";
            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
            {
                if (dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxUpdateProf.SelectedItem.ToString())
                    codProf = dr.ItemArray.GetValue(0).ToString();
            }
            foreach (DataGridViewRow row in dataGridViewUpdateProf.Rows)
            {
                if (row.Selected)
                {
                    string dateMatch = "notOk";
                    string hourMatch = "notOk";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        int index = cell.ColumnIndex;
                        string value = cell.Value.ToString();

                        foreach (DataRow dr in ds.Tables["EXAMEN"].Rows)
                        {
                            data = dr.ItemArray.GetValue(9).ToString();
                            if (index == 4)
                            {
                                if (Convert.ToDateTime(data) == Convert.ToDateTime(value.ToString()))
                                    dateMatch = "OK";
                            }
                            if (index == 5)
                            {
                                if (dr["ora"].ToString() == value)
                                    hourMatch = "OK";
                            }
                            if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta
                                 && dateMatch == "OK" && hourMatch == "OK" && dr["profTitular"].ToString() == codProf)
                            {
                                MessageBox.Show("Profesorul " + comboBoxUpdateProf.SelectedItem.ToString() + " este titular pentru un alt examen!");
                                return false;
                            }
                            if (dr["anUniversitar"].ToString() == anUniversitarCurent && dr["idSesiune"].ToString() == idSesiuneCurenta &&
                                 dateMatch == "OK" && hourMatch == "OK" && dr["profSupraveghetor"].ToString() == codProf)
                            {
                                MessageBox.Show("Profesorul " + comboBoxUpdateProf.SelectedItem.ToString() + " este asistent pentru un alt examen!");
                                return false;
                            }
                        }
                    }

                }
            }

            return true;
        }
        #endregion
    }
}
