using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaDAL.Models;


namespace ZopaDAL.Mappings
{
   public static class LoansMapper
    {
       public static IList<Loan> MapStringArrayToLoans(this string[] theArray)
       {
           IList<Loan> loans = new List<Loan>();

           for (int i = 1; i <theArray.Length; i++)
           {
               var row = theArray[i].Split(',');
               loans.Add(new Loan()
                   {
                       Lender = row[0].ToString(),
                       Interest = Convert.ToDecimal(row[1]),
                       Amount = Convert.ToDecimal(row[2])
                   });
           }

           return loans;
       }
    }
}
