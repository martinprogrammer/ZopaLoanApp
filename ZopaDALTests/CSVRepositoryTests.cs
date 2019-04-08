using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ZopaDAL.Logic;
using ZopaDAL.Models;
using System.IO;

namespace ZopaDALTests
{
    [TestFixture]
    class CSVRepositoryTests
    {
        const string NONVALIDFILENAME = "noName.csv";
        const string VALIDFILENAME = "MarketData1";

        [Test]
        public void GivenValidFileName_GetAllLoanOffers_Should_Get_All_Loans()
        {
            //arrange
            var loanRepo = new CSVLoanRepository(VALIDFILENAME);

            //ACT
            IList<Loan> loans = loanRepo.GetLoans();

            //assert
            //1st row is the header row
            Assert.AreEqual(7, loans.Count);
        }

        [Test]
        public void GivenNonValidFileName_GetAllLoanOffers_Should_Get_Loans()
        {
            //arrange
            var loanRepo = new CSVLoanRepository(NONVALIDFILENAME);

            //assert
            Assert.Throws<FileNotFoundException>(() => loanRepo.GetLoans());
        }
    }
}
