using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZopaService.LoanRequestSpecs;

namespace ZopaService.Models
{
    public class Message<T> where T : class
    {
        public T ContentObject  { get; set; }
        public ErrorsEnum ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
