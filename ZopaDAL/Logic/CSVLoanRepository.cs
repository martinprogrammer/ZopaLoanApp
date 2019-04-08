using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaDAL.Models;
using ZopaDAL.Mappings;

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
            var rows = import.GetRows();
            var loans = rows.MapStringArrayToLoans();
            return loans;
        }
    }
}
