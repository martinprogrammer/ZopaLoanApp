using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZopaService.LoanSelectorLogic;
using ZopaDAL.Models;

namespace ZopaServiceTests
{
    [TestFixture]
    class ThreeYearCompoundInterestLoanSelectorTests
    {
        [Test]
        public void Given_Amount_And_ListOfLoans_CalculateInterest_Should_Return_Correct_Interest()
        {
            //arrange
            ILoanSelectorLogic logic = new ThreeYearCompoundInterestLoanSelector();
            IList<Loan> loans = new List<Loan>();
            loans.Add(new Loan(){
               Lender="Jane", Amount=480, Interest=0.069M
            });
            loans.Add(new Loan(){
               Lender="Fred", Amount=520, Interest=0.071M
            });

            decimal amount = 1000;

            //act 
            var result = logic.CalculateInterest(loans, amount);

            //assert
            Assert.That(result == 7);
        }

        [Test]
        public void Given_Amount_Interest_Years_CompoundPeriods_CalculateTotalRepayment_Should_Return_Correct_TotalRepayment()
        {
            //arrange
            ILoanSelectorLogic logic = new ThreeYearCompoundInterestLoanSelector();
            double amount = 1000;
            double interest = 7;
            double years = 3;
            double compoundPeriods = 12;

            //act
            var result = logic.CalculateTotalRepayment(amount, interest, years, compoundPeriods);

            //assert
            Assert.That(result == 1232.9255874769281);

        }
    }
}
