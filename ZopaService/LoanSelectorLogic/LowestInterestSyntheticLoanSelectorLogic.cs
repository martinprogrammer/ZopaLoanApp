using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZopaService.LoanSelectorLogic
{
    public class LowestInterestSyntheticLoanSelectorLogic : ILoanSelectorLogic
    {
        public Models.Message<Models.LoanResponse> GetOptimalLoan(IList<ZopaDAL.Models.Loan> loans, Models.Message<Models.LoanRequest> request)
        {
            throw new NotImplementedException();
        }
    }
}
