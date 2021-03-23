using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestiuneExameneWindowsForms
{
    public static class CreateNewControls
    {
        public static CheckBox createCheckBox(string checkBoxText, int leftPosition, int topPosition)
        {
            CheckBox ch = new CheckBox();
            ch.Text = checkBoxText;
            ch.AutoSize = true;
            ch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            ch.Location = new System.Drawing.Point(leftPosition, topPosition);
            return ch;
        }

        public static RadioButton createRadioButton(string radioButtonText, int leftPosition, int topPosition)
        {
            RadioButton rb = new RadioButton();
            rb.Text = radioButtonText;
            rb.AutoSize = true;
            rb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            rb.Location = new System.Drawing.Point(leftPosition, topPosition);
            return rb;
        }

        public static GroupBox createGroupBox(string groupBoxText, int leftPosition, int topPosition)
        {
            GroupBox gb = new GroupBox();
            gb.Text = groupBoxText;
            gb.AutoSize = true;
            gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            gb.Location = new System.Drawing.Point(leftPosition, topPosition);
            return gb;
        }

        public static Button createButton(string buttonText, int leftPosition, int topPosition)
        {
            Button btn = new Button();
            btn.Text = buttonText;
            btn.AutoSize = true;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            btn.Location = new System.Drawing.Point(leftPosition, topPosition);
            return btn;
        }

        public static TextBox createTextBox(int leftPosition, int topPosition, int width)
        {
            TextBox tb = new TextBox();
            tb.AutoSize = true;
            tb.Width = width;
            tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            tb.Location = new System.Drawing.Point(leftPosition, topPosition);
            return tb;
        }

        public static ListBox createListBox(int leftPosition, int topPosition, int width, int height)
        {
            ListBox lb = new ListBox();
            lb.Height = height;
            lb.Width = width;
            lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            lb.Location = new System.Drawing.Point(leftPosition, topPosition);
            return lb;
        }

        public static Label createLabel(string textLabel, int leftPosition, int topPosition)
        {
            Label newLabel = new Label();
            newLabel.Text = textLabel;
            newLabel.AutoSize = true;
            newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            newLabel.Location = new System.Drawing.Point(leftPosition, topPosition);
            return newLabel;
        }

        public static SqlConnection conectareDB(string path)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + path + "';Integrated Security=True";
            return con;
        }

        public static void completeazaDataSet(SqlConnection con, DataSet ds, string interogare, string dataSetTableName)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(interogare, con);
            da.Fill(ds, dataSetTableName);
            con.Close();
        }

        public static void updateDB(SqlConnection con, string cmdSql)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(cmdSql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Baza de date a fost actualizata cu succes!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
