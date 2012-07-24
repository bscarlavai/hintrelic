using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using System.Diagnostics;

namespace SmsBirthdayReminder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";
            ViewBag.FriendData = new List<string>();

            try
            {
                string accessToken = string.Empty;
                try
                {
                    accessToken = Session["accessToken"].ToString();
                }
                catch (Exception) { }

                if (!string.IsNullOrEmpty(accessToken))
                {
                    var client = new FacebookClient(accessToken);
                    dynamic friends = client.Get("me/friends", new {limit = "50"});

                    //List<string> friendData = new List<string>();
                    //foreach (var friend in friends.data)
                    //{
                    //   friendData.Add(friend.name + " " + client.Get(friend.id).birthday);
                    //}

                    //ViewBag.FriendData = friendData;
                }

                Debug.Write("Home.Index() completed. Access token = " + accessToken);
            }
            catch (Exception ex) 
            {
                throw ex;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
