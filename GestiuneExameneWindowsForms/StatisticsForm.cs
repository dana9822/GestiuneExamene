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
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            conectare();
            ExamenAnUniv examen = new ExamenAnUniv(); //DataSet personalizat
            //string connectionString = @"Data Source=.;Initial Catalog=GestiuneExamene;Integrated Security=True";
            //SqlConnection cn = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,profTit.numeProfesor+' '+profTit.prenumeProfesor AS profesorTitular,profAsist.numeProfesor+' '+profAsist.prenumeProfesor AS profesorAsistent FROM ProgramareExamen exm JOIN Specializare spec ON exm.idSpecializare=spec.idSpecializare JOIN Grupa gr ON gr.idSpecializare = exm.idSpecializare AND gr.nrGrupa = exm.nrGrupa AND gr.anStudiu = exm.anStudiu AND gr.anUniversitar = exm.anUniversitar JOIN Disciplina disc ON disc.idDisciplina = exm.idDisciplina JOIN Corp crp ON crp.idCorp = exm.idCorp JOIN Sala sl ON sl.idCorp = exm.idCorp AND sl.nrSala=exm.nrSala AND sl.etaj=exm.etaj JOIN Profesor profTit ON profTit.marcaProfesor=exm.profTitular JOIN Profesor profAsist ON profAsist.marcaProfesor=exm.profSupraveghetor WHERE exm.anUniversitar = " + AddDataForm.anUniversitarCurent + " GROUP BY spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp,sl.etaj,sl.nrSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(examen, examen.Tables[0].TableName);
            con.Close();

            ReportDataSource rds = new ReportDataSource("DataSet_ExamenAnUniv", examen.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
        }

        void conectare()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=GestiuneExamene;Integrated Security=True"; //connection string pentru BD de pe SQL Server
        }

        //void adaugaExamenJoinToDataSet()
        //{
        //    foreach (DataTable dt in ds.Tables)
        //        if (dt.TableName == "ExamenJoin")
        //            ds.Tables["ExamenJoin"].Clear();

        //    con.Open();
        //string selectExamenJoin = "SELECT spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor FROM ProgramareExamen exm JOIN Specializare spec ON exm.idSpecializare=spec.idSpecializare JOIN Grupa gr ON gr.idSpecializare = exm.idSpecializare AND gr.nrGrupa = exm.nrGrupa AND gr.anStudiu = exm.anStudiu AND gr.anUniversitar = exm.anUniversitar JOIN Disciplina disc ON disc.idDisciplina = exm.idDisciplina JOIN Corp crp ON crp.idCorp = exm.idCorp JOIN Sala sl ON sl.idCorp = exm.idCorp AND sl.nrSala=exm.nrSala AND sl.etaj=exm.etaj JOIN Profesor profTit ON profTit.marcaProfesor=exm.profTitular JOIN Profesor profAsist ON profAsist.marcaProfesor=exm.profSupraveghetor WHERE exm.anUniversitar = "+ AddDataForm.anUniversitarCurent.ToString()+
        //" GROUP BY spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor";
        //    da = new SqlDataAdapter(selectExamenJoin, con);
        //    da.Fill(ds, "ExamenJoin");
        //    con.Close();
        //}
    }
}
