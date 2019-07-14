using ComputerScienceAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ComputerScienceAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string URL = $"https://grandcircusco.github.io/demo-apis/computer-science-hall-of-fame.json";

            HttpWebRequest request = WebRequest.CreateHttp(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();

            JToken JTokenName = JToken.Parse(APIText);
            Person p = new Person();

            p.firstName = JTokenName["complete"][0]["firstName"].ToString();
            p.lastName = JTokenName["complete"][0]["lastName"].ToString();
            p.innovation = JTokenName["complete"][0]["innovation"].ToString();
            p.year = (int)JTokenName["complete"][0]["year"];

            return View(p);
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
    }
}