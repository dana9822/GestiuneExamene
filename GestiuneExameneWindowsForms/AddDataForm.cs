using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        #region restrictii_typing_TextBox
        private void onlyAlphanumeric_Space(object sender, KeyPressEventArgs e) //doar litere+space
        {
            //accepta doar space si litere (casetele text de nume+prenume+materie+spec+sesiune)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void number_Alphanumeric_Space(object sender, KeyPressEventArgs e) //doar litere+space
        {
            //accepta doar space si litere (casetele text de nume+prenume+materie+spec+sesiune)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region declarare variabile
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        List<RadioButton> listRadioButtonFormaInvatamant = new List<RadioButton>();
        List<RadioButton> listRadioButtonGradProfesor = new List<RadioButton>();
        List<RadioButton> listRadioButtonTipSala = new List<RadioButton>();
        List<RadioButton> listRadioButtonSemestru = new List<RadioButton>();
        List<RadioButton> listRadioButtonTipEvaluare = new List<RadioButton>();
        //Alocare alocareForm = new Alocare();
        Acoperire acoperireForm = new Acoperire();
        DealocareDisciplina dealocareDisciplinaForm = new DealocareDisciplina();
        public static string idDisciplinaAdaugata = "";
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
            addAnUnivAutomat();
            getAnUniversitarCurent();
            getSesiuneCurenta();
            getSesiuneCurentaRestante();
            showCurrentAcademicYear();
            adaugaSpecializareToDropDownList();
            adaugaDisciplinaToDropDownList();
            adaugaAnStudiuToDropDownList();
            adaugaSesiuneToDropDownList();
            adaugaCorpToDropDownList();
            labelAnUniversitarGrupa.Visible = true;
            labelAnUniversitarGrupa.Text = anUniversitarCurent.ToString();
            labelAnUniversitarCurentSesiune.Visible = true;
            labelAnUniversitarCurentSesiune.Text = anUniversitarCurent.ToString();            
            label_facultate_curenta.Text = Form1.denumireFacultateSelectata.ToString();
            label_id_facultate_curenta.Text = Form1.idFacultateSelectata.ToString();
            label_SpecTab_Facultate.Text = Form1.denumireFacultateSelectata.ToString();
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
        //void adaugaFacultateToDropDownList()
        //{
        //    comboBoxDropDownListFacultate.Items.Clear();

        //    foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
        //        comboBoxDropDownListFacultate.Items.Add(dr.ItemArray.GetValue(1).ToString());

        //    if (comboBoxDropDownListFacultate.Items.Count > 0)
        //        comboBoxDropDownListFacultate.SelectedIndex = 0;
        //}

        void adaugaSpecializareToDropDownList()
        {
            comboBoxDropDownListSpecializareGrupa.Items.Clear();
            comboBoxDropDownListAlocareDiscSpecList.Items.Clear();

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
            {
                if (dr.ItemArray.GetValue(3).ToString() == Form1.idFacultateSelectata.ToString())
                {
                    comboBoxDropDownListSpecializareGrupa.Items.Add(dr.ItemArray.GetValue(1).ToString());
                    comboBoxDropDownListAlocareDiscSpecList.Items.Add(dr.ItemArray.GetValue(1).ToString());
                }
            }

            if (comboBoxDropDownListSpecializareGrupa.Items.Count > 0)
                comboBoxDropDownListSpecializareGrupa.SelectedIndex = 0;
            if (comboBoxDropDownListAlocareDiscSpecList.Items.Count > 0)
                comboBoxDropDownListAlocareDiscSpecList.SelectedIndex = 0;
        }

        void adaugaAnStudiuToDropDownList()
        {
            comboBoxDropDownListAnStudiuGrupa.Items.Clear();
            comboBoxDropDownListAlocareDiscAnStudiuList.Items.Clear();

            foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
            {
                comboBoxDropDownListAnStudiuGrupa.Items.Add(dr.ItemArray.GetValue(0).ToString());
                comboBoxDropDownListAlocareDiscAnStudiuList.Items.Add(dr.ItemArray.GetValue(0).ToString());
            }

            if (comboBoxDropDownListAnStudiuGrupa.Items.Count > 0)
                comboBoxDropDownListAnStudiuGrupa.SelectedIndex = 0;
            if (comboBoxDropDownListAlocareDiscAnStudiuList.Items.Count > 0)
                comboBoxDropDownListAlocareDiscAnStudiuList.SelectedIndex = 0;
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

            foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
            {
                comboBoxDropDownListAlocareDiscDiscList.Items.Add(dr.ItemArray.GetValue(1).ToString());
            }

            if (comboBoxDropDownListAlocareDiscDiscList.Items.Count > 0)
                comboBoxDropDownListAlocareDiscDiscList.SelectedIndex = 0;
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
                labelAddDataConnectionStatus.Text = String.Format("Server online");
            }
            catch (Exception e)
            {
                labelAddDataConnectionStatus.Visible = true;
                labelAddDataConnectionStatus.ForeColor = Color.Red;
                labelAddDataConnectionStatus.Text = String.Format("Server offline.");
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

        #region insertAutomatAnUniversitar
        private void addAnUnivAutomat()
        {
            if (DateTime.Now.Month != 10 && DateTime.Now.Day != 1)
                MessageBox.Show("Anul universitar incepe la data de 1 Octombrie a fiecarui an!\nNu a fost adaugat niciun an universitar nou in baza de date!");
            else
            {
                StringBuilder idAnUniv = new StringBuilder();
                idAnUniv.Append(DateTime.Now.Year + " - " + DateTime.Now.AddYears(+1).Year); //generare id automat
                bool exista = false;
                foreach (DataRow dr in ds.Tables["ANUNIVERSITAR"].Rows)
                    if (dr.ItemArray.GetValue(0).ToString() == idAnUniv.ToString())
                    {
                        exista = true; //anul deja exista                        
                        break;
                    }
                if (exista == false)
                {
                    string insertNewYear = "INSERT INTO AnUniversitar VALUES ('" + idAnUniv.ToString() + "')";
                    con.Open();
                    SqlCommand cmdInsert = new SqlCommand(insertNewYear, con);
                    cmdInsert.ExecuteNonQuery();

                    ds.Tables["ANUNIVERSITAR"].Clear();
                    SqlDataAdapter daNewYear = new SqlDataAdapter("SELECT * FROM AnUniversitar", con);
                    daNewYear.Fill(ds, "ANUNIVERSITAR");
                    con.Close();
                    getAnUniversitarCurent();
                    labelAnUniversitarGrupa.Visible = true;
                    labelAnUniversitarGrupa.Text = anUniversitarCurent.ToString();
                    labelAnUniversitarCurentSesiune.Visible = true;
                    labelAnUniversitarCurentSesiune.Text = anUniversitarCurent.ToString();
                    MessageBox.Show("Anul a fost adaugat cu succes!");
                }
                //else
                //    MessageBox.Show("Anul universitar este deja existent in baza de date!");
            }


        }
        #endregion

        #region An Universitar Curent
        public static string anUniversitarCurent;

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

        #region Sesiune Curenta + Sesiune de restante
        static string idSesiuneCurenta;
        static string dataInceputSesiuneCurenta;
        static string dataFinalSesiuneCurenta;
        static string denumireSesiuneCurenta;

        static string idSesiuneRestante;
        static string dataInceputSesiuneRestante;
        static string dataFinalSesiuneRestante;
        static string denumireSesiuneRestante;

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

        }

        string returnRadioButtonName(List<RadioButton> listaRadioButtons)
        {
            foreach (RadioButton rb in listaRadioButtons)
                if (rb.Checked)
                    return rb.Text;
            return "";
        }
        #endregion

        private string concatenateString(string str)
        {
            return str.Replace(" ", String.Empty);
        }

        #region Insert Buttons

        //private void buttonAdaugaFacultate_Click(object sender, EventArgs e)
        //{
        //    bool verificaId = false;
        //    int nrCaractereExtrase = 0;
        //    int pozCaracterExtras = 0;
        //    StringBuilder idFacultateDB = new StringBuilder();
        //    string[] idFacultate;

        //    if (string.IsNullOrEmpty(textBoxDenumireFacultate.Text))
        //        MessageBox.Show("Introduceti denumirea facultatii!");
        //    else
        //    {
        //        idFacultate = textBoxDenumireFacultate.Text.ToString().Split(' ');

        //        if (idFacultate.Length > 1)
        //        {

        //            foreach (string s in idFacultate)
        //                if (s.Length >= 4)
        //                    idFacultateDB.Append(s.Substring(0, 1));

        //            pozCaracterExtras = 0;
        //            do
        //            {
        //                verificaId = false;
        //                foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
        //                {
        //                    if (dr.ItemArray.GetValue(0).ToString() == idFacultateDB.ToString())
        //                    {
        //                        verificaId = true;
        //                        pozCaracterExtras++;

        //                        idFacultateDB.Append((idFacultate[idFacultate.Length - 1]).ToString().Substring(pozCaracterExtras, 1));
        //                    }
        //                }
        //            } while (verificaId);
        //        }
        //        else
        //        {
        //            nrCaractereExtrase = 3;
        //            do
        //            {
        //                verificaId = false;
        //                idFacultateDB.Clear();
        //                idFacultateDB.Append(textBoxDenumireFacultate.Text.Substring(0, nrCaractereExtrase));
        //                foreach (DataRow dr in ds.Tables["FACULTATE"].Rows)
        //                {
        //                    if (dr.ItemArray.GetValue(0).ToString() == idFacultateDB.ToString())
        //                    {
        //                        verificaId = true;
        //                        nrCaractereExtrase++;
        //                    }
        //                }
        //            } while (verificaId);
        //        }

        //    }

        //    ds.Tables["FACULTATE"].Clear();

        //    string insertFacultate = "INSERT INTO Facultate VALUES ('" + idFacultateDB.ToString() + "', '" + textBoxDenumireFacultate.Text + "', '" + textBoxAdresaFacultate.Text + "')";

        //    con.Open();
        //    SqlCommand cmdInsertFacultate = new SqlCommand(insertFacultate, con);
        //    cmdInsertFacultate.ExecuteNonQuery();

        //    da = new SqlDataAdapter("SELECT * FROM Facultate", con);
        //    da.Fill(ds, "FACULTATE");

        //    con.Close();

        //    MessageBox.Show(textBoxDenumireFacultate.Text.ToString()+" a fost adaugata!");

        //    textBoxDenumireFacultate.Clear();
        //    textBoxAdresaFacultate.Clear();
        //}

        private void buttonAdaugaSpecializare_Click(object sender, EventArgs e)
        {
            string specOriginalText = textBoxDenumireSpecializare.Text.ToString();
            string concatenatedString = concatenateString(textBoxDenumireSpecializare.Text.ToString());
            bool verifCodSpec;
            string idFacultate = Form1.idFacultateSelectata.ToString();
            string formaInvatamant = returnRadioButtonName(listRadioButtonFormaInvatamant);
            bool exista = false;

            if (!string.IsNullOrEmpty(textBoxDenumireSpecializare.Text))
            {
                string dbConcatenatedString = "";
                foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                {
                    dbConcatenatedString = concatenateString(dr.ItemArray.GetValue(1).ToString());
                    if (dbConcatenatedString.ToUpper() == concatenatedString.ToUpper())
                        exista = true;
                }
            }

            if (!String.IsNullOrEmpty(formaInvatamant))
            {
                if (!string.IsNullOrEmpty(textBoxDenumireSpecializare.Text))
                {
                    if (exista == true)
                        MessageBox.Show("Specializarea " + specOriginalText + " exista deja in baza de date!");
                    else
                    {
                        StringBuilder codSpec = new StringBuilder();
                        codSpec.Append(formaInvatamant.Substring(0, 1).ToUpper() + specOriginalText.Substring(0, 1).ToUpper());
                        for (int i = 1; i < specOriginalText.ToString().Length; i++)
                        {
                            if (specOriginalText.ToString()[i] == ' ')
                                codSpec.Append(specOriginalText.ToUpper().ToString()[i + 1]);
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

                        if (MessageBox.Show("Se adauga specializarea: \nDenumire: " + specOriginalText +
                            "\nForma Invatamant: " + formaInvatamant + "\nFacultatea: " + Form1.denumireFacultateSelectata.ToString(), "Specializare noua", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            string insertSpecializare = "INSERT INTO Specializare VALUES ('" + codSpec + "', '" + specOriginalText + "', '" + formaInvatamant + "' , '" + idFacultate + "')";
                            con.Open();
                            SqlCommand cmdInsertSpec = new SqlCommand(insertSpecializare, con);
                            cmdInsertSpec.ExecuteNonQuery();

                            ds.Tables["SPECIALIZARE"].Clear();
                            SqlDataAdapter daSpec = new SqlDataAdapter("SELECT * FROM Specializare", con);
                            daSpec.Fill(ds, "SPECIALIZARE");
                            con.Close();

                            adaugaSpecializareToDropDownList();

                            MessageBox.Show("Specializarea a fost adaugata cu succes!");
                            textBoxDenumireSpecializare.Clear();
                        }
                        else
                            MessageBox.Show("Eroare!");
                    }
                }
                else
                    MessageBox.Show("Introduceti denumirea specializarii!");
            }
            else
                MessageBox.Show("Selectati forma de invatamant: Licenta / Master!");
        }

        private void buttonAdaugaGrupa_Click(object sender, EventArgs e)
        {
            if (comboBoxDropDownListSpecializareGrupa.Items.Count <= 0)
                MessageBox.Show("Lista specializarilor este goala!\nAdaugarea grupei nu se poate realiza!");
            else
                if (comboBoxDropDownListAnStudiuGrupa.Items.Count <= 0)
                MessageBox.Show("Lista anilor de studiu este goala!\nAdaugarea grupei nu se poate realiza!");
            else
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
            textBoxNumeProfesor.Clear();
            textBoxPrenumeProfesor.Clear();
        }
       
        private void buttonAdaugaDisciplina_Click(object sender, EventArgs e)
        {
            string discOriginalText = textBoxDenumireDisciplina.Text.ToString();
            string concatenatedString = concatenateString(textBoxDenumireDisciplina.Text.ToString());
            bool exista = false;
            bool verificaId = false;
            int nrCaractereExtrase = 0;
            int pozCaracterExtras = 0;
            StringBuilder idDisciplinaDB = new StringBuilder();
            string[] idDisciplina;

            if (!string.IsNullOrEmpty(textBoxDenumireDisciplina.Text))
            {
                string dbConcatenatedString = "";
                foreach (DataRow dr in ds.Tables["DISCIPLINA"].Rows)
                {
                    dbConcatenatedString = concatenateString(dr.ItemArray.GetValue(1).ToString());
                    if (dbConcatenatedString.ToUpper() == concatenatedString.ToUpper())
                        exista = true;
                }
            }

            if (string.IsNullOrEmpty(textBoxDenumireDisciplina.Text))
                MessageBox.Show("Introduceti denumirea disciplinei!");
            if( exista == true)
                MessageBox.Show("Disciplina " + discOriginalText + " exista deja in baza de date!");
            else
            {
                idDisciplina = discOriginalText.ToUpper().Split(' ');

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
                        idDisciplinaDB.Append(discOriginalText.Substring(0, nrCaractereExtrase));
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
                if (verificaId == false)
                {
                    ds.Tables["DISCIPLINA"].Clear();

                    string insertDisciplina = "INSERT INTO Disciplina VALUES ('" + idDisciplinaDB.ToString() + "', '" + discOriginalText + "')";

                    con.Open();
                    SqlCommand cmdInsertDisciplina = new SqlCommand(insertDisciplina, con);
                    cmdInsertDisciplina.ExecuteNonQuery();

                    da = new SqlDataAdapter("SELECT * FROM Disciplina", con);
                    da.Fill(ds, "DISCIPLINA");

                    con.Close();
                    MessageBox.Show("Disciplina " + discOriginalText.ToString() + " a fost adaugata cu succes!");
                    adaugaDisciplinaToDropDownList();
                    textBoxDenumireDisciplina.Clear();
                    idDisciplinaAdaugata = idDisciplinaDB.ToString();
                    Alocare alocareForm = new Alocare();
                    this.Hide();
                    alocareForm.ShowDialog();
                }
                else 
                {
                    MessageBox.Show("A aparut o eroare!");
                }
            }

        }
        
        private void buttonAdaugaAnSesiune_Click(object sender, EventArgs e)
        {
            if (comboBoxDropDownListSesiune.Items.Count <= 0)
                MessageBox.Show("Lista tipului de sesiune este goala.\nProgramarea sesiunii nu se poate realiza!");
            else
            {
                if (dateTimePickerSesiuneInceput.Value.Date >= dateTimePickerSesiuneFinal.Value.Date)
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

                    bool perioadaValida = true;
                    bool exista = false;
                    string idSesiune = "";
                    string mesajSesiuneIarnaPerioadaInvalida = "Sesiunea de Iarna nu poate avea loc in afara lunilor Ianuarie - Februarie!";
                    string mesajSesiuneVaraPerioadaInvalida = "Sesiunea de Vara nu poate avea loc in afara lunilor Mai - Iunie!";

                    foreach (DataRow dr in ds.Tables["SESIUNE"].Rows)
                    {
                        if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListSesiune.SelectedItem.ToString())
                            idSesiune = dr.ItemArray.GetValue(0).ToString();
                    }

                    if (idSesiune == "1") //daca este sesiunea de Iarna
                    {
                        if (dateTimePickerSesiuneInceput.Value.Date.Month != 1 || dateTimePickerSesiuneFinal.Value.Date.Month != 2) //daca lunile alese pentru data sesiunii de iarna nu sunt Ianuarie/Februarie
                            perioadaValida = false;
                    }

                    if (idSesiune == "2") //daca este sesiunea de Vara
                    {
                        if (dateTimePickerSesiuneInceput.Value.Date.Month != 5 || dateTimePickerSesiuneFinal.Value.Date.Month != 6) //daca luna aleasa pentru data sesiunii de vara nu este Iunie
                            perioadaValida = false;
                    }

                    if (perioadaValida == false)
                    {
                        if (idSesiune == "1")
                            MessageBox.Show(mesajSesiuneIarnaPerioadaInvalida);
                        else
                            if (idSesiune == "2")
                            MessageBox.Show(mesajSesiuneVaraPerioadaInvalida);
                    }
                    else
                    {
                        foreach (DataRow dr in ds.Tables["ANSESIUNE"].Rows)
                        {
                            if (dr.ItemArray.GetValue(0).ToString() == idSesiune.ToString())  //daca mai exista sesiune in acelasi tip de sesiune -Vara,Iarna,Restanta
                            {
                                if (dr.ItemArray.GetValue(1).ToString() == anUniversitarCurent.ToString())  //daca mai exista sesiune inregistrata in acelasi an
                                {
                                    if (Convert.ToDateTime(dr.ItemArray.GetValue(2).ToString()) == dateTimePickerSesiuneInceput.Value.Date) //verifica unicitate prin data
                                    {
                                        MessageBox.Show("Sesiunea de " + comboBoxDropDownListSesiune.SelectedItem.ToString() + " din anul universitar " + anUniversitarCurent.ToString() + " din data de " + dateTimePickerSesiuneInceput.Value.Date.ToString() + " este deja inregistrata!");
                                        exista = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (exista == false)
                        {
                            dr1[0] = idSesiune.ToString();
                            dr1[1] = anUniversitarCurent.ToString();
                            dr1[2] = dateTimePickerSesiuneInceput.Value.Date;
                            dr1[3] = dateTimePickerSesiuneFinal.Value.Date;

                            dt.Rows.Add(dr1);
                            SqlCommandBuilder cb = new SqlCommandBuilder(daAnSesiune);
                            cb.DataAdapter.Update(dt);
                            MessageBox.Show("Sesiunea de " + comboBoxDropDownListSesiune.SelectedItem.ToString() + " din anul universitar " + anUniversitarCurent.ToString() + " din data de " + dateTimePickerSesiuneInceput.Value.ToShortDateString().ToString() + " a fost programata cu succes!");
                        }
                    }
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
            string corpOriginalText = textBoxDenumireCorp.Text.ToString();
            string stringWithoutSpclCharac = Regex.Replace(textBoxDenumireCorp.Text.ToString(), @"[^0-9a-zA-Z\._]", "");
            string concatenatedString = concatenateString(stringWithoutSpclCharac);
            bool exista = false;

            if (!string.IsNullOrEmpty(textBoxDenumireCorp.Text))
            {
                string dbConcatenatedString = "";
                foreach (DataRow dr in ds.Tables["CORP"].Rows)
                {
                    dbConcatenatedString = concatenateString(dr.ItemArray.GetValue(1).ToString());
                    if (dbConcatenatedString.ToUpper() == concatenatedString.ToUpper())
                        exista = true;
                }
            }
            if (exista == true)
                MessageBox.Show("Corpul " + corpOriginalText + " exista deja in baza de date!");
            else
            {
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
                    dr1[1] = corpOriginalText;
                    dr1[2] = textBoxAdresaCorp.Text.ToString();

                }
                dt.Rows.Add(dr1);
                SqlCommandBuilder cb = new SqlCommandBuilder(daCorp);
                cb.DataAdapter.Update(dt);

                MessageBox.Show("Corpul " + corpOriginalText + " a fost adaugat cu succes in baza de date!");
                textBoxDenumireCorp.Clear();
                textBoxAdresaCorp.Clear();
                comboBoxDropDownListCorp.Items.Clear();
                adaugaCorpToDropDownList();
            }
        }
        
        private void buttonAdaugaSala_Click(object sender, EventArgs e)
        {
            if (comboBoxDropDownListCorp.Items.Count <= 0)
                MessageBox.Show("Lista corpurilor este goala.\nInregistrarea salii nu se poate realiza!\nAdaugati mai intai un corp in baza de date,apoi reveniti pentru a inregistra salile aferente acestuia!");
            else
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
        }

        private void buttonAlocaDisciplina_Click(object sender, EventArgs e)
        {
            if (comboBoxDropDownListAlocareDiscSpecList.Items.Count <= 0)
                MessageBox.Show("Lista specializarilor este goala!\nNu se poate realiza alocarea!");
            else
                if (comboBoxDropDownListAlocareDiscDiscList.Items.Count <= 0)
                MessageBox.Show("Lista disciplinelor este goala!\nAlocarea nu se poate realiza!");
            else
                if (comboBoxDropDownListAlocareDiscAnStudiuList.Items.Count <= 0)
                MessageBox.Show("Lista anilor de studiu este goala!\nAlocarea nu se poate realiza!");
            else
            {
                string codSpec = "";
                string idDisc = "";
                string anStudiuId = "";
                string statusDisc = "Activ";
                bool exista = false;
                foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                    if (dr.ItemArray.GetValue(1).ToString() == comboBoxDropDownListAlocareDiscSpecList.SelectedItem.ToString())
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
                    string insertAlocare = "INSERT INTO AlocareDisciplina VALUES ('" + codSpec.ToString() + "', '" + idDisc.ToString() + "','" + anStudiuId.ToString() + "','" + returnRadioButtonName(listRadioButtonSemestru).ToString() + "','" + returnRadioButtonName(listRadioButtonTipEvaluare).ToString() + "','" + statusDisc + "')";
                    con.Open();
                    SqlCommand cmdInsertAlocare = new SqlCommand(insertAlocare, con);
                    cmdInsertAlocare.ExecuteNonQuery();
                    ds.Tables["ALOCAREDISCIPLINA"].Clear();
                    SqlDataAdapter daAlocare = new SqlDataAdapter("SELECT * FROM AlocareDisciplina", con);
                    daAlocare.Fill(ds, "ALOCAREDISCIPLINA");
                    con.Close();
                    MessageBox.Show("Disciplina " + comboBoxDropDownListAlocareDiscDiscList.SelectedItem.ToString() + " a fost alocata cu succes, avand urmatoarele specificatii:" + "\nSpecializarea: " + comboBoxDropDownListAlocareDiscSpecList.SelectedItem.ToString() + " \nAnul de studiu: " + comboBoxDropDownListAlocareDiscAnStudiuList.SelectedItem.ToString() + "\nSemestrul: " + returnRadioButtonName(listRadioButtonSemestru).ToString() + " \nTip Evaluare: " + returnRadioButtonName(listRadioButtonTipEvaluare).ToString() + "\nStatus: " + statusDisc);
                    // reset drop down numeric fields to their default values?
                }
                else
                    MessageBox.Show("Alocarea exista deja in baza de date!");
            }

        }
        #endregion

        private void button_ToAcoperireDisc_Click(object sender, EventArgs e)
        {
            this.Hide();
            acoperireForm.ShowDialog();
        }

        private void buttonDealocareDisc_Click(object sender, EventArgs e)
        {
            this.Hide();
            dealocareDisciplinaForm.ShowDialog();
        }
    }
}
