using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZopaService.Models
{
    public class LoanResponse
    {
        public string Lender { get; set; }
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
    }
}
