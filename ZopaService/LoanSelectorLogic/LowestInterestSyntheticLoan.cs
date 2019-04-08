using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZopaService.LoanSelectorLogic
{
    public class LowestInterestSyntheticLoan : ILoanSelectorLogic
    {
        public Models.Message<Models.LoanResponse> OptimalLoan(IList<ZopaDAL.Models.Loan> loans, Models.Message<Models.LoanRequest> request)
        {
            throw new NotImplementedException();
        }
    }
}
