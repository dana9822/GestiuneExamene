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
            showCurrentAcademicYear();
            adaugaFacultateToDropDownList();
            adaugaSpecializareToDropDownList();
            adaugaAnStudiuToDropDownList();
            labelAnUniversitarGrupa.Visible = true;
            labelAnUniversitarGrupa.Text = anUniversitarCurent.ToString();
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

            foreach (DataRow dr in ds.Tables["SPECIALIZARE"].Rows)
                   comboBoxDropDownListSpecializareGrupa.Items.Add(dr.ItemArray.GetValue(1).ToString());

            if (comboBoxDropDownListSpecializareGrupa.Items.Count > 0)
                comboBoxDropDownListSpecializareGrupa.SelectedIndex = 0;
        }

        void adaugaAnStudiuToDropDownList()
        {
            comboBoxDropDownListAnStudiuGrupa.Items.Clear();

            foreach (DataRow dr in ds.Tables["ANSTUDIU"].Rows)
                comboBoxDropDownListAnStudiuGrupa.Items.Add(dr.ItemArray.GetValue(0).ToString());

            if (comboBoxDropDownListAnStudiuGrupa.Items.Count > 0)
                comboBoxDropDownListAnStudiuGrupa.SelectedIndex = 0;
        }
        #endregion

        #region labelGUIAcademicYearAndServerStatus
        void showGUIServerStatus()
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

        void showCurrentAcademicYear()
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

        #region RadioButtonMethods
        void adaugaRadioButtonInList()
        {

            foreach (Control c in groupBoxFormaInv.Controls)
                listRadioButtonFormaInvatamant.Add((RadioButton)c);
            foreach (Control c in groupBoxGradDidactic.Controls)
                listRadioButtonGradProfesor.Add((RadioButton)c);

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
                        //Grupa.Items.Clear();
                        //adaugaGrupaToListBox();
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
            textBoxNumeProfesor.Clear();
            textBoxPrenumeProfesor.Clear();
        }
        #endregion
    }
}
