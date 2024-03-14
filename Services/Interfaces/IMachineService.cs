using SmartFactory_maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFactory_maui.Services.Interfaces
{
    public interface IMachineService
    {
        public List<Machine> GetViewModels();
        public Machine GetViewModel(string machineName);
    }
}
