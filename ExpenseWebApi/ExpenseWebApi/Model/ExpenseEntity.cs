using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ExpenseWebApi.Model
{
    
        public class ExpenseEntity
        {
            [Key]
            public int ExpenseId { get; set; }


            [Required(ErrorMessage = "Please Select Expense Date.")]
            [DataType(DataType.Date)]
            [Display(Name = "Expense Date")]
            public DateTime ExpenseDate { get; set; }


            [Required(ErrorMessage = "Please Enter E    xpense Given to Details")]
            [MinLength(3, ErrorMessage = "The Given Name is too Short")]
            [Display(Name = "Paid to")]
            public string? ExpenseGIvenTo { get; set; }



            [Required(ErrorMessage = "PLease Enter Expense Amount")]
            [Range(0, double.MaxValue, ErrorMessage = "Please Enter a Valid Expense Amount")]
            [Display(Name = "Expense Amount")]
            public double? ExpenseAmount { get; set; }
        }
    
}
