using System.Collections.Generic;
using System.Web.Mvc;
using Login_Controller_Ver.Models;

namespace Login_Controller_Ver.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Credentials inputCredentials)
        {
            ViewBag.Account = "123";
            ViewBag.Password = "123";

            ViewBag.LoginResult = LogIn(inputCredentials);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public string LogIn(Credentials inputCredentials)
        {
            var dataBase = new List<Credentials>
            {
                new Credentials{Account = "Test", Password = "1234", Authorized = true},
                new Credentials{Account = "Bob", Password = "123", Authorized = false}
            };

            bool login = true;
            bool authorized = true;

            foreach (var credential in dataBase)
            {
                if (inputCredentials.Account != credential.Account || inputCredentials.Password != credential.Password)
                {
                    login = false;
                }
                else
                {
                    if (!credential.Authorized)
                    {
                        login = true;
                        authorized = false;
                    }
                    else
                    {
                        login = true;
                        authorized = true;
                        break;
                    }
                }

            }

            if (login && authorized)
            {
                return "<div class=\"alert alert-success\" role=\"alert\" style=\"display: block\">Login Succeed</div>";
                // return LogInSucceeded
            }
            else if (login && !authorized)
            {
                return "<div class=\"alert alert-danger\" role=\"alert\" style=\"display: block\">Unauthorized</div>";
                // return LogInUnAuthorized
            }
            else
            {
                return "<div class=\"alert alert-danger\" role=\"alert\" style=\" display: block\">Login Failed</div>";
                //return LogInFailed
            }
        }
    }
}