using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaService.Models;

namespace ZopaService.LoanRequestSpecs
{
    public class MultiplesAmountRule : IRequestRule
    {
        public Message<LoanRequest> SatisfySpecification(Message<LoanRequest> request)
        {
            if (request.ContentObject.Amount %100 != 0)
            {
                request.Success = false;
                request.ErrorMessage = ErrorsEnum.INCORRECTMULTIPLE;
            }

            return request;
        }
    }
}
