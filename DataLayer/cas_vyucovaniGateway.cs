using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class cas_vyucovaniGateway
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

                    string sql = "SELECT * FROM cas_vyucovani";
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


    public class cas_vyucovani
    {
        Student studentID;
        Predmet predmetID;
        Ucitel ucitelID;
        Mistnost cislo_ucebny;
        int vyucovani_od;
        int vyucovani_do;
        string den;
    
        public cas_vyucovani(Student _studentID, Predmet _predmetID, Ucitel _ucitelID, Mistnost _cislo_ucebny, int _vyucovani_od, int _vyucovani_do, string _den)
        {
            studentID = _studentID;
            predmetID = _predmetID;
            ucitelID = _ucitelID;
            cislo_ucebny = _cislo_ucebny;
            vyucovani_od = _vyucovani_od;
            vyucovani_do = _vyucovani_do;
            den = _den;
        }

        private static cas_vyucovani MapResultsetToObject(DataRow dr)
        {
            int __studentID = Convert.ToInt32(dr.ItemArray[0].ToString());
            Student _studentID = Student.FindByID(__studentID);

            int __predmetID = Convert.ToInt32(dr.ItemArray[1].ToString());
            Predmet _predmetID = Predmet.FindByID(__predmetID);

            int __ucitelID = Convert.ToInt32(dr.ItemArray[2].ToString());
            Ucitel _ucitelID = Ucitel.FindByID(__ucitelID);

            string __cislo_ucebny = dr.ItemArray[3].ToString();
            Mistnost _cislo_ucebny = Mistnost.FindByID(__cislo_ucebny);
            
            int _vyucovani_od = Convert.ToInt32(dr.ItemArray[4].ToString());
            int _vyucovani_do = Convert.ToInt32(dr.ItemArray[5].ToString());
            string _den = dr.ItemArray[6].ToString();

            cas_vyucovani cv = new cas_vyucovani(_studentID, _predmetID, _ucitelID, _cislo_ucebny, _vyucovani_od, _vyucovani_do, _den);

            return cv;
        }

        public static List<cas_vyucovani> Find()
        {
            List<cas_vyucovani> cas_vyucovaniList = new List<cas_vyucovani>();

            cas_vyucovaniGateway cas_vyucovani_gtw = new cas_vyucovaniGateway();
            DataTable dt = cas_vyucovani_gtw.Find();
            foreach (DataRow dr in dt.Rows)
                cas_vyucovaniList.Add(MapResultsetToObject(dr));

            return cas_vyucovaniList;
        }

        public override string ToString()
        {
            return (
                "studentID: " + studentID.jmeno + 
                " predmetID: " + predmetID.jazyk + 
                " ucitelID: " + ucitelID.jmeno + 
                " cislo_ucebny: " + cislo_ucebny.kapacita + 
                " vyucovani_od: " + vyucovani_od +
                " vyucovani_do: " + vyucovani_do +
                " den: " + den);
        }



    }


}
