using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFactory_maui.Models
{
    public class QuantityAnalysis
    {
        public int ExpectedValue { get; set; }
        public int ActualValue { get; set; }
        public int RejectedValue {  get; set; }
        public QuantityAnalysis(int ExpectedValue, int ActualValue, int RejectedValue)
        {
            this.ExpectedValue = ExpectedValue;
            this.ActualValue = ActualValue;
            this.RejectedValue = RejectedValue;
        }
    }
}
