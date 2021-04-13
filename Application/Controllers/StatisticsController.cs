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
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("")]
        public ActionResult Index()
        {
            List<StudentModel> student = (List<StudentModel>) GetStud();

            var StudCnt = student.Count();
            var maxScience = student.Max(u => u.Science);
            var maxMaths = student.Max(u => u.Maths);
            var maxEnglish = student.Max(u => u.English);
            var minScience = student.Min(u => u.Science);
            var minMaths = student.Min(u => u.Maths);
            var minEnglish = student.Min(u => u.English);
            var avgScience = student.Average(u => long.Parse(u.Science));
            var avgMaths = student.Min(u => long.Parse(u.Maths));
            var avgEnglish = student.Min(u => long.Parse(u.English));

            Response.Cookies.Append("StudCnt", StudCnt.ToString());
            Response.Cookies.Append("maxScience", maxScience);
            Response.Cookies.Append("maxMaths", maxMaths);
            Response.Cookies.Append("maxEnglish", maxEnglish);
            Response.Cookies.Append("minScience", minScience);
            Response.Cookies.Append("minMaths", minMaths);
            Response.Cookies.Append("minEnglish", minEnglish);
            Response.Cookies.Append("avgScience", avgScience.ToString());
            Response.Cookies.Append("avgMaths", avgMaths.ToString());
            Response.Cookies.Append("avgEnglish", avgEnglish.ToString());

            var mxsStud = from stud in student
                           where stud.Science == maxScience
                           select new { StudName1 = stud.Name};
            foreach(var s in mxsStud)
            {
                Response.Cookies.Append("MaxStudScience", s.StudName1);
            }
            var mxeStud = from stud1 in student
                          where stud1.English == maxEnglish
                          select new { StudName2 = stud1.Name };
            foreach (var s in mxeStud)
            {
                Response.Cookies.Append("MaxStudEnglish", s.StudName2);
            }
            var mxmStud = from stud2 in student
                          where stud2.Maths == maxMaths
                          select new { StudName3 = stud2.Name };
            foreach (var s in mxmStud)
            {
                Response.Cookies.Append("MaxStudMaths", s.StudName3);
            }

            var mnsStud = from s1 in student
                          where s1.Science == minScience
                          select new { S1Name = s1.Name };
            foreach( var s in mnsStud)
            {
                Response.Cookies.Append("MinStudScience", s.S1Name);
            }
            var mneStud = from s2 in student
                          where s2.English == minEnglish
                          select new { S2Name = s2.Name };
            foreach( var s in mneStud)
            {
                Response.Cookies.Append("MinStudEnglish", s.S2Name);
            }
            var mnmStud = from s3 in student
                          where s3.Maths == minMaths
                          select new { S3Name = s3.Name };
            foreach(var s in mnmStud)
            {
                Response.Cookies.Append("MinStudMaths", s.S3Name);
            }

            return View();
        }

        [Route("Rare")]
        public IEnumerable<StudentModel> GetStud()
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
