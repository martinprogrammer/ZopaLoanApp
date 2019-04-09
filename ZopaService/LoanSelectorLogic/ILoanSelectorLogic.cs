using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaDAL.Models;
using ZopaService.Models;

namespace ZopaService.LoanSelectorLogic
{
    public interface ILoanSelectorLogic
    {
        Message<LoanResponse> GetOptimalLoan(IList<Loan> loans, Message<LoanRequest> request);
        double CalculateInterest(IList<Loan> loans, decimal amount);
        double CalculateTotalRepayment(double amount, double interest, double years, double compoundPeriods);

    }
}
