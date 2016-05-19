using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ToDo.MVC.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(string id)
        {
            ToDoService.ToDoServiceClient service = new ToDoService.ToDoServiceClient();
            List<ToDoService.ToDoItemContract> items = service.GetToDoItems("").ToList();
            ToDoService.ToDoItemContract model = items.Where(x => x.Id == id).FirstOrDefault();

            //only set in edit mode
            if (id!=null)
                model.RelatedItems = items.Where(x => x.Id != id).ToArray();

            return View(model);
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ToDoService.ToDoServiceClient service = new ToDoService.ToDoServiceClient();

                ToDoService.ToDoItemContract task = new ToDoService.ToDoItemContract();
                task.Title = collection.Get("TaskName");
                task.Description = collection.Get("TaskDescription");

                service.SaveToDoItem(task);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                //Was returing View, but Create has no view so we return the Index Page.
                return Index();
            }
        }
        
        //
        // GET: /Task/Edit/5
 
        public ActionResult Edit(string id)
        {
            return View();
        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                string relatedId = string.Empty;
                ToDoService.ToDoServiceClient service = new ToDoService.ToDoServiceClient();

                ToDoService.ToDoItemContract task = new ToDoService.ToDoItemContract();
                task.Id = collection.Get("Id");
                task.Title = collection.Get("Title");
                task.Description = collection.Get("Description");

                // MVC sends a checkbox and RelatedId value grouped with a hidden field.
                string complete = collection.Get("Complete").Split(',')[0];
                task.Complete = Convert.ToBoolean(complete);

                //take the second result
                if (collection.Get("RelatedId").Contains(","))
                {
                    relatedId = collection.Get("RelatedId").Split(',')[1];
                    
                }
                else
                {
                    relatedId = collection.Get("RelatedId");
                }
                task.RelatedId = relatedId;

                service.SaveToDoItem(task);
 
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("Index", "Home");
            }
        }

        //
        // GET: /Task/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Task/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
