using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;

namespace ExpenseManagement.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly DbContextExpMgt _context;

        public ExpenseController(DbContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity> expensesList = _context.Expenses.ToList();
            return View(expensesList);
        }

        public IActionResult Create(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetExpenseDetailsForUpdate(int? id)
        {
            //var _ExpenseDetail = _context.Expenses.Find(id);
            //if (_ExpenseDetail == null)
            //{
            //    return NotFound();
            //}
            return View();
        }

        public IActionResult Update(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult GetExpenseDetailsForDelete(int? id)
        {
            var _ExpenseDetail = _context.Expenses.Find(id);
            if (_ExpenseDetail == null)
            {
                return NotFound();
            }
            return View(_ExpenseDetail);
        }

        public IActionResult Delete(int ExpenseId)
        {
            var _ExpenseDetail = _context.Expenses.Find(ExpenseId);
            if (_ExpenseDetail == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(_ExpenseDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
