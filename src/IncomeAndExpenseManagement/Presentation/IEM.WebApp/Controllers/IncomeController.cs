using IEM.Business.Interfaces;
using IEM.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEM.WebApp.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        // GET: IncomeController
        public ActionResult Index(int userID)
        {
            ViewBag.UserID = userID;
            var incomes = _incomeService.IncomeForUser(userID);
            return View(incomes);
        }

        // GET: IncomeController/Details/5
        public ActionResult Details(int id, int userID)
        {
            ViewBag.UserID = userID;
            var incomes = _incomeService.GetAll().Where(x => x.IncomeID == id).FirstOrDefault();
            return View(incomes);
        }

        // GET: IncomeController/Create
        public ActionResult Create(int? userID)
        {
            ViewBag.UserID = userID;
            return View();
        }

        // POST: IncomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IncomeModel model)
        {
            try
            {
                //ToDo: Need to check if it is useful
                model.User = null;
                _incomeService.Add(model);
                return RedirectToAction(nameof(Index), new { userID = model.UserID });
            }
            catch
            {
                return View();
            }
        }

        // GET: IncomeController/Edit/5
        public ActionResult Edit(int id, int userID)
        {
            ViewBag.UserID = userID;
            var incomes = _incomeService.GetAll().Where(x => x.IncomeID == id).FirstOrDefault();
            return View(incomes);
        }

        // POST: IncomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IncomeModel model)
        {
            try
            {
                _incomeService.Update(model);
                return RedirectToAction(nameof(Index), new { userID = model.UserID });
            }
            catch
            {
                return View();
            }
        }

        // GET: IncomeController/Delete/5
        public ActionResult Delete(int id, int userID)
        {
            _incomeService.Delete(id);
            return RedirectToAction(nameof(Index), new { userID });
        }
    }
}
