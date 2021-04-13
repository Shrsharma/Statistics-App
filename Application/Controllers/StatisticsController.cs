using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{

    [Route("Statistic")]


    public class StatisticsController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("opr")]
        public ActionResult Opeartion()
        {
            List<StudentModel> student = GetStud();
            List<SubjectModel> subject = new List<SubjectModel>();

            var minScience = student.Min(u => u.Science);

            HttpContext.Session.SetString("Mins", minScience);

            return View();
        }

        public List<StudentModel> GetStud()
        {
            string connectionstring = "Server=HSC-6JVKLC2\\SQLEXPRESS; Database=StatDb; Trusted_Connection=True;";


            List<StudentModel> users = new List<StudentModel>();

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("select * from [StudentModel]", con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StudentModel user = new StudentModel();
                    user.ID = rdr["Id"].ToString();
                    user.Name = rdr["Name"].ToString();
                    user.Class = rdr["Class"].ToString();
                    user.Science = rdr["Science"].ToString();
                    user.English = rdr["English"].ToString();
                    user.Maths = rdr["Maths"].ToString();
                    users.Add(user);
                }
                con.Close();
            }
            return users;
        }
    }
}
