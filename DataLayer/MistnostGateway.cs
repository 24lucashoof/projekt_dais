using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class MistnostGateway
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

                    string sql = "SELECT * FROM mistnost";
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

        public DataTable FindByID(string id)
        {
            DataTable dt = new DataTable();
            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    string sql = "select * from mistnost where cislo_ucebny = @id";
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
                Console.WriteLine("Couldnt find the ucitel with given ID");
            }

            if (dt.Rows.Count == 0)
                Console.WriteLine("Ucitel with given ID doesnt exist");

            return dt;
        }

    }

    public class Mistnost
    {
        // cislo_ucebny = ID
        public string cislo_ucebny;
        public int kapacita;
        public bool pocitacova_ucebna;

        public Mistnost(string _cislo_ucebny, int _kapacita, bool _pocitacova_ucebna)
        {
            cislo_ucebny = _cislo_ucebny;
            kapacita = _kapacita;
            pocitacova_ucebna = _pocitacova_ucebna;
        }

        private static Mistnost MapResultsetToObject(DataRow dr)
        {
            string _cislo_ucebny = dr.ItemArray[0].ToString();
            int _kapacita = Convert.ToInt32(dr.ItemArray[1].ToString());
            bool _pocitacova_ucebna;
            string __pocitacova_ucebna = dr.ItemArray[2].ToString();
            if (__pocitacova_ucebna == "0")
                _pocitacova_ucebna = false;
            else
                _pocitacova_ucebna = true;

            Mistnost m = new Mistnost(_cislo_ucebny, _kapacita, _pocitacova_ucebna);

            return m;
        }

        public static List<Mistnost> Find()
        {
            List<Mistnost> mistnostList = new List<Mistnost>();

            MistnostGateway mistnost_gtw = new MistnostGateway();
            DataTable dt = mistnost_gtw.Find();
            foreach (DataRow dr in dt.Rows)
                mistnostList.Add(MapResultsetToObject(dr));

            return mistnostList;
        }

        public static Mistnost FindByID(string id)
        {
            MistnostGateway ucitel_gtw = new MistnostGateway();
            DataTable dt = ucitel_gtw.FindByID(id);
            if (dt.Rows.Count == 0)
                return new Mistnost("ERROR", -1, false);
            DataRow dr = dt.Rows[0];

            return MapResultsetToObject(dr);
        }

        public override string ToString()
        {
            return ("cislo_ucebny: " + cislo_ucebny + " kapacita: " + kapacita + " pocitacova_ucebna: " + pocitacova_ucebna);
        }


    }

}
