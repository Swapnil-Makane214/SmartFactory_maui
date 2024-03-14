
using Microsoft.AspNetCore.Components;
using SmartFactory_maui.Models;
using SmartFactory_maui.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFactory_maui.Components.Pages
{
    public partial class MachineDashboard
    {
        List<Machine> Machines { get; set; }
        [Inject]IMachineService MachineService { get; set; }
       
        protected override void OnInitialized()
        {
            Machines = MachineService.GetViewModels();
            base.OnInitialized();
        }
    }
}
