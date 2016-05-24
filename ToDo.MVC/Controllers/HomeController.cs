using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDo.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ToDoService.ToDoServiceClient service = new ToDoService.ToDoServiceClient();

            List<ToDoService.ToDoItemContract> tasks = new List<ToDoService.ToDoItemContract>();
            tasks = service.GetToDoItems("").ToList();

            ViewData["Tasks"] = tasks;

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
    }
}