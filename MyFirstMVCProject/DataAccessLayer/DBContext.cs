using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFirstMVCProject.DataAccessLayer
{
    public class DBContext
    {
        //setting connection
        private static SqlConnection GetSqlConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["StudentDBConnection"].ToString();

            return new SqlConnection(connectionString);

        }

        //To Select all the student
        public static IEnumerable<Models.Student> SelectAllStudents()
        {
            IEnumerable<Models.Student> studentList = new List<Models.Student>();

            using (SqlConnection cnn = GetSqlConnection())
            {
                String sql = $"Select * From Student";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    cnn.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        Models.Student student;
                        while (dataReader.Read())
                        {
                            student = new Models.Student();
                            student.StudentId = (int)dataReader.GetValue(0);
                            student.StudentName = (string)dataReader.GetValue(1);
                            student.Age = (int)dataReader.GetValue(2);

                            ((List<Models.Student>)studentList).Add(student);
                            //studentList.ToList<Models.Student>().Add(student);
                            
                        }
                    }
                }
            }

            return studentList;
        }
        //To Insert student Information
        public static int CreateStudent(Models.Student student)
        {

            int result;
            int newId = -1;
            using (SqlConnection cnn = GetSqlConnection())
            {
                String sql = $"Insert into Student(StudentName,Age) values ('{student.StudentName}',{student.Age})";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    //open connection
                    cnn.Open();

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;
                    //execute query
                    result = command.ExecuteNonQuery();

                    //select id of newly added record
                    string query2 = "Select @@Identity as newId from Student";
                    command.CommandText = query2;

                    newId = Convert.ToInt32(command.ExecuteScalar());

                }
            }
            return newId;

        }

        //To Select student Information depends on Id given
        public static Models.Student SelectStudentById(int? stdId)
        {
            Models.Student studentInfo = new Models.Student();

            using (SqlConnection cnn = GetSqlConnection())
            {
                String sql = $"Select * From Student Where Id = {stdId}";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    cnn.Open();

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            studentInfo.StudentId = (int)dataReader.GetValue(0);
                            studentInfo.StudentName = (string)dataReader.GetValue(1);
                            studentInfo.Age = (int)dataReader.GetValue(2);
                        }
                    }
                }
            }

            return studentInfo;
        }

        //To Update student Information depends on Id given
        public static int UpdateStudentById(int? stdId, Models.Student student)
        {
            int result;

            using (SqlConnection cnn = GetSqlConnection())
            {
                String sql = $"Update Student Set StudentName='{student.StudentName}',Age={student.Age} Where Id = {stdId}";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    cnn.Open();

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;
                    result = command.ExecuteNonQuery();
                }
            }

            return result;
        }

        //To Delete user Information depends on Id given
        public static int DeleteStudentById(int? stdId)
        {
            int result;

            using (SqlConnection cnn = GetSqlConnection())
            {
                String sql = $"Delete from Student Where Id = {stdId}";

                using (SqlCommand command = new SqlCommand(sql, cnn))
                {
                    cnn.Open();

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = sql;
                    result = command.ExecuteNonQuery();
                }
            }

            return result;
        }
    }
}