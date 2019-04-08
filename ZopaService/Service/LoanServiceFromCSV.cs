using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZopaService.Service
{
    public class LoanServiceFromCSV : ILoanService
    {
        IList<LoanRequestSpecs> _requestSpecs;
        IList<LoanResponseLogic> _responseLogic;
        IFormatResponse _responseFormatter;

        public LoanServiceFromCSV(IList<LoanRequestSpecs> requestSpecs, IList<LoanResponseLogic> responseLogic, IFormatResponse responseFormatter)
        {
            _requestSpecs = requestSpecs;
            _responseLogic = responseLogic;
            _responseFormatter = responseFormatter;
        }

        public LoanServiceFromCSV()
        {
            _requestSpecs = new List<LoanRequestSpecs>();
            _responseLogic = new List<
        }


        public Models.Message<Models.LoanResponse> GetOptimalLoanFor(Models.Message<Models.LoanRequest> request)
        {
            throw new NotImplementedException();
        }
    }
}
