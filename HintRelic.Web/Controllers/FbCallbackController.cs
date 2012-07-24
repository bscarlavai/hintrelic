using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSBirthdayReminder.Controllers
{
    public class FbCallbackController : Controller
    {
        //
        // GET: /FbCallback/

        [HttpPost]
        public string Index(string data)
        {
            var accessToken = Request["accessToken"];
            Session["AccessToken"] = accessToken;

            return "success";
        }
    }
}
