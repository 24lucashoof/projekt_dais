using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class InfoGateway
    {
        public DataTable Find()
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM info";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

            }
            catch
            {
                Console.WriteLine("Couldnt connect to the DB");
            }

            return dt;
        }
        
        public DataTable FindByID(int id)
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Info WHERE infoid = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Couldnt find the info with given ID");
            }

            if (dt.Rows.Count == 0)
                Console.WriteLine("Info with given ID doesnt exist");

            return dt;
        }

    }

    public class Info
    {
        public int infoID;
        public string telefon;
        public string adresa;
        public string email;
        public DateTime datum_narozeni; // check

        public Info(int _infoID, string _telefon, string _adresa, string _email, DateTime _datum_narozeni)
        {
            infoID = _infoID;
            telefon = _telefon;
            adresa = _adresa;
            email = _email;
            datum_narozeni = _datum_narozeni;
        }

        private static Info MapResultsetToObject(DataRow dr)
        {
            string _telefon = dr.ItemArray[0].ToString();
            string _adresa = dr.ItemArray[1].ToString();
            string _email = dr.ItemArray[2].ToString();
            DateTime _datum_narozeni = Convert.ToDateTime(dr.ItemArray[3].ToString());
            int _infoID = Convert.ToInt32(dr.ItemArray[4].ToString());

            Info info = new Info(_infoID, _telefon, _adresa, _email, _datum_narozeni);

            return info;
        }

        public static List<Info> Find()
        {
            List<Info> infoList = new List<Info>();

            InfoGateway info_gtw = new InfoGateway();
            DataTable dt = info_gtw.Find();
            foreach (DataRow dr in dt.Rows)
                infoList.Add(MapResultsetToObject(dr));

            return infoList;
        }

        public static Info FindByID(int id)
        {
            InfoGateway info_gtw = new InfoGateway();
            DataTable dt = info_gtw.FindByID(id);
            if (dt.Rows.Count == 0)
                return new Info(-1, "ERROR", "ERROR", "ERROR", new DateTime(0, DateTimeKind.Local));
            DataRow dr = dt.Rows[0];

            return MapResultsetToObject(dr);
        }

        public override string ToString()
        {
            return ("id: " + infoID + " telefon: " + telefon + " adresa: " + adresa + " email: " + email + " date: " + datum_narozeni.ToString());
        }

    }

}
