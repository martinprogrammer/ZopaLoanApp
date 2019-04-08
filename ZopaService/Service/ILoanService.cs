using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaService.Models;

namespace ZopaService.Service
{
    public interface ILoanService
    {
        Message<LoanResponse> GetOptimalLoanFor(Message<LoanRequest> request);
        Message<LoanRequest> ValidateRequest(Message<LoanRequest> request);
    }
}
