﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaDAL.Logic;
using ZopaDAL.Models;
using ZopaService.Formatters;
using ZopaService.LoanMaketSpecs;
using ZopaService.LoanRequestSpecs;
using ZopaService.LoanSelectorLogic;
using ZopaService.Models;

namespace ZopaService.Service
{
    public class LoanServiceFromCSV : ILoanService
    {
        IList<IRequestRule> _requestSpecs;
        IList<ILoanMarketRule> _loanMarketSpecs;
        ILoanSelectorLogic _responseLogic;
        IResponseFormatter _responseFormatter;


        public LoanServiceFromCSV(IList<IRequestRule> requestSpecs, ILoanSelectorLogic responseLogic, IResponseFormatter responseFormatter, IList<ILoanMarketRule> loanMarketSpecs)
        {
            _requestSpecs = requestSpecs;
            _responseLogic = responseLogic;
            _responseFormatter = responseFormatter;
            _loanMarketSpecs = loanMarketSpecs;
        }

        public LoanServiceFromCSV()
        {
            _requestSpecs = new List<IRequestRule>();

            _requestSpecs.Add(new MaximumAmountRule());
            _requestSpecs.Add(new MinimumAmountRule());
            _requestSpecs.Add(new MultiplesAmountRule());

            _loanMarketSpecs = new List<ILoanMarketRule>();
            _loanMarketSpecs.Add(new SufficientOffersToSatisfyLoanRequestRule());

            _responseLogic = new LowestInterestSyntheticLoanSelectorLogic();
            _responseFormatter = new DefaultResponseFormatter();
        }


        public Models.Message<Models.LoanResponse> GetOptimalLoanFor(Models.Message<Models.LoanRequest> request)
        {
            ILoanRepository repository = new CSVLoanRepository("MarketData1");

            var response = new Message<LoanResponse>();

            var loans = repository.GetLoans();

            var validLoans = ValidateLoans(new Message<IList<Loan>>(){ContentObject = loans}, request.ContentObject.Amount);

           if(validLoans.Success==false)
           {
               response.Success = false;
               response.ErrorMessage = validLoans.ErrorMessage;
               return response;
           }

            if(ValidateRequest(request).Success==false)
            {
                response.Success = false;
                response.ErrorMessage = request.ErrorMessage;
                return response;
            }

            var optimalLoanResponse = _responseLogic.GetOptimalLoan(loans, request);
            var formattedLoanResponse = _responseFormatter.FormatLoanResponse(optimalLoanResponse);

            return formattedLoanResponse;
  
        }

        public Message<IList<Loan>> ValidateLoans(Message<IList<Loan>> loans, decimal amount)
        {
            foreach(ILoanMarketRule rule in _loanMarketSpecs)
            {
                if (rule.SatisfySpecification(loans, amount).Success == false)
                {
                    return loans;
                }
            }

            return loans;

        }

        public Message<LoanRequest> ValidateRequest(Models.Message<Models.LoanRequest> request)
        {
            
            foreach (IRequestRule rule in _requestSpecs)
            {
                if (rule.SatisfySpecification(request).Success==false)
                {
                    return request;
                }
            }

            return request;
        }
    }
}
