using Microsoft.AspNetCore.Components;

using SmartFactory_maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartFactory_maui.Components.Pages
{
    public partial class MachineCard
    {
        [Parameter]
        public Machine machine { get; set; }
        [Inject]NavigationManager NavigationManager{ get; set; }
        private string Status;
        protected override void OnInitialized()
        {
            Status = machine.MachineState == "Running" ? "status online" : "status offline";
            base.OnInitialized();
        }

        private void DivClickEvent()
        {
            
            NavigationManager.NavigateTo($"/Report/{machine.MachineName}");
        }
    }
}
