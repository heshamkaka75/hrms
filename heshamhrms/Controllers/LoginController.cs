using heshamhrms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace heshamhrms.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(heshamhrms.Models.Users usermodel)
        {
            using (hrmsEntities db = new hrmsEntities())
            {

                var userd = db.Users.Where(x => x.User_name == usermodel.User_name && x.password == usermodel.password).FirstOrDefault();
                
                if(userd == null){
                    usermodel.loginerr = "اسم المستخدم او كلمة المرور غير صحيحة";
                    return View("Index", usermodel);
                }else{
                    Session["userid"] = userd.User_id;
                    Session["username"] = userd.User_name;
                    Session["userauth"] = userd.User_auth_id;
                    return RedirectToAction("Home", "Login");
                }
            }
        
        }


        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Notauth()
        {
            return View();
        }
        
        public ActionResult Notfound()
        {
            return View();
        }

        
        public ActionResult Dashboord()
        {
            return View();
        }




	}
}