using MyTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTeam.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Role
        public ActionResult RoleList()
        {
            var roleList = db.Roles.ToList();


            return View();
        }
    }
}