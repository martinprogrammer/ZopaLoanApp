using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaService.Models;

namespace ZopaService.LoanRequestSpecs
{
    public interface IRequestRule
    {
        Message<LoanRequest> SatisfySpecification(Message<LoanRequest> request);
    }
}
