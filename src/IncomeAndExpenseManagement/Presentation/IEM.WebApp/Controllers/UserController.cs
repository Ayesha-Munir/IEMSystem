using IEM.Business.Interfaces;
using IEM.Business.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IEM.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IIncomeService _incomeService;
        private readonly IExpenditureService _expenditureService;
        public UserController
            (
            IUserService userService,
            IIncomeService incomeService,
            IExpenditureService expenditureService
            )
        {
            _userService = userService;
            _incomeService = incomeService;
            _expenditureService = expenditureService;
        }
        // GET: UserController
        public ActionResult Index()
        {
            List<UserModel> users;
            users = _userService.GetAll();
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.TotalIncome = TotalIncome(id);
            ViewBag.TotalExpenditure = TotalExpenditure(id);
            ViewBag.Savings = Savings(id);
            var users = _userService.GetAll().Where(x => x.UserID == id).FirstOrDefault();
            return View(users);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var users = _userService.GetByID(id);
            return View(users);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel model)
        {
            try
            {
                _userService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction(nameof(Index));

        }

        public ActionResult SignIn()
        {
            return View();
        }

        // POST: UserController/SignIn/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UserModel model)
        {
            try
            {
                var user = _userService.GetAll()
                    .Where(x => x.Username == model.Username && x.Password == model.Password)
                    .FirstOrDefault();

                if (!(user == null))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("SignIn", "User");
                }
            }
            catch (Exception exp)
            {
                return RedirectToAction("SignIn", "User");
            }
        }

        // GET: UserController/SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: UserController/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserModel model)
        {
            try
            {
                _userService.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await this.HttpContext.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
        public int TotalIncome(int userID)
        {
            return _incomeService.GetAll()
                .Where(x => x.UserID == userID)
                .Select(x => x.Amount)
                .Sum();
        }
        public int TotalExpenditure(int userID)
        {
            return _expenditureService.GetAll()
                .Where(x => x.UserID == userID)
                .Select(x => x.Amount)
                .Sum();
        }
        public int Savings(int userID)
        {
            return TotalIncome(userID) - TotalExpenditure(userID);
        }
    }
}
