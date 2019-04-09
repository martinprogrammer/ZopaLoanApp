using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaDAL.Models;
using ZopaService.Models;

namespace ZopaService.Service
{
    public interface ILoanService
    {
        Message<LoanResponse> GetOptimalLoanFor(decimal amount);
        Message<LoanRequest> ValidateRequest(Message<LoanRequest> request);
        Message<IList<Loan>> ValidateLoans(Message<IList<Loan>> loans, decimal amount);
    }
}
