using Mar27.Data;
using Mar27.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mar27.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var mgr = new DatabaseManager();
            var vm = new PeopleViewModel
            {
                People = mgr.GetPeople()
            };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(List<Person> people)
        {
            var mgr = new DatabaseManager();
            mgr.AddPeople(people);
            if(people.Count == 1)
            {
                TempData["message"] = "1 person has been added!";
            }
            else
            {
                TempData["message"] = $"{people.Count} people have been added!";
            }
            
            return Redirect("/home/index");
        }
    }
}