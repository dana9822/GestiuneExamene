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
        #endregion
        private void buttonAddDataBack_Click(object sender, EventArgs e)
        {
            Form1 home = new Form1();
            this.Hide();
            this.Dispose();

            home.ShowDialog();
        }

        private void AddDataForm_Load(object sender, EventArgs e)
        {
            conectare();
        }

        void conectare()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=GestiuneExamene;Integrated Security=True"; //connection string pentru BD de pe SQL Server

            //verificare conexiune si afisare mesaj in label cu statusul conexiunii
            //try
            //{
            //    con.Open();
            //    labelAddDataConnectionStatus.Visible = true;
            //    labelAddDataConnectionStatus.ForeColor = Color.Green;
            //    labelAddDataConnectionStatus.Text = String.Format("Connected to database.");
            //}
            //catch ( Exception e) {
            //    labelAddDataConnectionStatus.Visible = true;
            //    labelAddDataConnectionStatus.ForeColor = Color.Red;
            //    labelAddDataConnectionStatus.Text = String.Format("Not connected to database.");
            //    MessageBox.Show(e.Message.ToString());
            //}
        }
    }
}
