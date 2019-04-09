using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaService.Models;


namespace ZopaService.LoanMaketSpecs
{
    public class SufficientOffersToSatisfyLoanRequestRule : ILoanMarketRule
    {
        public Models.Message<IList<ZopaDAL.Models.Loan>> SatisfySpecification(Models.Message<IList<ZopaDAL.Models.Loan>> loans, decimal amount)
        {
            loans.Success = true;

            if (loans.ContentObject.Select(p => p.Amount).ToList().Sum() < amount)
            {
                loans.Success = false;
                loans.ErrorMessage = ErrorsEnum.INSUFFICIENTFUNDSFROMLENDERS;
            }

            return loans;
        }
    }
}
