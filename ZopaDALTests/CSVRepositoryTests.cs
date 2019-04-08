using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZopaDAL.Logic;
using ZopaDAL.Models;

namespace ZopaDALTests
{
    [TestFixture]
    class CSVRepositoryTests
    {
        const string NONVALIDFILENAME = "noName.csv";
        const string VALIDFILENAME = "MarketData";

        [Test]
        public void GetAllLoanOffers_Should_Get_All_Loans()
        {
            //arrange
            var loanRepo = new CSVLoanRepository(VALIDFILENAME);

            //ACT
            IList<Loan> loans = loanRepo.GetLoans();

            //assert
            //1st row is the header row
            Assert.AreEqual(7, loans.Count);
        }

    }
}
