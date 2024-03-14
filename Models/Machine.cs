using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFactory_maui.Models
{
    public class Machine
    {
        public string MachineName { get; set; }
        public string MachineState { get; set; }
        public string ImagePath {  get; set; }
        public QuantityAnalysis _QuantityAnalysis { get; set; }
        public int OEE {  get; set; }
        public int Run {  get; set; }

        public Machine(string MachineName, string MachineState, int ExpectedValue, int ActualValue, int RejectedValue,int OEE,int Run)
        {
            this.MachineName = MachineName;
            this.MachineState = MachineState;
            _QuantityAnalysis = new QuantityAnalysis(ExpectedValue,ActualValue, RejectedValue);
            this.OEE = OEE; 
            this.Run = Run;
            ImagePath = "";
        }
    }
}
