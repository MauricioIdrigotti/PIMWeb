using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SildeBar.Models;

namespace SildeBar.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard1()
        {
            return View();
        }
        public IActionResult Desenvolvimento()
        {
            return View();
        }
        public IActionResult DataTable()
        {
            return View("DataTable");
        }
        public IActionResult getPerson()
        {
            person p;
            List<person> lp = new List<person>();
            conncetion login = new conncetion();
            DataTable dt = new DataTable();
            if (login.ErrCode == 0)
            {
                string str = "select * from tb_person";
                login.AD = new System.Data.SqlClient.SqlDataAdapter(str, login.CN);
                login.AD.Fill(dt);

                foreach(DataRow row in dt.Rows)
                {
                    p = new person();
                    p.name = row[1].ToString();
                    p.position = row[2].ToString();
                    p.office = row[3].ToString();
                    p.age = Convert.ToInt32(row[4].ToString());
                    p.date = Convert.ToDateTime(row[5].ToString());
                    p.salary = Convert.ToDouble(row[6].ToString());
                    lp.Add(p);
                }
            }
            return Ok(lp);
        }
        public IActionResult PostObject(List<person> modals)
        {
            return Ok();
        }
  
    }
}