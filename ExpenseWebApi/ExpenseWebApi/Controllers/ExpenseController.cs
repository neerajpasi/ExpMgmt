using ExpenseWebApi.Datalayer;
using ExpenseWebApi.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace ExpenseWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        public readonly DbContextExpMgt _context;

        public ExpenseController(DbContextExpMgt context)
        {
            _context = context;
        }

        [HttpGet(Name = "Get Expense")]
        public IEnumerable<ExpenseEntity> Get()
        {
            IEnumerable<ExpenseEntity> expensesList = _context.Expenses.ToList();
            return expensesList;
        }

        [HttpPost("Create")]
        public IActionResult Create(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
            }
            return Ok();
        }

        [HttpGet("GetExpenseByID")]
        public IActionResult GetExpenseDetailsForUpdate(int? id)
        {
            var _ExpenseDetail = _context.Expenses.Find(id);
            if (_ExpenseDetail == null)
            {
                return NotFound();
            }
            return Ok(_ExpenseDetail);
        }
        [HttpPost("Update")]
        public IActionResult Update(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
            }
            return Ok();
        }

        //public IActionResult GetExpenseDetailsForDelete(int? id)
        //{
        //    var _ExpenseDetail = _context.Expenses.Find(id);
        //    if (_ExpenseDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(_ExpenseDetail);
        //}

        [HttpDelete("Delete")]
        public IActionResult Delete(int ExpenseId)
        {
            var _ExpenseDetail = _context.Expenses.Find(ExpenseId);
            if (_ExpenseDetail == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(_ExpenseDetail);
            _context.SaveChanges();
            return Ok(_ExpenseDetail);
        }

    }
}
