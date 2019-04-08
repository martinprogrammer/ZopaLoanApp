using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaDAL.Models;

namespace ZopaDAL.Logic
{
    public interface ILoanRepository
    {
        IList<Loan> GetLoans();
    }
}
