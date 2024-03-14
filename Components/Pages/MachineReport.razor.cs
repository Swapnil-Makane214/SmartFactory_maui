using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using SmartFactory_maui.Models;
using SmartFactory_maui.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Machine = SmartFactory_maui.Models.Machine;

namespace SmartFactory_maui.Components.Pages
{
    public partial class MachineReport
    {
        [Parameter]
        public string machineName { get; set; }
        public Machine machine { get; set; }

        [Inject] IMachineService MachineService { get; set; }


        public string backgroundColor { get; set; }
        public BarChart quantityAnalysisChart = default!;
        public BarChartOptions quantityAnalysisChartOptions = default!;
        public ChartData quantityAnalysisChartData = default!;

        public double[] RunAnalysisChartData { get; set; }
        public MudBlazor.ChartOptions RunAnalysisChartOptions { get; set; }
        public string[] RunAnalysisChartLabel { get; set; }
        public double[] OEEAnalysisChartData { get; set; }
        public MudBlazor.ChartOptions OEEAnalysisChartOptions { get; set; }
        public string[] OEEAnalysisChartLabel { get; set; }


        protected override void OnInitialized()
        {
            machine = MachineService.GetViewModel(machineName);
            QuantityChartInitialization();
            QualityChartInitialization();
            backgroundColor = machine.MachineState == "Running" ? "Green" : "Red";
        }

        private void QuantityChartInitialization()
        {
            var labels = new List<string> { "Expected Value", "Actual Value", "Rejected Value" };
            var datasets = new List<IChartDataset>();

            var dataset1 = new BarChartDataset()
            {
                Data = new List<double> { machine._QuantityAnalysis.ExpectedValue, machine._QuantityAnalysis.ActualValue, machine._QuantityAnalysis.RejectedValue },
                BackgroundColor = new List<string> { "#FFFF00", ColorBuilder.CategoricalTwelveColors[5], "#FF0000" },
                BorderColor = new List<string> { ColorBuilder.CategoricalTwelveColors[0] },
                BorderWidth = new List<double> { 0 },
            };
            datasets.Add(dataset1);

            quantityAnalysisChartData = new ChartData
            {
                Labels = labels,
                Datasets = datasets
            };

            quantityAnalysisChartOptions = new BarChartOptions();
            quantityAnalysisChartOptions.Responsive = true;
            quantityAnalysisChartOptions.Interaction = new Interaction { Mode = InteractionMode.Y };
            quantityAnalysisChartOptions.IndexAxis = "y";



            quantityAnalysisChartOptions.Scales.X!.Title!.Text = "Quantity Analysis";
            quantityAnalysisChartOptions.Scales.X.Title.Display = true;

            quantityAnalysisChartOptions.Scales.Y!.Title!.Text = "";
            quantityAnalysisChartOptions.Scales.Y.Title.Display = true;

            quantityAnalysisChartOptions.Plugins.Legend.Display = false;



        }

        private void QualityChartInitialization()
        {

            RunAnalysisChartData = [machine.Run, 100 - machine.Run];
            RunAnalysisChartOptions = new()
            {
                DisableLegend = true,
                ChartPalette = ["#00FF00", "#FFFFFF"]
            };
            OEEAnalysisChartData = [machine.OEE, 100 - machine.OEE];
            OEEAnalysisChartOptions = new()
            {
                DisableLegend = true,
                ChartPalette = ["#00FF00", "#FFFFFF"],
                LineStrokeWidth = 1,
            };

            RunAnalysisChartLabel = new[] { "Running", "unused" };
            OEEAnalysisChartLabel = new[] { "Running", "unused" };

        }



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await quantityAnalysisChart.InitializeAsync(quantityAnalysisChartData, quantityAnalysisChartOptions);

            }
            await base.OnAfterRenderAsync(firstRender);

        }
    }
}
