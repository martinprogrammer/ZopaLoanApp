using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZopaService.Formatters
{
    public class DefaultResponseFormatter : IResponseFormatter
    {
        public Models.Message<Models.LoanResponse> FormatLoanResponse(Models.Message<Models.LoanResponse> response)
        {
            throw new NotImplementedException();
        }
    }
}
