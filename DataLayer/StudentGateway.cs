using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{

    public class StudentGateway
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

                    string sql = "SELECT * FROM student";
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

                    string sql = "SELECT * FROM Student WHERE Student.studentid = @id";
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
                Console.WriteLine("Couldnt find the student with given ID");
            }

            if (dt.Rows.Count == 0)
                Console.WriteLine("Student with given ID doesnt exist");

            return dt;
        }


    }

    public class Student
    {
        public int studentID;
        public string jmeno;
        public string prijmeni;
        public Info infoID;
        public int rocnik;

        public Student(int _id, string _jmeno, string _prijmeni, Info _infoID, int _rocnik)
        {
            studentID = _id;
            jmeno = _jmeno;
            prijmeni = _prijmeni;
            infoID = _infoID;
            rocnik = _rocnik;
        }

        private static Student MapResultsetToObject(DataRow dr)
        {
            int _id = Convert.ToInt32(dr.ItemArray[0].ToString());
            string _jmeno = dr.ItemArray[1].ToString();
            string _prijmeni = dr.ItemArray[2].ToString();
            int __infoID = Convert.ToInt32(dr.ItemArray[3].ToString());
            Info _infoID = Info.FindByID(__infoID);

            int _rocnik = Convert.ToInt32(dr.ItemArray[4].ToString());

            Student st = new Student(_id, _jmeno, _prijmeni, _infoID, _rocnik);

            return st;
        }

        public static List<Student> Find()
        {
            List<Student> studentList = new List<Student>();

            StudentGateway student_gtw = new StudentGateway();
            DataTable dt = student_gtw.Find();
            foreach (DataRow dr in dt.Rows)
                studentList.Add(MapResultsetToObject(dr));

            return studentList;
        }

        public static Student FindByID(int id)
        {
            StudentGateway student_gtw = new StudentGateway();
            DataTable dt = student_gtw.FindByID(id);
            if (dt.Rows.Count == 0)
                return new Student(-1, "ERROR", "ERROR", new Info(-1, "ERROR", "ERROR", "ERROR", new DateTime(0, DateTimeKind.Local)), -1);
            DataRow dr = dt.Rows[0];

            return MapResultsetToObject(dr);
        }

        public override string ToString()
        {
            return ("id: " + studentID + " jmeno: " + jmeno + " prijmeni: " + prijmeni + " infoID: " + infoID.email + " rocnik: " + rocnik);
        }


    }

}
