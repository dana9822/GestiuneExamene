using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
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

namespace GestiuneExameneWindowsForms
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            conectare();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            conectare();
            completareDataSet();
            getAnUniversitarCurent();
            getSesiuneCurenta();
            denumireSesiuneCurenta= SesiuneCurenta.getDenumireSesiuneCurenta(idSesiuneCurenta).ToUpper();
            completeazaGridExamen();
            seteazaProprietatiGridExamen();
        }

        #region Declarare Variabile
        static string anUniversitarCurent = "";
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        static string idSesiuneCurenta;
        static string dataInceputSesiuneCurenta;
        static string denumireSesiuneCurenta;
        #endregion

        #region Conectare + Dataset
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
        #endregion

        #region An Universitar Curent
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

        #region SesiuneCurenta
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
            }

            con.Close();
            //MessageBox.Show("Sesiune curenta id: "+ idSesiuneCurenta +" ,denumire: "+denumireSesiuneCurenta+ " ,data inceput: "+ dataInceputSesiuneCurenta+ " ,data final: "+ dataFinalSesiuneCurenta);
        }

        #endregion

        #region DataGrid Examen
        void completeazaGridExamen()
        {
            adaugaExamenJoinToDataSet();
            dataGridViewOrarExamen.DataSource = ds.Tables["ExamenJoin"];
        }
        void adaugaExamenJoinToDataSet()
        {
            foreach (DataTable dt in ds.Tables)
                if (dt.TableName == "ExamenJoin")
                    ds.Tables["ExamenJoin"].Clear();

            con.Open();
            //string selectExamenJoin = "SELECT spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor,gr.anUniversitar,ses.denumireSesiune,exm.modEvaluare FROM ProgramareExamen exm JOIN Specializare spec ON exm.idSpecializare=spec.idSpecializare JOIN Grupa gr ON gr.idSpecializare = exm.idSpecializare AND gr.nrGrupa = exm.nrGrupa AND gr.anStudiu = exm.anStudiu AND gr.anUniversitar = exm.anUniversitar JOIN Disciplina disc ON disc.idDisciplina = exm.idDisciplina JOIN Corp crp ON crp.idCorp = exm.idCorp JOIN Sala sl ON sl.idCorp = exm.idCorp AND sl.nrSala=exm.nrSala AND sl.etaj=exm.etaj JOIN Profesor profTit ON profTit.marcaProfesor=exm.profTitular JOIN Profesor profAsist ON profAsist.marcaProfesor=exm.profSupraveghetor JOIN Sesiune ses ON ses.idSesiune=exm.idSesiune WHERE exm.anUniversitar = '" + anUniversitarCurent + "' GROUP BY spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor,gr.anUniversitar,ses.denumireSesiune,exm.modEvaluare";
            string query = "SELECT spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp+sl.etaj+sl.nrSala AS denumireSala,profTit.numeProfesor+' '+profTit.prenumeProfesor AS profesorTitular,profAsist.numeProfesor+' '+profAsist.prenumeProfesor AS profesorAsistent FROM ProgramareExamen exm JOIN Specializare spec ON exm.idSpecializare=spec.idSpecializare JOIN Grupa gr ON gr.idSpecializare = exm.idSpecializare AND gr.nrGrupa = exm.nrGrupa AND gr.anStudiu = exm.anStudiu AND gr.anUniversitar = exm.anUniversitar JOIN Disciplina disc ON disc.idDisciplina = exm.idDisciplina JOIN Corp crp ON crp.idCorp = exm.idCorp JOIN Sala sl ON sl.idCorp = exm.idCorp AND sl.nrSala=exm.nrSala AND sl.etaj=exm.etaj JOIN Profesor profTit ON profTit.marcaProfesor=exm.profTitular JOIN Profesor profAsist ON profAsist.marcaProfesor=exm.profSupraveghetor WHERE exm.anUniversitar = '" + anUniversitarCurent + "' AND exm.idSesiune = '" + idSesiuneCurenta + "' GROUP BY spec.denumireSpecializare,gr.nrGrupa,gr.anStudiu,disc.denumireDisciplina,exm.data,exm.ora,crp.denumireCorp,sl.etaj,sl.nrSala,profTit.numeProfesor,profTit.prenumeProfesor,profAsist.numeProfesor,profAsist.prenumeProfesor";
            da = new SqlDataAdapter(query, con);
            da.Fill(ds, "ExamenJoin");
            con.Close();
        }
        void seteazaProprietatiGridExamen()
        {
            dataGridViewOrarExamen.Columns[0].Visible = true;
            dataGridViewOrarExamen.AllowUserToAddRows = false;
            dataGridViewOrarExamen.Columns[0].HeaderText = "SPECIALIZARE";
            dataGridViewOrarExamen.Columns[1].HeaderText = "GRUPA";
            dataGridViewOrarExamen.Columns[2].HeaderText = "AN STUDIU";
            dataGridViewOrarExamen.Columns[3].HeaderText = "DISCIPLINA";
            dataGridViewOrarExamen.Columns[4].HeaderText = "DATA";
            dataGridViewOrarExamen.Columns[5].HeaderText = "ORA";
            dataGridViewOrarExamen.Columns[6].HeaderText = "SALA";
            dataGridViewOrarExamen.Columns[7].HeaderText = "PROFESOR TITULAR";
            dataGridViewOrarExamen.Columns[8].HeaderText = "ASISTENT EXAMINATOR";

            dataGridViewOrarExamen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewOrarExamen.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 15, FontStyle.Regular);
            dataGridViewOrarExamen.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < dataGridViewOrarExamen.Columns.Count; i++)
            {
                dataGridViewOrarExamen.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewOrarExamen.Columns[i].DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 15, FontStyle.Regular);
                dataGridViewOrarExamen.Columns[i].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }
        #endregion

        private void buttonStatisticsBack_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Hide();
            this.Dispose();

            home.ShowDialog();
        }

        private void button_descarcaOrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrarExamen.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Orar_Examene - " + anUniversitarCurent + ".pdf";
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
                            Paragraph title = new Paragraph("ORAR EXAMENE "+ anUniversitarCurent);
                            title.Alignment = Element.ALIGN_CENTER;
                            title.Font = FontFactory.GetFont("Arial", 32);

                            Paragraph subtitle = new Paragraph("SESIUNEA " + denumireSesiuneCurenta);
                            subtitle.Alignment = Element.ALIGN_CENTER;
                            subtitle.Font = FontFactory.GetFont("Arial", 32);
                            subtitle.SpacingAfter = 25;
                            subtitle.SetLeading(1, 1);

                            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                            PdfPTable pdfTable = new PdfPTable(dataGridViewOrarExamen.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100f;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            pdfTable.DefaultCell.BorderWidth = 1;

                            foreach (DataGridViewColumn column in dataGridViewOrarExamen.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = new iTextSharp.text.BaseColor(Color.LightBlue);
                                cell.HorizontalAlignment = 1;
                                cell.VerticalAlignment = 1;
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridViewOrarExamen.Rows)
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
                                Document pdfDoc = new Document(new iTextSharp.text.Rectangle(288f, 144f), 10, 10, 10, 10); 
                                pdfDoc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(title);
                                pdfDoc.Add(subtitle);
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
    }
}
