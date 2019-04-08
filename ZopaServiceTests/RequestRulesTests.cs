using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZopaService.Service;
using ZopaService.Models;
using ZopaService.LoanRequestSpecs;

namespace ZopaServiceTests
{
    [TestFixture]
    class RequestRulesTests
    {
        const int TOOBIGAMOUNT = 15001;
        const int TOOSMALLAMOUNT = 900;
        const int INCORRECTMULTIPLE = 1120;
        const int CORRECTAMOUNT = 1100;

        
        

        [Test]
        public void Given_TOOBIGAMOUNT_SatisfySpecification_Should_Assign_Success_to_False()
        {
            //arrange
            ILoanService loanService = new LoanServiceFromCSV();
            Message<LoanRequest> request = new Message<LoanRequest>() { ContentObject = new LoanRequest() { Amount = TOOBIGAMOUNT } };

            //act
            var result =loanService.ValidateRequest(request);
            
            //assert
            Assert.That(result.Success == false);
            Assert.That(result.ErrorMessage == ErrorsEnum.TOOBIGAMOUNT);

        }

        [Test]
        public void Given_TOOSMALLAMOUNT_SatisfySpecification_Should_Assign_Success_to_False()
        {
            //arrange
            ILoanService loanService = new LoanServiceFromCSV();
            Message<LoanRequest> request = new Message<LoanRequest>() { ContentObject = new LoanRequest() { Amount = TOOSMALLAMOUNT } };

            //act
            var result = loanService.ValidateRequest(request);

            //assert
           Assert.That(result.Success == false);
           Assert.That(result.ErrorMessage == ErrorsEnum.TOOSMALLAMOUNT);

        }

        public void Given_INCORRECTMULTIPLE_SatisfySpecification_Should_Assign_Success_to_False()
        {
            //arrange
            ILoanService loanService = new LoanServiceFromCSV();
            Message<LoanRequest> request = new Message<LoanRequest>() { ContentObject = new LoanRequest() { Amount = INCORRECTMULTIPLE } };

            //act
            var result = loanService.ValidateRequest(request);

            //assert
            Assert.That(result.Success == false);
            Assert.That(result.ErrorMessage == ErrorsEnum.INCORRECTMULTIPLE);

        }

        public void Given_CORRECTAMOUNT_SatisfySpecification_Should_Assign_Success_to_True()
        {
            //arrange
            ILoanService loanService = new LoanServiceFromCSV();
            Message<LoanRequest> request = new Message<LoanRequest>() { ContentObject = new LoanRequest() { Amount = CORRECTAMOUNT } };

            //act
            var result = loanService.ValidateRequest(request);

            //assert
            Assert.That(result.Success == true);
            Assert.That(result.ErrorMessage == ErrorsEnum.CORRECTAMOUNT);

        }
    }
}
