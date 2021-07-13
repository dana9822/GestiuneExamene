using Microsoft.Reporting.WinForms;
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
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            conectare();
        }

        private void buttonStatisticsBack_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Hide();
            this.Dispose();

            home.ShowDialog();
        }

        SqlConnection con;
        static string anUniversitarCurent = "";
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
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            conectare();
            completareDataSet();
            getAnUniversitarCurent();
            ExamenAnUniv examen = new ExamenAnUniv(); //DataSet personalizat
            con.Open();
            string query = "SELECT spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,profTit.numeProfesor+' '+profTit.prenumeProfesor AS profesorTitular,profAsist.numeProfesor+' '+profAsist.prenumeProfesor AS profesorAsistent FROM ProgramareExamen exm JOIN Specializare spec ON exm.idSpecializare=spec.idSpecializare JOIN Grupa gr ON gr.idSpecializare = exm.idSpecializare AND gr.nrGrupa = exm.nrGrupa AND gr.anStudiu = exm.anStudiu AND gr.anUniversitar = exm.anUniversitar JOIN Disciplina disc ON disc.idDisciplina = exm.idDisciplina JOIN Corp crp ON crp.idCorp = exm.idCorp JOIN Sala sl ON sl.idCorp = exm.idCorp AND sl.nrSala=exm.nrSala AND sl.etaj=exm.etaj JOIN Profesor profTit ON profTit.marcaProfesor=exm.profTitular JOIN Profesor profAsist ON profAsist.marcaProfesor=exm.profSupraveghetor WHERE exm.anUniversitar = '" + anUniversitarCurent + "' GROUP BY spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp,sl.etaj,sl.nrSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            //da.Fill(examen, "Examen");
            DataTable dt = new DataTable();
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("DataSet_ExamenAnUniv", dt);
            foreach (DataRow dr in dt.Rows)
            {
                MessageBox.Show(dr.ItemArray.GetValue(0).ToString());
            }
            //ReportDataSource rds = new ReportDataSource("DataSet_ExamenAnUniv", examen.Tables["Examen"]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            //this.reportViewer1.LocalReport.Refresh();
            con.Close();
            this.reportViewer1.RefreshReport();
        }

        void conectare()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=GestiuneExamene;Integrated Security=True"; //connection string pentru BD de pe SQL Server
        }

        void completareDataSet()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
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
    }
}
