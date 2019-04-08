using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZopaDAL.Models
{
    public class Loan
    {
        public string Lender { get; set; }
        public decimal Amount { get; set; }
        public decimal Interest { get; set; }
    }
}
