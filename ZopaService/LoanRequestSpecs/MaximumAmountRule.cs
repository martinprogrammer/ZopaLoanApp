using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaService.Models;

namespace ZopaService.LoanRequestSpecs
{
   public class MaximumAmountRule : IRequestRule
    {
        public Message<LoanRequest> SatisfySpecification(Message<LoanRequest> request)
        {
            request.Success = true;

            if(request.ContentObject.Amount>15000)
            {
                request.Success = false;
                request.ErrorMessage = ErrorsEnum.TOOBIGAMOUNT;
            }

            return request;
        }
    }
}
