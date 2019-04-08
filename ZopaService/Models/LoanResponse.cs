using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZopaService.Models
{
    public class LoanResponse
    {
        public decimal RequestedAmount { get; set; }
        public decimal Rate { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public decimal TotalRepayment { get; set; }
    }
}
