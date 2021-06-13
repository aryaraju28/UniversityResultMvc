using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityResultMvc.Models;

namespace UniversityResultMvc.Controllers
{
    public class StudentController : Controller
    {
        string connectionString = "Server=RAED_COMPUTER\\SQLEXPRESS;Database=UniversityResultSystem;Trusted_Connection=True";
        // GET: Student
        public ActionResult Index()
        {
           
           
            return View();
        }
        public ActionResult StudentResult(int RegisterNo)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("ReadStudent", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("RegisterNo", RegisterNo);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Student student = new Student();

            student.Name = reader["Name"].ToString();
            student.Malayalam = Convert.ToInt32(reader["Malayalam"]);

            student.English = Convert.ToInt32(reader["English"]);
            student.Hindi = Convert.ToInt32(reader["Hindi"]);
            student.Maths = Convert.ToInt32(reader["Maths"]);
            student.Science = Convert.ToInt32(reader["Science"]);
            //student.Total = Convert.ToInt32(reader["Total"]);
            student.Total = student.Malayalam + student.English + student.Hindi + student.Maths + student.Science;
            if (student.Total > 350)
            {
                student.Status = "PASSED";
            }
            else
            {
                student.Status = "FAILED";
            }
            reader.Close();
            connection.Close();

            return View("Result", student);

        }
    }
}
