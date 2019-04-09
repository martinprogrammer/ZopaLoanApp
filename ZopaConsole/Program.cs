using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaService.Service;

namespace ZopaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
          
                decimal amount = 0;
                bool correctAmount = decimal.TryParse(args[0], out amount);
               // bool correctAmount = decimal.TryParse("1000", out amount);
                
                if (!correctAmount)
                    Console.WriteLine("Incorrect amount");
                else
                {
                    ILoanService service = new LoanServiceFromCSV();
                    var loans = service.GetOptimalLoanFor(amount);
                    if (loans.Success == false)
                        Console.WriteLine(loans.ErrorMessage);
                    else
                    {
                        Console.WriteLine("Requested amount: £{0}", amount);
                        Console.WriteLine("Rate: {0}%", loans.ContentObject.Rate);
                        Console.WriteLine("Monthly repayment: £{0}", loans.ContentObject.MonthlyRepayment);
                        Console.WriteLine("Total repayment: £{0}", loans.ContentObject.TotalRepayment);
                    }
                        
                }

            }
            
            
        }
    }

