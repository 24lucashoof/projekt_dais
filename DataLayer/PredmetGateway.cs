using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class PredmetGateway
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

                    string sql = "SELECT * FROM predmet";
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

                    string sql = "SELECT * FROM Predmet WHERE predmetid = @id";
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
                Console.WriteLine("Couldnt find the predmet with given ID");
            }

            if (dt.Rows.Count == 0)
                Console.WriteLine("Predmet with given ID doesnt exist");

            return dt;
        }

    }

    public class Predmet
    {
        public int predmetID;
        public string jmeno;
        public string zkratka;
        public string typ_predmetu;
        public string jazyk;

        public Predmet(int _id, string _jmeno, string _zkratka, string _typ_predmetu, string _jazyk)
        {
            predmetID = _id;
            jmeno = _jmeno;
            zkratka = _zkratka;
            typ_predmetu = _typ_predmetu;
            jazyk = _jazyk;
        }

        private static Predmet MapResultsetToObject(DataRow dr)
        {
            int _id = Convert.ToInt32(dr.ItemArray[0].ToString());
            string _jmeno = dr.ItemArray[1].ToString();
            string _zkratka = dr.ItemArray[2].ToString();
            string _typ_predmetu = dr.ItemArray[3].ToString();
            string _jazyk = dr.ItemArray[4].ToString();

            Predmet p = new Predmet(_id, _jmeno, _zkratka, _typ_predmetu, _jazyk);

            return p;
        }

        public static List<Predmet> Find()
        {
            List<Predmet> predmetList = new List<Predmet>();

            PredmetGateway predmet_gtw = new PredmetGateway();
            DataTable dt = predmet_gtw.Find();
            foreach (DataRow dr in dt.Rows)
                predmetList.Add(MapResultsetToObject(dr));

            return predmetList;
        }

        public static Predmet FindByID(int id)
        {
            PredmetGateway predmet_gtw = new PredmetGateway();
            DataTable dt = predmet_gtw.FindByID(id);
            if (dt.Rows.Count == 0)
                return new Predmet(-1, "ERROR", "ERROR", "ERROR", "ERROR");
            DataRow dr = dt.Rows[0];

            return MapResultsetToObject(dr);
        }

        public override string ToString()
        {
            return ("id: " + predmetID + " jmeno: " + jmeno + " zkratka: " + zkratka + " typ_predmetu: " + typ_predmetu + " jazyk: " + jazyk);
        }


    }

}
