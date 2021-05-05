using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class ZkouskyGateway
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

                    string sql = "SELECT * FROM zkousky";
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

    }

    public class Zkousky
    {
        public Student studentID;
        public Predmet predmetID;
        public DateTime datum_zkousky;
        public string znamka;
        public Ucitel ucitelID;

        public Zkousky(Student _studentID, Predmet _predmetID, DateTime _datum_zkousky, string _znamka, Ucitel _ucitelID)
        {
            studentID = _studentID;
            predmetID = _predmetID;
            datum_zkousky = _datum_zkousky;
            znamka = _znamka;
            ucitelID = _ucitelID;
        }

        private static Zkousky MapResultsetToObject(DataRow dr)
        {
            int __studentID = Convert.ToInt32(dr.ItemArray[0].ToString());
            Student _studentID = Student.FindByID(__studentID);

            int __predmetID = Convert.ToInt32(dr.ItemArray[1].ToString());
            Predmet _predmetID = Predmet.FindByID(__predmetID);
            DateTime _datum_zkousky = Convert.ToDateTime(dr.ItemArray[2].ToString());
            string _znamka = dr.ItemArray[3].ToString();
            int __ucitelID = Convert.ToInt32(dr.ItemArray[4].ToString());
            Ucitel _ucitelID = Ucitel.FindByID(__ucitelID);

            Zkousky z = new Zkousky(_studentID, _predmetID, _datum_zkousky, _znamka, _ucitelID);

            return z;
        }

        public static List<Zkousky> Find()
        {
            List<Zkousky> zkouskyList = new List<Zkousky>();

            ZkouskyGateway zkousky_gtw = new ZkouskyGateway();
            DataTable dt = zkousky_gtw.Find();
            foreach (DataRow dr in dt.Rows)
                zkouskyList.Add(MapResultsetToObject(dr));

            return zkouskyList;
        }

        public override string ToString()
        {
            return ("studentID: " + studentID.jmeno + " predmetID: " + predmetID.jazyk + " datum_zkousky: " + 
                datum_zkousky + " znamka: " + znamka + " ucitelID: " + ucitelID.jmeno);
        }

    }

}
