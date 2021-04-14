using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class UcitelGateway
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

                    string sql = "SELECT * FROM ucitel";
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

                    string sql = "select * from ucitel where ucitelid = @id";
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

    public class Ucitel
    {
        public int ucitelID;
        public string jmeno;
        public string prijmeni;
        public bool dekan;
        public Info infoID;

        public Ucitel(int _ucitelID, string _jmeno, string _prijmeni, bool _dekan, Info _infoID)
        {
            ucitelID = _ucitelID;
            jmeno = _jmeno;
            prijmeni = _prijmeni;
            dekan = _dekan;
            infoID = _infoID;
        }

        private static Ucitel MapResultsetToObject(DataRow dr)
        {
            int _id = Convert.ToInt32(dr.ItemArray[0].ToString());
            string _jmeno = dr.ItemArray[1].ToString();
            string _prijmeni = dr.ItemArray[2].ToString();
            string __dekan = dr.ItemArray[3].ToString();
            bool _dekan;
            if (__dekan == "0")
                _dekan = false;
            else
                _dekan = true;

            int __infoID = Convert.ToInt32(dr.ItemArray[4].ToString());
            Info _infoID = Info.FindByID(__infoID);


            Ucitel u = new Ucitel(_id, _jmeno, _prijmeni, _dekan, _infoID);

            return u;
        }

        public static List<Ucitel> Find()
        {
            List<Ucitel> ucitelList = new List<Ucitel>();

            UcitelGateway ucitel_gtw = new UcitelGateway();
            DataTable dt = ucitel_gtw.Find();
            foreach (DataRow dr in dt.Rows)
                ucitelList.Add(MapResultsetToObject(dr));

            return ucitelList;
        }

        public static Ucitel FindByID(int id)
        {
            UcitelGateway ucitel_gtw = new UcitelGateway();
            DataTable dt = ucitel_gtw.FindByID(id);
            if (dt.Rows.Count == 0)
                return new Ucitel(-1, "ERROR", "ERROR", false, new Info(-1, "ERROR", "ERROR", "ERROR", new DateTime(0, DateTimeKind.Local)));
            DataRow dr = dt.Rows[0];

            return MapResultsetToObject(dr);
        }

        public override string ToString()
        {
            return ("id: " + ucitelID + " jmeno: " + jmeno + " prijmeni: " + prijmeni + " dekan: " + dekan + " infoID: " + infoID.email);
        }

    }

}
