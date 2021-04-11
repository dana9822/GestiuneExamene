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
    public partial class AddDataForm : Form
    {
        public AddDataForm()
        {
            InitializeComponent();
            conectare();
        }

        #region declarare variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        List<RadioButton> listRadioButtonFormaInvatamant = new List<RadioButton>();
        List<RadioButton> listRadioButtonGradProfesor = new List<RadioButton>();
        List<RadioButton> listRadioButtonTipSala = new List<RadioButton>();
        List<RadioButton> listRadioButtonSemestru = new List<RadioButton>();
        List<RadioButton> listRadioButtonTipEvaluare = new List<RadioButton>();
        List<RadioButton> listRadioButtonStatusDisciplina = new List<RadioButton>();
        #endregion

        #region backButton
        private void buttonAddDataBack_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Hide();
            this.Dispose();

            home.ShowDialog();
        }
        #endregion

        private void AddDataForm_Load(object sender, EventArgs e)
        {
            conectare();
            showGUIServerStatus();
            completareDataSet();
            adaugaRadioButtonInList();
            getAnUniversitarCurent();
            getSesiuneCurenta();
            showCurrentAcademicYear();
            adaugaFacultateToDropDownList();
            adaugaSpecializareToDropDownList();
            adaugaAnStudiuToDropDownList();
            adaugaSesiuneToDropDownList();
            adaugaCorpToDropDownList();
            adaugaDisciplinaToDropDownList();
            adaugaProfesorToDropDownList();
            labelAnUniversitarGrupa.Visible = true;
            labelAnUniversitarGrupa.Text = anUniversitarCurent.ToString();
            labelAnUniversitarCurentSesiune.Visible = true;
            labelAnUniversitarCurentSesiune.Text = anUniversitarCurent.ToString();
            labelAcoperireDiscAnUniv.Visible = true;
            labelAcoperireDiscAnUniv.Text = anUniversitarCurent.ToString();
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

            //DataAdapter+DataSet
            da = new SqlDataAdapter(selectFacultate, con);
            da.Fill(ds,"FACULTATE");
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

        #region PopulateDropDownLists
        void adaugaFacultateToDropDownList()
        {
            comboBoxDropDownListFacultate.Items.Clear();

            foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
                comboBoxDropDownListFacultate.Items.Add(dr.ItemArray.GetValue(1).ToString());

            if (comboBoxDropDownListFacultate.Items.Count > 0)
                comboBoxDropDownListFacultate.SelectedIndex = 0;
        }

        void adaugaSpecializareToDropDownList()
        {
            comboBoxDropDownListSpecializareGrupa.Items.Clear();
            comboBoxDropDownListAlocareDisSpecList.Items.Clear();
            comboBoxDropDownListAcoperireDiscSpec.Items.Clear();

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
            {
                comboBoxDropDownListSpecializareGrupa.Items.Add(dr.ItemArray.GetValue(1).ToString());
                comboBoxDropDownListAlocareDisSpecList.Items.Add(dr.ItemArray.GetValue(1).ToString());
                comboBoxDropDownListAcoperireDiscSpec.Items.Add(dr.ItemArray.GetValue(1).ToString());
            }

            if (comboBoxDropDownListSpecializareGrupa.Items.Count > 0)
                comboBoxDropDownListSpecializareGrupa.SelectedIndex = 0;
            if (comboBoxDropDownListAlocareDisSpecList.Items.Count > 0)
                comboBoxDropDownListAlocareDisSpecList.SelectedIndex = 0;
            if (comboBoxDropDownListAcoperireDiscSpec.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscSpec.SelectedIndex = 0;
        }

        void adaugaAnStudiuToDropDownList()
        {
            comboBoxDropDownListAnStudiuGrupa.Items.Clear();
            comboBoxDropDownListAlocareDiscAnStudiuList.Items.Clear();
            comboBoxDropDownListAcoperireDiscAnStudiu.Items.Clear();

            foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
            {
                comboBoxDropDownListAnStudiuGrupa.Items.Add(dr.ItemArray.GetValue(0).ToString());
                comboBoxDropDownListAlocareDiscAnStudiuList.Items.Add(dr.ItemArray.GetValue(0).ToString());
                comboBoxDropDownListAcoperireDiscAnStudiu.Items.Add(dr.ItemArray.GetValue(0).ToString());
            }

            if (comboBoxDropDownListAnStudiuGrupa.Items.Count > 0)
                comboBoxDropDownListAnStudiuGrupa.SelectedIndex = 0;
            if (comboBoxDropDownListAlocareDiscAnStudiuList.Items.Count > 0)
                comboBoxDropDownListAlocareDiscAnStudiuList.SelectedIndex = 0;
            if (comboBoxDropDownListAcoperireDiscAnStudiu.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscAnStudiu.SelectedIndex = 0;
        }

        void adaugaSesiuneToDropDownList()
        {
            comboBoxDropDownListSesiune.Items.Clear();

            foreach (DataRow dr in ds.Tables["SESIUNE"].Rows)
            {
                comboBoxDropDownListSesiune.Items.Add(dr.ItemArray.GetValue(1).ToString());
            }

            if (comboBoxDropDownListSesiune.Items.Count > 0)
                comboBoxDropDownListSesiune.SelectedIndex = 0;
        }

        void adaugaCorpToDropDownList()
        {
            comboBoxDropDownListCorp.Items.Clear();

            foreach (DataRow dr in ds.Tables["CORP"].Rows)
            {
                comboBoxDropDownListCorp.Items.Add(dr.ItemArray.GetValue(1).ToString());
            }

            if (comboBoxDropDownListCorp.Items.Count > 0)
                comboBoxDropDownListCorp.SelectedIndex = 0;
        }

        void adaugaDisciplinaToDropDownList()
        {
            comboBoxDropDownListAlocareDiscDiscList.Items.Clear();
            comboBoxDropDowListAcoperireDiscDisc.Items.Clear();

            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
            {
                comboBoxDropDownListAlocareDiscDiscList.Items.Add(dr.ItemArray.GetValue(1).ToString());
                comboBoxDropDowListAcoperireDiscDisc.Items.Add(dr.ItemArray.GetValue(1).ToString());
            }

            if (comboBoxDropDownListAlocareDiscDiscList.Items.Count > 0)
                comboBoxDropDownListAlocareDiscDiscList.SelectedIndex = 0;
            if (comboBoxDropDowListAcoperireDiscDisc.Items.Count > 0)
                comboBoxDropDowListAcoperireDiscDisc.SelectedIndex = 0;
        }

        void adaugaProfesorToDropDownList()
        {
            comboBoxDropDownListAcoperireDiscProf.Items.Clear();

            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                comboBoxDropDownListAcoperireDiscProf.Items.Add(dr.ItemArray.GetValue(3).ToString()+" "+dr.ItemArray.GetValue(1).ToString()+" "+dr.ItemArray.GetValue(2).ToString());
            if (comboBoxDropDownListAcoperireDiscProf.Items.Count > 0)
                comboBoxDropDownListAcoperireDiscProf.SelectedIndex = 0;
        }
        #endregion

        #region labelGUIAcademicYearAndServerStatus
        public void showGUIServerStatus()
        {
            //verificare conexiune si afisare mesaj in label cu statusul conexiunii
            try
            {
                con.Open();
                labelAddDataConnectionStatus.Visible = true;
                labelAddDataConnectionStatus.ForeColor = Color.Green;
                labelAddDataConnectionStatus.Text = String.Format("Connected to database.");
            }
            catch (Exception e)
            {
                labelAddDataConnectionStatus.Visible = true;
                labelAddDataConnectionStatus.ForeColor = Color.Red;
                labelAddDataConnectionStatus.Text = String.Format("Not connected to database.");
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void showCurrentAcademicYear()
        {
            if (!String.IsNullOrEmpty(anUniversitarCurent))
            {
                labelAnUniversitarCurent.Visible = true;
                labelAnUniversitarCurent.Text = "Anul universitar in curs: " + anUniversitarCurent;
            }
            else 
            {
                labelAnUniversitarCurent.Visible = true;
                labelAnUniversitarCurent.Text = "Datele nu sunt disponibile";
            }
        }
        #endregion

        #region An Universitar Curent
        static string anUniversitarCurent;

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

        #region Sesiune Curenta
        static string idSesiuneCurenta;
        static string dataInceputSesiuneCurenta;
        static string dataFinalSesiuneCurenta;
        static string denumireSesiuneCurenta;

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
            MessageBox.Show("Sesiune curenta id: "+ idSesiuneCurenta +" ,denumire: "+denumireSesiuneCurenta+ " ,data inceput: "+ dataInceputSesiuneCurenta+ " ,data final: "+ dataFinalSesiuneCurenta);
        }
        #endregion

        #region RadioButtonMethods
        void adaugaRadioButtonInList()
        {

            foreach (Control c in groupBoxFormaInv.Controls)
                listRadioButtonFormaInvatamant.Add((RadioButton)c);
            foreach (Control c in groupBoxGradDidactic.Controls)
                listRadioButtonGradProfesor.Add((RadioButton)c);
            foreach (Control c in groupBoxTipSala.Controls)
                listRadioButtonTipSala.Add((RadioButton)c);
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

        #region Insert Buttons

        private void buttonAdaugaFacultate_Click(object sender, EventArgs e)
        {
            bool verificaId = false;
            int nrCaractereExtrase = 0;
            int pozCaracterExtras = 0;
            StringBuilder idFacultateDB = new StringBuilder();
            string[] idFacultate;

            if (string.IsNullOrEmpty(textBoxDenumireFacultate.Text))
                MessageBox.Show("Introduceti denumirea facultatii!");
            else
            {
                idFacultate = textBoxDenumireFacultate.Text.ToString().Split(' ');

                if (idFacultate.Length > 1)
                {

                    foreach (string s in idFacultate)
                        if (s.Length >= 4)
                            idFacultateDB.Append(s.Substring(0, 1));

                    pozCaracterExtras = 0;
                    do
                    {
                        verificaId = false;
                        foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
                        {
                            if (dr.ItemArray.GetValue(0).ToString() == idFacultateDB.ToString())
                            {
                                verificaId = true;
                                pozCaracterExtras++;

                                idFacultateDB.Append((idFacultate[idFacultate.Length - 1]).ToString().Substring(pozCaracterExtras, 1));
                            }
                        }
                    } while (verificaId);
                }
                else
                {
                    nrCaractereExtrase = 3;
                    do
                    {
                        verificaId = false;
                        idFacultateDB.Clear();
                        idFacultateDB.Append(textBoxDenumireFacultate.Text.Substring(0, nrCaractereExtrase));
                        foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
                        {
                            if (dr.ItemArray.GetValue(0).ToString() == idFacultateDB.ToString())
                            {
                                verificaId = true;
                                nrCaractereExtrase++;
                            }
                        }
                    } while (verificaId);
                }

            }

            ds.Tables["FACULTATE"].Clear();

            string insertFacultate = "INSERT INTO Facultate VALUES ('" + idFacultateDB.ToString() + "', '" + textBoxDenumireFacultate.Text + "', '" + textBoxAdresaFacultate.Text + "')";

            con.Open();
            SqlCommand cmdInsertFacultate = new SqlCommand(insertFacultate, con);
            cmdInsertFacultate.ExecuteNonQuery();

            da = new SqlDataAdapter("SELECT * FROM Facultate", con);
            da.Fill(ds, "FACULTATE");

            con.Close();

            MessageBox.Show(textBoxDenumireFacultate.Text.ToString()+" a fost adaugata!");

            textBoxDenumireFacultate.Clear();
            textBoxAdresaFacultate.Clear();
            comboBoxDropDownListFacultate.Items.Clear();
            adaugaFacultateToDropDownList();
        }

        private void buttonAdaugaSpecializare_Click(object sender, EventArgs e)
        {
            bool verifCodSpec;
            string idFacultate = "";
            string formaInvatamant = returnRadioButtonName(listRadioButtonFormaInvatamant);

            if (!String.IsNullOrEmpty(formaInvatamant))
            {
                if (string.IsNullOrEmpty(textBoxDenumireSpecializare.Text))
                    MessageBox.Show("Introduceti denumirea specializarii!");
                else
                {
                    foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
                        if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListFacultate.SelectedItem.ToString())
                            idFacultate = dr.ItemArray.GetValue(0).ToString();
                    StringBuilder codSpec = new StringBuilder();
                    codSpec.Append(formaInvatamant.Substring(0, 1).ToUpper() + textBoxDenumireSpecializare.Text.Substring(0, 1).ToUpper());
                    for (int i = 1; i < textBoxDenumireSpecializare.Text.ToString().Length; i++)
                    {
                        if (textBoxDenumireSpecializare.Text.ToString()[i] == ' ')
                            codSpec.Append(textBoxDenumireSpecializare.Text.ToUpper().ToString()[i + 1]);
                    }

                    do
                    {
                        verifCodSpec = true;
                        foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                            if (dr.ItemArray.GetValue(0).ToString() == codSpec.ToString())
                            {
                                codSpec.Append("1");
                                verifCodSpec = false;
                            }
                    } while (!verifCodSpec);

                    if (MessageBox.Show("Se adauga specializarea: \nDenumire: " + textBoxDenumireSpecializare.Text +
                        "\nForma Invatamant: " + formaInvatamant + "\nFacultatea: "+ comboBoxDropDownListFacultate.SelectedItem.ToString(), "Specializare noua", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        string insertSpecializare = "INSERT INTO Specializare VALUES ('" + codSpec + "', '" + textBoxDenumireSpecializare.Text + "', '" + formaInvatamant + "' , '" + idFacultate + "')";
                        con.Open();
                        SqlCommand cmdInsertSpec = new SqlCommand(insertSpecializare, con);
                        cmdInsertSpec.ExecuteNonQuery();

                        ds.Tables["SPECIALIZARE"].Clear();
                        SqlDataAdapter daSpec = new SqlDataAdapter("SELECT * FROM Specializare", con);
                        daSpec.Fill(ds, "SPECIALIZARE");
                        con.Close();

                        adaugaSpecializareToDropDownList();

                        MessageBox.Show("Specializarea a fost adaugata cu succes!");
                    }
                    else
                        MessageBox.Show("Eroare!");
                }
                textBoxDenumireSpecializare.Clear();
            }
            else
                MessageBox.Show("Selectati forma de invatamant: Licenta / Master!");
        }

        private void buttonAdaugaGrupa_Click(object sender, EventArgs e)
        {
            string codSpec = "";
            string anStudiuId = "";
            bool exista = false;
            if (string.IsNullOrEmpty(numericUpDownNrGrupa.Text))
                MessageBox.Show("Introduceti numarul grupei!");
            else
                if (Convert.ToInt32(numericUpDownNrStudentiGrupa.Value) < 10)
                MessageBox.Show("O grupa nu poate avea mai putin de 10 studenti!");
                else
                {
                    foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                        if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListSpecializareGrupa.SelectedItem.ToString())
                            codSpec = dr.ItemArray.GetValue(0).ToString();
                    foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                        if (dr.ItemArray.GetValue(0).ToString() == comboBoxDropDownListAnStudiuGrupa.SelectedItem.ToString())
                            anStudiuId = dr.ItemArray.GetValue(0).ToString();

                    foreach (DataRow dr in ds.Tables["GRUPA"].Rows)
                        if (dr.ItemArray.GetValue(0).ToString() == codSpec.ToString() && dr.ItemArray.GetValue(1).ToString() == numericUpDownNrGrupa.Value.ToString() && dr.ItemArray.GetValue(2).ToString() == anStudiuId && dr.ItemArray.GetValue(3).ToString() == anUniversitarCurent.ToString())
                        {
                            exista = true; //grupa exista deja  pentru specializarea selectata                    
                            break;
                        }
                    if (exista == false)
                    {
                        string insertGrupa = "INSERT INTO Grupa VALUES ('" + codSpec.ToString() + "', '" + numericUpDownNrGrupa.Value.ToString() + "','" + anStudiuId.ToString() + "','" + anUniversitarCurent.ToString() + "','" + Convert.ToInt32(numericUpDownNrStudentiGrupa.Value) + "')";
                        con.Open();
                        SqlCommand cmdInsertGrupa = new SqlCommand(insertGrupa, con);
                        cmdInsertGrupa.ExecuteNonQuery();
                        ds.Tables["GRUPA"].Clear();
                        SqlDataAdapter daGrupa = new SqlDataAdapter("SELECT * FROM Grupa", con);
                        daGrupa.Fill(ds, "GRUPA");
                        con.Close();
                        MessageBox.Show("Grupa " + numericUpDownNrGrupa.Value.ToString() + " pentru specializarea " + comboBoxDropDownListSpecializareGrupa.SelectedItem.ToString() + "(" + codSpec + ")" + " in anul de studiu " + anStudiuId.ToString() + " si anul universitar " + anUniversitarCurent.ToString() + " a fost adaugata cu succes!");
                        // reset drop down numeric fields to their default values?
                    }
                    else
                        MessageBox.Show("Grupa exista deja in baza de date!");
                }
        }
       
        private void buttonAdaugaProfesor_Click(object sender, EventArgs e)
        {
            ds.Tables["PROFESOR"].Clear();
            SqlDataAdapter daProf = new SqlDataAdapter("SELECT * FROM Profesor", con);
            con.Open();
            daProf.Fill(ds, "PROFESOR");
            con.Close();
            DataTable dt = ds.Tables["PROFESOR"];
            DataRow dr1 = dt.NewRow();

            List<Int32> listMarcaProf = new List<int>();
            if (ds.Tables["PROFESOR"].Rows.Count == 0)  //daca nu exista inregistrari, pentru primul insert in tabel,tratare exceptie " no element found "
            {
                dr1[0] = "1";
                dr1[1] = textBoxNumeProfesor.Text.ToString();
                dr1[2] = textBoxPrenumeProfesor.Text.ToString();
                dr1[3] = returnRadioButtonName(listRadioButtonGradProfesor);
            }
            else
            {
                foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                {
                    if (dr.ItemArray.GetValue(0).ToString() != "NoProf")
                        listMarcaProf.Add(Convert.ToInt32(dr.ItemArray.GetValue(0)));
                }
                string newMarcaProf = (listMarcaProf.Max() + 1).ToString();

                dr1[0] = newMarcaProf;
                dr1[1] = textBoxNumeProfesor.Text.ToString();
                dr1[2] = textBoxPrenumeProfesor.Text.ToString();
                dr1[3] = returnRadioButtonName(listRadioButtonGradProfesor);

            }
            dt.Rows.Add(dr1);
            SqlCommandBuilder cb = new SqlCommandBuilder(daProf);
            cb.DataAdapter.Update(dt);

            MessageBox.Show("Domnul/Doamna "+ returnRadioButtonName(listRadioButtonGradProfesor).ToString()+" "+textBoxNumeProfesor.Text.ToString()+" "+textBoxPrenumeProfesor.Text.ToString()+" a fost inregistrat/a cu succes!");
            adaugaProfesorToDropDownList();
            textBoxNumeProfesor.Clear();
            textBoxPrenumeProfesor.Clear();
        }
       
        private void buttonAdaugaDisciplina_Click(object sender, EventArgs e)
        {
            bool verificaId = false;
            int nrCaractereExtrase = 0;
            int pozCaracterExtras = 0;
            StringBuilder idDisciplinaDB = new StringBuilder();
            string[] idDisciplina;

            if (string.IsNullOrEmpty(textBoxDenumireDisciplina.Text))
                MessageBox.Show("Introduceti denumirea disciplinei!");
            else
            {
                idDisciplina = textBoxDenumireDisciplina.Text.ToString().Split(' ');

                if (idDisciplina.Length > 1)
                {

                    foreach (string s in idDisciplina)
                        if (s.Length >= 4)
                            idDisciplinaDB.Append(s.Substring(0, 1));

                    pozCaracterExtras = 0;
                    do
                    {
                        verificaId = false;
                        foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                        {
                            if (dr.ItemArray.GetValue(0).ToString() == idDisciplinaDB.ToString())
                            {
                                verificaId = true;
                                pozCaracterExtras++;

                                idDisciplinaDB.Append((idDisciplina[idDisciplina.Length - 1]).ToString().Substring(pozCaracterExtras, 1));
                            }
                        }
                    } while (verificaId);
                }
                else
                {
                    nrCaractereExtrase = 3;
                    do
                    {
                        verificaId = false;
                        idDisciplinaDB.Clear();
                        idDisciplinaDB.Append(textBoxDenumireDisciplina.Text.Substring(0, nrCaractereExtrase));
                        foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                        {
                            if (dr.ItemArray.GetValue(0).ToString() == idDisciplinaDB.ToString())
                            {
                                verificaId = true;
                                nrCaractereExtrase++;
                            }
                        }
                    } while (verificaId);
                }

            }

            ds.Tables["DISCIPLINA"].Clear();

            string insertDisciplina = "INSERT INTO Disciplina VALUES ('" + idDisciplinaDB.ToString() + "', '" + textBoxDenumireDisciplina.Text + "')";

            con.Open();
            SqlCommand cmdInsertDisciplina = new SqlCommand(insertDisciplina, con);
            cmdInsertDisciplina.ExecuteNonQuery();

            da = new SqlDataAdapter("SELECT * FROM Disciplina", con);
            da.Fill(ds, "DISCIPLINA");

            con.Close();
            MessageBox.Show("Disciplina " + textBoxDenumireDisciplina.Text.ToString() + " a fost adaugata cu succes!");
            textBoxDenumireDisciplina.Clear();
            comboBoxDropDownListAlocareDiscDiscList.Items.Clear();
            adaugaDisciplinaToDropDownList();
        }
        
        private void buttonAdaugaAnSesiune_Click(object sender, EventArgs e)
        {

            if (dateTimePickerSesiuneInceput.Value >= dateTimePickerSesiuneFinal.Value)
                MessageBox.Show("Data inceperii sesiunii nu poate fi mai tarzie decat cea a finalului sesiunii si datele nu pot coincine!");
            else
            {
                ds.Tables["ANSESIUNE"].Clear();
                SqlDataAdapter daAnSesiune = new SqlDataAdapter("SELECT * FROM An_Sesiune", con);
                con.Open();
                daAnSesiune.Fill(ds, "ANSESIUNE");
                con.Close();
                DataTable dt = ds.Tables["ANSESIUNE"];
                DataRow dr1 = dt.NewRow();

                bool exista = false;
                string idSesiune = "";

                foreach (DataRow dr in ds.Tables["SESIUNE"].Rows)
                {
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListSesiune.SelectedItem.ToString())
                        idSesiune = dr.ItemArray.GetValue(0).ToString();
                }

                foreach (DataRow dr in ds.Tables["ANSESIUNE"].Rows)
                {
                    if (dr.ItemArray.GetValue(0).ToString() == idSesiune.ToString() && dr.ItemArray.GetValue(1).ToString() == anUniversitarCurent.ToString() && dr.ItemArray.GetValue(2).ToString() == dateTimePickerSesiuneInceput.Value.ToShortDateString()) // nu intra pe ramura if, niciodata nu vede PK-urile egale!
                    {
                        MessageBox.Show("Sesiunea de " + comboBoxDropDownListSesiune.SelectedItem.ToString() + " din anul universitar " + anUniversitarCurent.ToString() + " din data de " + dateTimePickerSesiuneInceput.Value.ToShortDateString().ToString() + " este deja inregistrata!");
                        exista = true;
                        break;
                    }
                }

                if (exista == false)
                {
                    dr1[0] = idSesiune.ToString();
                    dr1[1] = anUniversitarCurent.ToString();
                    dr1[2] = dateTimePickerSesiuneInceput.Value.ToShortDateString();
                    dr1[3] = dateTimePickerSesiuneFinal.Value.ToShortDateString();

                    dt.Rows.Add(dr1);
                    SqlCommandBuilder cb = new SqlCommandBuilder(daAnSesiune);
                    cb.DataAdapter.Update(dt);
                    MessageBox.Show("Sesiunea de " + comboBoxDropDownListSesiune.SelectedItem.ToString() + " din anul universitar " + anUniversitarCurent.ToString() + " din data de " + dateTimePickerSesiuneInceput.Value.ToShortDateString().ToString() + " a fost programata cu succes!");
                }
            }

        }
       
        private void buttonAdaugaCorp_Click(object sender, EventArgs e)
        {
            ds.Tables["CORP"].Clear();
            SqlDataAdapter daCorp = new SqlDataAdapter("SELECT * FROM Corp", con);
            con.Open();
            daCorp.Fill(ds, "CORP");
            con.Close();
            DataTable dt = ds.Tables["CORP"];
            DataRow dr1 = dt.NewRow();

            List<Int32> listIdCorp = new List<int>();
            if (ds.Tables["CORP"].Rows.Count == 0)  //daca nu exista inregistrari, pentru primul insert in tabel,tratare exceptie " no element found "
            {
                dr1[0] = "1";
                dr1[1] = textBoxDenumireCorp.Text.ToString();
                dr1[2] = textBoxAdresaCorp.Text.ToString();
            }
            else
            {
                foreach (DataRow dr in ds.Tables["CORP"].Rows)
                {
                        listIdCorp.Add(Convert.ToInt32(dr.ItemArray.GetValue(0)));
                }
                string newIdCorp = (listIdCorp.Max() + 1).ToString();

                dr1[0] = newIdCorp;
                dr1[1] = textBoxDenumireCorp.Text.ToString();
                dr1[2] = textBoxAdresaCorp.Text.ToString();

            }
            dt.Rows.Add(dr1);
            SqlCommandBuilder cb = new SqlCommandBuilder(daCorp);
            cb.DataAdapter.Update(dt);

            MessageBox.Show("Corpul " + textBoxDenumireCorp.Text.ToString() + " a fost adaugat cu succes in baza de date!");
            textBoxDenumireCorp.Clear();
            textBoxAdresaCorp.Clear();
            comboBoxDropDownListCorp.Items.Clear();
            adaugaCorpToDropDownList();
        }
        
        private void buttonAdaugaSala_Click(object sender, EventArgs e)
        {
            string codCorp = "";
            bool exista = false;
            if (string.IsNullOrEmpty(numericUpDownNrSala.Value.ToString()))
                MessageBox.Show("Introduceti numarul salii!");
            else
            {
                foreach (DataRow dr in ds.Tables["CORP"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListCorp.SelectedItem.ToString())
                        codCorp = dr.ItemArray.GetValue(0).ToString();

                foreach (DataRow dr in ds.Tables["SALA"].Rows)
                    if (dr.ItemArray.GetValue(0).ToString() == codCorp.ToString() && dr.ItemArray.GetValue(1).ToString() == numericUpDownNrSala.Value.ToString() && dr.ItemArray.GetValue(2).ToString() == numericUpDownEtaj.Value.ToString())
                    {
                        exista = true; // sala deja exista in BD                   
                        break;
                    }
                if (exista == false)
                {
                    string insertSala = "INSERT INTO Sala VALUES ('" + codCorp.ToString() + "', '" + numericUpDownNrSala.Value.ToString() + "','" + numericUpDownEtaj.Value.ToString() + "','" + Convert.ToInt32(numericUpDownNrLocuriSala.Value) + "','" + returnRadioButtonName(listRadioButtonTipSala).ToString() + "')";
                    con.Open();
                    SqlCommand cmdInsertSala = new SqlCommand(insertSala, con);
                    cmdInsertSala.ExecuteNonQuery();
                    ds.Tables["SALA"].Clear();
                    SqlDataAdapter daSala = new SqlDataAdapter("SELECT * FROM Sala", con);
                    daSala.Fill(ds, "SALA");
                    con.Close();
                    MessageBox.Show("Sala " + comboBoxDropDownListCorp.SelectedItem.ToString() + numericUpDownEtaj.Value.ToString() + numericUpDownNrSala.Value.ToString() + " a fost adaugata cu succes!");
                    // reset drop down numeric fields to their default values?
                }
                else
                    MessageBox.Show("Sala exista deja in baza de date!");
            }
        }
        
        private void buttonAlocaDisciplina_Click(object sender, EventArgs e)
        {
            string codSpec = "";
            string idDisc = "";
            string anStudiuId = "";
            bool exista = false;
            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAlocareDisSpecList.SelectedItem.ToString())
                    codSpec = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAlocareDiscDiscList.SelectedItem.ToString())
                    idDisc = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() == comboBoxDropDownListAlocareDiscAnStudiuList.SelectedItem.ToString())
                    anStudiuId = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow dr in ds.Tables["ALOCAREDISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() == codSpec.ToString() && dr.ItemArray.GetValue(1).ToString() == idDisc.ToString() && dr.ItemArray.GetValue(2).ToString() == anStudiuId.ToString())
                {
                    exista = true; // alocarea exista deja                 
                    break;
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
                MessageBox.Show("Disciplina "+comboBoxDropDownListAlocareDiscDiscList.SelectedItem.ToString()+ " a fost alocata cu succes, avand urmatoarele specificatii:"+ "\nSpecializarea: "+comboBoxDropDownListAlocareDisSpecList.SelectedItem.ToString()+" \nAnul de studiu: "+ comboBoxDropDownListAlocareDiscAnStudiuList.SelectedItem.ToString()+"\nSemestrul: "+ returnRadioButtonName(listRadioButtonSemestru).ToString()+" \nTip Evaluare: "+returnRadioButtonName(listRadioButtonTipEvaluare).ToString()+"\nStatus: "+returnRadioButtonName(listRadioButtonStatusDisciplina).ToString());
                // reset drop down numeric fields to their default values?
            }
            else
                MessageBox.Show("Alocarea exista deja in baza de date!");
        }

        private void buttonAcoperireDisciplina_Click(object sender, EventArgs e)
        {
            string codSpec = "";
            string idDisc = "";
            string marcaProf = "";
            string anStudiuId = "";
            bool exista = false;
            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAlocareDisSpecList.SelectedItem.ToString())
                    codSpec = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAlocareDiscDiscList.SelectedItem.ToString())
                    idDisc = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["PROFESOR"].Rows)
                if (dr.ItemArray.GetValue(3).ToString() + " " + dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString() == comboBoxDropDownListAcoperireDiscProf.SelectedItem.ToString())
                    marcaProf = dr.ItemArray.GetValue(0).ToString();
            foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() == comboBoxDropDownListAlocareDiscAnStudiuList.SelectedItem.ToString())
                    anStudiuId = dr.ItemArray.GetValue(0).ToString();

            foreach (DataRow dr in ds.Tables["ACOPERIREDISCIPLINA"].Rows)
                if (dr.ItemArray.GetValue(0).ToString() == codSpec.ToString() && dr.ItemArray.GetValue(1).ToString() == idDisc.ToString() && dr.ItemArray.GetValue(2).ToString() == marcaProf.ToString() && dr.ItemArray.GetValue(3).ToString() == anStudiuId.ToString() && dr.ItemArray.GetValue(4).ToString() == anUniversitarCurent.ToString())
                {
                    exista = true; // acoperirea exista deja                 
                    break;
                }
            if (exista == false)
            {
                string insertAcoperire = "INSERT INTO AcoperireDisciplina VALUES ('" + codSpec.ToString() + "', '" + idDisc.ToString() + "','"+ marcaProf.ToString() + "','" + anStudiuId.ToString() + "','" + anUniversitarCurent.ToString() + "')";
                con.Open();
                SqlCommand cmdInsertAcoperire = new SqlCommand(insertAcoperire, con);
                cmdInsertAcoperire.ExecuteNonQuery();
                ds.Tables["ACOPERIREDISCIPLINA"].Clear();
                SqlDataAdapter daAcoperire = new SqlDataAdapter("SELECT * FROM AcoperireDisciplina", con);
                daAcoperire.Fill(ds, "ACOPERIREDISCIPLINA");
                con.Close();
                MessageBox.Show("Disciplina " + comboBoxDropDowListAcoperireDiscDisc.SelectedItem.ToString() + " a fost acoperita cu succes, avand urmatoarele specificatii:" + "\nSpecializarea: " + comboBoxDropDownListAcoperireDiscSpec.SelectedItem.ToString() +"\nPredata de: "+comboBoxDropDownListAcoperireDiscProf.SelectedItem.ToString()+ " \nAnul de studiu: " + comboBoxDropDownListAcoperireDiscAnStudiu.SelectedItem.ToString() + "\nAnul universitar: " + anUniversitarCurent.ToString());
                // reset drop down numeric fields to their default values?
            }
            else
                MessageBox.Show("Acoperirea exista deja in baza de date!");
        }
        #endregion
    }
}
