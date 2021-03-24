using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using StudentDatabaseApi.Models;
using System.Net;
using System.Data;
using System.Net.Http;
using System.Text.Json;

//using BooksAPI.DTOs;
//using BooksAPI.Models;
/*using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;*/
/*using System.Web.Http;
using System.Web.Http.Description;*/
//using Newtonsoft.Json;

namespace StudentDatabaseApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]

        public class CourseController : ControllerBase
        {
            [HttpGet]
            [Route("[Controller]/id")]
            public IEnumerable<Course> GetCourses()
            {
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\raviy\OneDrive\Documents\StudentCourse.mdf; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                SqlConnection conn = new SqlConnection(connectionString);
                //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\raviy\OneDrive\Documents\StudentCourse.mdf; Integrated Security = True; Connect Timeout = 30
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Course", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Course> e = new List<Course>();
                Dictionary<int, Course> dic = new Dictionary<int, Course>();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Course e1 = new Course();
                        e1.Id = sdr.GetInt32(0);
                        e1.Name = sdr.GetString(1);
                        //e1.LastName = sdr.GetString(2);
                        e.Add(e1);
                        //Console.WriteLine(sdr.GetInt32(0));
                    }
                }
                else
                {
                    Console.WriteLine("No rows selected");
                }
                return e;
            }

            [HttpGet]
            [Route("[Controller]/{id}")]
            public Course GetCourse(int id)
            {
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\raviy\OneDrive\Documents\StudentCourse.mdf; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                SqlConnection conn = new SqlConnection(connectionString);
                //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\raviy\OneDrive\Documents\StudentCourse.mdf; Integrated Security = True; Connect Timeout = 30
                conn.Open();
                SqlCommand cmd = new SqlCommand("DisplayCourseDetails", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Course> e = new List<Course>();
                Dictionary<int, Course> dic = new Dictionary<int, Course>();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Course e1 = new Course();
                        e1.Id = sdr.GetInt32(0);
                        e1.Name = sdr.GetString(1);
                        //e1.LastName = sdr.GetString(2);
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
       /* public string DeleteStudent(int id)
        {
            SqlConnection conn = ConnectionClass.Connecting();

            SqlCommand cmd = new SqlCommand("DeleteCourse", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            return "successfully deleted";
        }*/
    }

    } 


