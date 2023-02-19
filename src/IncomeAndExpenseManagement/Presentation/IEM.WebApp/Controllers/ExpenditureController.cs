using IEM.Business.Interfaces;
using IEM.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEM.WebApp.Controllers
{
    public class ExpenditureController : Controller
    {
        private readonly IExpenditureService _expenditureService;
        public ExpenditureController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        // GET: ExpenditureController
        public ActionResult Index(int userID)
        {
            ViewBag.UserID = userID;
            var expenditures = _expenditureService.ExpenditureForUser(userID);
            return View(expenditures);
        }

        // GET: ExpenditureController/Details/5
        public ActionResult Details(int id, int userID)
        {
            ViewBag.UserID = userID;
            var expenditure = _expenditureService.GetAll().Where(x => x.ExpID == id).FirstOrDefault();
            return View(expenditure);
        }

        // GET: ExpenditureController/Create
        public ActionResult Create(int? userID)
        {
            ViewBag.UserID = userID;
            return View();
        }

        // POST: ExpenditureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenditureModel model)
        {
            try
            {
                //ToDo: Need to check if it is useful
                model.User = null;
                _expenditureService.Add(model);
                return RedirectToAction(nameof(Index), new { userID = model.UserID });
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpenditureController/Edit/5
        public ActionResult Edit(int id, int userID)
        {
            ViewBag.UserID = userID;
            var expenditure = _expenditureService.GetAll().Where(x => x.ExpID == id).FirstOrDefault();
            return View(expenditure);
        }

        // POST: ExpenditureController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenditureModel model)
        {
            try
            {
                _expenditureService.Update(model);
                return RedirectToAction(nameof(Index), new { userID = model.UserID });
            }
            catch
            {
                return View();
            }
        }

        // GET: ExpenditureController/Delete/5
        public ActionResult Delete(int id, int userID)
        {
            _expenditureService.Delete(id);
            return RedirectToAction(nameof(Index), new { userID });
        }
    }
}
