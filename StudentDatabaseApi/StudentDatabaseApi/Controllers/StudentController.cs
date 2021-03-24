using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using StudentDatabaseApi.Models;

namespace StudentDatabaseApi.Controllers
{ 
     [ApiController]

    public class StudentController : ControllerBase
    {
        [HttpPost]
        [Route("[Controller]/any")]
        public Student Post(Student s)
        {
            s.Id += 1;
            s.FirstName = "Hello " + s.FirstName;
            return s;
        }

        [HttpGet]
        [Route("[Controller]/id")]
        public IEnumerable<Student> Get()
        {
            SqlConnection conn = ConnectionClass.Connecting();
            SqlCommand cmd = new SqlCommand("select * from student", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Student> e = new List<Student>();
            Dictionary<int, Student> dic = new Dictionary<int, Student>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Student e1 = new Student();
                    e1.Id = sdr.GetInt32(0);
                    e1.FirstName = sdr.GetString(1);
                    e1.LastName = sdr.GetString(2);
                    e.Add(e1);
                    //Console.WriteLine(sdr.GetInt32(0));
                }
            }
            else
            {
                Console.WriteLine("No rows selected");
            }
            //SqlCommand cmd = new SqlCommand("Insert into student ", conn);
            conn.Close();
            return e;
        }
        [HttpGet]
        [Route("[Controller]/idss")]
        public float GetNumber(float ids)
        {
            return ids + 1;
        }
        [HttpGet]
        [Route("[Controller]/ids")]
        public Student Getstudent(int id)
        {
            SqlConnection conn = ConnectionClass.Connecting();
            SqlCommand cmd = new SqlCommand("select * from student", conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<Student> e = new List<Student>();
            Dictionary<int, Student> dic = new Dictionary<int, Student>();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Student e1 = new Student();
                    e1.Id = sdr.GetInt32(0);
                    e1.FirstName = sdr.GetString(1);
                    e1.LastName = sdr.GetString(2);
                    dic.Add(e1.Id, e1);
                    //Console.WriteLine(sdr.GetInt32(0));
                }
            }
            else
            {
                Console.WriteLine("No rows selected");
            }
            return dic[id];
        }
        
        [HttpPost]
        [Route("[Controller]/insert")]
        public String Insert(Student s)
        {
            SqlConnection conn = ConnectionClass.Connecting();
            string str = "Insert into student(Id,Firstname,Lastname) values (@studentId,@studentfname,@studentlname)";
            SqlCommand insertcmd = new SqlCommand(str, conn);
            insertcmd.Parameters.AddWithValue("studentId", s.Id);
            insertcmd.Parameters.AddWithValue("studentfname", s.FirstName);
            insertcmd.Parameters.AddWithValue("studentlname", s.LastName);

            insertcmd.ExecuteNonQuery();
            //conn.Close;
            return "inserted successfully";

        }
        [HttpGet]
        [Route("[Controller]/procedure")]
        public DataTable GetProcedure()
        {
            SqlConnection conn = ConnectionClass.Connecting();
            SqlCommand cmd = new SqlCommand("DisplayCourseDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;

        }
        [HttpDelete]
        [Route("[Controller]/Delete")]
        public string DeleteStudent(int id)
        {
            SqlConnection conn = ConnectionClass.Connecting();
            
            SqlCommand cmd = new SqlCommand("deleteStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            return "successfully deleted";
        }
       
    }
}
