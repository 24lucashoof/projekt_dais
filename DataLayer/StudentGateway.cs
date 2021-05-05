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

        public void UpdateStudent(int id, string jmeno, string prijmeni)
        { 
            try
            {
                SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Student SET jmeno = @jmeno, prijmeni = @prijmeni WHERE studentID = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@jmeno", jmeno);
                        command.Parameters.AddWithValue("@prijmeni", prijmeni);
                        command.ExecuteScalar();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Couldnt UPDATE student in the DB" + e.Message);
            }

        }

        public void UpdateInfo(int infoID, string adresa, string telefon, string email)
        {
            try
            {
                SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Info SET adresa = @adresa, telefon = @telefon WHERE infoID = @infoID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@adresa", adresa);
                        command.Parameters.AddWithValue("@telefon", telefon);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@infoID", infoID);
                        command.ExecuteScalar();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Couldnt UPDATE student_info in the DB" + e.Message);
            }
        }



        public string vysveceni(int id)
        {
            DataTable dt = new DataTable();
            string _return_value = "";

            SqlConnectionStringBuilder builder = DBConnector.GetBuilder();
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = "vytvorit_vysveceni";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var output__ = command.Parameters.Add("@o_prospech", SqlDbType.VarChar, 50);
                        output__.Direction = ParameterDirection.Output;
                        var student_id_ = command.Parameters.AddWithValue("@studentID", id);
                        student_id_.Direction = ParameterDirection.Input;
                        command.ExecuteNonQuery();
                        _return_value = output__.Value.ToString();

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Couldnt connect to the DB");
            }

            return _return_value;
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
            return studentID.ToString();
        }

        public string vysveceni()
        {
            StudentGateway gtw = new StudentGateway();
            return gtw.vysveceni(this.studentID);
        }

        public void Update()
        {
            StudentGateway gtw = new StudentGateway();
            gtw.UpdateStudent(studentID, jmeno, prijmeni);
            gtw.UpdateInfo(infoID.infoID, infoID.adresa, infoID.telefon, infoID.email);
        }

    }

}
