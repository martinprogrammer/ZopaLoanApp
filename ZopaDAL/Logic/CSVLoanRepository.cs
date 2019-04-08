using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaDAL.Models;

namespace ZopaDAL.Logic
{
    public class CSVLoanRepository :ILoanRepository
    {
        ImportDataFromCSV import;
        public CSVLoanRepository(string fileName)
        {
            import = new ImportDataFromCSV(fileName);
        }
        public IList<Loan> GetLoans()
        {
            throw new NotImplementedException();
        }
    }
}
