using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApplication.Models;

namespace ProjectManagementApplication.Controllers
{
    public class ProjectController : Controller
    {
        private static IList<Project> _projects = new List<Project>
        {
            new Project(){Id = 1,Name = "Aplikacja zarządzania Sklepem",Description = "projekt polega na napisaniu aplikacji internetowej która bedzie zarządzac sklepem ",Members = "Agnieszka, Witold",Deadline = "20.12.2023"},
            new Project(){Id = 2,Name = "Aplikacja zarządająca projektami ",Description = "projekt polega na napisaniu aplikacji internetowej która bedzie zarządzac projektami ",Members = "Alex, Magda, Monika",Deadline = "22.11.2023"}

        };
        // GET: Project
        public ActionResult Index()
        {
            return View(_projects);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View(_projects.FirstOrDefault(project => project.Id==id ));
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            project.Id = _projects.Count + 1;
            _projects.Add(project);
            return RedirectToAction("Index");
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_projects.FirstOrDefault(project => project.Id==id ));
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,  Project project)
        {

            Project projectToEdit = _projects.FirstOrDefault(project => project.Id == id);

            projectToEdit.Name = project.Name;
            projectToEdit.Description = project.Description;
            projectToEdit.Members = project.Members;
            projectToEdit.Deadline = project.Deadline;

            
            return RedirectToAction("Index");
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_projects.FirstOrDefault(project =>    project.Id == id));
        }

        // POST: Project/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,  Project project)
        {
            Project projectToRemove = _projects.FirstOrDefault(x => x.Id == id);
            _projects.Remove(projectToRemove);
            return RedirectToAction("Index");
        }
    }
}