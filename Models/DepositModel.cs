using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deposit_calc.Models
{
    public class DepositModel
    {
        public double DepositAmount { get; set; }
        public double AnnualInterestRate { get; set; }
        public int DepositTermInMonths { get; set; }
        public double InterestRate => AnnualInterestRate / 12;
        public string Currency { get; set; }
        public double TotalAmount { get; set; }
        public double TotalAmountExchange { get; set; }
        public bool Capitalization { get; set; }
    }
}
