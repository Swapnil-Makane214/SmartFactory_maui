using SmartFactory_maui.Models;
using SmartFactory_maui.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFactory_maui.Services
{
    public class MachineService: IMachineService
    {
        List<Machine> ViewModels { get; set; }

        public MachineService()
        {
             ViewModels = new List<Machine>()
             {
                new ("Samputensilli(Old)","Running",200,150,50,60,80),
                 new ("Samputensilli(Old)","Failed",200, 50, 150, 0, 0)
             };
        }

        public List<Machine> GetViewModels()
        {
            return ViewModels;
        }
        public Machine GetViewModel(string machineName)
        {
            return ViewModels.Find(machine=>machine.MachineName == machineName);
        }
    }
}
