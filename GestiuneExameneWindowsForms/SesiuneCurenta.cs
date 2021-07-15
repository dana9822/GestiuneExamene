using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiuneExameneWindowsForms
{
    public static class SesiuneCurenta
    {
        public static string getDenumireSesiuneCurenta(string idSesiuneCurenta)
        {
            string denumireSesiuneCurenta = "";
            SqlConnection con;
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=GestiuneExamene;Integrated Security=True";

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string selectSesiune = "SELECT * FROM Sesiune";
            da = new SqlDataAdapter(selectSesiune, con);
            da.Fill(ds, "SESIUNE");

            foreach (DataRow dr in ds.Tables["SESIUNE"].Rows)
            {
                if (dr.ItemArray.GetValue(0).ToString() == idSesiuneCurenta)
                    denumireSesiuneCurenta = dr.ItemArray.GetValue(1).ToString();
            }

            return denumireSesiuneCurenta;
        }
    }
}
